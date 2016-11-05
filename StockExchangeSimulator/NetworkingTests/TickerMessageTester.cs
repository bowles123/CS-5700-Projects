using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Networking;

namespace CommonTesting
{
    [TestClass]
    public class TickerMessageTester
    {
        [TestMethod]
        public void TickerMessage_TestEncodeAndDecode()
        {
            TickerMessage m1 = new TickerMessage()
            {
                Symbol = "ABCD",
                MessageTimestamp = DateTime.Now,
                OpeningPrice = 1001,
                PreviousClosingPrice = 1002,
                CurrentPrice = 1003,
                AskPrice = 1004,
                BidPrice = 1005,
                CurrentVolume = 1006,
                AverageVolume = 1007
            };

            byte[] encodedMessage = m1.Encode();
            Assert.IsNotNull(encodedMessage);
            Assert.AreEqual(42, encodedMessage.Length);
            
            TickerMessage m2 = TickerMessage.Decode(encodedMessage);
            Assert.IsNotNull(m2);
            Assert.AreEqual(m1.Symbol, m2.Symbol);
            Assert.AreEqual(m1.OpeningPrice, m2.OpeningPrice);
            Assert.AreEqual(m1.PreviousClosingPrice, m2.PreviousClosingPrice);
            Assert.AreEqual(m1.CurrentPrice, m2.CurrentPrice);
            Assert.AreEqual(m1.AskPrice, m2.AskPrice);
            Assert.AreEqual(m1.BidPrice, m2.BidPrice);
            Assert.AreEqual(m1.CurrentVolume, m2.CurrentVolume);
            Assert.AreEqual(m1.AverageVolume, m2.AverageVolume);
        }

        [TestMethod]
        public void TickerMessage_TestEncodingOfEmptyMessage()
        {
            TickerMessage m1 = new TickerMessage();
            byte[] encodedMessage = m1.Encode();
            Assert.IsNotNull(encodedMessage);
            Assert.AreEqual(42, encodedMessage.Length);
            for (int i = 0; i < 6; i++)
                Assert.AreEqual(32, encodedMessage[i]);
            for (int i = 6; i < 42; i++)
                Assert.AreEqual(0, encodedMessage[i]);

        }

        [TestMethod]
        public void TickerMessage_TestDecodingOfBadBytes()
        {
            TickerMessage m = TickerMessage.Decode(null);
            Assert.IsNull(m);

            byte[] bytes = new byte[] { };
            m = TickerMessage.Decode(bytes);
            Assert.IsNull(m);

            bytes = new byte[] { 65, 66, 67 };
            m = TickerMessage.Decode(bytes);
            Assert.IsNull(m);

            bytes = new byte[] { 65, 66, 67, 68, 69, 70, 0, 0 ,0, 0 };
            m = TickerMessage.Decode(bytes);
            Assert.IsNull(m);

            bytes = new byte[] { 65, 66, 67, 68, 69, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            m = TickerMessage.Decode(bytes);
            Assert.IsNull(m);
        }
    }
}
