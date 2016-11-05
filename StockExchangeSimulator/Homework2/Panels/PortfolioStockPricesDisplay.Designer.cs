namespace Panels
{
    partial class PortfolioStockPricesDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stockSymbolLabel = new System.Windows.Forms.Label();
            this.askPriceLabel = new System.Windows.Forms.Label();
            this.bidPriceLabel = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.openingPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stockSymbolLabel
            // 
            this.stockSymbolLabel.AutoSize = true;
            this.stockSymbolLabel.Location = new System.Drawing.Point(3, 0);
            this.stockSymbolLabel.Name = "stockSymbolLabel";
            this.stockSymbolLabel.Size = new System.Drawing.Size(35, 13);
            this.stockSymbolLabel.TabIndex = 0;
            this.stockSymbolLabel.Text = "Stock";
            // 
            // askPriceLabel
            // 
            this.askPriceLabel.AutoSize = true;
            this.askPriceLabel.Location = new System.Drawing.Point(299, 0);
            this.askPriceLabel.Name = "askPriceLabel";
            this.askPriceLabel.Size = new System.Drawing.Size(25, 13);
            this.askPriceLabel.TabIndex = 2;
            this.askPriceLabel.Text = "Ask";
            // 
            // bidPriceLabel
            // 
            this.bidPriceLabel.AutoSize = true;
            this.bidPriceLabel.Location = new System.Drawing.Point(257, 0);
            this.bidPriceLabel.Name = "bidPriceLabel";
            this.bidPriceLabel.Size = new System.Drawing.Size(22, 13);
            this.bidPriceLabel.TabIndex = 3;
            this.bidPriceLabel.Text = "Bid";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(188, 0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(49, 13);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "Direction";
            // 
            // currentPriceLabel
            // 
            this.currentPriceLabel.AutoSize = true;
            this.currentPriceLabel.Location = new System.Drawing.Point(128, 0);
            this.currentPriceLabel.Name = "currentPriceLabel";
            this.currentPriceLabel.Size = new System.Drawing.Size(41, 13);
            this.currentPriceLabel.TabIndex = 5;
            this.currentPriceLabel.Text = "Current";
            // 
            // openingPriceLabel
            // 
            this.openingPriceLabel.AutoSize = true;
            this.openingPriceLabel.Location = new System.Drawing.Point(58, 0);
            this.openingPriceLabel.Name = "openingPriceLabel";
            this.openingPriceLabel.Size = new System.Drawing.Size(54, 13);
            this.openingPriceLabel.TabIndex = 6;
            this.openingPriceLabel.Text = "O/C Price";
            // 
            // PortfolioStockPricesDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openingPriceLabel);
            this.Controls.Add(this.currentPriceLabel);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.bidPriceLabel);
            this.Controls.Add(this.askPriceLabel);
            this.Controls.Add(this.stockSymbolLabel);
            this.Name = "PortfolioStockPricesDisplay";
            this.Size = new System.Drawing.Size(342, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stockSymbolLabel;
        private System.Windows.Forms.Label askPriceLabel;
        private System.Windows.Forms.Label bidPriceLabel;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.Label currentPriceLabel;
        private System.Windows.Forms.Label openingPriceLabel;
    }
}
