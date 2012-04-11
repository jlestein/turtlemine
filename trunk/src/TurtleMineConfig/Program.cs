using System;
using System.Windows.Forms;
using TurtleMine.Settings;

namespace TurtleMine
{
    static class Program
    {
        /// <summary>
        /// Gets or sets the args.
        /// </summary>
        /// <value>The args.</value>
        internal static string[] Args { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Make Args visible to rest of the application
            Args = args;

            //Load settings file if exists
            SettingsManager.LoadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Configuration());
        }
    }
}
