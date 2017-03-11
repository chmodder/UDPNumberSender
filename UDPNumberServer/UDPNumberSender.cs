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
        #region Instance Fields and Properties

        private UdpClient _udpSender;
        public int LocalPortNumber { get; set; }
        public bool UdpSenderIsRunning { get; set; }

        #endregion

        #region Constructors

        public UDPNumberSender(int localPortNumber)
        {
            UdpSenderIsRunning = false;
            LocalPortNumber = localPortNumber;
            this._udpSender = new UdpClient("127.0.0.1", localPortNumber);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts sending numbers
        /// </summary>
        public void StartSending()
        {
            UdpSenderIsRunning = true;

            try
            {
                int i = 0;

                while (UdpSenderIsRunning)
                {
                    string messageToSend = $"Number is: {i.ToString()}";
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(messageToSend);
                    _udpSender.Send(sendBytes, sendBytes.Length);

                    Console.WriteLine($"\nNumber sent: {i}");

                    i++;
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            _udpSender.Close();
        }

        /// <summary>
        /// Stops sending numbers
        /// </summary>
        public void StopSending()
        {
            UdpSenderIsRunning = false;
        }

        #endregion
    }
}
