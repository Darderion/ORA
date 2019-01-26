using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class GameController
    {
        public GameController()
        {
            subtitles = new Subtitles();
        }

        private static GameController instance;

        private string[] text;
        public Subtitles subtitles;
        public bool isPlaying;

        private bool paused;

        public void SetGameController(AxWindowsMediaPlayer inp_player, Button inp_button, Control control)
        {
            player = inp_player;
            controlButton = inp_button;
            Init(control);
        }

        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        IMap map;
        int curTimerPos = 0;
        int prevTimerPos = 0;

        int curSubtitlePos = 0;
        int curSubtitleInd = 2;

        Timer timer;
        AxWindowsMediaPlayer player;
        Button controlButton;

        private void Init(Control control)
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 250;
            timer.Tick += TimerTick;

            text = new string[3] { "", "", "" };
            controlButton.KeyPress += UserTyped;

            controlButton.Click += controlButton_Click;

            subtitles.SetParents(control);
        }

        public void Play()
        {
            if (isPlaying == true) return;
            if (map != null)
            {
                isPlaying = true;
                paused = false;
                text[0] = "..."; text[1] = ".."; text[2] = ".";
                curTimerPos = 0;
                prevTimerPos = 0;
                timer.Enabled = true;
                player.URL = map.VideoURL;
                player.Ctlcontrols.currentPosition = map.startPos;
                player.Ctlcontrols.play();
            }
        }

        private void controlButton_Click(Object o, EventArgs e)
        {
            Play();
        }

        public void SetMap(IMap inp_map)
        {
            map = inp_map;
            curSubtitlePos = 0;
            isPlaying = false;
        }

        private void TimerTick(Object o, EventArgs e)
        {
            curTimerPos = (int) player.Ctlcontrols.currentPosition;
            if (prevTimerPos < curTimerPos)
            {
                if (curTimerPos == map.finishPos)
                {
                    //Finish line
                    player.Ctlcontrols.stop();
                }
                if (map.dict.ContainsKey(curTimerPos))
                {
                    if (subtitles.FinishedLine == false)
                    {
                        Pause();
                    }
                    else
                    {
                        UpdateSubtitles();
                    }
                }
                prevTimerPos = curTimerPos;
            }
            controlButton.Text = curSubtitlePos + "<";
        }

        private void Pause()
        {
            if (paused == false)
            {
                paused = true;
                player.Ctlcontrols.pause();
            }
        }

        private void Resume()
        {
            if (paused == true)
            {
                paused = false;
                player.Ctlcontrols.play();
            }
        }

        private void UpdateSubtitles()
        {
            if (map.dict.ContainsKey(curTimerPos))
            {
                subtitles.SetText(map.dict[curTimerPos]);
            }
        }

        public static bool isInputChar(char inp)
        {
            if (inp == ' ') return true;
            if ((inp >= 'a') && (inp <= 'z')) return true;
            if ((inp >= 'A') && (inp <= 'Z')) return true;
            return false;
        }

        private void UserTyped(Object o, EventArgs e)
        {
            char symb = ((KeyPressEventArgs)e).KeyChar;
            if (UserSettings.Instance.gameMode.IgnoreUpperCase == true)
                symb = Char.ToLower(symb);
            if (letterTypedCorrectly(symb) == true)
            {
                subtitles.MoveToNextAvailableSymbol();
                if (subtitles.FinishedLine == true)
                {
                    Resume();
                    UpdateSubtitles();
                }
            }
        }

        private bool letterTypedCorrectly(Char symb)
        {
            if (subtitles.CurrentlySelected == symb)
                return true;
            return false;
        }
    }
}
