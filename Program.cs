using ProcessMash.UI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProcessMash.Tools;

namespace ProcessMash
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //Application.ThreadException += Application_ThreadException;
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // TODO enable event handlers

            Application.Run(new SettingsForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) 
            => Logger.LogException((Exception)e.ExceptionObject);

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) 
            => Logger.LogException(e.Exception);
    }
}
