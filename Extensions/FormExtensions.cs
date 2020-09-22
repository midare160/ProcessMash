using System.Windows.Forms;

namespace ProcessMash.Extensions
{
    public static class FormExtensions
    {
        public static void Hide(this Form form, bool showInTaskBar)
        {
            form.Hide();
            form.ShowInTaskbar = showInTaskBar;
        }

        public static void Show(this Form form, bool showInTaskBar)
        {
            form.Show();
            form.WindowState = FormWindowState.Normal;
            form.ShowInTaskbar = showInTaskBar;
        }
    }
}
