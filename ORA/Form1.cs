using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    public partial class Form1 : Form
    {
        public IMapStorage storage;
        TMapEditor mapEditor;
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

            editorPlayer.Width = tabPage2.Width - 50;
            editorPlayer.Top = buttonPlay.Top + 50;
            editorPlayer.Left = 20;
            editorPlayer.Height = tabPage2.Height - editorPlayer.Top - 50;

            textBoxVideoURL.Left = editorPlayer.Left;
            textBoxSubtitle.Left = editorPlayer.Left + 80;
            textBoxVideoURL.Width = tabPage2.Width - 50 - 170;
            textBoxSubtitle.Width = textBoxVideoURL.Width + editorPlayer.Left - textBoxSubtitle.Left;
            textBoxSubtitle.Top = editorPlayer.Top + editorPlayer.Height + 10;
            textBoxVideoTimer.Left = editorPlayer.Left;
            textBoxVideoTimer.Top = textBoxSubtitle.Top;
            textBoxVideoTimer.Text = "";

            listBoxEditor.Width = editorPlayer.Width;
            listBoxEditor.Height = editorPlayer.Height;
            listBoxEditor.Left = editorPlayer.Left;
            listBoxEditor.Top = editorPlayer.Top;
            
            //Test properties
            tabPage1.BackColor = Color.Black;
            tabPage2.BackColor = Color.Gray;
            tabPage3.BackColor = Color.Green;
            textBoxVideoURL.Text = "C:\\Programming\\JJS.mp4";

            mapEditor = TMapEditor.Create()
                .Play(buttonPlay)
                .Player(editorPlayer)
                .Timer(editorTimer)
                .PauseResume(buttonResumePause)
                .Load(buttonLoad)
                .Save(buttonSave)
                .ListBox(listBoxEditor)
                .View(buttonEditorView)
                .Subtitles(textBoxSubtitle)
                .LabelForTimer(textBoxVideoTimer)
                .TextBoxURL(textBoxVideoURL)
                .MapStorage(storage);
            mapEditor.AddHandlers();
            mapEditor.ChangeDBConnectionState(false);

            DB_Init_ASync();
        }

        public async Task DB_Init_ASync()
        {
            await Task.Run(Init_ASync);
        }

        public async Task Init_ASync()
        {
            try
            {
                storage.Reset();

                Map map = new Map("Test Map", "JJS.mp4", 7, 160);
                map.AddSubtitle(8, "JJ1-0") //0
                    .AddSubtitle(9, "JJ1-1") //1
                    .AddSubtitle(4, "JJ1-4")
                    .AddSubtitle(3, "JJ1-3");
                storage.Save(map);

                map = new Map("Test Map 2", "JJS.mp4", 0, 162);
                map.AddSubtitle(0, "0")
                    .AddSubtitle(1, "1")
                    .AddSubtitle(5, "5")
                    .AddSubtitle(7, "7");
                storage.Save(map);

                mapEditor.ChangeDBConnectionState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editorTimer_Tick(object sender, EventArgs e)
        {
            mapEditor.timerTick();
        }

        private void textBoxSubtitle_TextChanged(object sender, EventArgs e)
        {
            mapEditor.subtitles_line_changed();
        }

        private void textBoxSubtitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mapEditor.SaveLine();
            }
        }

        private void buttonEditorView_Click(object sender, EventArgs e)
        {
            mapEditor.ChangeViewState();
        }

        private void buttonScroll1s_Click(object sender, EventArgs e)
        {
            mapEditor.Scroll(-1);
        }

        private void buttonScroll5s_Click(object sender, EventArgs e)
        {
            mapEditor.Scroll(-5);
        }

        private void listBoxEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxEditor.SelectedIndex != -1)
                {
                    mapEditor.DeleteLine(listBoxEditor.Items[listBoxEditor.SelectedIndex].ToString());
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (editorPlayer.currentMedia != null)
            {
                using (var frm = new FormSaveMap())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowXY(textBoxVideoURL.Text, (int)editorPlayer.currentMedia.duration - 1);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        mapEditor.Save(frm.VideoURL, frm.SceneName, frm.Pos1, frm.Pos2);
                        mapEditor.LoadMap(frm.SceneName);
                    }
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (var frm = new FormLoadMap())
            {
                frm.mapStorage = storage;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mapEditor.LoadMap(frm.currentMap.Name);
                }
            }
        }

        private void listBoxEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEditor.SelectedIndex != -1)
            {
                int ind = 0;
                string line = listBoxEditor.Items[listBoxEditor.SelectedIndex].ToString();
                line = line.Remove(line.IndexOf(']')).Remove(0, 1);
                if (Int32.TryParse(line, out ind) == true)
                {
                    editorPlayer.Ctlcontrols.currentPosition = ind;
                    mapEditor.Pause();
                }
            }
        }
    }
}
