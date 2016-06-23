namespace Client
{
    partial class UserForm
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
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.nickLabel = new System.Windows.Forms.Label();
            this.mailLabel = new System.Windows.Forms.Label();
            this.userMailLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.userPointsLabel = new System.Windows.Forms.Label();
            this.rankingLabel = new System.Windows.Forms.Label();
            this.userRankingLabel = new System.Windows.Forms.Label();
            this.designationLabel = new System.Windows.Forms.Label();
            this.userDesignationLabel = new System.Windows.Forms.Label();
            this.trophyLabel = new System.Windows.Forms.Label();
            this.trophy1PictureBox = new System.Windows.Forms.PictureBox();
            this.trophy2PictureBox = new System.Windows.Forms.PictureBox();
            this.trophy3PictureBox = new System.Windows.Forms.PictureBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userPasswordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy3PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Image = global::Client.Properties.Resources.avatar;
            this.avatarPictureBox.Location = new System.Drawing.Point(14, 14);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(149, 132);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPictureBox.TabIndex = 0;
            this.avatarPictureBox.TabStop = false;
            this.avatarPictureBox.Click += new System.EventHandler(this.avatarPictureBox_Click);
            // 
            // nickLabel
            // 
            this.nickLabel.AutoSize = true;
            this.nickLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nickLabel.Location = new System.Drawing.Point(243, 14);
            this.nickLabel.Name = "nickLabel";
            this.nickLabel.Size = new System.Drawing.Size(83, 30);
            this.nickLabel.TabIndex = 1;
            this.nickLabel.Text = "Anonim";
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mailLabel.Location = new System.Drawing.Point(192, 65);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(54, 20);
            this.mailLabel.TabIndex = 2;
            this.mailLabel.Text = "e-mail:";
            // 
            // userMailLabel
            // 
            this.userMailLabel.AutoSize = true;
            this.userMailLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userMailLabel.Location = new System.Drawing.Point(315, 65);
            this.userMailLabel.Name = "userMailLabel";
            this.userMailLabel.Size = new System.Drawing.Size(18, 20);
            this.userMailLabel.TabIndex = 3;
            this.userMailLabel.Text = "...";
            this.userMailLabel.Click += new System.EventHandler(this.userMailLabel_Click);
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointsLabel.Location = new System.Drawing.Point(192, 149);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(55, 20);
            this.pointsLabel.TabIndex = 4;
            this.pointsLabel.Text = "points:";
            // 
            // userPointsLabel
            // 
            this.userPointsLabel.AutoSize = true;
            this.userPointsLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userPointsLabel.Location = new System.Drawing.Point(315, 149);
            this.userPointsLabel.Name = "userPointsLabel";
            this.userPointsLabel.Size = new System.Drawing.Size(18, 20);
            this.userPointsLabel.TabIndex = 5;
            this.userPointsLabel.Text = "...";
            // 
            // rankingLabel
            // 
            this.rankingLabel.AutoSize = true;
            this.rankingLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rankingLabel.Location = new System.Drawing.Point(192, 189);
            this.rankingLabel.Name = "rankingLabel";
            this.rankingLabel.Size = new System.Drawing.Size(65, 20);
            this.rankingLabel.TabIndex = 6;
            this.rankingLabel.Text = "ranking:";
            // 
            // userRankingLabel
            // 
            this.userRankingLabel.AutoSize = true;
            this.userRankingLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userRankingLabel.Location = new System.Drawing.Point(315, 189);
            this.userRankingLabel.Name = "userRankingLabel";
            this.userRankingLabel.Size = new System.Drawing.Size(18, 20);
            this.userRankingLabel.TabIndex = 7;
            this.userRankingLabel.Text = "...";
            // 
            // designationLabel
            // 
            this.designationLabel.AutoSize = true;
            this.designationLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designationLabel.Location = new System.Drawing.Point(192, 234);
            this.designationLabel.Name = "designationLabel";
            this.designationLabel.Size = new System.Drawing.Size(92, 20);
            this.designationLabel.TabIndex = 8;
            this.designationLabel.Text = "designation:";
            // 
            // userDesignationLabel
            // 
            this.userDesignationLabel.AutoSize = true;
            this.userDesignationLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userDesignationLabel.Location = new System.Drawing.Point(315, 234);
            this.userDesignationLabel.Name = "userDesignationLabel";
            this.userDesignationLabel.Size = new System.Drawing.Size(18, 20);
            this.userDesignationLabel.TabIndex = 9;
            this.userDesignationLabel.Text = "...";
            // 
            // trophyLabel
            // 
            this.trophyLabel.AutoSize = true;
            this.trophyLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trophyLabel.Location = new System.Drawing.Point(56, 149);
            this.trophyLabel.Name = "trophyLabel";
            this.trophyLabel.Size = new System.Drawing.Size(60, 21);
            this.trophyLabel.TabIndex = 10;
            this.trophyLabel.Text = "Trophy";
            // 
            // trophy1PictureBox
            // 
            this.trophy1PictureBox.Location = new System.Drawing.Point(14, 190);
            this.trophy1PictureBox.Name = "trophy1PictureBox";
            this.trophy1PictureBox.Size = new System.Drawing.Size(42, 35);
            this.trophy1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trophy1PictureBox.TabIndex = 11;
            this.trophy1PictureBox.TabStop = false;
            // 
            // trophy2PictureBox
            // 
            this.trophy2PictureBox.Location = new System.Drawing.Point(63, 190);
            this.trophy2PictureBox.Name = "trophy2PictureBox";
            this.trophy2PictureBox.Size = new System.Drawing.Size(42, 36);
            this.trophy2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trophy2PictureBox.TabIndex = 12;
            this.trophy2PictureBox.TabStop = false;
            // 
            // trophy3PictureBox
            // 
            this.trophy3PictureBox.Location = new System.Drawing.Point(112, 189);
            this.trophy3PictureBox.Name = "trophy3PictureBox";
            this.trophy3PictureBox.Size = new System.Drawing.Size(41, 36);
            this.trophy3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trophy3PictureBox.TabIndex = 13;
            this.trophy3PictureBox.TabStop = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordLabel.Location = new System.Drawing.Point(192, 108);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "password:";
            // 
            // userPasswordLabel
            // 
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userPasswordLabel.Location = new System.Drawing.Point(316, 112);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(18, 20);
            this.userPasswordLabel.TabIndex = 15;
            this.userPasswordLabel.Text = "...";
            this.userPasswordLabel.Click += new System.EventHandler(this.userPasswordLabel_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 278);
            this.Controls.Add(this.userPasswordLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.trophy3PictureBox);
            this.Controls.Add(this.trophy2PictureBox);
            this.Controls.Add(this.trophy1PictureBox);
            this.Controls.Add(this.trophyLabel);
            this.Controls.Add(this.userDesignationLabel);
            this.Controls.Add(this.designationLabel);
            this.Controls.Add(this.userRankingLabel);
            this.Controls.Add(this.rankingLabel);
            this.Controls.Add(this.userPointsLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.userMailLabel);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.nickLabel);
            this.Controls.Add(this.avatarPictureBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy3PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label nickLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label userMailLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label userPointsLabel;
        private System.Windows.Forms.Label rankingLabel;
        private System.Windows.Forms.Label userRankingLabel;
        private System.Windows.Forms.Label designationLabel;
        private System.Windows.Forms.Label userDesignationLabel;
        private System.Windows.Forms.Label trophyLabel;
        private System.Windows.Forms.PictureBox trophy1PictureBox;
        private System.Windows.Forms.PictureBox trophy2PictureBox;
        private System.Windows.Forms.PictureBox trophy3PictureBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userPasswordLabel;
    }
}