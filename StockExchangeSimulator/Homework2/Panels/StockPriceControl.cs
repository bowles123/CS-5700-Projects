using System.Windows.Forms;
using Networking;
using Stocks;

namespace Panels
{
    public partial class StockPriceControl : UserControl, DisplayPanel
    {
        private bool upFromBefore;
        public static PortfolioStockPricesDisplay portfolioPanel;
        public static Communicator communicator;
        public Stock Stock { get; private set; }
        public bool UpFromBefore { get { return upFromBefore; } }

        public StockPriceControl(Stock stock)
        {
            InitializeComponent();
            Stock = stock;
            upFromBefore = false;
            portfolioPanel.addStockPriceControl(this);
        }

        public void update(Subject stock)
        {
            if (stock != null)
            {
                Stock actualStock = stock as Stock;

                if (actualStock.CurrentPrice > Stock.CurrentPrice)
                {
                    upFromBefore = true;
                }

                Stock.OpeningPrice = actualStock.OpeningPrice;
                Stock.CurrentPrice = actualStock.CurrentPrice;
                Stock.BidPrice = actualStock.BidPrice;
                Stock.AskPrice = actualStock.AskPrice;
            }
        }

        public void updateGui(string priceText)
        {
            openingPriceLabel.Text = priceText;
            updateGui();
        }

        public void updateGui()
        {
            symbolLabel.Text = Stock.Symbol;
            currentPriceLabel.Text = Stock.CurrentPrice.ToString();
            bidPriceLabel.Text = Stock.BidPrice.ToString();
            askPriceLabel.Text = Stock.AskPrice.ToString();

            if (UpFromBefore)
                directionLabel.Text = "^";
            else
                directionLabel.Text = "V";
            portfolioPanel.repaint();
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            portfolioPanel.removeStockPriceControl(this);
            portfolioPanel.repaint();
            communicator.Portfolio.Remove(Stock.Symbol);
            Stock.Unsubscribe(this);
        }
    }
}
