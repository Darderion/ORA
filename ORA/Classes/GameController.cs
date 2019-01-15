using AxWMPLib;
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
        public GameController(AxWindowsMediaPlayer inp_player, Button inp_button, RichTextBox inp_textBoxSubtitles)
        {
            player = inp_player;
            controlButton = inp_button;
            subtitles = inp_textBoxSubtitles;
            Ini();
        }

        IMap map;
        int curPos = 0;
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

        public void SetMap(IMap inp_map)
        {
            map = inp_map;
        }

        private void TimerTick(Object o, EventArgs e)
        {
            curPos = (int) player.Ctlcontrols.currentPosition;
        }
    }
}
