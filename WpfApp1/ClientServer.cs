using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// i was helping from GeeksforGeeks
namespace FlightSimulatorWpf
{
	interface ClientServer
	{
		void connect();
		void connect(string ip, int port);
		String read(String asking);
		void writh(String asking);
		void disconnect();

	}
}
