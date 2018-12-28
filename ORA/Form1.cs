using System;
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
        private enum EditorViewState { Video, List };
        EditorViewState editorViewState = EditorViewState.Video;
        private enum EditorPlayState { Play, Pause };
        EditorPlayState editorPlayState = EditorPlayState.Pause;

        PictureBox[] menuButtons;
        //Test vars
        TMap map = new TMap("JJV1", "C:\\Programming\\JJS.mp4", 162);
        int curPos = 0;

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

            editorPlayer.Width = tabPage2.Width - 50;
            editorPlayer.Top = buttonPlay.Top + 50;
            editorPlayer.Left = 20;
            editorPlayer.Height = tabPage2.Height - editorPlayer.Top - 50;

            textBoxVideoURL.Left = editorPlayer.Left;
            textBoxSubtitle.Left = editorPlayer.Left + 80;
            textBoxVideoURL.Width = tabPage2.Width - 50;
            textBoxSubtitle.Width = textBoxVideoURL.Width + editorPlayer.Left - textBoxSubtitle.Left;
            textBoxSubtitle.Top = editorPlayer.Top + editorPlayer.Height + 10;
            labelVideoTimer.Left = editorPlayer.Left;
            labelVideoTimer.Top = textBoxSubtitle.Top;
            labelVideoTimer.Text = "";

            listBoxEditor.Width = editorPlayer.Width;
            listBoxEditor.Height = editorPlayer.Height;
            listBoxEditor.Left = editorPlayer.Left;
            listBoxEditor.Top = editorPlayer.Top;
            
            //Test properties
            tabPage1.BackColor = Color.Black;
            tabPage2.BackColor = Color.Gray;
            tabPage3.BackColor = Color.Green;
            textBoxVideoURL.Text = "C:\\Programming\\JJS.mp4";
        }

        private void buttonResumePause_Click(object sender, EventArgs e)
        {
            if (editorPlayState == EditorPlayState.Pause)
            {
                editorPlayState = EditorPlayState.Play;
                editorTimer.Enabled = true;
                buttonResumePause.Text = "Pause";
                textBoxSubtitle.ForeColor = Color.Black;
                textBoxSubtitle.Enabled = false;
                editorPlayer.Ctlcontrols.play();
            }
            else
            {
                editorPlayState = EditorPlayState.Pause;
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
                    textBoxSubtitle.Text = "";
                    editorTimer.Enabled = true;
                    buttonResumePause.Text = "Pause";
                    textBoxSubtitle.Enabled = false;
                    editorPlayer.URL = textBoxVideoURL.Text;
                    labelVideoTimer.Text = "0";
                    UpdateEditorListBox();
                }
            }
        }

        private void editorTimer_Tick(object sender, EventArgs e)
        {
            double timer_curPos = editorPlayer.Ctlcontrols.currentPosition;
            curPos = (int)timer_curPos;
            string str;
            if (map.subtitles.TryGetValue(curPos,out str) == true)
            {
                textBoxSubtitle.ForeColor = Color.Green;
                textBoxSubtitle.Text = str;
                //7-11-12-8
            }
            labelVideoTimer.Text = curPos.ToString();
        }

        private void buttonScroll1s_Click(object sender, EventArgs e)
        {
            editorPlayer.Ctlcontrols.currentPosition -= 1;
            editorPlayer.Ctlcontrols.play();
            editorPlayer.Ctlcontrols.pause();
            curPos = (int)editorPlayer.Ctlcontrols.currentPosition;
            labelVideoTimer.Text = curPos.ToString();
        }

        private void textBoxSubtitle_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (map.subtitles.TryGetValue(curPos, out str) == true)
            {
                if (textBoxSubtitle.Text == str)
                {
                    textBoxSubtitle.ForeColor = Color.Green;
                }
                else
                {
                    textBoxSubtitle.ForeColor = Color.Red;
                }
            }
            else
            {
                textBoxSubtitle.ForeColor = Color.Blue;
            }
        }

        private void UpdateEditorListBox()
        {
            listBoxEditor.Items.Clear();
            listBoxEditor.Items.AddRange(map.GetEditorList().ToArray());
        }

        private void textBoxSubtitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                map.subtitles[curPos] = textBoxSubtitle.Text;
                textBoxSubtitle.ForeColor = Color.Green;
                UpdateEditorListBox();
            }
        }

        private void buttonEditorView_Click(object sender, EventArgs e)
        {
            if (editorViewState == EditorViewState.Video)
            {
                editorViewState = EditorViewState.List;
                buttonEditorView.Text = "List";
                editorPlayer.Visible = false;
                listBoxEditor.Visible = true;
            }
            else
            {
                editorViewState = EditorViewState.Video;
                buttonEditorView.Text = "Video";
                editorPlayer.Visible = true;
                listBoxEditor.Visible = false;
            }
        }

        private void buttonScroll5s_Click(object sender, EventArgs e)
        {
            editorPlayer.Ctlcontrols.currentPosition -= 5;
            editorPlayer.Ctlcontrols.play();
            editorPlayer.Ctlcontrols.pause();
            curPos = (int)editorPlayer.Ctlcontrols.currentPosition;
            labelVideoTimer.Text = curPos.ToString();
        }
    }
}
