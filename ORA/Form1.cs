﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            this.Font = new Font("Splash", 18, FontStyle.Bold);
            //Full-screen mode
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //Setting tabControl's properties
            mainTabControl.Left = 170;
            mainTabControl.Width = Width - mainTabControl.Left - 10;
            mainTabControl.Height = Height - mainTabControl.Top + 30;
            mainTabControl.Top = -35;
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
            tabPage2.BackColor = Color.Gray;
            tabPage3.BackColor = Color.Green;

            editorPlayer.Width = tabPage2.Width - 50;
            editorPlayer.Top = buttonPlay.Top + 50;
            editorPlayer.Left = 20;
            editorPlayer.Height = tabPage2.Height - editorPlayer.Top - 50;

            textBoxVideoURL.Left = editorPlayer.Left;
            textBoxSubtitle.Left = editorPlayer.Left + 80;
            textBoxVideoURL.Width = tabPage2.Width - 50;
            textBoxSubtitle.Width = textBoxVideoURL.Width + editorPlayer.Left - textBoxSubtitle.Left;
            textBoxSubtitle.Top = editorPlayer.Top + editorPlayer.Height + 10;
            labelCurrentPos.Left = editorPlayer.Left;
            labelCurrentPos.Top = textBoxSubtitle.Top;
            labelCurrentPos.Text = "";
        }

        private void buttonResumePause_Click(object sender, EventArgs e)
        {
            if (buttonResumePause.Text == "Resume")
            {
                editorTimer.Enabled = true;
                buttonResumePause.Text = "Pause";
                textBoxSubtitle.Enabled = false;
                editorPlayer.Ctlcontrols.play();
            }
            else
            {
                editorTimer.Enabled = false;
                buttonResumePause.Text = "Resume";
                textBoxSubtitle.Enabled = true;
                editorPlayer.Ctlcontrols.pause();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxVideoURL.Text) == true)
            {
                if (textBoxVideoURL.Text.Remove(0, textBoxVideoURL.Text.Length - 3) == "mp4")
                {
                    editorTimer.Enabled = true;
                    buttonResumePause.Text = "Pause";
                    textBoxSubtitle.Enabled = false;
                    editorPlayer.URL = textBoxVideoURL.Text;
                    labelCurrentPos.Text = "0";
                }
            }
        }

        private void editorTimer_Tick(object sender, EventArgs e)
        {
            double curPos = editorPlayer.Ctlcontrols.currentPosition;
            labelCurrentPos.Text = curPos.ToString();
        }

        private void buttonScroll5s_Click(object sender, EventArgs e)
        {
            editorPlayer.Ctlcontrols.currentPosition -= 5;
            editorPlayer.Ctlcontrols.play();
            editorPlayer.Ctlcontrols.pause();
        }
    }
}
