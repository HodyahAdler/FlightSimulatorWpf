using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// i was helping from GeeksforGeeks
namespace WpfApp1
{
		//todo this is was need to be change? with command? i dont sure
		//todo click that can change thing?
	class ClientServerSimple : ClientServer
	{
		class notSeccsedConnectToServer: Exception{}
		class notSeccsedSendTheMassage : Exception {}
		Thread sendThread;
		TcpClient client;
		bool stop = false;
		Dictionary<string, string> mapStringOfSimulator = new Dictionary<string, string>(){};
		
		public void openIp() {
			//TODO how to do the map in constructor
			mapStringOfSimulator.Add("lengthLine", "get /position/longitude-deg\n");
			mapStringOfSimulator.Add("widthLine", "get / position / latitude - deg\n");
			try {
				const int port = 5402;
//				this.client = new TcpClient(Dns.GetHostName(), port);
				this.client = new TcpClient("127.0.0.1", port);
				this.sendThread = new Thread(getInformation);
				this.sendThread.Start();
			} catch (Exception e){
				throw new notSeccsedConnectToServer();
			}
		}
		public void getInformation()
		{
			while (!stop)
			{
				try
				{
					byte[] reader = Encoding.ASCII.GetBytes("get /controls/flight/rudder\n" +
					"get /controls/engines/current-engine/throttle\n" + mapStringOfSimulator["lengthLine"] +
					mapStringOfSimulator["widthLine"]);
					this.client.GetStream().Write(reader, 0, reader.Length);
					byte[] buffer = new byte[1024];
					this.client.GetStream().Read(buffer, 0, 1024);
					string information = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
					Console.WriteLine(information);
				}
				catch (Exception e) { close(); throw new notSeccsedSendTheMassage(); }
			}
		}

		public void close()
		{
			//TODO check if this how stop theard
			//			stop = true;
			this.sendThread.Join();
			this.client.Close();
			//todo if need delete?
		}
	}
}