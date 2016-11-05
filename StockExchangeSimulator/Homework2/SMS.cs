using System;
using System.Collections.Generic;
using Stocks;
using System.Windows.Forms;
using System.IO;
using Networking;
using Panels;
using System.Net;
using Microsoft.VisualBasic;

namespace Homework1
{
    public partial class SMS : Form
    {
        private List<string> companies;
        private Communicator communicator;

        public SMS()
        {
            InitializeComponent();
            readInCompanies();
            communicator = new Communicator();
            communicator.Portfolio = new StockPortfolio();
            communicator.RemoteEndPoint = new IPEndPoint(IPAddress.Parse("54.69.169.164"), 12099);
            communicator.Start();
            StockPriceControl.portfolioPanel = portfolioDisplay;
            StockPriceControl.communicator = communicator;
        }

        private void readInCompanies()
        {
            StreamReader reader = new StreamReader(File.OpenRead(@"CompanyList.csv"));
            companies = new List<string>();

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                companies.Add(values[0]);
            }
        }

        private void removePanel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;

            for (int i = 1; i < Panel2.Controls.Count; i++)
                Panel2.Controls.Remove(Panel2.Controls[i]);
        }

        private void remoePanel3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;

            for (int i = 1; i < Panel3.Controls.Count; i++)
                Panel3.Controls.Remove(Panel3.Controls[i]);
        }

        private void removePanel4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;

            for (int i = 1; i < Panel4.Controls.Count; i++)
                Panel4.Controls.Remove(Panel4.Controls[i]);
        }

        private void removePanel5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;

            for (int i = 1; i < Panel5.Controls.Count; i++)
                Panel5.Controls.Remove(Panel5.Controls[i]);
        }
        
        private void removePanel6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel6.Visible = false;

            for (int i = 1; i < Panel6.Controls.Count; i++)
                Panel6.Controls.Remove(Panel6.Controls[i]);
        }

        private void addPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddPanelForm(companies, communicator.Portfolio).ShowDialog();
            UserControl control;

            if (AddPanelForm._panel != null)
            {
                control = AddPanelForm._panel.Panel as UserControl;

                switch (AddPanelForm._panelNumber)
                {
                    case 1:
                        StockPriceControl panel = AddPanelForm._panel.Panel as StockPriceControl;

                        if (!portfolioDisplay.Stocks.Contains(panel))
                            portfolioDisplay.addStockPriceControl(panel);
                        break;
                    case 2:
                        control.SetBounds(panel2Label.Location.X, panel2Label.Location.Y + 20,
                            control.Width, control.Height);
                        Panel2.Controls.Add(control);
                        Panel2.Visible = true;
                        break;
                    case 3:
                        control.SetBounds(panel3Label.Location.X, panel3Label.Location.Y + 20,
                            control.Width, control.Height);
                        Panel3.Controls.Add(control);
                        Panel3.Visible = true;
                        break;
                    case 4:
                        control.SetBounds(panel4Label.Location.X, panel4Label.Location.Y + 20,
                            control.Width, control.Height);
                        Panel4.Controls.Add(control);
                        Panel4.Visible = true;
                        break;
                    case 5:
                        control.SetBounds(panel5Label.Location.X, panel5Label.Location.Y + 20,
                            control.Width, control.Height);
                        Panel5.Controls.Add(control);
                        Panel5.Visible = true;
                        break;
                    case 6:
                        control.SetBounds(panel6Label.Location.X, panel6Label.Location.Y + 20,
                            control.Width, control.Height);
                        Panel6.Controls.Add(control);
                        Panel6.Visible = true;
                        break;
                }

                AddPanelForm._panel.StartRefreshTimer();
                communicator.Stop();
                communicator.Start();
            }
        }

        private void SMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            communicator.Stop();
        }

        private void savePortfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = Interaction.InputBox("Enter the name of the file", "Save Portfolio",
                "",-1, -1);
            communicator.Portfolio.Save(file);
        }

        private void loadPorfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = Interaction.InputBox("Enter the name of the file", "Load Portfolio",
                "", -1, -1);

            if (File.Exists(file))
            {
                communicator.Portfolio.Load(file);
                
                foreach (string stock in communicator.Portfolio.Keys)
                {
                    StockPriceControl control = new StockPriceControl(
                        new Stock() { Symbol = stock });
                    OpeningPriceDisplayPanelDecorator decorator = new
                        OpeningPriceDisplayPanelDecorator(control);
                    portfolioDisplay.addStockPriceControl(control);
                    decorator.updateGui();
                    decorator.StartRefreshTimer();
                }
            }
            else
            {
                MessageBox.Show("File does not exist, try a different file.");
            }
        }
    }
}
