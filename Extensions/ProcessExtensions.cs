using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace ProcessMash.Extensions
{
    public static class ProcessExtensions
    {
        public static void Destroy(this Process process)
        {
            try
            {
                process.Kill();
            }
            catch (Win32Exception)
            {
                SystemSounds.Asterisk.Play();
            }
        }
    }
}
