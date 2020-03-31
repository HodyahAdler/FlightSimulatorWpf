using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

// i was helping from GeeksforGeeks
namespace FlightSimulatorWpf
{
		//todo this is was need to be change? with command? i dont sure
		//todo click that can change thing?
	class TelnetClient : ITelnetClient
    {
		class notSuccessedConnectToServer : Exception { }
		class notSuccessedSendTheMassage : Exception { }
		TcpClient client;
		string ip = "127.0.0.1";
		int port = 5402;
		public void connect(string ip, int port)
		{
			this.ip = ip;
			this.port = port;
			connect();
		}
		public void connect()
		{
			try
			{
				this.client = new TcpClient(ip, port);
				//				this.sendThread = new Thread(start);
				//				this.sendThread.Start();
			}
			catch (Exception)
			{
				// TO-DO: need to show message for client
				throw new notSuccessedConnectToServer();
			}
		}
		public String read(String asking)
		{
			try
			{
				byte[] reader = Encoding.ASCII.GetBytes("get " + asking + "\n");
				this.client.GetStream().Write(reader, 0, reader.Length);
				byte[] buffer = new byte[1024];
				this.client.GetStream().Read(buffer, 0, 1024);
				String information = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
				try { Double.Parse(information); } catch (Exception) { return "0"; }
				return information;
			}
			catch (Exception) { disconnect(); throw new notSuccessedSendTheMassage(); }
		}
		public void write(String asking)
		{
			try
			{
				byte[] reader = Encoding.ASCII.GetBytes("set" + asking + "\n");
				this.client.GetStream().Write(reader, 0, reader.Length);
			}
			catch (Exception) { disconnect(); throw new notSuccessedSendTheMassage(); }
		}
		public void disconnect()
		{
			this.client.GetStream().Close();
			this.client.Close();
			//todo if need delete?
		}
	}
}
