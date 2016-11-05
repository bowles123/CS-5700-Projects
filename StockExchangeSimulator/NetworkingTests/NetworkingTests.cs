using Microsoft.VisualStudio.TestTools.UnitTesting;
using Networking;
using System.Net.Sockets;
using Stocks;
using System.Net;
using System.Threading;

namespace NetworkingTests
{
    [TestClass]
    public class NetworkingTests
    {
        StockPortfolio portfolio;
        Communicator mockCommunicator;
        UdpClient mockClient;

        private void setup()
        {
            portfolio = new StockPortfolio();
            mockCommunicator = new Communicator();
            mockClient = new UdpClient(0);
           
            portfolio.Add("AMZN", new Stock()
            { AskPrice = 5, AverageVolume = 2, BidPrice = 1, CurrentPrice = 1, CurrentVolume = 1, Symbol = "AMZN" });
            mockCommunicator.Portfolio = portfolio;
            mockCommunicator.RemoteEndPoint = new IPEndPoint(IPAddress.Loopback, ((IPEndPoint)mockClient.Client.LocalEndPoint).Port);
        }

        [TestMethod]
        public void CommunicatorReceiveExistingStockTest()
        {
            setup();
            TickerMessage mssg = new TickerMessage()
            { AskPrice = 5, AverageVolume = 2, BidPrice = 1, CurrentPrice = 2, CurrentVolume = 3, Symbol = "AMZN" };
            Stock stock;
            mockCommunicator.Start();

            byte[] bytes = mssg.Encode();
            mockClient.Send(bytes, bytes.Length, mockCommunicator.MyLocalEndPoint);
            Thread.Sleep(100);
            mockCommunicator.Stop();

            // Ensure the appropriate stock in the portfolio was updated correctly.
            Assert.IsTrue(mockCommunicator.Portfolio.ContainsKey("AMZN"));
            stock = mockCommunicator.Portfolio["AMZN"];
            Assert.IsNotNull(stock);
            Assert.AreEqual(stock.AskPrice, mssg.AskPrice);
            Assert.AreEqual(stock.AverageVolume, mssg.AverageVolume);
            Assert.AreEqual(stock.BidPrice, mssg.BidPrice);
            Assert.AreEqual(stock.CurrentPrice, mssg.CurrentPrice);
            Assert.AreEqual(stock.CurrentVolume, mssg.CurrentVolume);
            Assert.AreEqual(stock.Symbol, mssg.Symbol);
        }

        [TestMethod]
        public void CommunicatorRecieveNonExistingStockTest()
        {
            setup();
            TickerMessage mssg = new TickerMessage()
            { AskPrice = 3, AverageVolume = 1, BidPrice = 2, CurrentPrice = 2, CurrentVolume = 0, Symbol = "GNB" };
            int sizeBeforeSend = mockCommunicator.Portfolio.Count;
            mockCommunicator.Start();

            byte[] bytes = mssg.Encode();
            mockClient.Send(bytes, bytes.Length, mockCommunicator.MyLocalEndPoint);
            Thread.Sleep(100);
            mockCommunicator.Stop();

            // Ensure no changes were made to the portfolio.
            Assert.IsFalse(mockCommunicator.Portfolio.ContainsKey("GNB"));
            Assert.AreEqual(mockCommunicator.Portfolio.Count, sizeBeforeSend);
        }

        [TestMethod]
        public void CommunicatorSendTest()
        {
            setup();
            StreamStocksMessage mssg;
            mockCommunicator.Start();
            IPEndPoint ep = mockCommunicator.MyLocalEndPoint;
            byte[] bytes = null;
            Thread.Sleep(100);
            mockCommunicator.Stop();
            bytes = mockClient.Receive(ref ep);

            // Ensure that the message contains the expected data from the stock portfolio.
            Assert.IsNotNull(bytes);
            mssg = StreamStocksMessage.Decode(bytes);
            Assert.IsNotNull(mssg);
            Assert.IsNotNull(mssg.Symbols);
            Assert.AreEqual(1, mssg.Symbols.Count);
            Assert.AreEqual("AMZN", mssg.Symbols[0]);
        }
    }
}
