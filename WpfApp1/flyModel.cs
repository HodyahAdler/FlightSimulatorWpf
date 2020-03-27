using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WpfApp1
{
	public class flyData
	{
		public flyData(String addres, String value, bool Iread)
		{
			this.addres = addres;
			this.value = value;
			this.Iread = Iread;
		}
		public String addres { get; set; }
		public String value { get; set; }
		public bool Iread { get; set; }
	}
	class flyModel
	{
		class NotSeccsedTookWithServer : Exception { };
		private ClientServer clientServer;
		private bool stop = false;
		private Thread updateThread;
		private Dictionary<string, flyData> valueMap;
		public flyModel()
		{
			//read value
			valueMap = new Dictionary<string, flyData>();
			valueMap.Add("LATITUDE", new flyData("/position/latitude-deg", "0" , true));
			valueMap.Add("LONGITUDE", new flyData("/position/longitude-deg", "0", true));
			valueMap.Add("AIR_SPEED", new flyData("/instrumentation/airspeed-indicator/indicated-speed-kt", "0", true));
			valueMap.Add("ALTITUDE", new flyData("/instrumentation/gps/indicated-altitude-ft", "0", true));
			valueMap.Add("ROLL", new flyData("/instrumentation/attitude-indicator/internal-roll-deg", "0", true));
			valueMap.Add("PITCH", new flyData("/instrumentation/attitude-indicator/internal-pitch-deg", "0", true));
			valueMap.Add("ALTIMETER", new flyData("/instrumentation/altimeter/indicated-altitude-ft", "0", true));
			valueMap.Add("HEADING", new flyData("/instrumentation/heading-indicator/indicated-heading-deg", "0", true));
			valueMap.Add("GROUND_SPEED", new flyData("/instrumentation/gps/indicated-ground-speed-kt", "0", true));
			valueMap.Add("VERTICAL_SPEED", new flyData("/instrumentation/gps/indicated-vertical-speed", "0", true));
			// writh value
			valueMap.Add("THROTTLE", new flyData("/controls/engines/current-engine/throttle", "0", false));
			valueMap.Add("AILERON", new flyData("/controls/flight/aileron", "0", false));
			valueMap.Add("ELEVATOR", new flyData("/controls/flight/elevator", "0", false));
			valueMap.Add("RUDDER", new flyData("/controls/flight/rudder", "0", false));

			this.clientServer = new ClientServerSimple();
		}
		public void connect(string ip, int port){ this.clientServer.connect(ip, port); }
		public void connect(){ this.clientServer.connect(); }
		public void disconnect()
		{
			stop = true;
			//todo not need stop the thread? 
			this.clientServer.disconnect();
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
								this.valueMap[key].value = (this.clientServer.read(this.valueMap[key].addres));
								//todo need do somthing?
								//if ((this.valueMap[key].value.ToString).Equals("ERR")) { }
//								Console.WriteLine(key + ""+ this.valueMap[key].value);
							}
							else { this.clientServer.writh(this.valueMap[key].addres); }
						}
					}
					catch (Exception error) { throw new NotSeccsedTookWithServer(); }
					Thread.Sleep(250);
				}
			});
			this.updateThread.Start();
		}
	}
}
