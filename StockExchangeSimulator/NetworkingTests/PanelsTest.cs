using Panels;
using Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkingTests
{
    [TestClass]
    public class PanelsTest
    {
        private DisplayPanel panel;

        [TestMethod]
        public void UpdateStockPriceControlTest()
        {
            // Setup stock and observer to be tested on.
            Stock stock = new Stock() { Symbol = "AMZN" };
            StockPriceControl actualPanel;
            StockPriceControl.portfolioPanel = new PortfolioStockPricesDisplay();
            Stock newStock = new Stock()
            {
                Symbol = "AMZN",
                AskPrice = 11,
                BidPrice = 1,
                CurrentPrice = 3,
                AverageVolume = 2,
                CurrentVolume = 2,
                OpeningPrice = 2,
                PreviousClosingPrice = 13
            };

            // Update the observer with the new stock.
            panel = new StockPriceControl(stock);
            panel.update(newStock);
            Assert.IsNotNull(panel);
            actualPanel = panel as StockPriceControl;

            // Assert that the observer now has the new stock's values.
            Assert.AreEqual(actualPanel.Stock.Symbol, newStock.Symbol);
            Assert.AreEqual(actualPanel.Stock.AskPrice, newStock.AskPrice);
            Assert.AreEqual(actualPanel.Stock.BidPrice, newStock.BidPrice);
            Assert.AreEqual(actualPanel.Stock.CurrentPrice, newStock.CurrentPrice);
            Assert.AreEqual(actualPanel.Stock.OpeningPrice, newStock.OpeningPrice);
        }

        [TestMethod]
        public void UpdateIncreasingPriceStockPriceControlTest()
        {
            StockPriceControl actualPanel;
            StockPriceControl.portfolioPanel = new PortfolioStockPricesDisplay();
            Stock stock = new Stock()
            {
                Symbol = "AMZN",
                AskPrice = 11,
                BidPrice = 1,
                CurrentPrice = 3,
                AverageVolume = 2,
                CurrentVolume = 2,
                OpeningPrice = 2,
                PreviousClosingPrice = 13
            };

            Stock newStock = new Stock()
            {
                Symbol = "AMZN",
                AskPrice = 11,
                BidPrice = 3,
                CurrentPrice = 5,
                AverageVolume = 2,
                CurrentVolume = 3,
                OpeningPrice = 2,
                PreviousClosingPrice = 13
            };

            // Update the observer with the new stock.
            panel = new StockPriceControl(stock);
            panel.update(newStock);
            Assert.IsNotNull(panel);
            actualPanel = panel as StockPriceControl;

            // Assert that the observer now has the new stock's values and UpFromBefore is true.
            Assert.AreEqual(actualPanel.Stock.Symbol, newStock.Symbol);
            Assert.AreEqual(actualPanel.Stock.AskPrice, newStock.AskPrice);
            Assert.AreEqual(actualPanel.Stock.BidPrice, newStock.BidPrice);
            Assert.AreEqual(actualPanel.Stock.CurrentPrice, newStock.CurrentPrice);
            Assert.AreEqual(actualPanel.Stock.OpeningPrice, newStock.OpeningPrice);
            Assert.IsTrue(actualPanel.UpFromBefore);
        }

        [TestMethod]
        public void AddRemoveControlFromPortfolioDisplayTest()
        {
            // Setup controls to be added and removed from the portfolio.
            PortfolioStockPricesDisplay pspd = new PortfolioStockPricesDisplay();
            StockPriceControl.portfolioPanel = new PortfolioStockPricesDisplay();
            StockPriceControl stock1 = new StockPriceControl(new Stock() { Symbol = "AMZN" });
            StockPriceControl stock2 = new StockPriceControl(new Stock() { Symbol = "NEA" });
            StockPriceControl stock3 = new StockPriceControl(new Stock() { Symbol = "FAAR" });

            // Add controls and Assert that they were added correctly.
            pspd.addStockPriceControl(stock1);
            pspd.addStockPriceControl(stock2);
            pspd.addStockPriceControl(stock3);
            Assert.AreEqual(pspd.Stocks.Count, 3);
            Assert.AreEqual(pspd.Stocks[0].Stock.Symbol, "AMZN");
            Assert.AreEqual(pspd.Stocks[1].Stock.Symbol, "NEA");
            Assert.AreEqual(pspd.Stocks[2].Stock.Symbol, "FAAR");

            // Remove controls and Assert that they were removed correctly.
            pspd.removeStockPriceControl(stock1);
            pspd.removeStockPriceControl(stock3);
            Assert.AreEqual(pspd.Stocks.Count, 1);
            Assert.AreEqual(pspd.Stocks[0].Stock.Symbol, "NEA");
        }
    }
}
