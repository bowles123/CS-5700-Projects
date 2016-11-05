using System.IO;
using System.Collections.Generic;
using Networking;
using log4net;

namespace Stocks
{
    public class StockPortfolio : Dictionary<string, Stock>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StockPortfolio));
        public void Update(TickerMessage message)
        {
            if (message == null) return;
            logger.Debug("Updating StockPortfolio...");

            if (ContainsKey(message.Symbol))
            {
                this[message.Symbol].Update(message);
                logger.Debug("Successfully updated StockPortfolio.");
            }
        }

        public void Save(string file)
        {
            StreamWriter writer = new StreamWriter(file);

            foreach (string symbol in Keys)
                writer.WriteLine(symbol);
            writer.Close();
        }

        public void Load(string file)
        {
            StreamReader reader = new StreamReader(file);
            string line;

            while ((line = reader.ReadLine()) != null)
                Add(line, new Stock() { Symbol = line });
            reader.Close();
        }
    }
}
