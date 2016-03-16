using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetHttpsForFreeUI.Properties;

namespace GetHttpsForFreeUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Attempt to upgrade the settings file if one is found
            try
            {
                Settings.Default.Upgrade();
            }
            catch
            {
                // Don't care if we can't upgrade, just continue with an empty settings file in that case

            }

            Application.Run(new MainForm());
        }

        
    }
}
