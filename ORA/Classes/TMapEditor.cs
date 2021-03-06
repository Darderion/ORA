﻿using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    public class TMapEditor
    {
        public class TMapEditorBuilder
        {
            private TMapEditor mapEditor;
            public TMapEditorBuilder(TMapEditor inp_editor)
            {
                mapEditor = inp_editor;
            }
            public TMapEditorBuilder PauseResume(Button inp_button)
            {
                mapEditor.buttonPauseResume = inp_button;
                return this;
            }
            public TMapEditorBuilder Play(Button inp_button)
            {
                mapEditor.buttonPlay = inp_button;
                return this;
            }
            public TMapEditorBuilder View(Button inp_button)
            {
                mapEditor.buttonView = inp_button;
                return this;
            }
            public TMapEditorBuilder Load(Button inp_button)
            {
                mapEditor.buttonLoad = inp_button;
                return this;
            }
            public TMapEditorBuilder Save(Button inp_button)
            {
                mapEditor.buttonSave = inp_button;
                return this;
            }
            public TMapEditorBuilder Timer(Timer inp_timer)
            {
                mapEditor.timer = inp_timer;
                return this;
            }
            public TMapEditorBuilder Player(AxWindowsMediaPlayer inp_player)
            {
                mapEditor.player = inp_player;
                return this;
            }
            public TMapEditorBuilder ListBox(ListBox inp_listBox)
            {
                mapEditor.listBox = inp_listBox;
                return this;
            }
            public TMapEditorBuilder Subtitles(TextBox inp_textBox)
            {
                mapEditor.subtitles = inp_textBox;
                return this;
            }
            public TMapEditorBuilder LabelForTimer(TextBox inp_textBox)
            {
                mapEditor.textBoxTimer = inp_textBox;
                return this;
            }
            public TMapEditorBuilder TextBoxURL(TextBox inp_textBox)
            {
                mapEditor.textBoxURL = inp_textBox;
                return this;
            }
            public TMapEditorBuilder MapStorage(IMapStorage inp_mapStorage)
            {
                mapEditor.mapStorage = inp_mapStorage;
                return this;
            }
            public TMapEditorBuilder Thumbnail(Button inp_buttonThumbnail)
            {
                mapEditor.buttonThumbnail = inp_buttonThumbnail;
                return this;
            }

            public static implicit operator TMapEditor(TMapEditorBuilder editorBuilder)
            {
                return editorBuilder.mapEditor;
            }
        }

        public static TMapEditorBuilder Create()
        {
            return new TMapEditorBuilder(new TMapEditor());
        }

        public enum EditorViewState { Video, List };
        public enum EditorPlayState { Play, Pause };

        //Variables

        public IMapStorage mapStorage;

        EditorViewState viewState = EditorViewState.Video;
        EditorPlayState playState = EditorPlayState.Pause;
        Map map = new Map("JJV1", "C:\\Programming\\JJS.mp4", 0, 162);
        public int curPos = 0;

        Button buttonPauseResume;
        Button buttonPlay;
        Button buttonView;
        Button buttonLoad;
        Button buttonSave;
        Button buttonThumbnail;
        TextBox textBoxTimer;
        Timer timer;
        AxWindowsMediaPlayer player;
        ListBox listBox;
        TextBox subtitles;
        TextBox textBoxURL;

        bool isConnectedToDB = false;
        public Image Thumbnail;
        
        public int StartPos
        {
            get
            {
                return map.startPos;
            }
            set
            {
                map.startPos = value;
            }
        }

        public int FinishPos
        {
            get
            {
                return map.finishPos;
            }
            set
            {
                map.finishPos = value;
            }
        }

        //Methods

        public bool ChangeDBConnectionState()
        {
            return ChangeDBConnectionState(!isConnectedToDB);
        }

        public bool ChangeDBConnectionState(bool isConnected)
        {
            isConnectedToDB = isConnected;
            if (isConnectedToDB == false)
            {
                buttonSave.BeginInvoke((MethodInvoker)(() =>
                {
                    buttonLoad.Enabled = false;
                    buttonLoad.Text = "Connecting...";
                    buttonLoad.Font = new Font("Splash", 12, FontStyle.Italic);

                    buttonSave.Enabled = false;
                    buttonSave.Text = "Connecting...";
                    buttonSave.Font = new Font("Splash", 12, FontStyle.Italic);
                }));
            }
            else
            {
                buttonSave.BeginInvoke((MethodInvoker)(() =>
                {
                    buttonLoad.Enabled = true;
                    buttonLoad.Text = "Load";
                    buttonLoad.Font = buttonLoad.Parent.Font;

                    buttonSave.Enabled = true;
                    buttonSave.Text = "Save";
                    buttonSave.Font = buttonSave.Parent.Font;
                }));
            }
            return isConnectedToDB;
        }

        public EditorViewState ChangeViewState()
        {
            if (viewState == EditorViewState.Video)
            {
                viewState = EditorViewState.List;
                buttonView.Text = "List";
                player.Visible = false;
                listBox.Visible = true;
            }
            else
            {
                viewState = EditorViewState.Video;
                buttonView.Text = "Video";
                player.Visible = true;
                listBox.Visible = false;
            }
            return viewState;
        }

        public EditorPlayState ChangePlayState()
        {
            if (playState == EditorPlayState.Pause)
            {
                playState = EditorPlayState.Play;
                timer.Enabled = true;
                buttonPauseResume.Text = "Pause";
                subtitles.ForeColor = Color.Black;
                subtitles.Enabled = false;
                if (player.Ctlcontrols.currentItem != null)
                    textBoxTimer.Enabled = false;
                player.Ctlcontrols.play();
            }
            else
            {
                playState = EditorPlayState.Pause;
                timer.Enabled = false;
                buttonPauseResume.Text = "Resume";
                subtitles.Enabled = true;
                if (player.Ctlcontrols.currentItem != null)
                    textBoxTimer.Enabled = true;
                player.Ctlcontrols.pause();
            }
            return playState;
        }

        public void Pause()
        {
            player.Ctlcontrols.play();
            player.Ctlcontrols.pause();
            timerTick();
            if (playState == EditorPlayState.Play)
            {
                ChangePlayState();
            }
        }

        private void UpdateEditorListBox()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(GetEditorList().ToArray());
        }

        public void SetVideoTimer(int inp)
        {
            textBoxTimer.Text = inp.ToString();
            player.Ctlcontrols.currentPosition = inp;
            player.Ctlcontrols.play();
            player.Ctlcontrols.pause();
            if (map.dict.ContainsKey(inp))
                subtitles.Text = map.dict[inp];
            else
                subtitles.Text = "";
        }

        public void Play()
        {
            subtitles.Text = "";
            timer.Enabled = true;
            buttonPauseResume.Text = "Pause";
            subtitles.Enabled = false;
            player.URL = textBoxURL.Text;
            player.Ctlcontrols.currentPosition = map.startPos;
            textBoxTimer.Text = map.startPos.ToString();
            UpdateEditorListBox();
            textBoxTimer.Enabled = false;

            playState = EditorPlayState.Play;
        }

        public void Scroll(int inp)
        {
            player.Ctlcontrols.currentPosition += inp;
            curPos = (int)player.Ctlcontrols.currentPosition;
            SetVideoTimer(curPos);
        }

        public void SaveLine()
        {
            map.dict[curPos] = subtitles.Text;
            subtitles.ForeColor = Color.Green;
            UpdateEditorListBox();
        }

        public void timerTick()
        {
            double timer_curPos = player.Ctlcontrols.currentPosition;
            curPos = (int)timer_curPos;
            string str;
            if (map.dict.TryGetValue(curPos, out str) == true)
            {
                subtitles.ForeColor = Color.Green;
                subtitles.Text = str;
            }
            textBoxTimer.Text = curPos.ToString();
        }

        public bool LoadMap(string inp)
        {
            Map LoadedMap = mapStorage.Load(inp);
            if (LoadedMap != null)
            {
                Thumbnail = MenuService.getThumbnail(inp);
                map = LoadedMap;
                textBoxURL.Text = map.VideoURL;
                UpdateEditorListBox();
                return true;
            }
            return false;
        }

        public bool Save(string inp_VideoName, string inp_SceneName, int pos1, int pos2)
        {
            map.Name = inp_SceneName;
            map.VideoURL = inp_VideoName;
            map.startPos = pos1;
            map.finishPos = pos2;
            return mapStorage.Save(map);
        }

        public void subtitles_line_changed()
        {
            string str;
            if (map.dict.TryGetValue(curPos, out str) == true)
            {
                if (subtitles.Text == str)
                {
                    subtitles.ForeColor = Color.Green;
                }
                else
                {
                    subtitles.ForeColor = Color.Red;
                }
            }
            else
            {
                subtitles.ForeColor = Color.Blue;
            }
        }

        public void DeleteLine(string inp)
        {
            string s = inp.Remove(0, 1);
            s = s.Remove(s.IndexOf(']'));
            int ind;
            if (Int32.TryParse(s, out ind) == true)
            {
                map.dict.Remove(ind);
                UpdateEditorListBox();
            }
        }

        //Handlers

        public void AddHandlers()
        {
            buttonPlay.Click += buttonPlay_Click;
            buttonPauseResume.Click += buttonResumePause_Click;
            textBoxTimer.TextChanged += textBoxVideoTimer_TextChanged;
            buttonThumbnail.Click += buttonThumbnail_Click;
        }

        private void buttonThumbnail_Click(object sender, EventArgs e)
        {
            Pause();
            try
            {
                Bitmap bitmap = new Bitmap(player.Width, player.Height);
                {
                    Graphics g = Graphics.FromImage(bitmap);
                    {
                        Graphics gg = player.CreateGraphics();
                        {
                            g.CopyFromScreen(
                                player.PointToScreen(new Point()).X,
                                player.PointToScreen(new Point()).Y,
                                0, 0,
                                new Size(player.Width, player.Height));
                        }
                    }
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    Thumbnail = Image.FromStream(ms);
                }

                MessageBox.Show("Saved thumbnail");
            }
            catch(Exception ex)
            {
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxURL.Text) == true)
            {
                if (textBoxURL.Text.Remove(0, textBoxURL.Text.Length - 3) == "mp4")
                {
                    Play();
                }
            }
        }

        private void buttonResumePause_Click(object sender, EventArgs e)
        {
            ChangePlayState();
        }

        private void textBoxVideoTimer_TextChanged(object sender, EventArgs e)
        {
            if (playState == EditorPlayState.Play) return;
            int pos;
            if (Int32.TryParse(textBoxTimer.Text, out pos) == true)
            {
                textBoxTimer.ForeColor = Color.Black;
                SetVideoTimer(pos);
            }
            else
            {
                textBoxTimer.ForeColor = Color.Red;
            }
        }

        public List<string> GetEditorList()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < map.finishPos; i++)
            {
                if (map.dict.ContainsKey(i) == true)
                {
                    res.Add("[" + i + "] " + map.dict[i]);
                }
            }
            return res;
        }
    }
}
