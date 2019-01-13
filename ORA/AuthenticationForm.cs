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

        private bool SetImage(PictureBox pic, string fileName)
        {
            if (isUsingDB == true)
                fileName = fileName.Replace(CL.StorageType, "DB");
            else
                fileName = fileName.Replace(CL.StorageType, "XML");
            string path = CL.FolderImages + fileName;
            if (File.Exists(path))
            {
                pic.Image = Image.FromFile(path);
                return true;
            }
            else
            {
                //MessageBox.Show("Failed to load " + fileName);
                return false;
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
                if (SetImage(menuButtons[i], CL.LoginMenuButtonsNames[i] + ".png") == true)
                {
                    menuButtons[i].Width = menuButtons[i].Image.Width;
                    menuButtons[i].Height = menuButtons[i].Image.Height;
                }
                menuButtons[i].MouseHover += Button_OnMouseHoverOn;
                menuButtons[i].MouseLeave += Button_OnMouseHoverOff;
            }
            menuButtons[CL.LoginMenuButtonPlay].Left = 556;
            menuButtons[CL.LoginMenuButtonPlay].Top = 151;
            menuButtons[CL.LoginMenuButtonPlay].Click += ButtonPlay_OnClick;

            menuButtons[CL.LoginMenuButtonExit].Left = 612;
            menuButtons[CL.LoginMenuButtonExit].Top = 305;
            menuButtons[CL.LoginMenuButtonExit].Click += ButtonExit_OnClick;

            menuButtons[CL.LoginMenuButtonSettings].Left = 526; //536
            menuButtons[CL.LoginMenuButtonSettings].Top = 400; //400
            menuButtons[CL.LoginMenuButtonSettings].Click += ButtonSettings_OnClick;

            menuButtons[CL.LoginSettingsButtonStorage].Left = 502;
            menuButtons[CL.LoginSettingsButtonStorage].Top = 372;
            menuButtons[CL.LoginSettingsButtonStorage].Click += ButtonStorage_OnClick;

            menuButtons[CL.LoginSettingsButtonBack].Left = 612;
            menuButtons[CL.LoginSettingsButtonBack].Top = 305;
            menuButtons[CL.LoginSettingsButtonBack].Click += ButtonBack_OnClick;

            menuButtons[CL.LoginSettingsButtonResolution].Left = 531;
            menuButtons[CL.LoginSettingsButtonResolution].Top = 132;

            SwitchMenuState(true);
            //502, 372
            //531, 132
        }

        private void SwitchMenuState(bool isInMainMenu)
        {
            int start_pos = 0;
            int finish_pos = 6;
            if (isInMainMenu == true)
            {
                finish_pos = 3;
            }
            else
            {
                start_pos = 3;
            }
            for(int i = 0; i < CL.LoginMenuButtons; i++)
            {
                if ((i >= start_pos)&&(i < finish_pos))
                {
                    menuButtons[i].Visible = true;
                }
                else
                {
                    menuButtons[i].Visible = false;
                }
            }
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

        private void ButtonBack_OnClick(Object o, EventArgs e)
        {
            SwitchMenuState(true);
        }

        private void ButtonStorage_OnClick(Object o, EventArgs e)
        {
            isUsingDB = !isUsingDB;
            ButtonHover(menuButtons[CL.LoginSettingsButtonStorage], true);
        }

        private void ButtonSettings_OnClick(Object o, EventArgs e)
        {
            SwitchMenuState(false);
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
