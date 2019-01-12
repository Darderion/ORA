using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    public partial class AuthenticationForm : Form
    {
        PictureBox[] menuButtons = new PictureBox[CL.LoginMenuButtons];
        bool isUsingDB = false;

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void SetImage(PictureBox pic, string fileName)
        {
            string path = CL.FolderImages + fileName;
            if (File.Exists(path))
            {
                pic.Image = Image.FromFile(path);
            }
            else
            {
                MessageBox.Show("Failed to load " + fileName);
            }
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(CL.FolderImages+"MainMenu.bmp") == true)
            {
                this.BackgroundImage = Image.FromFile(CL.FolderImages + "MainMenu.bmp");
            }
            Width = 800;
            Height = 600;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            Region region = new Region(path);
            this.Region = region;
            this.CenterToScreen();

            for(int i = 0; i < CL.LoginMenuButtons; i++)
            {
                menuButtons[i] = new PictureBox();
                menuButtons[i].Parent = this;
                menuButtons[i].BackColor = Color.Transparent;
                SetImage(menuButtons[i], CL.LoginMenuButtonsNames[i] + ".png");
                menuButtons[i].Width = menuButtons[i].Image.Width;
                menuButtons[i].Height = menuButtons[i].Image.Height;
                menuButtons[i].MouseHover += Button_OnMouseHoverOn;
                menuButtons[i].MouseLeave += Button_OnMouseHoverOff;
            }
            menuButtons[CL.LoginMenuButtonPlay].Left = 556;
            menuButtons[CL.LoginMenuButtonPlay].Top = 151;
            menuButtons[CL.LoginMenuButtonPlay].Click += ButtonPlay_OnClick;

            menuButtons[CL.LoginMenuButtonExit].Left = 612;
            menuButtons[CL.LoginMenuButtonExit].Top = 305;
            menuButtons[CL.LoginMenuButtonExit].Click += ButtonExit_OnClick;

            menuButtons[CL.LoginMenuButtonSettings].Left = 536;
            menuButtons[CL.LoginMenuButtonSettings].Top = 400;
            menuButtons[CL.LoginMenuButtonSettings].Click += ButtonSettings_OnClick;

        }

        private void ButtonHover(PictureBox pic, bool inside)
        {
            string s = "";
            int ind = -1;
            for(int i = 0; i < CL.LoginMenuButtons; i++)
            {
                if (pic == menuButtons[i])
                    ind = i;
            }
            if (inside == true) s = "On";
            SetImage(menuButtons[ind], CL.LoginMenuButtonsNames[ind] + s + ".png");
        }

        private void ButtonExit_OnClick(Object o, EventArgs e)
        {
            Close();
        }

        private void ButtonSettings_OnClick(Object o, EventArgs e)
        {
            string str_using = "--(Using now)-->";
            string str_not_using = "----------------->";

            string str_db = "Local Database";
            string str_xml = "Local files (Recommended)";

            if (isUsingDB == true)
            {
                str_db = str_using + str_db;
                str_xml = str_not_using + str_xml;
            }
            else
            {
                str_db = str_not_using + str_db;
                str_xml = str_using + str_xml;
            }

            DialogResult dialogResult = MessageBox.Show(
                "List of possible map storages : "+Environment.NewLine
                +str_xml+Environment.NewLine
                +str_db+Environment.NewLine
                +"Do you want to change storage?", "Settings", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                isUsingDB = !isUsingDB;
            }
        }

        private void ButtonPlay_OnClick(Object o, EventArgs e)
        {
            using (var frm = new Form1())
            {
                if (isUsingDB == true)
                    frm.storage = new MapsDB();
                else
                    frm.storage = new MapsXML();
                frm.ShowDialog();
            }
            Close();
        }

        private void Button_OnMouseHoverOn(Object o, EventArgs e)
        {
            ButtonHover((PictureBox)o, true);
        }

        private void Button_OnMouseHoverOff(Object o, EventArgs e)
        {
            ButtonHover((PictureBox)o, false);
        }
    }
}
