using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProcessMash.UI;

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

            Application.Run(new SettingsForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) 
            => LogException((Exception)e.ExceptionObject);

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) 
            => LogException(e.Exception);

        private static void LogException(Exception exception)
        {
            var exceptionString = $"[{DateTime.Now}] {exception.ToString().Replace("\r\n", null)}\r\n";

            File.AppendAllText(Path.Combine(Application.StartupPath, "error.log"), exceptionString);
        }
    }
}
