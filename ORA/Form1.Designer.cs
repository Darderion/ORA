namespace ORA
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxVideoURL = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResumePause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.editorPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelCurrentPos = new System.Windows.Forms.Label();
            this.textBoxSubtitle = new System.Windows.Forms.TextBox();
            this.editorTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonScroll5s = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Location = new System.Drawing.Point(72, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(706, 523);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonScroll5s);
            this.tabPage2.Controls.Add(this.textBoxSubtitle);
            this.tabPage2.Controls.Add(this.labelCurrentPos);
            this.tabPage2.Controls.Add(this.editorPlayer);
            this.tabPage2.Controls.Add(this.buttonPlay);
            this.tabPage2.Controls.Add(this.buttonResumePause);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBoxVideoURL);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video URL";
            // 
            // buttonResumePause
            // 
            this.buttonResumePause.Location = new System.Drawing.Point(121, 52);
            this.buttonResumePause.Name = "buttonResumePause";
            this.buttonResumePause.Size = new System.Drawing.Size(57, 23);
            this.buttonResumePause.TabIndex = 2;
            this.buttonResumePause.Text = "Resume";
            this.buttonResumePause.UseVisualStyleBackColor = true;
            this.buttonResumePause.Click += new System.EventHandler(this.buttonResumePause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(6, 52);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(109, 23);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Play from start";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
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
            // labelCurrentPos
            // 
            this.labelCurrentPos.AutoSize = true;
            this.labelCurrentPos.Location = new System.Drawing.Point(6, 481);
            this.labelCurrentPos.Name = "labelCurrentPos";
            this.labelCurrentPos.Size = new System.Drawing.Size(31, 13);
            this.labelCurrentPos.TabIndex = 5;
            this.labelCurrentPos.Text = "$$$$";
            // 
            // textBoxSubtitle
            // 
            this.textBoxSubtitle.Enabled = false;
            this.textBoxSubtitle.Location = new System.Drawing.Point(6, 458);
            this.textBoxSubtitle.Name = "textBoxSubtitle";
            this.textBoxSubtitle.Size = new System.Drawing.Size(237, 20);
            this.textBoxSubtitle.TabIndex = 6;
            // 
            // editorTimer
            // 
            this.editorTimer.Interval = 250;
            this.editorTimer.Tick += new System.EventHandler(this.editorTimer_Tick);
            // 
            // buttonScroll5s
            // 
            this.buttonScroll5s.Location = new System.Drawing.Point(183, 52);
            this.buttonScroll5s.Name = "buttonScroll5s";
            this.buttonScroll5s.Size = new System.Drawing.Size(57, 23);
            this.buttonScroll5s.TabIndex = 7;
            this.buttonScroll5s.Text = "<-";
            this.buttonScroll5s.UseVisualStyleBackColor = true;
            this.buttonScroll5s.Click += new System.EventHandler(this.buttonScroll5s_Click);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxVideoURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonResumePause;
        private System.Windows.Forms.Button buttonPlay;
        private AxWMPLib.AxWindowsMediaPlayer editorPlayer;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.Label labelCurrentPos;
        private System.Windows.Forms.Timer editorTimer;
        private System.Windows.Forms.Button buttonScroll5s;
    }
}

