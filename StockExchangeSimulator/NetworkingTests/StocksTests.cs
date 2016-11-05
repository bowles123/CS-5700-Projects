using Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stocks;
using Panels;

namespace NetworkingTests
{
    [TestClass]
    public class StocksTests
    {
        private StockPortfolio portfolio;
        private TickerMessage tMssg;
        private int countBeforeUpdate;
        private Stock stock;
        private DisplayPanel panel1, panel2, panel3;

        private void setup()
        {
            portfolio = new StockPortfolio()
            { { "AMZN", new Stock{ Symbol = "AMZN", AskPrice = 5, AverageVolume = 3, BidPrice = 2, CurrentPrice = 2 } } };
            countBeforeUpdate = portfolio.Count;
        }

        private void subjectSetup(bool shouldAddObservers)
        {
            StockPriceControl.portfolioPanel = new PortfolioStockPricesDisplay();
            stock = new Stock() { Symbol = "AMZN" };
            panel1 = new StockPriceControl(stock);
            panel2 = new IndividualStockPricesGraph(stock);
            panel3 = new IndividualStockVolumesGraph(stock);

            if (shouldAddObservers)
            {
                stock.Subscribe(panel1);
                stock.Subscribe(panel2);
                stock.Subscribe(panel3);
            }
        }

        [TestMethod]
        public void StockPortfolioUpdateExistingStockTest()
        {
            setup();
            tMssg = new TickerMessage()
            { Symbol = "AMZN", AskPrice = 5, AverageVolume = 3, BidPrice = 2, CurrentPrice = 2 };
            portfolio.Update(tMssg);

            // Ensure that the correct stock in the portfolio was updated correctly.
            Assert.AreEqual(portfolio.Count, countBeforeUpdate);
            Assert.IsTrue(portfolio.ContainsKey("AMZN"));
            stock = portfolio["AMZN"];
            Assert.IsNotNull(stock);
            Assert.AreEqual(stock.Symbol, tMssg.Symbol);
            Assert.AreEqual(stock.AskPrice, tMssg.AskPrice);
            Assert.AreEqual(stock.AverageVolume, tMssg.AverageVolume);
            Assert.AreEqual(stock.BidPrice, tMssg.BidPrice);
            Assert.AreEqual(stock.CurrentPrice, tMssg.CurrentPrice);
        }

        [TestMethod]
        public void StockPortfolioUpdateNonExistingStockTest()
        {
            setup();
            tMssg = new TickerMessage()
            { Symbol = "GNB", AskPrice = 5, AverageVolume = 3, BidPrice = 2, CurrentPrice = 2 };
            portfolio.Update(tMssg);

            // Ensure that no change occured in the portfolio.
            Assert.AreEqual(portfolio.Count, countBeforeUpdate);
            Assert.IsFalse(portfolio.ContainsKey("GNB"));
        }

        [TestMethod]
        public void LoadSaveStockPortfolioTest()
        {
            // Setup portfolios, to be saved and to be loaded.
            StockPortfolio portfolio = new StockPortfolio();
            StockPortfolio portfolioAfterSave = new StockPortfolio();
            portfolio.Add("AMZN", new Stock() { Symbol = "AMZN" });
            portfolio.Add("NEA", new Stock() { Symbol = "NEA" });
            portfolio.Add("FAAR", new Stock() { Symbol = "FAAR" });

            // Save portfolio, then load it into a new portfolio.
            portfolio.Save("testSave.txt");
            portfolioAfterSave.Load("testSave.txt");

            // Assert that the two portfolios contain the same values.
            Assert.AreEqual(3, portfolioAfterSave.Count);
            Assert.AreEqual("AMZN", portfolioAfterSave["AMZN"].Symbol);
            Assert.AreEqual("NEA", portfolioAfterSave["NEA"].Symbol);
            Assert.AreEqual("FAAR", portfolioAfterSave["FAAR"].Symbol);
        }

        [TestMethod]
        public void SubscribeUnsubscribeTest()
        {
            // Subscribe and assert that the correct information is in the Observers list.
            subjectSetup(false);
            stock.Subscribe(panel1);
            Assert.AreEqual(stock.Observers.Count, 1);
            stock.Subscribe(panel2);
            Assert.AreEqual(stock.Observers.Count, 2);
            stock.Subscribe(panel3);
            Assert.AreEqual(stock.Observers.Count, 3);

            foreach (Observer observer in stock.Observers)
            {
                Assert.IsNotNull(observer);
                Assert.IsInstanceOfType(observer, typeof(DisplayPanel));
            }

            Assert.IsInstanceOfType(stock.Observers[0], typeof(StockPriceControl));
            Assert.IsInstanceOfType(stock.Observers[1], typeof(IndividualStockPricesGraph));
            Assert.IsInstanceOfType(stock.Observers[2], typeof(IndividualStockVolumesGraph));

            // Unsubscribe and assert that all the observers were removed from the Observers list.
            stock.Unsubscribe(panel1);
            Assert.AreEqual(stock.Observers.Count, 2);
            stock.Unsubscribe(panel2);
            Assert.AreEqual(stock.Observers.Count, 1);
            stock.Unsubscribe(panel3);
            Assert.AreEqual(stock.Observers.Count, 0);
        }

        [TestMethod]
        public void NotifyObserversTest()
        {
            // Setup and update stock.
            subjectSetup(true);
            stock.Update(new TickerMessage()
            {
                AskPrice = 3,
                AverageVolume = 4,
                BidPrice = 2,
                CurrentPrice = 5,
                Symbol = "AMZN",
                CurrentVolume = 4,
                OpeningPrice = 3,
                PreviousClosingPrice = 12,
                MessageTimestamp = new System.DateTime()
            });

            // Ensure that the stock was setup correctly, has the correct number of observers.
            Assert.IsNotNull(stock.Observers);
            Assert.IsTrue(stock.Observers.Count == 3);
            Assert.IsInstanceOfType(stock.Observers[0], typeof(StockPriceControl));
            StockPriceControl spc = stock.Observers[0] as StockPriceControl;
            Assert.IsInstanceOfType(stock.Observers[1], typeof(IndividualStockPricesGraph));
            IndividualStockPricesGraph ispg = stock.Observers[1] as IndividualStockPricesGraph;
            Assert.IsInstanceOfType(stock.Observers[2], typeof(IndividualStockVolumesGraph));
            IndividualStockVolumesGraph isvg = stock.Observers[2] as IndividualStockVolumesGraph;

            // Assert that the StockPriceControl observer was updated correctly.
            Assert.AreEqual(spc.Stock.AskPrice, stock.AskPrice);
            Assert.AreEqual(spc.Stock.BidPrice, stock.BidPrice);
            Assert.AreEqual(spc.Stock.CurrentPrice, stock.CurrentPrice);
            Assert.AreEqual(spc.Stock.OpeningPrice, stock.OpeningPrice);
            Assert.AreEqual(spc.Stock.Symbol, stock.Symbol);

            // Assert that the other two observers were updated correctly.
            Assert.IsNotNull(ispg.getStockPrices());
            Assert.IsTrue(ispg.getStockPrices().Count == 1);
            Assert.AreEqual(ispg.getStockPrices()[0], stock.CurrentPrice);
            Assert.IsNotNull(isvg.getStockVolumes());
            Assert.IsTrue(isvg.getStockVolumes().Count == 1);
            Assert.AreEqual(isvg.getStockVolumes()[0], stock.CurrentVolume);
        }
    }
}
