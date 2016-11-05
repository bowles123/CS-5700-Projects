namespace Panels
{
    partial class StockPriceControl
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
            this.symbolLabel = new System.Windows.Forms.Label();
            this.askPriceLabel = new System.Windows.Forms.Label();
            this.bidPriceLabel = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.openingPriceLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(3, 0);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(35, 13);
            this.symbolLabel.TabIndex = 0;
            this.symbolLabel.Text = "label1";
            // 
            // askPriceLabel
            // 
            this.askPriceLabel.AutoSize = true;
            this.askPriceLabel.Location = new System.Drawing.Point(298, 0);
            this.askPriceLabel.Name = "askPriceLabel";
            this.askPriceLabel.Size = new System.Drawing.Size(13, 13);
            this.askPriceLabel.TabIndex = 2;
            this.askPriceLabel.Text = "3";
            // 
            // bidPriceLabel
            // 
            this.bidPriceLabel.AutoSize = true;
            this.bidPriceLabel.Location = new System.Drawing.Point(254, 0);
            this.bidPriceLabel.Name = "bidPriceLabel";
            this.bidPriceLabel.Size = new System.Drawing.Size(13, 13);
            this.bidPriceLabel.TabIndex = 3;
            this.bidPriceLabel.Text = "4";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(199, 0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(13, 13);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "5";
            // 
            // currentPriceLabel
            // 
            this.currentPriceLabel.AutoSize = true;
            this.currentPriceLabel.Location = new System.Drawing.Point(130, 0);
            this.currentPriceLabel.Name = "currentPriceLabel";
            this.currentPriceLabel.Size = new System.Drawing.Size(13, 13);
            this.currentPriceLabel.TabIndex = 5;
            this.currentPriceLabel.Text = "6";
            // 
            // openingPriceLabel
            // 
            this.openingPriceLabel.AutoSize = true;
            this.openingPriceLabel.Location = new System.Drawing.Point(67, 0);
            this.openingPriceLabel.Name = "openingPriceLabel";
            this.openingPriceLabel.Size = new System.Drawing.Size(13, 13);
            this.openingPriceLabel.TabIndex = 6;
            this.openingPriceLabel.Text = "2";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(346, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(16, 13);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // StockPriceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openingPriceLabel);
            this.Controls.Add(this.currentPriceLabel);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.bidPriceLabel);
            this.Controls.Add(this.askPriceLabel);
            this.Controls.Add(this.symbolLabel);
            this.Name = "StockPriceControl";
            this.Size = new System.Drawing.Size(365, 15);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Label askPriceLabel;
        private System.Windows.Forms.Label bidPriceLabel;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.Label currentPriceLabel;
        private System.Windows.Forms.Label openingPriceLabel;
        private System.Windows.Forms.Button closeButton;
    }
}
