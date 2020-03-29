using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
	public class FlyData
	{
		public FlyData(String addres, String value, bool Iread)
		{
			this.addres = addres;
			this.value = value;
			this.Iread = Iread;
		}
		public String addres { get; set; }
		public String value { get; set; }
		public bool Iread { get; set; }
		public Mutex mutex = new Mutex();
	}
	class FlyModel : IModel
	{
		class NotSuccessedTookWithServer : Exception { };
		private ITelnetClient telnetClient;
		private bool stop = false;
		private Thread updateThread;
		private Dictionary<string, FlyData> valueMap;
		/**
		private double headingDeg;
		private double verticalSpeed;
		private double groundSpeed;
			private double indicatedSpeed;
			private double gpsAltitude;
			private double internalRoll;
			private double internalPitch;
			private double altimeterAltitude;
			*/
		public event PropertyChangedEventHandler PropertyChanged;
		public FlyModel(ITelnetClient telClient)
		{
			//read value
			valueMap = new Dictionary<string, FlyData>();
			valueMap.Add("latitude", new FlyData("/position/latitude-deg", "0", true));
			valueMap.Add("longitude", new FlyData("/position/longitude-deg", "0", true));
			valueMap.Add("indicatedSpeed", new FlyData("/instrumentation/airspeed-indicator/indicated-speed-kt", "0", true));
			valueMap.Add("gpsAltitude", new FlyData("/instrumentation/gps/indicated-altitude-ft", "0", true));
			valueMap.Add("internalRoll", new FlyData("/instrumentation/attitude-indicator/internal-roll-deg", "0", true));
			valueMap.Add("internalPitch", new FlyData("/instrumentation/attitude-indicator/internal-pitch-deg", "0", true));
			valueMap.Add("altimeterAltitude", new FlyData("/instrumentation/altimeter/indicated-altitude-ft", "0", true));
			valueMap.Add("headingDeg", new FlyData("/instrumentation/heading-indicator/indicated-heading-deg", "0", true));
			valueMap.Add("groundSpeed", new FlyData("/instrumentation/gps/indicated-ground-speed-kt", "0", true));
			valueMap.Add("verticalSpeed", new FlyData("/instrumentation/gps/indicated-vertical-speed", "0", true));
			// writh value 
			valueMap.Add("throttle", new FlyData("/controls/engines/current-engine/throttle", "0", false));
			valueMap.Add("aileron", new FlyData("/controls/flight/aileron", "0", false));
			valueMap.Add("elevator", new FlyData("/controls/flight/elevator", "0", false));
			valueMap.Add("rudder", new FlyData("/controls/flight/rudder", "0", false));

			stop = false;
			this.telnetClient = telClient;
		}
		public void connect(string ip, int port) { this.telnetClient.connect(ip, port); }
		public void connect() { this.telnetClient.connect(); }
		public void disconnect()
		{
			stop = true;
			//todo not need stop the thread? 
			this.telnetClient.disconnect();
		}
		public void start()
		{
			this.updateThread = new Thread(delegate ()
			{
				while (!stop)
				{
					try
					{
						foreach (string key in valueMap.Keys)
						{
							if (this.valueMap[key].Iread)
							{
								//need check if 10 second not have anser
								//this.valueMap[key].value = (this.clientServer.read(this.valueMap[key].addres));
								upDateSetProperty(key, Double.Parse(this.telnetClient.read(this.valueMap[key].addres)));
								//todo need do somthing?
								//if ((this.valueMap[key].value.ToString).Equals("ERR")) { }
								//								Console.WriteLine(key + ""+ this.valueMap[key].value);
							}
							else { this.telnetClient.write(this.valueMap[key].addres); }
						}
					}
					catch (Exception) { throw new NotSuccessedTookWithServer(); }
					Thread.Sleep(250);
				}
			});
			this.updateThread.Start();
		}

		public void NotifyPropertyChanged(string PropertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
			}
		}

		public void moveJoystick(double elevator, double rudder)
		{
			//todo - semothing else?
			Elevator = elevator;
			Rudder = rudder;
		}

		public void moveSlider(double throttle, double aileron)
		{
			Throttle = throttle;
			Aileron = aileron;
		}
		private void upDateSetProperty(String propartyName, Double value)
		{
			this.valueMap[propartyName].mutex.WaitOne();
			this.valueMap[propartyName].value = value.ToString();
			this.NotifyPropertyChanged(char.ToUpper(propartyName[0]) + propartyName.Substring(1));
			this.valueMap[propartyName].mutex.ReleaseMutex();
		}
		// Properties for binding with the viewModel
		public double HeadingDeg
		{
			get { return Double.Parse(this.valueMap["headingDeg"].value); }
			/**set{ upDateSetProperty("headingDeg", value) }*/
		}
		public double VerticalSpeed
		{
			get { return Double.Parse(this.valueMap["verticalSpeed"].value); }
			/**set{ upDateSetProperty("verticalSpeed", value) }*/
		}
		public double GroundSpeed
		{
			get { return Double.Parse(this.valueMap["groundSpeed"].value); }
			/**set{ upDateSetProperty("groundSpeed", value) }*/
		}
		public double IndicatedSpeed
		{
			get { return Double.Parse(this.valueMap["indicatedSpeed"].value); }
			/**set{ upDateSetProperty("indicatedSpeed", value) }*/
		}
		public double GpsAltitude
		{
			get { return Double.Parse(this.valueMap["gpsAltitude"].value); }
			/**set{ upDateSetProperty("gpsAltitude", value) }*/
		}
		public double InternalRoll
		{
			get { return Double.Parse(this.valueMap["internalRoll"].value); }
			/**set{ upDateSetProperty("internalRoll", value) }*/
		}
		public double InternalPitch
		{
			get { return Double.Parse(this.valueMap["internalPitch"].value); }
			/**set{ upDateSetProperty("internalPitch", value) }*/
		}
		public double AltimeterAltitude
		{
			get { return Double.Parse(this.valueMap["altimeterAltitude"].value); }
			/**set{ upDateSetProperty("altimeterAltitude", value) }*/
		}

		public double Latitude
		{
			get { return Double.Parse(this.valueMap["latitude"].value); }
			/**set{ upDateSetProperty("latitude", value) }*/
		}
		public double Longitude
		{
			get { return Double.Parse(this.valueMap["longitude"].value); }
			/**set{ upDateSetProperty("longitude", value); }*/
		}
		public double Throttle
		{
			get { return Double.Parse(this.valueMap["throttle"].value); }
			set { upDateSetProperty("throttle", value); }
		}
		public double Aileron
		{
			get { return Double.Parse(this.valueMap["aileron"].value); }
			set { upDateSetProperty("aileron", value); }
		}
		public double Elevator
		{
			get { return Double.Parse(this.valueMap["elevator"].value); }
			set { upDateSetProperty("elevator", value); }
		}
		public double Rudder
		{
			get { return Double.Parse(this.valueMap["rudder"].value); }
			set { upDateSetProperty("rudder", value); }
		}
	}
}