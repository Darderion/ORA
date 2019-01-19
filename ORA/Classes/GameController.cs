﻿using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORA
{
    class GameController
    {
        private static GameController instance;

        public void SetGameController(AxWindowsMediaPlayer inp_player, Button inp_button, RichTextBox inp_textBoxSubtitles)
        {
            player = inp_player;
            controlButton = inp_button;
            subtitles = inp_textBoxSubtitles;
            subtitles.ScrollBars = RichTextBoxScrollBars.None;
            Ini();
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
        int curPos = 0;
        int prevPos = 0;
        Timer timer;
        AxWindowsMediaPlayer player;
        Button controlButton;
        RichTextBox subtitles;

        private void Ini()
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 250;
            timer.Tick += TimerTick;
        }

        public void Play()
        {
            if (map != null)
            {
                curPos = 0;
                prevPos = 0;
                timer.Enabled = true;
                //player.Ctlcontrols.currentPosition = 0;
                player.URL = map.VideoURL;
                player.Ctlcontrols.currentPosition = map.startPos;
                player.Ctlcontrols.play();

                subtitles.Clear();
            }
        }

        public void SetMap(IMap inp_map)
        {
            map = inp_map;
        }

        private void TimerTick(Object o, EventArgs e)
        {
            curPos = (int) player.Ctlcontrols.currentPosition;
            if (prevPos < curPos)
            {
                if (curPos == map.finishPos)
                    player.Ctlcontrols.stop();
                prevPos = curPos;
                if (map.dict.ContainsKey(curPos))
                {
                    subtitles.Text += map.dict[curPos] + Environment.NewLine;
                    subtitles.SelectionStart = subtitles.Text.Length;
                    subtitles.ScrollToCaret();
                }
            }
        }
    }
}
