namespace GameViewControl.Promotion
{
    partial class PromotionForm
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
            this.queenButton = new System.Windows.Forms.Button();
            this.knightButton = new System.Windows.Forms.Button();
            this.rookButton = new System.Windows.Forms.Button();
            this.bishopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your pawn is promoted! \n Choose your piece!";
            // 
            // queenButton
            // 
            this.queenButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.queenButton.Location = new System.Drawing.Point(12, 108);
            this.queenButton.Name = "queenButton";
            this.queenButton.Size = new System.Drawing.Size(84, 71);
            this.queenButton.TabIndex = 1;
            this.queenButton.Text = "Queen";
            this.queenButton.UseVisualStyleBackColor = true;
            this.queenButton.Click += new System.EventHandler(this.queenButton_Click);
            // 
            // knightButton
            // 
            this.knightButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.knightButton.Location = new System.Drawing.Point(102, 108);
            this.knightButton.Name = "knightButton";
            this.knightButton.Size = new System.Drawing.Size(84, 71);
            this.knightButton.TabIndex = 2;
            this.knightButton.Text = "Knight";
            this.knightButton.UseVisualStyleBackColor = true;
            this.knightButton.Click += new System.EventHandler(this.knightButton_Click);
            // 
            // rookButton
            // 
            this.rookButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rookButton.Location = new System.Drawing.Point(192, 108);
            this.rookButton.Name = "rookButton";
            this.rookButton.Size = new System.Drawing.Size(84, 71);
            this.rookButton.TabIndex = 3;
            this.rookButton.Text = "Rook";
            this.rookButton.UseVisualStyleBackColor = true;
            this.rookButton.Click += new System.EventHandler(this.rookButton_Click);
            // 
            // bishopButton
            // 
            this.bishopButton.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bishopButton.Location = new System.Drawing.Point(282, 108);
            this.bishopButton.Name = "bishopButton";
            this.bishopButton.Size = new System.Drawing.Size(84, 71);
            this.bishopButton.TabIndex = 4;
            this.bishopButton.Text = "Bishop";
            this.bishopButton.UseVisualStyleBackColor = true;
            this.bishopButton.Click += new System.EventHandler(this.bishopButton_Click);
            // 
            // PromotionForm
            // 
            this.ClientSize = new System.Drawing.Size(375, 191);
            this.Controls.Add(this.bishopButton);
            this.Controls.Add(this.rookButton);
            this.Controls.Add(this.knightButton);
            this.Controls.Add(this.queenButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromotionForm";
            this.Text = "Promotion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button queenButton;
        private System.Windows.Forms.Button knightButton;
        private System.Windows.Forms.Button rookButton;
        private System.Windows.Forms.Button bishopButton;
        private System.Windows.Forms.Label label1;
    }
}