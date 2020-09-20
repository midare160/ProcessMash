using System;
using System.Windows.Forms;

namespace ProcessMash.Extensions
{
    public static class StringExtensions
    {
        public static Keys ToKey(this string keyString)
        {
            try
            {
                return (Keys)Enum.Parse(typeof(Keys), keyString);
            }
            catch (ArgumentException)
            {
                return Keys.None;
            }
        }
    }
}
