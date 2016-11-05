using Networking;

namespace Stocks
{
    public class Stock : Subject
    {
        public string Symbol { get; set; }
        public int OpeningPrice { get; set; }
        public int PreviousClosingPrice { get; set; }
        public int CurrentPrice { get; set; }
        public int BidPrice { get; set; }
        public int AskPrice { get; set; }
        public int CurrentVolume { get; set; }
        public int AverageVolume { get; set; }

        private void updateStock(TickerMessage message)
        {
            OpeningPrice = message.OpeningPrice;
            PreviousClosingPrice = message.PreviousClosingPrice;
            CurrentPrice = message.CurrentPrice;
            BidPrice = message.BidPrice;
            AskPrice = message.AskPrice;
            CurrentVolume = message.CurrentVolume;
            AverageVolume = message.AverageVolume;
        }
       
        public void Update(TickerMessage message)
        {
            if (Symbol.Equals(message.Symbol))
            {
                updateStock(message);
                NotifyObservers();
            }

        }
    }
}
