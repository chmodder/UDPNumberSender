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
    class Program
    {
        static void Main(string[] args)
        {

            UDPNumberSenderBroad theSender = new UDPNumberSenderBroad(9999);

            #region Infinite number sending

            theSender.StartBroadcasting();

            #endregion

            #region If sender should stop sending after a specific amount of time
            //Task.Factory.StartNew(() => theSender.StartBroadcasting());

            ////Sets the amount of time for the listener to listen before invkong the StopListening method
            ////this is to prevent that the program ends before receiving anything
            //Thread.Sleep(5000);

            //theSender.StopSending();
            #endregion
        }
    }
}
