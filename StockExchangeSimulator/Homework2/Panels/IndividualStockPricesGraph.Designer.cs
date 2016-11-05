namespace Panels
{
    partial class IndividualStockPricesGraph
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
            this.graphTitleLabel = new System.Windows.Forms.Label();
            this.priceDisplayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // graphTitleLabel
            // 
            this.graphTitleLabel.AutoSize = true;
            this.graphTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.graphTitleLabel.Name = "graphTitleLabel";
            this.graphTitleLabel.Size = new System.Drawing.Size(35, 13);
            this.graphTitleLabel.TabIndex = 0;
            this.graphTitleLabel.Text = "label1";
            // 
            // priceDisplayLabel
            // 
            this.priceDisplayLabel.AutoSize = true;
            this.priceDisplayLabel.Location = new System.Drawing.Point(15, 13);
            this.priceDisplayLabel.Name = "priceDisplayLabel";
            this.priceDisplayLabel.Size = new System.Drawing.Size(35, 13);
            this.priceDisplayLabel.TabIndex = 3;
            this.priceDisplayLabel.Text = "label1";
            // 
            // IndividualStockPricesGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.priceDisplayLabel);
            this.Controls.Add(this.graphTitleLabel);
            this.Name = "IndividualStockPricesGraph";
            this.Size = new System.Drawing.Size(307, 316);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label graphTitleLabel;
        private System.Windows.Forms.Label priceDisplayLabel;
    }
}
