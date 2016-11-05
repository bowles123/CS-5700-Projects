using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Panels;
using Stocks;

namespace Homework1
{
    public partial class AddPanelForm : Form
    {
        public static DisplayPanelDecorator _panel;
        public static int _panelNumber;
        private List<string> _companies;
        private StockPortfolio _portfolio;
        private Stock stock;

        public AddPanelForm(List<string> companies, StockPortfolio portfolio)
        {
            InitializeComponent();
            _companies = companies;
            _portfolio = portfolio;

            foreach (string company in _companies)
            {
                symbolComboBox.Items.Add(company);
            }
        }

        private void panelConfigurationEnterButton_Click(object sender, EventArgs e)
        {
            if (_companies != null && _companies.Contains(symbolComboBox.Text))
            {
                if (!_portfolio.ContainsKey(symbolComboBox.Text))
                {
                    stock = new Stock() { Symbol = symbolComboBox.Text };
                    _portfolio.Add(symbolComboBox.Text, stock);
                }
                else
                    stock = _portfolio[symbolComboBox.Text];

                switch ((string) panelTypesListBox.SelectedItem)
                {
                    case "Open Portfolio Prices Display":
                        _panel = new OpeningPriceDisplayPanelDecorator(
                            new StockPriceControl(stock));
                        break;
                    case "Close Portfolio Prices Display":
                        _panel = new PreviousClosePriceDisplayPanelDecorator(
                            new StockPriceControl(stock));
                        break;
                    case "Open Individual Price Graph":
                        _panel = new OpeningPriceDisplayPanelDecorator(
                            new IndividualStockPricesGraph(stock));
                        break;
                    case "Close Individual Price Graph":
                        _panel = new PreviousClosePriceDisplayPanelDecorator(
                            new IndividualStockPricesGraph(stock));
                        break;
                    case "Open Individual Volume Graph":
                        _panel = new OpeningPriceDisplayPanelDecorator(
                            new IndividualStockVolumesGraph(stock));
                        break;
                    case "Close Individual Volume Graph":
                        _panel = new PreviousClosePriceDisplayPanelDecorator(
                            new IndividualStockVolumesGraph(stock));
                        break;
                    default:
                        MessageBox.Show("Invalid selection, try to select another panel type.");
                        break;
                }

                _panel.updateGui();
                stock.Subscribe(_panel);
            }
            else
            {
                MessageBox.Show("That stock is not in the list of companies," +
                    "try another stock.");
            }
            Close();
        }

        private void panelTypesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panelTypesListBox.SelectedIndex != 0 && panelTypesListBox.SelectedIndex != 1)
            {
                panelNumberLabel.Visible = true;
                panelNumberListBox.Visible = true;
            }
            else
                _panelNumber = 1;
        }

        private void panelNumberListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _panelNumber = panelNumberListBox.SelectedIndex + 2;
        }
    }
}
