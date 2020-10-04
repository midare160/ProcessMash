using System.Drawing;
using System.Windows.Forms;

namespace ProcessMash.ContextMenu
{
    public class ContextMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuItemBorder => Color.WhiteSmoke;

        public override Color MenuItemSelected => Color.LightSkyBlue;

        public override Color ImageMarginGradientBegin => Color.White;

        public override Color ImageMarginGradientMiddle => Color.White;

        public override Color ImageMarginGradientEnd => Color.White;
    }
}
