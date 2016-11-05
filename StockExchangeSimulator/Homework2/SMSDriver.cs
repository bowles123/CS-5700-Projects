using System;
using System.Windows.Forms;
using log4net.Config;

namespace Homework1
{
    static class SMSDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SMS());
        }
    }
}
