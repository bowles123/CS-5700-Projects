namespace Homework1
{
    partial class AddPanelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.symbolLabel = new System.Windows.Forms.Label();
            this.panelConfigurationEnterButton = new System.Windows.Forms.Button();
            this.panelTypesListBox = new System.Windows.Forms.ListBox();
            this.symbolComboBox = new System.Windows.Forms.ComboBox();
            this.panelNumberListBox = new System.Windows.Forms.ListBox();
            this.panelNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(3, 39);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(75, 13);
            this.symbolLabel.TabIndex = 1;
            this.symbolLabel.Text = "Stock Symbol:";
            // 
            // panelConfigurationEnterButton
            // 
            this.panelConfigurationEnterButton.Location = new System.Drawing.Point(23, 210);
            this.panelConfigurationEnterButton.Name = "panelConfigurationEnterButton";
            this.panelConfigurationEnterButton.Size = new System.Drawing.Size(75, 23);
            this.panelConfigurationEnterButton.TabIndex = 4;
            this.panelConfigurationEnterButton.Text = "Enter";
            this.panelConfigurationEnterButton.UseVisualStyleBackColor = true;
            this.panelConfigurationEnterButton.Click += new System.EventHandler(this.panelConfigurationEnterButton_Click);
            // 
            // panelTypesListBox
            // 
            this.panelTypesListBox.FormattingEnabled = true;
            this.panelTypesListBox.Items.AddRange(new object[] {
            "Open Portfolio Prices Display",
            "Close Portfolio Prices Display",
            "Open Individual Price Graph",
            "Close Individual Price Graph",
            "Open Individual Volume Graph",
            "Close Individual Volume Graph"});
            this.panelTypesListBox.Location = new System.Drawing.Point(23, 86);
            this.panelTypesListBox.Name = "panelTypesListBox";
            this.panelTypesListBox.Size = new System.Drawing.Size(158, 95);
            this.panelTypesListBox.TabIndex = 5;
            this.panelTypesListBox.SelectedIndexChanged += new System.EventHandler(this.panelTypesListBox_SelectedIndexChanged);
            // 
            // symbolComboBox
            // 
            this.symbolComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.symbolComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.symbolComboBox.FormattingEnabled = true;
            this.symbolComboBox.Items.AddRange(new object[] {
            "AMZN",
            "GGL",
            "MS"});
            this.symbolComboBox.Location = new System.Drawing.Point(84, 39);
            this.symbolComboBox.Name = "symbolComboBox";
            this.symbolComboBox.Size = new System.Drawing.Size(121, 21);
            this.symbolComboBox.TabIndex = 6;
            // 
            // panelNumberListBox
            // 
            this.panelNumberListBox.FormattingEnabled = true;
            this.panelNumberListBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.panelNumberListBox.Location = new System.Drawing.Point(209, 99);
            this.panelNumberListBox.Name = "panelNumberListBox";
            this.panelNumberListBox.Size = new System.Drawing.Size(25, 82);
            this.panelNumberListBox.TabIndex = 7;
            this.panelNumberListBox.Visible = false;
            this.panelNumberListBox.SelectedIndexChanged += new System.EventHandler(this.panelNumberListBox_SelectedIndexChanged);
            // 
            // panelNumberLabel
            // 
            this.panelNumberLabel.AutoSize = true;
            this.panelNumberLabel.Location = new System.Drawing.Point(187, 83);
            this.panelNumberLabel.Name = "panelNumberLabel";
            this.panelNumberLabel.Size = new System.Drawing.Size(47, 13);
            this.panelNumberLabel.TabIndex = 8;
            this.panelNumberLabel.Text = "Panel #:";
            this.panelNumberLabel.Visible = false;
            // 
            // AddPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 261);
            this.Controls.Add(this.panelNumberLabel);
            this.Controls.Add(this.panelNumberListBox);
            this.Controls.Add(this.symbolComboBox);
            this.Controls.Add(this.panelTypesListBox);
            this.Controls.Add(this.panelConfigurationEnterButton);
            this.Controls.Add(this.symbolLabel);
            this.Name = "AddPanelForm";
            this.Text = "Add Panel Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Button panelConfigurationEnterButton;
        private System.Windows.Forms.ListBox panelTypesListBox;
        private System.Windows.Forms.ComboBox symbolComboBox;
        private System.Windows.Forms.ListBox panelNumberListBox;
        private System.Windows.Forms.Label panelNumberLabel;
    }
}