using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace FlightSimulatorWpf
{
	/**
	 * FlyData save address and value of propartis, and mutex to the object.
	 * */
	public class FlyData
	{
		public FlyData(String address, double value)
		{
			this.address = address;
			this.value = value;
		}
		public String address { get; set; }
		public double value { get; set; }
		public Mutex mutex = new Mutex();

	}
	/**
	 * FlyModel responsability on fly algoritam. 
	 * handel the community with server, select the value, update.
	 */
	class FlyModel : IModel
	{
		private ITelnetClient telnetClient;
		private bool stop;
		private Thread updateThread;
		private Dictionary<string, FlyData> valueMap;
		public event PropertyChangedEventHandler PropertyChanged; //?
		private HashSet<string> messageError;
		private bool communityProblemTryFix;
		private List<String> dashBoardError;
		private Queue<string> sendToSimQueue;
		private readonly Mutex mut2 = new Mutex();
		private string ip;
		private string port;
		/**
		 * FlyModel constructor update variables. 
		 * get ITelnetClient.
		 */
		public FlyModel(ITelnetClient telClient)
		{
			//Read value
			valueMap = new Dictionary<string, FlyData>();
			valueMap.Add("longitude", new FlyData("/position/longitude-deg", 34.888781));
			valueMap.Add("latitude", new FlyData("/position/latitude-deg", 32.002644));
			valueMap.Add("indicatedSpeed", new FlyData("/instrumentation/airspeed-indicator/indicated-speed-kt", 0.0));
			valueMap.Add("gpsAltitude", new FlyData("/instrumentation/gps/indicated-altitude-ft", 0.0));
			valueMap.Add("internalRoll", new FlyData("/instrumentation/attitude-indicator/internal-roll-deg", 0.0));
			valueMap.Add("internalPitch", new FlyData("/instrumentation/attitude-indicator/internal-pitch-deg", 0.0));
			valueMap.Add("altimeterAltitude", new FlyData("/instrumentation/altimeter/indicated-altitude-ft", 0.0));
			valueMap.Add("headingDeg", new FlyData("/instrumentation/heading-indicator/indicated-heading-deg", 0.0));
			valueMap.Add("groundSpeed", new FlyData("/instrumentation/gps/indicated-ground-speed-kt", 0.0));
			valueMap.Add("verticalSpeed", new FlyData("/instrumentation/gps/indicated-vertical-speed", 0.0));
			// Write value 
			valueMap.Add("throttle", new FlyData("/controls/engines/current-engine/throttle", 0.0));
			valueMap.Add("aileron", new FlyData("/controls/flight/aileron", 0.0));
			valueMap.Add("elevator", new FlyData("/controls/flight/elevator", 0.0));
			valueMap.Add("rudder", new FlyData("/controls/flight/rudder", 0.0));
			this.dashBoardError = new List<string>();
			this.stop = false;
			this.telnetClient = telClient;
			sendToSimQueue = new Queue<string>();
			this.messageError = new HashSet<string>();
		}
		/**
		 * Connect get ip and port and try connect to server.
		 */
		public void Connect(string ip, string port)
		{
			if (ip.Length == 0)
			{
				this.ip = ConfigurationManager.AppSettings["ip"].ToString();
			}
			else
			{
				this.ip = ip;
			}
			if (port.Length == 0)
			{
				this.port = ConfigurationManager.AppSettings["port"].ToString();
			}
			else
			{
				this.port = port;
			}
			Connect();
		}
		/**
		 * Connect to server with this ip and port.
		 * if not seccsed, try again. 
		 * if this not seccsed update that have problem with connect.
		 */
		public void Connect()
		{
			try { 
				this.telnetClient.Connect(this.ip, this.port);
			}
			catch(Exception e)
			{
					if (!communityProblemTryFix)
					{
						communityProblemTryFix = true;
						try
						{
							this.telnetClient.Connect(this.ip, this.port);
						}
						catch
						{
							UpdateErrorMessageSet("telnetNotCanConnect");
						}

					}
					else
					{
						UpdateErrorMessageSet("telnetNotCanConnect");
					}
			}
		}
		public void Disconnect()
		{
			stop = true;
			if ((this.updateThread!=null) && this.updateThread.IsAlive)
			{
				this.updateThread.Abort();
			}
		}

		public void Start()
		{
			StartGet();
			StartSet();
		}
		public void StartGet()
		{
			//starting the get
			this.updateThread = new Thread(delegate ()
			{
				while (!stop)
				{
					HeadingDeg = ReadFromTelnetClient("headingDeg");
					VerticalSpeed = ReadFromTelnetClient("verticalSpeed");
					GroundSpeed = ReadFromTelnetClient("groundSpeed");
					IndicatedSpeed = ReadFromTelnetClient("indicatedSpeed");
					GpsAltitude = ReadFromTelnetClient("gpsAltitude");
					InternalRoll = ReadFromTelnetClient("internalRoll");
					InternalPitch = ReadFromTelnetClient("internalPitch");
					AltimeterAltitude = ReadFromTelnetClient("altimeterAltitude");
					Latitude = ReadFromTelnetClient("latitude");

					Longitude = ReadFromTelnetClient("longitude");
					Thread.Sleep(250);
				}
			});
			this.updateThread.Start();
		}

		public void StartSet()
		{
			//starting the get
			new Thread(delegate ()
			{
				while (!stop)
				{
					while (sendToSimQueue.Count() > 0)
					{
						mut2.WaitOne();
						this.telnetClient.Write(sendToSimQueue.Peek());
						sendToSimQueue.Dequeue();
						mut2.ReleaseMutex();
					}
				}

			}).Start();
		}


		public Double ReadFromTelnetClient(String variable)
		{
			try
			{
				Double value = Convert.ToDouble(this.telnetClient.Read(this.valueMap[variable].address));
				/**
				if ((variable.Equals("latitude")) && (value < 30))
				{
					this.stop = true;
				}
	*/
				if (this.telnetClient.ReadTakeMoreTenSecond) { UpdateErrorMessageSet("CommunicationSlowly"); }
				return value;
			}
			catch (NotSuccessedSendTheMessage)
			{
					this.telnetClient.Disconnect();
					Disconnect();
					UpdateErrorMessageSet("telnetNotCanConnect"); 
			}
			catch (FormatException)
			{
				if (variable.Equals("latitude") || variable.Equals("longitude")) { UpdateErrorMessageSet("error - " + variable); }
				else { UpdateDashBoardMessage("server error - " + variable); }

			}
			catch (Exception) { UpdateErrorMessageSet("UnepctedErr"); }
			return Convert.ToDouble(this.valueMap[variable].value);
		}
		public void UpdateErrorMessageSet(string errorName)
		{
			try
			{
				this.messageError.Add(errorName);
				NotifyPropertyChanged("MessageError");
			} catch { }

		}
		public void UpdateDashBoardMessage(string errorName)
		{
			this.dashBoardError.Add(errorName);
			string proparty = errorName.Split(' ')[3];
			this.NotifyPropertyChanged(char.ToUpper(proparty[0]) + proparty.Substring(1) + "ErrorList");
		}
		public void NotifyPropertyChanged(string PropertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}
		public void MoveNavigation(string propName)
		{
			sendToSimQueue.Enqueue(this.valueMap[propName].address + " " + this.valueMap[propName].value);
		}

		private void UpDateSetProperty(String proparty, Double value)
		{
			this.valueMap[proparty].mutex.WaitOne();
			this.valueMap[proparty].value = value;
			//			if (proparty.Equals("latitude") || proparty.Equals("longitude")) { this.NotifyPropertyChanged("AirPlaneLocation"); }
			if (proparty.Equals("latitude")) { this.NotifyPropertyChanged("AirPlaneLocation"); }
			else { this.NotifyPropertyChanged(char.ToUpper(proparty[0]) + proparty.Substring(1)); }
			this.valueMap[proparty].mutex.ReleaseMutex();
		}
		public void KeepLimitAndUpdate(double[] limit, Double value, String name)
		{
			if (value < limit[0]) { UpDateSetProperty(name, limit[0]); UpdateDashBoardMessage("limit error - " + name); }
			else if (value > limit[1]) { UpDateSetProperty(name, limit[1]); UpdateDashBoardMessage("limit error - " + name); }
			else { UpDateSetProperty(name, value); }
		}
		private List<string> CreateListErr(string name)
		{
			List<string> list = new List<string>();
			if (this.dashBoardError.Contains("limit error - " + name)) { list.Add("Limits Error"); }
			if (this.dashBoardError.Contains("server error - " + name)) { list.Add("Invalid Value"); }
			return list;
		}

		public double HeadingDeg
		{
			get { return (this.valueMap["headingDeg"].value); }
			set { KeepLimitAndUpdate(new double[] { 0, 360 }, value, "headingDeg"); }
		}
		public double VerticalSpeed
		{
			get { return (this.valueMap["verticalSpeed"].value); }
			set { KeepLimitAndUpdate(new double[] { -5000, 721 }, value, "verticalSpeed"); }
		}
		public double GroundSpeed
		{
			get { return (this.valueMap["groundSpeed"].value); }
			set { KeepLimitAndUpdate(new double[] { -50, 302 }, value, "groundSpeed"); }
		}
		public double IndicatedSpeed
		{
			get { return (this.valueMap["indicatedSpeed"].value); }
			set { KeepLimitAndUpdate(new double[] { 0, 228 }, value, "indicatedSpeed"); }
		}
		public double GpsAltitude
		{
			get { return (this.valueMap["gpsAltitude"].value); }
			set { KeepLimitAndUpdate(new double[] { 0, 13500 }, value, "gpsAltitude"); }
		}
		public Location AirPlaneLocation
		{
			get {
				return new Location(this.Latitude, this.Longitude); 
			}
		}
		public double InternalRoll
		{
			get { return (this.valueMap["internalRoll"].value); }
			set
			{
				//todo check this limit
				UpDateSetProperty("internalRoll", value);
			}
		}
		public double InternalPitch
		{
			get { return (this.valueMap["internalPitch"].value); }
			set
			{ //todo check this limit
				UpDateSetProperty("internalPitch", value);
			}
		}
		public double AltimeterAltitude
		{
			get { return (this.valueMap["altimeterAltitude"].value); }
			set { KeepLimitAndUpdate(new double[] { 0, 13500 }, value, "altimeterAltitude"); }
		}

		public double Latitude
		{
			get { return (this.valueMap["latitude"].value); }
			set { KeepLimitAndUpdate(new double[] { -90, 85 }, value, "latitude"); }
		}

		public double Longitude
		{
			get { return (this.valueMap["longitude"].value); }
			set { KeepLimitAndUpdate(new double[] { - 180, 180 }, value, "longitude"); }
		}

		public double Throttle
		{
			get { return (this.valueMap["throttle"].value); }
			set { KeepLimitAndUpdate(new double[] { 0, 1 }, value, "throttle"); }
		}
		public double Aileron
		{
			get { return (this.valueMap["aileron"].value); }
			set { KeepLimitAndUpdate(new double[] { -1, 1 }, value, "aileron"); }
		}
		public double Elevator
		{
			get { return (this.valueMap["elevator"].value); }
			set { KeepLimitAndUpdate(new double[] { -1, 1 }, value, "elevator"); }
		}
		public double Rudder
		{
			get { return (this.valueMap["rudder"].value); }
			set { KeepLimitAndUpdate(new double[] { -1, 1 }, value, "rudder"); }
		}
		public HashSet<string> MassageError { get { return this.messageError; } }
		public List<string> IndicatedSpeedErrorList { get { return CreateListErr("indicatedSpeed"); }}
		public List<string> GpsAltitudeErrorList { get { return CreateListErr("gpsAltitude"); } }
		public List<string> InternalRollErrorList { get { return CreateListErr("internalRoll"); } }
		public List<string> InternalPitchErrorList { get { return CreateListErr("internalPitch"); } }
		public List<string> AltimeterAltitudeErrorList { get { return CreateListErr("altimeterAltitude"); } }
		public List<string> HeadingDegErrorList { get { return CreateListErr("headingDeg"); } }
		public List<string> GroundSpeedErrorList { get { return CreateListErr("groundSpeed"); } }
		public List<string> VerticalSpeedErrorList { get { return CreateListErr("verticalSpee"); } }
	}
}

