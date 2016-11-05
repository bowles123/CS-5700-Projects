using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Stocks;
using log4net;

namespace Networking
{
    /// <summary>
    /// Sample, Partial Communicator
    /// 
    /// The following is a partial example of a class
    /// </summary>
    public class Communicator
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Communicator));
        private UdpClient _myUdpClient;
        private bool _isMonitoring;

        public IPEndPoint MyLocalEndPoint
        { get
            {
                return new IPEndPoint(IPAddress.Loopback, ((IPEndPoint)_myUdpClient.Client.LocalEndPoint).Port);
            }
        }

        // The following property will hold the communication end point for the simulator.  The object that creates
        // and setup an instance of the communicator, can use the EndPointParser to create an IPEndPoint from a string
        // like "127.0.0.1:12099" or from a host name and port number.  See EndPointParser class
        public IPEndPoint RemoteEndPoint { get; set; }

        /// <summary>
        /// This method just returns a status string, i.e., Monitoring if the communication is trying to receiving
        /// messages from the simulator.
        /// </summary>
        public string Status => _isMonitoring ? "Monitoring" : "";

        /// <summary>
        /// This is the stock portfolio known to the communicator.  When the communicator starts monitoring, it will send the simulator
        /// a StreamStocksMessage with all of the symbols in the Portfolio.  So, it is necessary for this portfolio to be setup before
        /// the communicator starts monitoring.  Also, when the communicator receives a TickerMessage, it will pass it onto the portfolio
        /// so it can update the right stock.
        /// </summary>
        public StockPortfolio Portfolio { get; set; }

        /// <summary>
        /// This method contains sample code for create a Datagram Socket (i.e., UdpClient) that can communicator with
        /// the simulator.  It also contain sample code for starting a thread tries to receive incoming message.
        /// </summary>
        public void Start()
        {
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 0);
            _myUdpClient = new UdpClient(localEp);

            _isMonitoring = true;
            logger.Debug("Starting Communicator....");
            ThreadPool.QueueUserWorkItem(Monitoring, null);
        }

        /// <summary>
        /// This method contains sample code for stopping the UdpClient.  Also, setting the _isMonitoring variable
        /// should stop the Monitoring thread
        /// </summary>
        public void Stop()
        {
            Send(new StreamStocksMessage());
            _isMonitoring = false;

            if (_myUdpClient != null)
            {
                _myUdpClient.Close();
                _myUdpClient = null;
            }
        }

        #region Private methods
        /// <summary>
        /// This is a partial implementation of the main method for the Monitoring thread.  It will first
        /// create and send StreamStocksMessage, and then go into a recieve loop until _isMonitoring is
        /// false
        /// </summary>
        /// <param name="state"></param>
        private void Monitoring(object state)
        {
            if (Portfolio == null) return;
            logger.Debug("Monitoring....");
            
            StreamStocksMessage startMessage = new StreamStocksMessage();
            foreach (KeyValuePair<string, Stock> kv in Portfolio)
               startMessage.Add(kv.Key);
            Send(startMessage);

            while (_isMonitoring)
            {
                // Try to receive a TickerMessage and pass it onto the Portfolio for procesing.  It will
                // wait 1000 ms before giving up on the receive attempt.  In that caase, the message will
                // be null and the Portfolio.Update method will do nothing.
                try
                {
                    var message = Receive(1000);
                    Portfolio.Update(message);
                }
                catch (Exception)
                {
                    logger.Debug("Didn't receive message before timeout.");
                }
            }
        }


        /// <summary>
        /// This method sends a message through the UdpClient to the RemoteEndPoint
        /// </summary>
        /// <param name="message"></param>
        private void Send(StreamStocksMessage message)
        {
            if (message == null) return;

            byte[] bytesToSend = message.Encode();

            try
            {
                _myUdpClient.Send(bytesToSend, bytesToSend.Length, RemoteEndPoint);
                logger.Debug("Successfully sent message to simulator.");
            }
            catch (Exception)
            {
                logger.Debug("Unable to send message, stopping process.");
                Stop();
            }
        }

        /// <summary>
        /// This method receives a single TickerMessage within some time limit.  If no message
        /// comes in within the time limit, then it returns a null.  Used by Monitoring method.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private TickerMessage Receive(int timeout = 0)
        {
            TickerMessage message = null;

            byte[] receivedBytes = ReceiveBytes(timeout);
            if (receivedBytes != null && receivedBytes.Length > 0)
            {
                message = TickerMessage.Decode(receivedBytes);
                logger.Debug("Received message from simulator.");
            }

            return message;
        }

        /// <summary>
        /// This method receives a byte array from the UpdClient, within some time limit.  Used by
        /// the Receive method
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private byte[] ReceiveBytes(int timeout)
        {
            byte[] receivedBytes = null;

            _myUdpClient.Client.ReceiveTimeout = timeout;
            IPEndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                receivedBytes = _myUdpClient.Receive(ref senderEndPoint);
            }
            catch (SocketException err)
            {
                if (err.SocketErrorCode != SocketError.TimedOut && err.SocketErrorCode != SocketError.Interrupted)
                    throw;
            }

            return receivedBytes;
        }
        #endregion
    }
}
