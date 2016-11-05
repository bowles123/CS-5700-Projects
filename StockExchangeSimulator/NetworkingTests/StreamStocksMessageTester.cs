using Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTesting
{
    [TestClass]
    public class StreamStocksMessageTester
    {
        [TestMethod]
        public void StartStreamMessage_TestAddEncodeAndDecode()
        {
            StreamStocksMessage m1 = new StreamStocksMessage();
            Assert.AreEqual(0, m1.Count);

            m1.Add("ABAX");
            Assert.AreEqual(1, m1.Count);

            m1.Add("AMZN");
            Assert.AreEqual(2, m1.Count);

            m1.Add("AAPL");
            Assert.AreEqual(3, m1.Count);

            m1.Add(null);
            Assert.AreEqual(3, m1.Count);

            m1.Add("");
            Assert.AreEqual(3, m1.Count);

            m1.Add("   ");
            Assert.AreEqual(3, m1.Count);

            byte[] encodedMessage = m1.Encode();
            Assert.IsNotNull(encodedMessage);
            Assert.AreEqual(20, encodedMessage.Length);

            StreamStocksMessage m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNotNull(m2);
            Assert.IsNotNull(m2.Symbols);
            Assert.AreEqual(3, m2.Symbols.Count);
            Assert.AreEqual("ABAX", m2.Symbols[0]);
            Assert.AreEqual("AMZN", m2.Symbols[1]);
            Assert.AreEqual("AAPL", m2.Symbols[2]);
        }

        [TestMethod]
        public void StartStreamMessage_TestMessageWithNoSymbols()
        {
            StreamStocksMessage m1 = new StreamStocksMessage();
            Assert.AreEqual(0, m1.Count);

            byte[] encodedMessage = m1.Encode();
            Assert.IsNotNull(encodedMessage);
            Assert.AreEqual(2, encodedMessage.Length);

            StreamStocksMessage m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNotNull(m2);
            Assert.IsNotNull(m2.Symbols);
            Assert.AreEqual(0, m2.Symbols.Count);
        }

        [TestMethod]
        public void StartStreamMessage_TestMessageWithNullSymbols()
        {
            StreamStocksMessage m1 = new StreamStocksMessage();
            byte[] encodedMessage = m1.Encode();
            Assert.IsNotNull(encodedMessage);
            Assert.AreEqual(2, encodedMessage.Length);

            StreamStocksMessage m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNotNull(m2);
            Assert.IsNotNull(m2.Symbols);
            Assert.AreEqual(0, m2.Symbols.Count);
        }

        [TestMethod]
        public void StartStreamMessage_TestDecodingOfBadBytes()
        {
            byte[] encodedMessage = new byte[0];
            StreamStocksMessage m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNull(m2);

            encodedMessage = new byte[] { 1 };
            m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNull(m2);

            encodedMessage = new byte[] { 0, 1, 65 };
            m2 = StreamStocksMessage.Decode(encodedMessage);
            Assert.IsNull(m2);

        }

    }
}
