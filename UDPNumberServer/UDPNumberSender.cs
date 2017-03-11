using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPNumberServer
{
    class UDPNumberSender
    {
        private IPEndPoint remoteIpEndPoint;

        public UDPNumberSender(IPEndPoint remoteIpEndPoint)
        {
            this.remoteIpEndPoint = remoteIpEndPoint;
        }
        
        public void StartSending()
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            bool exception_thrown = false;

            try
            {
                int i = 0;

                while (true)
                {

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(i.ToString());

                    #region copy pasta from codeproject.com
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
                        Console.WriteLine($"Message sent: {i}\n");
                    }
                    else
                    {
                        exception_thrown = false;
                        Console.WriteLine("The exception indicates the message was not sent.");
                    }
                    #endregion

                    Thread.Sleep(200);

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
