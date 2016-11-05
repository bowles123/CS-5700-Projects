using System;
using System.IO;
using System.Net;
using System.Text;

namespace Networking
{
    public class TickerMessage
    {
        public string Symbol { get; set; }
        public DateTime? MessageTimestamp { get; set; }
        public int OpeningPrice { get; set; }
        public int PreviousClosingPrice { get; set; }
        public int CurrentPrice { get; set; }
        public int BidPrice { get; set; }
        public int AskPrice { get; set; }
        public int CurrentVolume { get; set; }
        public int AverageVolume { get; set; }

        public byte[] Encode()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            // Write out Symbol as string, padded spaces to 6 characters, converted to a byte array using ASCII encoding
            byte[] bytes = Encoding.ASCII.GetBytes(PaddedSymbol);
            binaryWriter.Write(bytes, 0, bytes.Length);

            // Write out Timestamp as a long integer of "ticks" in Network Standard Byte Order
            long ticks = MessageTimestamp?.Ticks ?? 0;
            binaryWriter.Write(IPAddress.HostToNetworkOrder(ticks));

            // Write out OpeningPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
            binaryWriter.Write(IPAddress.HostToNetworkOrder(OpeningPrice));

            // Write out PreviousClosingPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
            binaryWriter.Write(IPAddress.HostToNetworkOrder(PreviousClosingPrice));

            // Write out CurrentPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
            binaryWriter.Write(IPAddress.HostToNetworkOrder(CurrentPrice));

            // Write out BidPrice, as ang integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
            binaryWriter.Write(IPAddress.HostToNetworkOrder(BidPrice));

            // Write out AskPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
            binaryWriter.Write(IPAddress.HostToNetworkOrder(AskPrice));

            // Write out CurrentVolume, as an integer in Network Standard Byte Order
            binaryWriter.Write(IPAddress.HostToNetworkOrder(CurrentVolume));

            // Write out AverageVolume, as an integer in Network Standard Byte Order
            binaryWriter.Write(IPAddress.HostToNetworkOrder(AverageVolume));

            return memoryStream.ToArray();
        }

        public static TickerMessage Decode(byte[] bytes)
        {
            TickerMessage message = null;
            if (bytes != null && bytes.Length == 42)
            {
                message = new TickerMessage();

                BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));

                // Read in Symbol as string, padded spaces to 6 characters, converted to a byte array using ASCII encoding
                byte[] tmp = binaryReader.ReadBytes(6);
                message.PaddedSymbol = Encoding.ASCII.GetString(tmp, 0, 6);

                // Read in Timestamp as a long integer of "ticks" in Network Standard Byte Order
                message.MessageTimestampInBytes = binaryReader.ReadBytes(8);

                // Read in OpeningPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
                message.OpeningPrice = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in PreviousClosingPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
                message.PreviousClosingPrice = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in CurrentPrice, as an integer in Network Standard Byte Order.  The integer represents pennies (not dollars)
                message.CurrentPrice = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in BidPrice, as an integer in Network Standard Byte order.  The integer represents pennies (not dollars)
                message.BidPrice = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in AskPrice, as an integer in Network Standard Byte order.  The integer represents pennies (not dollars)
                message.AskPrice = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in CurrentVolume, as an integer in Network Standard Byte Order
                message.CurrentVolume = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());

                // Read in AverageVolume, as an integer in Network Standard Byte Order
                message.AverageVolume = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
            }

            return message;
        }

        protected string PaddedSymbol
        {
            get
            {
                string result = (string.IsNullOrWhiteSpace(Symbol)) ? string.Empty : Symbol;
                return result.PadRight(6);
            }
            set
            {
                Symbol = null;
                if (!string.IsNullOrWhiteSpace(value))
                    Symbol = value.Trim().ToUpper();
            }
        }

        protected byte[] MessageTimestampInBytes
        {
            get
            {
                long ticks = DateTime.Now.Ticks;
                return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(ticks));
            }
            set
            {
                MessageTimestamp = null;
                if (value != null && value.Length >= 8)
                {
                    long ticks = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(value, 0));
                    MessageTimestamp = new DateTime(ticks);
                }
            }
        }
    }
}
