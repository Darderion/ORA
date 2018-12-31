using AxWMPLib;
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
    public partial class FormLoadMap : Form
    {
        List<Map> maps;
        public Map currentMap;

        public FormLoadMap()
        {
            InitializeComponent();
        }

        public void ShowListMaps()
        {
            listBoxMaps.Items.Clear();
            for (int i = 0; i < maps.Count; i++)
            {
                listBoxMaps.Items.Add(maps[i].Name);
            }
        }

        public void ShowListSubtitles(Map map)
        {
            listBoxSubtitles.Items.Clear();
            List<Subtitle> subs = map.subtitles.ToList();
            for(int i = 0; i < subs.Count; i++)
            {
                listBoxSubtitles.Items.Add("["+subs[i].pos+"] : "+subs[i].text);
            }
        }

        private void FormLoadMap_Load(object sender, EventArgs e)
        {
            listBoxMaps.Items.Clear();
            listBoxSubtitles.Items.Clear();
            using (var db = new TMapContext())
            {
                maps = db.Maps.ToList();
                ShowListMaps();
            }
            currentMap = new Map();
            currentMap.Name = "None";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Map map = Map.Load(listBoxMaps.Items[listBoxMaps.SelectedIndex].ToString());
            if(listBoxMaps.SelectedIndex != -1)
            {
                if (File.Exists(map.VideoURL) == true)
                {
                    editorPlayer.URL = map.VideoURL;
                    ShowListSubtitles(map);
                    currentMap = map;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            editorPlayer.Ctlcontrols.pause();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((currentMap != null) && (currentMap.Name != "None") == true)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            editorPlayer.Ctlcontrols.play();
        }
    }
}
