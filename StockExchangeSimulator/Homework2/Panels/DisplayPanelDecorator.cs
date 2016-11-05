using Stocks;
using log4net;
using System.Windows.Forms;
using System;

namespace Panels
{
    public abstract class DisplayPanelDecorator : DisplayPanel
    {
        protected static readonly ILog logger = LogManager.GetLogger(typeof(DisplayPanelDecorator));
        protected bool needsRepaint;
        protected readonly Timer refreshTimer = new Timer();
        protected readonly object myLock = new object();

        public bool NeedsRepaint { get { return needsRepaint; } }
        public DisplayPanel Panel { get; }
        public int RefreshFrequency { get; set; }
        public abstract void update(Subject stock);
        public abstract void updateGui();

        public void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0)
                RefreshFrequency = 50;

            refreshTimer.Interval = RefreshFrequency;
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (NeedsRepaint)
            {
                lock (myLock)
                {
                    updateGui();
                    needsRepaint = false;
                }
            }
        }

        public DisplayPanelDecorator(DisplayPanel panel)
        {
            Panel = panel;
            RefreshFrequency = 3000;
        }
    }
}
