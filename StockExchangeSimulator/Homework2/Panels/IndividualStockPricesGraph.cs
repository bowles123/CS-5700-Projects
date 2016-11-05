using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stocks;

namespace Panels
{
    public partial class IndividualStockPricesGraph : UserControl, DisplayPanel
    {
        private List<int> stockPrices;
        private Stock _stock;
        private int location;

        public IndividualStockPricesGraph(Stock stock)
        {
            InitializeComponent();
            stockPrices = new List<int>();
            location = 0;
            graphTitleLabel.Text = stock.Symbol + " - Price";
            _stock = stock;
        }

        public List<int> getStockPrices()
        {
            return stockPrices;
        }

        public void update(Subject stock)
        {
            if (stockPrices.Count < 30)
            {
                stockPrices.Add(((Stock)stock).CurrentPrice);
                location++;
            }
            else
            {
                if (location > 29)
                    location = 0;
                stockPrices[location] = ((Stock)stock).CurrentPrice;
                location++; 
            }
        }

        public void updateGui(char oc)
        {
            if (oc == 'o')
                priceDisplayLabel.Text = "Open Price: " + _stock.OpeningPrice;
            else
                priceDisplayLabel.Text = "Prev. Close Price: " + _stock.PreviousClosingPrice;
        }

        public void updateGui()
        {
            
        }
    }
}
