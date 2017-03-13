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
    public class UDPNumberSenderBroad
    {
        #region Instance Fields and Properties

        private UdpClient _udpSender;
        public int LocalPortNumber { get; set; }
        public bool UdpSenderIsRunning { get; set; }
        public IPEndPoint BroadcastEndPoint { get; set; }
        public IPAddress BroadcastIP { get; set; }


        #endregion

        #region Constructors

        public UDPNumberSenderBroad(int localPortNumber)
        {
            BroadcastIP = IPAddress.Broadcast;
            UdpSenderIsRunning = false;
            LocalPortNumber = localPortNumber;

            this._udpSender = new UdpClient(0);
            this._udpSender.EnableBroadcast = true;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts sending numbers
        /// </summary>
        public void StartBroadcasting()
        {
            BroadcastEndPoint = new IPEndPoint(BroadcastIP, LocalPortNumber);
            UdpSenderIsRunning = true;

            try
            {
                int i = 0;

                while (UdpSenderIsRunning)
                {
                    string messageToSend = $"Number sent by me is: {i.ToString()}, ";
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(messageToSend);

                    _udpSender.Send(sendBytes, sendBytes.Length,BroadcastEndPoint);

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
