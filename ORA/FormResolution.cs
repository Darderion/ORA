using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    public partial class FormResolution : Form
    {
        public int resWidth = Screen.PrimaryScreen.Bounds.Width;
        public int resHeight = Screen.PrimaryScreen.Bounds.Height;

        int maxWidth = Screen.PrimaryScreen.Bounds.Width;
        int maxHeight = Screen.PrimaryScreen.Bounds.Height;

        public FormResolution()
        {
            InitializeComponent();
        }

        private void FormResolution_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            Region region = new Region(path);
            this.Region = region;
            this.CenterToScreen();

            buttonSave.Left = Width / 2 - (buttonSave.Width / 2);
            buttonSave.Top = Height - 50;

            textBoxWidth.Top = buttonSave.Top - 50;
            textBoxHeight.Top = textBoxWidth.Top;
            textBoxWidth.Left = buttonSave.Left - 50;
            textBoxHeight.Left = textBoxWidth.Left + textBoxWidth.Width + label1.Width + 10;

            label1.Left = textBoxWidth.Left + textBoxWidth.Width + 5;
            label1.Top = textBoxWidth.Top + 5;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Green;

            textBoxWidth.Text = resWidth.ToString();
            textBoxHeight.Text = resHeight.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Green)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            int cur_width = 0;
            int cur_height = 0;
            if ((Int32.TryParse(textBoxWidth.Text, out cur_width) == true)
                && (cur_width >= CL.MinimalWidth)
                && (cur_width <= maxWidth)
                && (Int32.TryParse(textBoxHeight.Text, out cur_height) == true)
                && (cur_height >= CL.MinimalHeight)
                && (cur_height <= maxHeight))
            {
                label1.ForeColor = Color.Green;
                resWidth = cur_width;
                resHeight = cur_height;
                return;
            }
            label1.ForeColor = Color.Red;
        }
    }
}
