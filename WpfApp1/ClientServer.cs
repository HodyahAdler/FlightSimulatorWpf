using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// i was helping from GeeksforGeeks
namespace WpfApp1
{
	interface ClientServer
	{
		void openIp();
		void getInformation();
		void close();
	}
}
