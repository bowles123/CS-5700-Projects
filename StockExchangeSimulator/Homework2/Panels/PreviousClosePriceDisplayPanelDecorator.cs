using Stocks;
using System.Windows.Forms;

namespace Panels
{
    public class PreviousClosePriceDisplayPanelDecorator : DisplayPanelDecorator
    {
        private int closePrice;
        public PreviousClosePriceDisplayPanelDecorator(DisplayPanel p) : base(p) { }

        public override void update(Subject stock)
        {
            logger.Debug("Updating observer.");
            closePrice = ((Stock)stock).PreviousClosingPrice;
            Panel.update(stock);
            logger.Debug("Successfully updated observer.");
            needsRepaint = true;
        }

        public override void updateGui()
        {
            logger.Debug("Updating panel.");
            if (Panel is StockPriceControl)
            {
                StockPriceControl panel = Panel as StockPriceControl;
                panel.updateGui(closePrice.ToString() + " (C)");
            }
            else if (Panel is IndividualStockPricesGraph)
            {
                IndividualStockPricesGraph panel = Panel as IndividualStockPricesGraph;
                panel.updateGui('C');
            }
            else
            {
                IndividualStockVolumesGraph panel = Panel as IndividualStockVolumesGraph;
                panel.updateGui('C');
            }

            Panel.updateGui();
            logger.Debug("Successfully updated panel.");
        }
    }
}
