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
    public partial class FormSaveMap : Form
    {
        public string VideoURL;
        public string SceneName;
        public int Pos1;
        public int Pos2;

        public FormSaveMap()
        {
            InitializeComponent();
        }

        private void textBoxVideoURL_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBoxVideoURL.Text) == true)
            {
                textBoxVideoURL.ForeColor = Color.Green;
            }
            else
            {
                textBoxVideoURL.ForeColor = Color.Red;
            }
        }

        private void textBoxStartingPos_TextChanged(object sender, EventArgs e)
        {
            int startPos;
            if (Int32.TryParse(textBoxStartingPos.Text, out startPos) == true)
            {
                textBoxStartingPos.ForeColor = Color.Green;
            }
            else
            {
                textBoxStartingPos.ForeColor = Color.Red;
            }
        }

        private void textBoxFinishPosition_TextChanged(object sender, EventArgs e)
        {
            int finishPos;
            if (Int32.TryParse(textBoxFinishPosition.Text, out finishPos) == true)
            {
                textBoxFinishPosition.ForeColor = Color.Green;
            }
            else
            {
                textBoxFinishPosition.ForeColor = Color.Red;
            }
        }

        private void textBoxMapName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMapName.Text.Length > 0)
            {
                textBoxMapName.BackColor = Color.White;
            }
            else
            {
                textBoxMapName.BackColor = Color.Red;
            }
        }

        public void ShowXY(string videoURL, int finishPos)
        {
            this.textBoxVideoURL.Text = videoURL;
            this.textBoxStartingPos.Text = "0";
            this.textBoxFinishPosition.Text = finishPos.ToString();
            this.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int pos;
            if (Int32.TryParse(textBoxStartingPos.Text, out pos) == true)
            {
                Pos1 = pos;
                if (Int32.TryParse(textBoxFinishPosition.Text, out pos) == true)
                {
                    Pos2 = pos;
                    if (File.Exists(textBoxVideoURL.Text) == true)
                    {
                        VideoURL = textBoxVideoURL.Text;
                        if (textBoxMapName.Text.Length > 0)
                        {
                            SceneName = textBoxMapName.Text;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                            MessageBox.Show("Incorrect map name");
                    }
                    else
                        MessageBox.Show("Incorrect video URL");
                }
                else
                    MessageBox.Show("Incorrect finish position");
            }
            else
                MessageBox.Show("Incorrect starting position");
        }

        private void FormSaveMap_Load(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
