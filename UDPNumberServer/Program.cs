using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPNumberServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Creates a UdpClient for reading AND sending incoming data.
            //UdpClient udpServer = new UdpClient(9999);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9999);
            //udpServer.Connect(RemoteIpEndPoint);

            //UDPNumberSender theSender = new UDPNumberSender(udpServer,RemoteIpEndPoint);
            UDPNumberSender theSender = new UDPNumberSender(RemoteIpEndPoint);

            theSender.StartSending();
        }
    }
}
