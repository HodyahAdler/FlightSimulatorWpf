using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    interface ITelnetClient
    {
        void connect();
        void connect(string ip, int port);
        String read(String asking);
        void write(String asking);
        void disconnect();
    }
}
