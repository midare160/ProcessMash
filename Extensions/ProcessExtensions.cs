using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Timers;

namespace ProcessMash.Extensions
{
    public static class ProcessExtensions
    {
        public static void Destroy(this Process process, decimal secondsUntilKilled)
        {
            try
            {
                var secondsPassed = 0;

                var timer = new Timer(1000) { AutoReset = true, Enabled = true };
                timer.Elapsed += (s, e) => secondsPassed++;

                process.CloseMainWindow();

                while (!process.HasExited)
                {
                    if (secondsPassed >= secondsUntilKilled)
                    {
                        process.Kill();
                        break;
                    }
                }
            }
            catch (Win32Exception)
            {
                SystemSounds.Asterisk.Play();
            }
        }
    }
}
