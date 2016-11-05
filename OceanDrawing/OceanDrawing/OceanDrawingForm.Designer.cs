namespace OceanDrawing
{
    partial class OceanDrawingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OceanDrawingForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOceanBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oceanBottomBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sunkenShipBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scaleLabel = new System.Windows.Forms.ToolStripLabel();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sharkButton = new System.Windows.Forms.ToolStripButton();
            this.dolphinButton = new System.Windows.Forms.ToolStripButton();
            this.troutButton = new System.Windows.Forms.ToolStripButton();
            this.whaleButton = new System.Windows.Forms.ToolStripButton();
            this.seahorseButton = new System.Windows.Forms.ToolStripButton();
            this.seaTurtleButton = new System.Windows.Forms.ToolStripButton();
            this.tree07Button = new System.Windows.Forms.ToolStripButton();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAllSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateAllSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(811, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOceanBackgroundToolStripMenuItem,
            this.oceanBottomBackgroundToolStripMenuItem,
            this.sunkenShipBackgroundToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openOceanBackgroundToolStripMenuItem
            // 
            this.openOceanBackgroundToolStripMenuItem.Name = "openOceanBackgroundToolStripMenuItem";
            this.openOceanBackgroundToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openOceanBackgroundToolStripMenuItem.Text = "Open Ocean Background";
            this.openOceanBackgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundSelection_Click);
            this.openOceanBackgroundToolStripMenuItem.MouseEnter += new System.EventHandler(this.backgroundSelection_MouseEnter);
            this.openOceanBackgroundToolStripMenuItem.MouseLeave += new System.EventHandler(this.backgroundSelection_MouseLeave);
            // 
            // oceanBottomBackgroundToolStripMenuItem
            // 
            this.oceanBottomBackgroundToolStripMenuItem.Name = "oceanBottomBackgroundToolStripMenuItem";
            this.oceanBottomBackgroundToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.oceanBottomBackgroundToolStripMenuItem.Text = "Ocean Bottom Background";
            this.oceanBottomBackgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundSelection_Click);
            this.oceanBottomBackgroundToolStripMenuItem.MouseEnter += new System.EventHandler(this.backgroundSelection_MouseEnter);
            this.oceanBottomBackgroundToolStripMenuItem.MouseLeave += new System.EventHandler(this.backgroundSelection_MouseLeave);
            // 
            // sunkenShipBackgroundToolStripMenuItem
            // 
            this.sunkenShipBackgroundToolStripMenuItem.Name = "sunkenShipBackgroundToolStripMenuItem";
            this.sunkenShipBackgroundToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.sunkenShipBackgroundToolStripMenuItem.Text = "Sunken Ship Background";
            this.sunkenShipBackgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundSelection_Click);
            this.sunkenShipBackgroundToolStripMenuItem.MouseEnter += new System.EventHandler(this.backgroundSelection_MouseEnter);
            this.sunkenShipBackgroundToolStripMenuItem.MouseLeave += new System.EventHandler(this.backgroundSelection_MouseLeave);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.OrangeRed;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.toolStripSeparator2,
            this.scaleLabel,
            this.scale,
            this.toolStripSeparator1,
            this.sharkButton,
            this.dolphinButton,
            this.troutButton,
            this.whaleButton,
            this.seahorseButton,
            this.seaTurtleButton,
            this.tree07Button});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 24);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(93, 635);
            this.drawingToolStrip.TabIndex = 4;
            this.drawingToolStrip.Text = "toolStrip2";
            // 
            // pointerButton
            // 
            this.pointerButton.AutoSize = false;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(61, 50);
            this.pointerButton.Text = "pointerButton";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(90, 6);
            // 
            // scaleLabel
            // 
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(90, 15);
            this.scaleLabel.Text = "Scale (.01 to 99):";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(70, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
            // 
            // sharkButton
            // 
            this.sharkButton.AutoSize = false;
            this.sharkButton.CheckOnClick = true;
            this.sharkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sharkButton.Image = ((System.Drawing.Image)(resources.GetObject("sharkButton.Image")));
            this.sharkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sharkButton.Name = "sharkButton";
            this.sharkButton.Size = new System.Drawing.Size(61, 61);
            this.sharkButton.Text = "Shark";
            this.sharkButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // dolphinButton
            // 
            this.dolphinButton.AutoSize = false;
            this.dolphinButton.CheckOnClick = true;
            this.dolphinButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dolphinButton.Image = ((System.Drawing.Image)(resources.GetObject("dolphinButton.Image")));
            this.dolphinButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dolphinButton.Name = "dolphinButton";
            this.dolphinButton.Size = new System.Drawing.Size(61, 61);
            this.dolphinButton.Text = "Dolphin";
            this.dolphinButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // troutButton
            // 
            this.troutButton.AutoSize = false;
            this.troutButton.CheckOnClick = true;
            this.troutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.troutButton.Image = ((System.Drawing.Image)(resources.GetObject("troutButton.Image")));
            this.troutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.troutButton.Name = "troutButton";
            this.troutButton.Size = new System.Drawing.Size(61, 61);
            this.troutButton.Text = "Trout";
            this.troutButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // whaleButton
            // 
            this.whaleButton.CheckOnClick = true;
            this.whaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.whaleButton.Image = ((System.Drawing.Image)(resources.GetObject("whaleButton.Image")));
            this.whaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.whaleButton.Name = "whaleButton";
            this.whaleButton.Size = new System.Drawing.Size(90, 68);
            this.whaleButton.Text = "Whale";
            this.whaleButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // seahorseButton
            // 
            this.seahorseButton.CheckOnClick = true;
            this.seahorseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seahorseButton.Image = ((System.Drawing.Image)(resources.GetObject("seahorseButton.Image")));
            this.seahorseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seahorseButton.Name = "seahorseButton";
            this.seahorseButton.Size = new System.Drawing.Size(90, 68);
            this.seahorseButton.Text = "Seahorse";
            this.seahorseButton.ToolTipText = "Seahorse";
            this.seahorseButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // seaTurtleButton
            // 
            this.seaTurtleButton.CheckOnClick = true;
            this.seaTurtleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seaTurtleButton.Image = ((System.Drawing.Image)(resources.GetObject("seaTurtleButton.Image")));
            this.seaTurtleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seaTurtleButton.Name = "seaTurtleButton";
            this.seaTurtleButton.Size = new System.Drawing.Size(90, 68);
            this.seaTurtleButton.Text = "Seaturtle";
            this.seaTurtleButton.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // tree07Button
            // 
            this.tree07Button.CheckOnClick = true;
            this.tree07Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tree07Button.Image = ((System.Drawing.Image)(resources.GetObject("tree07Button.Image")));
            this.tree07Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree07Button.Name = "tree07Button";
            this.tree07Button.Size = new System.Drawing.Size(90, 68);
            this.tree07Button.Text = "Catfish";
            this.tree07Button.Click += new System.EventHandler(this.creatureButton_Click);
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(96, 27);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(703, 620);
            this.drawingPanel.TabIndex = 5;
            this.drawingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseClick);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllSelectedToolStripMenuItem,
            this.duplicateAllSelectedToolStripMenuItem,
            this.deselectAllSelectedToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(189, 70);
            // 
            // removeAllSelectedToolStripMenuItem
            // 
            this.removeAllSelectedToolStripMenuItem.Name = "removeAllSelectedToolStripMenuItem";
            this.removeAllSelectedToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.removeAllSelectedToolStripMenuItem.Text = "Remove All Selected";
            this.removeAllSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeAllSelectedToolStripMenuItem_Click);
            // 
            // duplicateAllSelectedToolStripMenuItem
            // 
            this.duplicateAllSelectedToolStripMenuItem.Name = "duplicateAllSelectedToolStripMenuItem";
            this.duplicateAllSelectedToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.duplicateAllSelectedToolStripMenuItem.Text = "Duplicate All Selected";
            this.duplicateAllSelectedToolStripMenuItem.Click += new System.EventHandler(this.duplicateAllSelectedToolStripMenuItem_Click);
            // 
            // deselectAllSelectedToolStripMenuItem
            // 
            this.deselectAllSelectedToolStripMenuItem.Name = "deselectAllSelectedToolStripMenuItem";
            this.deselectAllSelectedToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deselectAllSelectedToolStripMenuItem.Text = "Deselect All Selected";
            this.deselectAllSelectedToolStripMenuItem.Click += new System.EventHandler(this.deselectAllSelectedToolStripMenuItem_Click);
            // 
            // OceanDrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 659);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "OceanDrawingForm";
            this.Text = "Ocean Drawing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OceanDrawingForm_FormClosing);
            this.Load += new System.EventHandler(this.OceanDrawingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OceanDrawingForm_KeyDown);
            this.Resize += new System.EventHandler(this.OceanDrawingForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel scaleLabel;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sharkButton;
        private System.Windows.Forms.ToolStripButton dolphinButton;
        private System.Windows.Forms.ToolStripButton troutButton;
        private System.Windows.Forms.ToolStripButton whaleButton;
        private System.Windows.Forms.ToolStripButton seahorseButton;
        private System.Windows.Forms.ToolStripButton seaTurtleButton;
        private System.Windows.Forms.ToolStripButton tree07Button;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripMenuItem openOceanBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oceanBottomBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sunkenShipBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeAllSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateAllSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllSelectedToolStripMenuItem;
    }
}

