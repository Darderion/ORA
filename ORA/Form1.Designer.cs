﻿namespace ORA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonControl = new System.Windows.Forms.Button();
			this.gameMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonThumbnail = new System.Windows.Forms.Button();
			this.textBoxVideoTimer = new System.Windows.Forms.TextBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonScroll5s = new System.Windows.Forms.Button();
			this.buttonEditorView = new System.Windows.Forms.Button();
			this.listBoxEditor = new System.Windows.Forms.ListBox();
			this.buttonScroll1s = new System.Windows.Forms.Button();
			this.textBoxSubtitle = new System.Windows.Forms.TextBox();
			this.editorPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.buttonResumePause = new System.Windows.Forms.Button();
			this.labelVideoURL = new System.Windows.Forms.Label();
			this.textBoxVideoURL = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.labelStopWatchResult = new System.Windows.Forms.Label();
			this.editorTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureBoxResult = new System.Windows.Forms.PictureBox();
			this.mainTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gameMediaPlayer)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).BeginInit();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
			this.SuspendLayout();
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.tabPage1);
			this.mainTabControl.Controls.Add(this.tabPage2);
			this.mainTabControl.Controls.Add(this.tabPage3);
			this.mainTabControl.Controls.Add(this.tabPage4);
			this.mainTabControl.Controls.Add(this.tabPage5);
			this.mainTabControl.Location = new System.Drawing.Point(72, 12);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(706, 523);
			this.mainTabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.buttonControl);
			this.tabPage1.Controls.Add(this.gameMediaPlayer);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(698, 497);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPagePlayer";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonControl
			// 
			this.buttonControl.Location = new System.Drawing.Point(638, 264);
			this.buttonControl.Name = "buttonControl";
			this.buttonControl.Size = new System.Drawing.Size(60, 40);
			this.buttonControl.TabIndex = 2;
			this.buttonControl.Text = "Type";
			this.buttonControl.UseVisualStyleBackColor = true;
			// 
			// gameMediaPlayer
			// 
			this.gameMediaPlayer.Enabled = true;
			this.gameMediaPlayer.Location = new System.Drawing.Point(6, 32);
			this.gameMediaPlayer.Name = "gameMediaPlayer";
			this.gameMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("gameMediaPlayer.OcxState")));
			this.gameMediaPlayer.Size = new System.Drawing.Size(330, 182);
			this.gameMediaPlayer.TabIndex = 1;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.buttonThumbnail);
			this.tabPage2.Controls.Add(this.textBoxVideoTimer);
			this.tabPage2.Controls.Add(this.buttonLoad);
			this.tabPage2.Controls.Add(this.buttonSave);
			this.tabPage2.Controls.Add(this.buttonScroll5s);
			this.tabPage2.Controls.Add(this.buttonEditorView);
			this.tabPage2.Controls.Add(this.listBoxEditor);
			this.tabPage2.Controls.Add(this.buttonScroll1s);
			this.tabPage2.Controls.Add(this.textBoxSubtitle);
			this.tabPage2.Controls.Add(this.editorPlayer);
			this.tabPage2.Controls.Add(this.buttonPlay);
			this.tabPage2.Controls.Add(this.buttonResumePause);
			this.tabPage2.Controls.Add(this.labelVideoURL);
			this.tabPage2.Controls.Add(this.textBoxVideoURL);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(698, 497);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPageEditor";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// buttonThumbnail
			// 
			this.buttonThumbnail.Location = new System.Drawing.Point(249, 23);
			this.buttonThumbnail.Name = "buttonThumbnail";
			this.buttonThumbnail.Size = new System.Drawing.Size(66, 23);
			this.buttonThumbnail.TabIndex = 14;
			this.buttonThumbnail.Text = "Thumbnail";
			this.buttonThumbnail.UseVisualStyleBackColor = true;
			// 
			// textBoxVideoTimer
			// 
			this.textBoxVideoTimer.Enabled = false;
			this.textBoxVideoTimer.Location = new System.Drawing.Point(6, 481);
			this.textBoxVideoTimer.Name = "textBoxVideoTimer";
			this.textBoxVideoTimer.Size = new System.Drawing.Size(28, 20);
			this.textBoxVideoTimer.TabIndex = 13;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(321, 23);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(48, 23);
			this.buttonLoad.TabIndex = 12;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(321, 52);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(48, 23);
			this.buttonSave.TabIndex = 11;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonScroll5s
			// 
			this.buttonScroll5s.Location = new System.Drawing.Point(221, 52);
			this.buttonScroll5s.Name = "buttonScroll5s";
			this.buttonScroll5s.Size = new System.Drawing.Size(40, 23);
			this.buttonScroll5s.TabIndex = 10;
			this.buttonScroll5s.Text = "<<<";
			this.buttonScroll5s.UseVisualStyleBackColor = true;
			this.buttonScroll5s.Click += new System.EventHandler(this.buttonScroll5s_Click);
			// 
			// buttonEditorView
			// 
			this.buttonEditorView.Location = new System.Drawing.Point(267, 52);
			this.buttonEditorView.Name = "buttonEditorView";
			this.buttonEditorView.Size = new System.Drawing.Size(48, 23);
			this.buttonEditorView.TabIndex = 9;
			this.buttonEditorView.Text = "Video";
			this.buttonEditorView.UseVisualStyleBackColor = true;
			this.buttonEditorView.Click += new System.EventHandler(this.buttonEditorView_Click);
			// 
			// listBoxEditor
			// 
			this.listBoxEditor.FormattingEnabled = true;
			this.listBoxEditor.Location = new System.Drawing.Point(21, 94);
			this.listBoxEditor.Name = "listBoxEditor";
			this.listBoxEditor.Size = new System.Drawing.Size(120, 95);
			this.listBoxEditor.TabIndex = 8;
			this.listBoxEditor.Visible = false;
			this.listBoxEditor.SelectedIndexChanged += new System.EventHandler(this.listBoxEditor_SelectedIndexChanged);
			this.listBoxEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxEditor_KeyDown);
			// 
			// buttonScroll1s
			// 
			this.buttonScroll1s.Location = new System.Drawing.Point(183, 52);
			this.buttonScroll1s.Name = "buttonScroll1s";
			this.buttonScroll1s.Size = new System.Drawing.Size(32, 23);
			this.buttonScroll1s.TabIndex = 7;
			this.buttonScroll1s.Text = "<-";
			this.buttonScroll1s.UseVisualStyleBackColor = true;
			this.buttonScroll1s.Click += new System.EventHandler(this.buttonScroll1s_Click);
			// 
			// textBoxSubtitle
			// 
			this.textBoxSubtitle.Enabled = false;
			this.textBoxSubtitle.Location = new System.Drawing.Point(6, 458);
			this.textBoxSubtitle.Name = "textBoxSubtitle";
			this.textBoxSubtitle.Size = new System.Drawing.Size(237, 20);
			this.textBoxSubtitle.TabIndex = 6;
			this.textBoxSubtitle.TextChanged += new System.EventHandler(this.textBoxSubtitle_TextChanged);
			this.textBoxSubtitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSubtitle_KeyDown);
			// 
			// editorPlayer
			// 
			this.editorPlayer.Enabled = true;
			this.editorPlayer.Location = new System.Drawing.Point(6, 81);
			this.editorPlayer.Name = "editorPlayer";
			this.editorPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("editorPlayer.OcxState")));
			this.editorPlayer.Size = new System.Drawing.Size(234, 199);
			this.editorPlayer.TabIndex = 4;
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(6, 52);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(109, 23);
			this.buttonPlay.TabIndex = 3;
			this.buttonPlay.Text = "Play from start";
			this.buttonPlay.UseVisualStyleBackColor = true;
			// 
			// buttonResumePause
			// 
			this.buttonResumePause.Location = new System.Drawing.Point(121, 52);
			this.buttonResumePause.Name = "buttonResumePause";
			this.buttonResumePause.Size = new System.Drawing.Size(57, 23);
			this.buttonResumePause.TabIndex = 2;
			this.buttonResumePause.Text = "Resume";
			this.buttonResumePause.UseVisualStyleBackColor = true;
			// 
			// labelVideoURL
			// 
			this.labelVideoURL.AutoSize = true;
			this.labelVideoURL.Location = new System.Drawing.Point(6, 10);
			this.labelVideoURL.Name = "labelVideoURL";
			this.labelVideoURL.Size = new System.Drawing.Size(59, 13);
			this.labelVideoURL.TabIndex = 1;
			this.labelVideoURL.Text = "Video URL";
			// 
			// textBoxVideoURL
			// 
			this.textBoxVideoURL.Location = new System.Drawing.Point(6, 26);
			this.textBoxVideoURL.Name = "textBoxVideoURL";
			this.textBoxVideoURL.Size = new System.Drawing.Size(237, 20);
			this.textBoxVideoURL.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(698, 497);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPageSettings";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(698, 497);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "tabPageMaps";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.pictureBoxResult);
			this.tabPage5.Controls.Add(this.labelStopWatchResult);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(698, 497);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "tabPageResults";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// labelStopWatchResult
			// 
			this.labelStopWatchResult.AutoSize = true;
			this.labelStopWatchResult.Location = new System.Drawing.Point(20, 19);
			this.labelStopWatchResult.Name = "labelStopWatchResult";
			this.labelStopWatchResult.Size = new System.Drawing.Size(113, 13);
			this.labelStopWatchResult.TabIndex = 0;
			this.labelStopWatchResult.Text = "labelStopWatchResult";
			// 
			// editorTimer
			// 
			this.editorTimer.Interval = 250;
			this.editorTimer.Tick += new System.EventHandler(this.editorTimer_Tick);
			// 
			// pictureBoxResult
			// 
			this.pictureBoxResult.Location = new System.Drawing.Point(23, 44);
			this.pictureBoxResult.Name = "pictureBoxResult";
			this.pictureBoxResult.Size = new System.Drawing.Size(100, 50);
			this.pictureBoxResult.TabIndex = 1;
			this.pictureBoxResult.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 547);
			this.Controls.Add(this.mainTabControl);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.mainTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gameMediaPlayer)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxVideoURL;
        private System.Windows.Forms.Label labelVideoURL;
        private System.Windows.Forms.Button buttonResumePause;
        private System.Windows.Forms.Button buttonPlay;
        private AxWMPLib.AxWindowsMediaPlayer editorPlayer;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.Timer editorTimer;
        private System.Windows.Forms.Button buttonScroll1s;
        private System.Windows.Forms.Button buttonEditorView;
        private System.Windows.Forms.ListBox listBoxEditor;
        private System.Windows.Forms.Button buttonScroll5s;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxVideoTimer;
        private AxWMPLib.AxWindowsMediaPlayer gameMediaPlayer;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.Button buttonThumbnail;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label labelStopWatchResult;
		private System.Windows.Forms.PictureBox pictureBoxResult;
	}
}

