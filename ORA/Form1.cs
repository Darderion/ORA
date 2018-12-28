using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    public partial class Form1 : Form
    {
        PictureBox[] menuButtons;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayButton_OnClick_Handler(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 0;
        }

        private void MapsButton_OnClick_Handler(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 1;
        }

        private void OptionsButton_OnClick_Handler(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 2;
        }

        private void ExitButton_OnClick_Handler(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting font
            this.Font = new Font("Splash", 14, FontStyle.Bold);
            //Full-screen mode
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //Setting tabControl's properties
            mainTabControl.Left = 170;
            mainTabControl.Width = Width - mainTabControl.Left - 10;
            mainTabControl.Height = Height - mainTabControl.Top + 30;
            mainTabControl.Top = -30;
            mainTabControl.Appearance = TabAppearance.FlatButtons;
            mainTabControl.SizeMode = TabSizeMode.Fixed;
            //Initializing Menu Buttons (Represented by PictureBoxes)
            menuButtons = new PictureBox[CL.MenuButtons];
            for(int i = 0; i < CL.MenuButtons; i++)
            {
                menuButtons[i] = new PictureBox();
                menuButtons[i].Parent = this;
                menuButtons[i].Width = 120;
                menuButtons[i].Height = 80;
                menuButtons[i].Left = 30;
                menuButtons[i].Top = 50 + 100 * i;
                menuButtons[i].BackColor = Color.Transparent;
            }
            menuButtons[CL.PlayButton].Image = new Bitmap(Properties.Resources.Play_button);
            menuButtons[CL.MapsButton].Image = new Bitmap(Properties.Resources.Maps_button);
            menuButtons[CL.OptionsButton].Image = new Bitmap(Properties.Resources.Options_button);
            menuButtons[CL.ExitButton].Image = new Bitmap(Properties.Resources.Exit_button);

            menuButtons[CL.PlayButton].Click += PlayButton_OnClick_Handler;
            menuButtons[CL.MapsButton].Click += MapsButton_OnClick_Handler;
            menuButtons[CL.OptionsButton].Click += OptionsButton_OnClick_Handler;
            menuButtons[CL.ExitButton].Click += ExitButton_OnClick_Handler;

            tabPage1.BackColor = Color.Black;
            tabPage2.BackColor = Color.Blue;
            tabPage3.BackColor = Color.Green;
        }
    }
}
