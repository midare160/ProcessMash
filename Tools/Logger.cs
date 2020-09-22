using System;
using System.IO;
using System.Windows.Forms;

namespace ProcessMash.Tools
{
    public class Logger
    {
        public static void LogException(Exception exception)
        {
            var exceptionString = $"[{DateTime.Now}] {exception.ToString().Replace("\r\n", null)}\r\n";

            File.AppendAllText(Path.Combine(Application.StartupPath, "error.log"), exceptionString);
        }
    }
}
