using System;
using AxWMPLib;
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
        GameController gameController;
        TMapEditor mapEditor;
        PictureBox[] menuButtons;
        MenuMap[,] menuMaps;

        PictureBox pillar;

        public UserSettings settings;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayButton_OnClick_Handler(object sender, EventArgs e)
        {
            mainTabControl.SelectedIndex = 3;
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

        private int AllignToTheRight(Control ctrl)
        {
            return ctrl.Left + ctrl.Width + 10;
        }

        private int GetTextWidth(Button button, Font font)
        {
            return TextRenderer.MeasureText(button.Text, font).Width;
        }

        private int GetTextWidth(Button button, float size)
        {
            return TextRenderer.MeasureText(button.Text, new Font(button.Font.FontFamily,size)).Width;
        }

        private int GetTextWidth(Button button)
        {
            return GetTextWidth(button, button.Font);
        }

        private void SetFontSize(params Button[] buttons)
        {
            float size = GetFontSize(tabPage1.Width - 100, Font.Size, buttons);
            foreach (Button b in buttons)
            {
                b.Font = new Font(Font.FontFamily, size);
            }
        }

        private float GetFontSize(int width, float inp, Button[] buttons)
        {
            int sum = 0;
            Font font = new Font(Font.FontFamily, inp);
            foreach (Button b in buttons)
            {
                sum += GetTextWidth(b, inp) + 10;
            }
            if (width < sum)
                return GetFontSize(width, inp - 1, buttons);
            else
                return font.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting font
            this.Font = new Font("Splash", 18, FontStyle.Bold);
            if (settings.isUsingDB == true)
                storage = new MapsDB();
            else
                storage = new MapsXML();
            Width = settings.resolutionWidth;
            Height = settings.resolutionHeight;
            //Full-screen mode
            FormBorderStyle = FormBorderStyle.None;
            if (settings.isUsingDB == true)
                storage = new MapsDB();
            else
                storage = new MapsXML();
            Width = settings.resolutionWidth;
            Height = settings.resolutionHeight;
            //WindowState = FormWindowState.Maximized;
            Left = 0;
            Top = 0;
            //Setting tabControl's properties
            mainTabControl.Left = 170;
            mainTabControl.Width = Width - mainTabControl.Left - 10;
            mainTabControl.Height = Height - mainTabControl.Top + 30;
            mainTabControl.Top = -35;
            mainTabControl.Appearance = TabAppearance.FlatButtons;
            mainTabControl.SizeMode = TabSizeMode.Fixed;

            SetFontSize(buttonPlay, buttonResumePause, buttonScroll1s, buttonScroll5s, buttonEditorView, buttonSave);
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
            textBoxVideoURL.Width = tabPage2.Width - buttonThumbnail.Width - buttonLoad.Width - 100;
            textBoxSubtitle.Width = textBoxVideoURL.Width + editorPlayer.Left - textBoxSubtitle.Left;
            textBoxSubtitle.Top = editorPlayer.Top + editorPlayer.Height + 10;
            textBoxVideoTimer.Left = editorPlayer.Left;
            textBoxVideoTimer.Top = textBoxSubtitle.Top;
            textBoxVideoTimer.Text = "";
            textBoxSubtitle.Width = editorPlayer.Width + editorPlayer.Left - textBoxSubtitle.Left;

            buttonPlay.Width = GetTextWidth(buttonPlay) + 10;
            buttonResumePause.Width = GetTextWidth(buttonResumePause) + 10;
            buttonScroll1s.Width = GetTextWidth(buttonScroll1s) + 10;
            buttonScroll5s.Width = GetTextWidth(buttonScroll5s) + 10;
            buttonEditorView.Width = GetTextWidth(buttonEditorView) + 10;

            buttonThumbnail.Left = AllignToTheRight(textBoxVideoURL);
            buttonLoad.Left = AllignToTheRight(buttonThumbnail);
            buttonResumePause.Left = AllignToTheRight(buttonPlay);
            buttonScroll1s.Left = AllignToTheRight(buttonResumePause);
            buttonScroll5s.Left = AllignToTheRight(buttonScroll1s);
            buttonEditorView.Left = AllignToTheRight(buttonScroll5s);
            buttonSave.Left = AllignToTheRight(buttonEditorView);

            buttonSave.Width = editorPlayer.Left + editorPlayer.Width - buttonSave.Left;
            buttonLoad.Width = editorPlayer.Left + editorPlayer.Width - buttonLoad.Left;

            listBoxEditor.Width = editorPlayer.Width;
            listBoxEditor.Height = editorPlayer.Height;
            listBoxEditor.Left = editorPlayer.Left;
            listBoxEditor.Top = editorPlayer.Top;
            
            //Test properties
            tabPage1.BackColor = Color.Gray;
            tabPage2.BackColor = Color.Gray;
            tabPage3.BackColor = Color.Green;
            tabPage4.BackColor = Color.Gray;
            textBoxVideoURL.Text = "Data/Videos/";

            pillar = new PictureBox();
            pillar.Parent = this;
            pillar.Width = mainTabControl.Left - 10;
            pillar.Height = Height;
            pillar.Left = 0;
            pillar.Top = 0;
            pillar.Image = Image.FromFile(CL.FolderImages + "Pillar.png");
            pillar.SizeMode = PictureBoxSizeMode.StretchImage;

            BackColor = Color.Yellow;

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
                .MapStorage(storage)
                .Thumbnail(buttonThumbnail);
            mapEditor.AddHandlers();
            mapEditor.ChangeDBConnectionState(true);

            richTextBoxSubtitle.Width = tabPage1.Width - 20;
            richTextBoxSubtitle.Left = 10;
            richTextBoxSubtitle.Height = FontHeight * 3 + 5;
            richTextBoxSubtitle.Top = tabPage1.Height - richTextBoxSubtitle.Height - 10;

            buttonControl.Top = richTextBoxSubtitle.Top;
            buttonControl.Height = richTextBoxSubtitle.Height;
            buttonControl.Width = buttonControl.Height;
            buttonControl.Left = tabPage1.Width - buttonControl.Width - 10;
            richTextBoxSubtitle.Width -= buttonControl.Width + 10;

            gameMediaPlayer.Top = 10;
            gameMediaPlayer.Left = 10;
            gameMediaPlayer.Width = tabPage1.Width - 20;
            gameMediaPlayer.Height = richTextBoxSubtitle.Top - 20;

            menuMaps = new MenuMap[4, 4];
            MenuService.SetMenuMaps(ref menuMaps, tabPage4);
            foreach(var menuMap in menuMaps)
            {
                menuMap.pic.Click += MenuMap_Click;
            }
            
            GameController.Instance.SetGameController(
                gameMediaPlayer,
                buttonControl,
                richTextBoxSubtitle);
            MenuService.UpdateMapsPage(storage, ref menuMaps, 0);
            //DB_Init_ASync();
        }

        public void MenuMap_Click(Object o, EventArgs e)
        {
            int sx = 0;
            int sy = 0;
            for (int x = 0; x < menuMaps.GetLength(0); x++)
            {
                for (int y = 0; y < menuMaps.GetLength(1); y++)
                {
                    if (o == menuMaps[x, y].pic)
                    {
                        sx = x;
                        sy = y;
                    }
                }
            }
            GameController.Instance.SetMap(storage.Load(menuMaps[sx,sy].mapName));
            mainTabControl.SelectedIndex = 0;
            GameController.Instance.Play();
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

                Map map = new Map("Test Map", CL.VideoFolder + "JJS.mp4", 7, 160);
                map.AddSubtitle(8, "JJ1-0") //0
                    .AddSubtitle(9, "JJ1-1") //1
                    .AddSubtitle(4, "JJ1-4")
                    .AddSubtitle(3, "JJ1-3");
                storage.Save(map);

                map = new Map("Test Map 2", CL.VideoFolder + "JJS.mp4", 0, 162);
                map.AddSubtitle(0, "0")
                    .AddSubtitle(1, "1")
                    .AddSubtitle(5, "5")
                    .AddSubtitle(7, "7");
                storage.Save(map);

                mapEditor.ChangeDBConnectionState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Async : "+ex.Message);
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
                        Directory.CreateDirectory(CL.ThumbnailFolder);
                        mapEditor.Thumbnail.Save(CL.ThumbnailFolder + frm.SceneName + ".png");
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
