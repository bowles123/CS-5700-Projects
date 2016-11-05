using AppLayer.CommandPattern.Commands;
using System.Collections.Generic;

namespace OceanDrawing
{
    partial class HistoryForm
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
        private void InitializeComponent(Stack<Command> history)
        {
            this.historyListView = new System.Windows.Forms.ListView();
            addHistoryToView(history);
            this.SuspendLayout();
            // 
            // historyListView
            // 
            this.historyListView.Location = new System.Drawing.Point(12, 12);
            this.historyListView.Name = "historyListView";
            this.historyListView.Size = new System.Drawing.Size(260, 237);
            this.historyListView.TabIndex = 0;
            this.historyListView.UseCompatibleStateImageBehavior = false;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.historyListView);
            this.Name = "HistoryForm";
            this.Text = "History";
            this.ResumeLayout(false);
        }

        #endregion

        private void addHistoryToView(Stack<Command> history)
        {
            Command[] historyArray = history.ToArray();

            for (int i = historyArray.Length - 1; i >= 0; i--)
                historyListView.Items.Add(string.Format("{0}. {1}\n", historyArray.Length - i,
                    historyArray[i].ActualCommand));
        }

        private System.Windows.Forms.ListView historyListView;
    }
}