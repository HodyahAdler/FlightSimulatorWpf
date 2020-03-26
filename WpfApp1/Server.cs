using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
/**
namespace WpfApp1
{
    class Server
    {
        Socket socket;
        IPEndPoint localPoint;
        public void openIp()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localPoint = new IPEndPoint(ipAddr, 11111);
            this.socket = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(localPoint);
            socket.Listen(50);
        }

        public void sendInformation()
        {
            while (true)
               {
               Console.WriteLine("Waiting  to connection ... ");
               Socket clientSocket = listener.Accept();

                    // Data buffer 
                    byte[] bytes = new Byte[1024];
                    string data = null;
                    while (true)
                    {
                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes,
                                                   0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                        Socket clientSocket = socket.Accept();
                        byte[] massageByte = new Byte[1024];
                        string stringMassage = null;
                    }
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");
                    clientSocket.Send(message);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");
                    clientSocket.Send(message);
                }
            }
        public void close()
        {
            this.socket.Shutdown(SocketShutdown.Both);
            this.socket.Close();
        }
    }
}
    */