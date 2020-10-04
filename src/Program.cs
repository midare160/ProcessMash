using NLog;
using NLog.Config;
using NLog.Targets;
using ProcessMash.UI;
using System;
using System.Text;
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
            SetNLog();

            Application.ThreadException += (s, e) => Logger.Error(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Logger.Error((Exception)e.ExceptionObject);

            Application.Run(new SettingsForm());
        }

        private static void SetNLog()
        {
            var configuration = new LoggingConfiguration();

            var logfile = new FileTarget("*")
            {
                Layout = "${longdate} ${logger} ${message}${exception:format=ToString}",
                FileName = "${specialfolder:folder=LocalApplicationData}/ProcessMash/logs/error.log",
                KeepFileOpen = true,
                Encoding = Encoding.UTF8
            };

            var logconsole = new ConsoleTarget("logconsole");

            configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);
            configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);

            LogManager.Configuration = configuration;

        }
    }
}
