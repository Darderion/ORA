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
        GameController gameController;
        TMapEditor mapEditor;
        PictureBox[] menuButtons;
        MenuMap[,] menuMaps;
        PictureBox[] settingsCheckBoxes;
        Label[] settingsLabels;
        int curPage = 0;

        PictureBox pillar;

        public UserSettings settings;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayButton_OnClick_Handler(object sender, EventArgs e)
        {
            MenuService.UpdateMapsPage(storage, ref menuMaps, curPage);
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
            tabPage3.BackColor = Color.Gray; //Green
            tabPage4.BackColor = Color.Gray;
            tabPage5.BackColor = Color.Gray;
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
            
            buttonControl.Width = buttonControl.Height;
            buttonControl.Left = tabPage1.Width - buttonControl.Width - 10;

            gameMediaPlayer.Top = 10;
            gameMediaPlayer.Left = 10;
            gameMediaPlayer.Width = tabPage1.Width - 20;

            buttonControl.Width = 100;
            buttonControl.Height = buttonControl.Width;
            
            gameMediaPlayer.Height = tabPage1.Height - 40 - buttonControl.Height;

            buttonControl.Top = gameMediaPlayer.Top + gameMediaPlayer.Height + 10;
            buttonControl.Left = gameMediaPlayer.Left + gameMediaPlayer.Width - buttonControl.Width;

			pictureBoxResult.Width = tabPage5.Width - pictureBoxResult.Left - 10;
			pictureBoxResult.Height = tabPage5.Height - pictureBoxResult.Top - 10;
			pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;

            menuMaps = new MenuMap[4, 4];
            MenuService.SetMenuMaps(ref menuMaps, tabPage4);
            foreach(var menuMap in menuMaps)
            {
                menuMap.pic.Click += MenuMap_Click;
            }
            
            GameController.Instance.SetGameController(
                gameMediaPlayer,
                buttonControl,
                mainTabControl, 0, 4,
				labelStopWatchResult,
				pictureBoxResult);
			GameController.Instance.subtitles.SetPosition(
				gameMediaPlayer.Left,
				gameMediaPlayer.Top + gameMediaPlayer.Height + 20,
				gameMediaPlayer.Width - buttonControl.Width - 10,
				tabPage1.Width - gameMediaPlayer.Top - gameMediaPlayer.Height - 50
				);

            settingsCheckBoxes = new PictureBox[CL.SettingsButtons];
            settingsLabels = new Label[CL.SettingsButtons];
            for(int i = 0; i < CL.SettingsButtons; i++)
            {
                settingsCheckBoxes[i] = new PictureBox();
                settingsCheckBoxes[i].Parent = mainTabControl.TabPages[CL.OptionsButton];
                if (settings.gameMode[i] == true)
                    settingsCheckBoxes[i].Image = Image.FromFile(CL.FolderImages + "CheckedBox.png");
                else
                    settingsCheckBoxes[i].Image = Image.FromFile(CL.FolderImages + "UncheckedBox.png");
                settingsCheckBoxes[i].Size = settingsCheckBoxes[i].Image.Size;
                settingsCheckBoxes[i].Top = i * (settingsCheckBoxes[i].Size.Height + 10) + 10;
                settingsCheckBoxes[i].Left = 10;
                settingsCheckBoxes[i].Click += SettingsCheckBox_Click;

                settingsLabels[i] = new Label();
                settingsLabels[i].Parent = settingsCheckBoxes[i].Parent;
                settingsLabels[i].Left = settingsCheckBoxes[i].Left + settingsCheckBoxes[i].Width + 10;
                settingsLabels[i].Top = settingsCheckBoxes[i].Top + (settingsCheckBoxes[i].Height / 2);
                settingsLabels[i].Height = 50;
                settingsLabels[i].Font = new Font(settingsLabels[i].Parent.Font.FontFamily, 28);
            }
            settingsLabels[0].Text = "Pause mode (Unchangeable)";
            settingsLabels[1].Text = "Ignore special symbols";
            settingsLabels[2].Text = "Ignore upper case";
            settingsLabels[3].Text = "Ignore spaces";

            foreach(var label in settingsLabels)
            {
                label.Size = TextRenderer.MeasureText(label.Text, label.Font);
            }
            //DB_Init_ASync();
        }

        private void SettingsCheckBox_Click(Object o, EventArgs e)
        {
            int cur = -1;
            for(int i = 0; i < CL.SettingsButtons; i++)
            {
                if (settingsCheckBoxes[i] == o)
                    cur = i;
            }
            if (cur == CL.SettingsPauseBeforeText) return;
            settings.gameMode[cur] = !settings.gameMode[cur];
            settingsCheckBoxes[cur].Image = Image.FromFile(CL.FolderImages + getSettingsCheckBoxName(settings.gameMode[cur]) + ".png");
            settings.Save();
        }

        private string getSettingsCheckBoxName(bool inp)
        {
            if (inp == true)
                return "CheckedBox";
            else
                return "UncheckedBox";
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
            if (mapEditor.Thumbnail == null)
            {
                MessageBox.Show("No Thumbnail");
                return;
            }
            if (editorPlayer.currentMedia != null)
            {
                using (var frm = new FormSaveMap())
                {
                    frm.Pos1 = mapEditor.StartPos;
                    frm.Pos2 = mapEditor.FinishPos;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowXY(textBoxVideoURL.Text, (int)editorPlayer.currentMedia.duration - 1);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Directory.CreateDirectory(CL.ThumbnailFolder);
                        string thumbnailName = CL.ThumbnailFolder + frm.SceneName + ".png";
                        try
                        {
                            if (File.Exists(thumbnailName) == true)
                                File.Delete(thumbnailName);
                            mapEditor.Thumbnail.Save(thumbnailName);
                        }
                        catch(Exception ex)
                        {

                        }
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
