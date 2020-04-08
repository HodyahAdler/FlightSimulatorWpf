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
		System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
		bool wasMassageOnSlowleConnest = false;

		public void connect(string ip, string port)
		{
			try {
				this.client = new TcpClient(ip, Convert.ToInt16(port));
				this.ip = ip;
				this.port = Convert.ToInt16(port);
			} catch (Exception){ connect(); }
			}
		public void connect()
		{
			try { this.client = new TcpClient(this.ip, this.port); }
			catch (Exception) { throw new notSuccessedConnectToServer(); }
		}
		public String read(String asking)
		{
			try
			{
				byte[] reader = Encoding.ASCII.GetBytes("get " + asking + "\n");
				this.client.GetStream().Write(reader, 0, reader.Length);
				byte[] buffer = new byte[1024];
				//				this.client.ReceiveTimeout = 10000;
				this.watch.Start();
				this.client.GetStream().Read(buffer, 0, 1024);
				this.watch.Stop();
				String information = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
				return information;
			}
			catch (Exception) { disconnect(); throw new notSuccessedSendTheMassage(); }
		}
		public bool readTakeMoreTenSecond()
		{
			if (this.watch.Elapsed >= TimeSpan.FromSeconds(10) && !wasMassageOnSlowleConnest) 
			{
				wasMassageOnSlowleConnest = true;
				return true; 
			}
			wasMassageOnSlowleConnest = false;
			return false;
		}
		public void write(String asking)
		{
			//		try
			//			{
			//				byte[] reader = Encoding.ASCII.GetBytes("set" + asking + "\n");
			//				int write = this.client.GetStream().Write(reader, 0, reader.Length);
			//				string anser = this.client.read()
//			}
//		catch (Exception) { disconnect(); throw new notSuccessedSendTheMassage(); }
		}
		public void disconnect()
		{
			this.client.GetStream().Close();
			this.client.Close();
			//todo if need delete?
		}
	}
}