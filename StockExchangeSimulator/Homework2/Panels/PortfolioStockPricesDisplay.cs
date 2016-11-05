using System.Collections.Generic;
using System.Windows.Forms;

namespace Panels
{
    public partial class PortfolioStockPricesDisplay : UserControl
    {
        private int moveDown;
        public List<StockPriceControl> Stocks { get; private set; }

        public PortfolioStockPricesDisplay()
        {
            InitializeComponent();
            Stocks = new List<StockPriceControl>();
            moveDown = 20;
        }

        public void addStockPriceControl(StockPriceControl control)
        {
            if (Stocks != null)
                Stocks.Add(control);
            else
                Stocks = new List<StockPriceControl>() { control };
        }

        public void removeStockPriceControl(StockPriceControl control)
        {
            if (Stocks.Contains(control))
            {
                Stocks.Remove(control);
                Controls.Remove(control);
            }
        }

        public void repaint()
        {
            if (Stocks != null && Stocks.Count > 0)
            {
                foreach (StockPriceControl control in Stocks)
                {
                    control.SetBounds(stockSymbolLabel.Location.X, stockSymbolLabel.Location.Y + moveDown,
                        control.Width, control.Height);
                    Controls.Add(control);
                    moveDown += 20;
                }
                moveDown = 20;
            }
        }
    }
}
