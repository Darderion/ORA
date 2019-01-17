using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class MenuMap
    {
        public MenuMap(Control ctrl)
        {
            pic = new PictureBox();
            pic.Parent = ctrl;

            pic.Left = 20;
            pic.Top = 20;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Width = 100;
            pic.Height = 100;

            label = new Label();
            label.Parent = ctrl;
        }

        public PictureBox pic;
        public Label label;
    }
}
