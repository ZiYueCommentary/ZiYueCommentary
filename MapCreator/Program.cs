using MapCreator.Properties;
using System;
using System.Windows.Forms;

namespace MapCreator
{
    public static class Program
    {
        public static readonly Window instance;

        static Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            instance = new Window();
            Settings.SettingsLoaded();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(instance);
        }
    }
}
