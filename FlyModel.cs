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
			this.address = addres;
			this.value = value;
			this.Iread = Iread;
		}
		public String address { get; set; }
		public String value { get; set; }
		public bool Iread { get; set; }
	}
	class FlyModel : ISimulatorModel
	{
		class NotSeccsedTookWithServer : Exception { };
		private ITelnetClient telnetClient;
		private bool stop;
		private Thread updateThread;
		private Dictionary<string, FlyData> valueMap;

		// values coming from the simulator server
		/*	private double headingDeg;
			private double verticalSpeed;
			private double groundSpeed;
			private double indicatedSpeed;
			private double gpsAltitude;
			private double internalRoll;
			private double internalPitch;
			private double altimeterAltitude;*/

		public event PropertyChangedEventHandler PropertyChanged;


		// Properties for binding with the viewModel
		/*public double HeadingDeg
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				headingDeg = value;
				NotifyPropertyChanged("HeadingDeg");
			}
		}
		public double VerticalSpeed
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				verticalSpeed = value;
				NotifyPropertyChanged("VerticalSpeed");
			}
		}
		public double GroundSpeed
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				groundSpeed = value;
				NotifyPropertyChanged("GroundSpeed");
			}
		}
		public double IndicatedSpeed
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				indicatedSpeed = value;
				NotifyPropertyChanged("IndicatedSpeed");
			}
		}
		public double GpsAltitude
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				gpsAltitude = value;
				NotifyPropertyChanged("GpsAltitude");
			}
		}
		public double InternalRoll
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				internalRoll = value;
				NotifyPropertyChanged("InternalRoll");
			}
		}
		public double InternalPitch
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				internalPitch = value;
				NotifyPropertyChanged("InternalPitch");
			}
		}
		public double AltimeterAltitude
		{
			get { return 0;*//*return this.valueMap[key].value;*//* }
			set
			{
				altimeterAltitude = value;
				NotifyPropertyChanged("AltimeterAltitude");
			}
		}*/


		public FlyModel(ITelnetClient telClient)
		{
			//read value

			//valueMap.Add("HEADING", new FlyData("/instrumentation/heading-indicator/indicated-heading-deg", "0", true));


			valueMap = new Dictionary<string, FlyData>();
			valueMap.Add("LATITUDE", new FlyData("/position/latitude-deg", "0", true));
			valueMap.Add("LONGITUDE", new FlyData("/position/longitude-deg", "0", true));
			valueMap.Add("AIR_SPEED", new FlyData("/instrumentation/airspeed-indicator/indicated-speed-kt", "0", true));
			valueMap.Add("ALTITUDE", new FlyData("/instrumentation/gps/indicated-altitude-ft", "0", true));
			valueMap.Add("ROLL", new FlyData("/instrumentation/attitude-indicator/internal-roll-deg", "0", true));
			valueMap.Add("PITCH", new FlyData("/instrumentation/attitude-indicator/internal-pitch-deg", "0", true));
			valueMap.Add("ALTIMETER", new FlyData("/instrumentation/altimeter/indicated-altitude-ft", "0", true));
			valueMap.Add("GROUND_SPEED", new FlyData("/instrumentation/gps/indicated-ground-speed-kt", "0", true));
			valueMap.Add("VERTICAL_SPEED", new FlyData("/instrumentation/gps/indicated-vertical-speed", "0", true));
			// writh value
			valueMap.Add("THROTTLE", new FlyData("/controls/engines/current-engine/throttle", "0", false));
			valueMap.Add("AILERON", new FlyData("/controls/flight/aileron", "0", false));
			valueMap.Add("ELEVATOR", new FlyData("/controls/flight/elevator", "0", false));
			valueMap.Add("RUDDER", new FlyData("/controls/flight/rudder", "0", false));

			stop = false;
			this.telnetClient = telClient;
		}
		public void connect(string ip, int port) { this.telnetClient.connect(ip, port); }
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
								this.valueMap[key].value = (this.telnetClient.read(this.valueMap[key].address));
								//todo need do somthing?
								//if ((this.valueMap[key].value.ToString).Equals("ERR")) { }
								//								Console.WriteLine(key + ""+ this.valueMap[key].value);
							}
							else { this.telnetClient.write(this.valueMap[key].address); }
						}
					}
					catch (Exception) { throw new NotSeccsedTookWithServer(); }
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
			throw new NotImplementedException();
		}

		public void moveSlider(double throttle, double aileron)
		{
			string throttleString = this.valueMap["THROTTLE"].address + " " + throttle.ToString();
			string aileronString = this.valueMap["AILERON"].address + " " + aileron.ToString();

			telnetClient.write(throttleString);
			telnetClient.write(aileronString);
		}
	}
}
