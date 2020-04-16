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
		class notSuccessedSendTheMessage : Exception { }
		TcpClient client;
		string ip = "127.0.0.1";
		int port = 5402;
		bool wasMessageOnSlowleConnest = false;

		public void Connect(string ip, string port)
		{
			try
			{
				this.client = new TcpClient(ip, Convert.ToInt16(port));
				this.ip = ip;
				this.port = Convert.ToInt16(port);
			} catch (Exception) { Connect(); }
		}
		public void Connect()
		{
			try { this.client = new TcpClient(this.ip, this.port); }
			catch (Exception) { throw new notSuccessedConnectToServer(); }
		}
		public String Read(String asking)
		{
			try
			{
				System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
				byte[] reader = Encoding.ASCII.GetBytes("get " + asking + "\n");
				this.client.GetStream().Write(reader, 0, reader.Length);
				byte[] buffer = new byte[1024];
				//				this.client.ReceiveTimeout = 10000;
				watch.Start();
				this.client.GetStream().Read(buffer, 0, 1024);
				watch.Stop();
				String information = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
				if (watch.Elapsed >= TimeSpan.FromSeconds(10)) { ReadTakeMoreTenSecond = true; }
				else { ReadTakeMoreTenSecond = false; }
				return information;
			}
			catch (Exception) { Disconnect(); throw new notSuccessedSendTheMessage(); }
		}
		public bool ReadTakeMoreTenSecond
		{
			get { return this.wasMessageOnSlowleConnest; }
			set { this.wasMessageOnSlowleConnest = value; }
		}
		public void Write(String asking)
		{
			try
			{
				byte[] reader = Encoding.ASCII.GetBytes("set " + asking + "\n");
				Console.WriteLine("set" + asking + "\n");
				this.client.GetStream().Write(reader, 0, reader.Length);
				byte[] buffer = new byte[1024];
				this.client.GetStream().Read(buffer, 0, 1024);
				//String information = Encoding.ASCII.GetString(buffer, 0, buffer.Length);

			}
			catch (Exception) { Disconnect(); throw new notSuccessedSendTheMessage(); }
		}
		public void Disconnect()
		{
			//this.client.GetStream().Close();
			this.client.Close();
			//todo if need delete?
		}
	}
}