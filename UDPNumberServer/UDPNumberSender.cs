using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPNumberServer
{
    class UDPNumberSender
    {
        private IPEndPoint remoteIpEndPoint;
        //private UdpClient udpServer;

        public UDPNumberSender(IPEndPoint remoteIpEndPoint)
        {
            this.remoteIpEndPoint = remoteIpEndPoint;
        }

        //public UDPNumberSender(UdpClient udpServer, IPEndPoint remoteIpEndPoint)
        //{
        //    this.udpServer = udpServer;
        //    this.remoteIpEndPoint = remoteIpEndPoint;
        //}

        public void StartSending()
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            bool exception_thrown = false;

            try
            {
                int i = 0;

                while (true)
                {
                    #region Test code
                    //Byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);

                    //string sendData = $"The number is {i}";
                    #endregion

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(i.ToString());
                    //udpServer.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);

                    Console.WriteLine($"Number sent: {i}");

                    #region copy pasta from MSDN
                    try
                    {
                        sending_socket.SendTo(sendBytes, remoteIpEndPoint);
                    }
                    catch (Exception send_exception)
                    {
                        exception_thrown = true;
                        Console.WriteLine(" Exception {0}", send_exception.Message);
                    }

                    if (exception_thrown == false)
                    {
                        Console.WriteLine("Message has been sent to the broadcast address");
                    }
                    else
                    {
                        exception_thrown = false;
                        Console.WriteLine("The exception indicates the message was not sent.");
                    }
                    #endregion

                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
