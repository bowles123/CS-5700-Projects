using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Networking
{
    public class StreamStocksMessage
    {
        public List<string> Symbols { get; private set; }

        public int Count => Symbols?.Count ?? 0;

        public void Add(string symbol)
        {
            if (Symbols==null) Symbols = new List<string>();

            if (!string.IsNullOrWhiteSpace(symbol))
                Symbols.Add(symbol);
        }

        public byte[] Encode()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            if (Symbols != null)
            {
                binaryWriter.Write(IPAddress.HostToNetworkOrder(Convert.ToInt16(Symbols.Count)));
                foreach (string symbol in Symbols)
                {
                    byte[] tmp = Encoding.ASCII.GetBytes(symbol.PadRight(6));
                    binaryWriter.Write(tmp, 0, tmp.Length);
                }
            }
            else
                binaryWriter.Write((short) 0);                

            return memoryStream.ToArray();
        }

        public static StreamStocksMessage Decode(byte[] bytes)
        {
            StreamStocksMessage message = null;
            if (bytes != null && bytes.Length >= 2)
            {
                message = new StreamStocksMessage {Symbols = new List<string>()};

                BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
                short count = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                for (int i = 0; i < count; i++)
                {
                    byte[] tmp = binaryReader.ReadBytes(6);
                    if (tmp.Length == 6)
                    {
                        string symbol = Encoding.ASCII.GetString(tmp, 0, 6).Trim();
                        message.Symbols.Add(symbol);
                    }
                    else
                    {
                        message = null;
                        break;
                    }
                }
            }

            return message;
        }
    }
}
