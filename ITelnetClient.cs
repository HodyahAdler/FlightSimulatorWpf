
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorWpf
{
    class NotSuccessedConnectToServer : Exception { }
    class NotSuccessedSendTheMessage : Exception { }
    interface ITelnetClient
    {
        void Connect(string ip, string port);
        String Read(String asking);
        void Write(String asking);
        void Disconnect();
        bool ReadTakeMoreTenSecond { set; get; }
    }
}