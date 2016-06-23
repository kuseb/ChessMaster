namespace Client
{
    partial class SingleplayerForm
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newGameButton.Location = new System.Drawing.Point(70, 14);
            this.newGameButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(143, 56);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "NEW GAME";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(70, 94);
            this.continueButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(143, 56);
            this.continueButton.TabIndex = 1;
            this.continueButton.Text = "CONTINUE";
            this.continueButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(70, 176);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(143, 56);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "LOAD GAME";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(70, 257);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(143, 56);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // SingleplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 324);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.newGameButton);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleplayerForm";
            this.Text = "Single-player";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button exitButton;
    }
}