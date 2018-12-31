namespace ORA
{
    partial class FormLoadMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadMap));
            this.listBoxMaps = new System.Windows.Forms.ListBox();
            this.listBoxSubtitles = new System.Windows.Forms.ListBox();
            this.editorPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelLoadMaps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMaps
            // 
            this.listBoxMaps.FormattingEnabled = true;
            this.listBoxMaps.ItemHeight = 34;
            this.listBoxMaps.Location = new System.Drawing.Point(12, 80);
            this.listBoxMaps.Name = "listBoxMaps";
            this.listBoxMaps.Size = new System.Drawing.Size(325, 480);
            this.listBoxMaps.TabIndex = 0;
            this.listBoxMaps.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBoxSubtitles
            // 
            this.listBoxSubtitles.FormattingEnabled = true;
            this.listBoxSubtitles.ItemHeight = 34;
            this.listBoxSubtitles.Location = new System.Drawing.Point(343, 318);
            this.listBoxSubtitles.Name = "listBoxSubtitles";
            this.listBoxSubtitles.Size = new System.Drawing.Size(329, 242);
            this.listBoxSubtitles.TabIndex = 1;
            // 
            // editorPlayer
            // 
            this.editorPlayer.Enabled = true;
            this.editorPlayer.Location = new System.Drawing.Point(343, 80);
            this.editorPlayer.Name = "editorPlayer";
            this.editorPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("editorPlayer.OcxState")));
            this.editorPlayer.Size = new System.Drawing.Size(329, 184);
            this.editorPlayer.TabIndex = 5;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(581, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 62);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(451, 270);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(91, 42);
            this.buttonPause.TabIndex = 7;
            this.buttonPause.Text = "II";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Splash", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(548, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Steppes TT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(343, 270);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(102, 42);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelLoadMaps
            // 
            this.labelLoadMaps.AutoSize = true;
            this.labelLoadMaps.Font = new System.Drawing.Font("Splash", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadMaps.Location = new System.Drawing.Point(12, 6);
            this.labelLoadMaps.Name = "labelLoadMaps";
            this.labelLoadMaps.Size = new System.Drawing.Size(492, 68);
            this.labelLoadMaps.TabIndex = 10;
            this.labelLoadMaps.Text = "List of Maps";
            // 
            // FormLoadMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(695, 583);
            this.Controls.Add(this.labelLoadMaps);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.editorPlayer);
            this.Controls.Add(this.listBoxSubtitles);
            this.Controls.Add(this.listBoxMaps);
            this.Font = new System.Drawing.Font("Splash", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "FormLoadMap";
            this.Text = "FormLoadMap";
            this.Load += new System.EventHandler(this.FormLoadMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaps;
        private System.Windows.Forms.ListBox listBoxSubtitles;
        private AxWMPLib.AxWindowsMediaPlayer editorPlayer;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelLoadMaps;
    }
}