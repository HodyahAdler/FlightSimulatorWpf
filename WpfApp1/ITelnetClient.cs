using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class notSuccessedConnectToServer : Exception { }
    class notSuccessedSendTheMassage : Exception { }
    interface ITelnetClient
    {
        void connect();
        void connect(string ip, string port);
        String read(String asking);
        void write(String asking);
        void disconnect();
        bool ReadTakeMoreTenSecond { set; get; }
    }
}