using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            public TMapEditorBuilder LabelForTimer(Label inp_label)
            {
                mapEditor.labelTimer = inp_label;
                return this;
            }
            public TMapEditorBuilder TextBoxURL(TextBox inp_textBox)
            {
                mapEditor.textBoxURL = inp_textBox;
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

        EditorViewState viewState = EditorViewState.Video;
        EditorPlayState playState = EditorPlayState.Pause;
        TMap map = new TMap("JJV1", "C:\\Programming\\JJS.mp4", 0, 162);
        public int curPos = 0;

        Button buttonPauseResume;
        Button buttonPlay;
        Button buttonView;
        Timer timer;
        AxWindowsMediaPlayer player;
        ListBox listBox;
        TextBox subtitles;
        Label labelTimer;
        TextBox textBoxURL;

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
                player.Ctlcontrols.play();
            }
            else
            {
                playState = EditorPlayState.Pause;
                timer.Enabled = false;
                buttonPauseResume.Text = "Resume";
                subtitles.Enabled = true;
                player.Ctlcontrols.pause();
            }
            return playState;
        }

        private void UpdateEditorListBox()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(map.GetEditorList().ToArray());
        }

        public void Save(string inp_videoURL, string inp_sceneName, int inp_pos1, int inp_pos2)
        {
            map.startPos = inp_pos1;
            map.maxPos = inp_pos2;
            map.sceneName = inp_sceneName;
            map.videoName = inp_videoURL;
        }

        public void Play()
        {
            subtitles.Text = "";
            timer.Enabled = true;
            buttonPauseResume.Text = "Pause";
            subtitles.Enabled = false;
            player.URL = textBoxURL.Text;
            player.Ctlcontrols.currentPosition = map.startPos;
            labelTimer.Text = map.startPos.ToString();
            UpdateEditorListBox();

            playState = EditorPlayState.Play;
        }

        public void Scroll(int inp)
        {
            player.Ctlcontrols.currentPosition += inp;
            player.Ctlcontrols.play();
            player.Ctlcontrols.pause();
            curPos = (int)player.Ctlcontrols.currentPosition;
            labelTimer.Text = curPos.ToString();
        }

        public void SaveLine()
        {
            map.subtitles[curPos] = subtitles.Text;
            subtitles.ForeColor = Color.Green;
            UpdateEditorListBox();
        }

        public void timerTick()
        {
            double timer_curPos = player.Ctlcontrols.currentPosition;
            curPos = (int)timer_curPos;
            string str;
            if (map.subtitles.TryGetValue(curPos, out str) == true)
            {
                subtitles.ForeColor = Color.Green;
                subtitles.Text = str;
            }
            labelTimer.Text = curPos.ToString();
        }

        public void subtitles_line_changed()
        {
            string str;
            if (map.subtitles.TryGetValue(curPos, out str) == true)
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
                map.subtitles.Remove(ind);
                UpdateEditorListBox();
            }
        }

        //Handlers

        public void AddHandlers()
        {
            buttonPlay.Click += buttonPlay_Click;
            buttonPauseResume.Click += buttonResumePause_Click;
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
    }
}
