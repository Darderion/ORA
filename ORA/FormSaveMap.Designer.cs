namespace ORA
{
    partial class FormSaveMap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.textBoxVideoURL = new System.Windows.Forms.TextBox();
            this.textBoxStartingPos = new System.Windows.Forms.TextBox();
            this.textBoxFinishPosition = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "VideoURL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Map Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starting Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "Finish Position";
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Location = new System.Drawing.Point(236, 31);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(629, 42);
            this.textBoxMapName.TabIndex = 4;
            this.textBoxMapName.TextChanged += new System.EventHandler(this.textBoxMapName_TextChanged);
            // 
            // textBoxVideoURL
            // 
            this.textBoxVideoURL.Location = new System.Drawing.Point(236, 79);
            this.textBoxVideoURL.Name = "textBoxVideoURL";
            this.textBoxVideoURL.Size = new System.Drawing.Size(629, 42);
            this.textBoxVideoURL.TabIndex = 5;
            this.textBoxVideoURL.TextChanged += new System.EventHandler(this.textBoxVideoURL_TextChanged);
            // 
            // textBoxStartingPos
            // 
            this.textBoxStartingPos.Location = new System.Drawing.Point(346, 136);
            this.textBoxStartingPos.Name = "textBoxStartingPos";
            this.textBoxStartingPos.Size = new System.Drawing.Size(137, 42);
            this.textBoxStartingPos.TabIndex = 6;
            this.textBoxStartingPos.TextChanged += new System.EventHandler(this.textBoxStartingPos_TextChanged);
            // 
            // textBoxFinishPosition
            // 
            this.textBoxFinishPosition.Location = new System.Drawing.Point(346, 192);
            this.textBoxFinishPosition.Name = "textBoxFinishPosition";
            this.textBoxFinishPosition.Size = new System.Drawing.Size(137, 42);
            this.textBoxFinishPosition.TabIndex = 7;
            this.textBoxFinishPosition.TextChanged += new System.EventHandler(this.textBoxFinishPosition_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(489, 136);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(217, 98);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(712, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(153, 98);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormSaveMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(21F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(877, 269);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxFinishPosition);
            this.Controls.Add(this.textBoxStartingPos);
            this.Controls.Add(this.textBoxVideoURL);
            this.Controls.Add(this.textBoxMapName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Splash", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "FormSaveMap";
            this.Text = "FormSaveMap";
            this.Load += new System.EventHandler(this.FormSaveMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.TextBox textBoxVideoURL;
        private System.Windows.Forms.TextBox textBoxStartingPos;
        private System.Windows.Forms.TextBox textBoxFinishPosition;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}