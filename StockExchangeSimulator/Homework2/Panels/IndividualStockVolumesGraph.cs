using System.Collections.Generic;
using System.Windows.Forms;
using Stocks;

namespace Panels
{
    public partial class IndividualStockVolumesGraph : UserControl, DisplayPanel
    {
        private List<int> stockVolumes;
        private int location;
        private Stock _stock;

        public IndividualStockVolumesGraph(Stock stock)
        {
            InitializeComponent();
            stockVolumes = new List<int>();
            graphTitleLabel.Text = stock.Symbol + " - Volume";
            _stock = stock;
        }

        public List<int> getStockVolumes()
        {
            return stockVolumes;
        }

        public void update(Subject stock)
        {
            if (stockVolumes.Count < 30)
            {
                stockVolumes.Add(((Stock)stock).CurrentVolume);
                location++;
            }
            else
            {
                if (location > 29)
                    location = 0;
                stockVolumes[location] = ((Stock)stock).CurrentVolume;
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
            //throw new NotImplementedException();
        }
    }
}
