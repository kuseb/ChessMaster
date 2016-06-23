namespace Client
{
    partial class MainForm
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
            this.singleplayerButton = new System.Windows.Forms.Button();
            this.multiplayerButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.nickLabel = new System.Windows.Forms.Label();
            this.facePictureBox = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // singleplayerButton
            // 
            this.singleplayerButton.Location = new System.Drawing.Point(77, 244);
            this.singleplayerButton.Name = "singleplayerButton";
            this.singleplayerButton.Size = new System.Drawing.Size(272, 46);
            this.singleplayerButton.TabIndex = 1;
            this.singleplayerButton.Text = "SINGLE-PLAYER";
            this.singleplayerButton.UseVisualStyleBackColor = true;
            this.singleplayerButton.Click += new System.EventHandler(this.singleplayerButton_Click);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.Location = new System.Drawing.Point(77, 192);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new System.Drawing.Size(272, 46);
            this.multiplayerButton.TabIndex = 2;
            this.multiplayerButton.Text = "MULTIPLAYER";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new System.EventHandler(this.multiplayerButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(77, 296);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(272, 46);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "OPTIONS";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(77, 348);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(272, 46);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // nickLabel
            // 
            this.nickLabel.AutoSize = true;
            this.nickLabel.Location = new System.Drawing.Point(350, 65);
            this.nickLabel.Name = "nickLabel";
            this.nickLabel.Size = new System.Drawing.Size(41, 13);
            this.nickLabel.TabIndex = 6;
            this.nickLabel.Text = "anonim";
            // 
            // facePictureBox
            // 
            this.facePictureBox.Image = global::Client.Properties.Resources.avatar;
            this.facePictureBox.Location = new System.Drawing.Point(339, 12);
            this.facePictureBox.Name = "facePictureBox";
            this.facePictureBox.Size = new System.Drawing.Size(59, 50);
            this.facePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.facePictureBox.TabIndex = 4;
            this.facePictureBox.TabStop = false;
            this.facePictureBox.Click += new System.EventHandler(this.facePictureBox_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::Client.Properties.Resources.Chess;
            this.logoPictureBox.Location = new System.Drawing.Point(106, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(210, 160);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.WaitOnLoad = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 406);
            this.Controls.Add(this.nickLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.facePictureBox);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.multiplayerButton);
            this.Controls.Add(this.singleplayerButton);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "ChessMaster";
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button singleplayerButton;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.PictureBox facePictureBox;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label nickLabel;
    }
}

