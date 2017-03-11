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
            //Set up Host
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9999);

            //Create Sender
            UDPNumberSender theSender = new UDPNumberSender(RemoteIpEndPoint);

            //Start sending
            theSender.StartSending();
        }
    }
}
