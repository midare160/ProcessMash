using NLog;
using ProcessMash.UI;
using System;
using System.Windows.Forms;

namespace ProcessMash
{
    internal static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // TODO enable event handlers
            Application.ThreadException += (s, e) => Logger.Error(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Logger.Error((Exception)e.ExceptionObject);

            Application.Run(new SettingsForm());
        }
    }
}
