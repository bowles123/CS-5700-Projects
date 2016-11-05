using Stocks;

namespace Panels
{
    public class OpeningPriceDisplayPanelDecorator : DisplayPanelDecorator
    {
        private int openPrice;

        public OpeningPriceDisplayPanelDecorator(DisplayPanel p) : base(p) { }

        public override void update(Subject stock)
        {
            logger.Debug("Updating observer....");
            openPrice = ((Stock)stock).OpeningPrice;
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
                panel.updateGui(openPrice.ToString() + " (O)");
            }
            else if (Panel is IndividualStockPricesGraph)
            {
                IndividualStockPricesGraph panel = Panel as IndividualStockPricesGraph;
                panel.updateGui('O');
            }
            else
            {
                IndividualStockVolumesGraph panel = Panel as IndividualStockVolumesGraph;
                panel.updateGui('O');
            }

            Panel.updateGui();
            logger.Debug("Successfully updated panel.");
        }
    }
}
