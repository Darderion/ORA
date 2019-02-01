using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class Letter
    {
        public Letter()
        {
            label = new Label();

            timerAnimation = new Timer();
            timerAnimation.Interval = 20;
            timerAnimation.Enabled = false;
            timerAnimation.Tick += timerAnimation_tick;

            label.Size = defaultSize;
        }

        public char value;
        private Label label;
        private int progress;
        private Timer timerAnimation;

        private static Color ColourActivated;
        private static Color ColourDeactivated;
        private static Font defaultFont;
        private static int maxProgressRange;
        private static int halfProgressRange;
        private static Size defaultSize;

        public static int halfRange
        {
            get
            {
                return halfProgressRange;
            }
        }

        public bool Visible
        {
            get
            {
                return label.Visible;
            }
            set
            {
                label.Visible = value;
            }
        }
        public Control Parent
        {
            get
            {
                return label.Parent;
            }
            set
            {
                label.Parent = value;
            }
        }

        public int X
        {
            get
            {
                return label.Left;
            }
            set
            {
                label.Left = value;
            }
        }
        public int Y
        {
            get
            {
                return label.Top;
            }
            set
            {
                label.Top = value;
            }
        }
        public int Width
        {
            get
            {
                return label.Width;
            }
            set
            {
                label.Width = value;
            }
        }
        public int Height
        {
            get
            {
                return label.Height;
            }
            set
            {
                label.Height = value;
            }
        }

        public static void Init(Color inp_ColourActivated, Color inp_ColourDeactivated, Font inp_defaultFont, int inp_maxProgressRange)
        {
            ColourActivated = inp_ColourActivated;
            ColourDeactivated = inp_ColourDeactivated;
            defaultFont = inp_defaultFont;
            maxProgressRange = inp_maxProgressRange;
            halfProgressRange = maxProgressRange / 2;
            Size curSize;
            int maxWidth = 0;
            int maxHeight = 0;
            for(int i = 'A'; i <= 'Z'; i++)
            {
                curSize = TextRenderer.MeasureText(Char.ConvertFromUtf32(i), defaultFont);
                maxWidth = Math.Max(maxWidth, curSize.Width);
                maxHeight = Math.Max(maxHeight, curSize.Height);
            }
            defaultSize = new Size(maxWidth, maxHeight);
        }

        public void Reset()
        {
            progress = 0;
            timerAnimation.Enabled = false;
            label.Font = defaultFont;
            label.ForeColor = ColourDeactivated;
        }

        public void SetValue(char inp, bool IgnoreUpperCase)
        {
            Reset();
            label.Text = inp.ToString();
            if (IgnoreUpperCase == true)
                value = char.ToLower(inp);
            else
                value = inp;
            UpdateSize();
        }

        public void SetPosition(int x_inp, int y_inp)
        {
            label.Left = x_inp;
            label.Top = y_inp;
        }

        private void timerAnimation_tick(Object o, EventArgs e)
        {
            int dif = halfProgressRange - Math.Abs(halfProgressRange - progress);

            label.Font = new Font(defaultFont.FontFamily, defaultFont.Size + dif);
            label.Size = TextRenderer.MeasureText(label.Text, label.Font);

            if (progress == maxProgressRange)
            {
                progress = 0;
                timerAnimation.Enabled = false;
            }

            progress++;
        }

        public void Activate()
        {
            timerAnimation.Enabled = true;
            progress = 0;
            label.ForeColor = ColourActivated;
        }

        public void UpdateSize()
        {
            label.Size = TextRenderer.MeasureText(label.Text, label.Font);
        }
    }
}
