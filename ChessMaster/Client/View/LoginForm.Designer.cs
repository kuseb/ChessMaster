namespace Client
{
    partial class LoginForm
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
            this.nickSignInLabel = new System.Windows.Forms.Label();
            this.passwordSignInLabel = new System.Windows.Forms.Label();
            this.nickSignInTextBox = new System.Windows.Forms.TextBox();
            this.passwordSignInTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nickSignUpLabel = new System.Windows.Forms.Label();
            this.mailSignUpLabel = new System.Windows.Forms.Label();
            this.passwordSignUpLabel = new System.Windows.Forms.Label();
            this.nickSignUpTextBox = new System.Windows.Forms.TextBox();
            this.mailSignUpTextBox = new System.Windows.Forms.TextBox();
            this.passwordSignUpTextBox = new System.Windows.Forms.TextBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.fbSignInButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fbSignUpButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "or";
            // 
            // nickSignInLabel
            // 
            this.nickSignInLabel.AutoSize = true;
            this.nickSignInLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nickSignInLabel.Location = new System.Drawing.Point(6, 33);
            this.nickSignInLabel.Name = "nickSignInLabel";
            this.nickSignInLabel.Size = new System.Drawing.Size(80, 15);
            this.nickSignInLabel.TabIndex = 1;
            this.nickSignInLabel.Text = "Nick or e-mail";
            // 
            // passwordSignInLabel
            // 
            this.passwordSignInLabel.AutoSize = true;
            this.passwordSignInLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordSignInLabel.Location = new System.Drawing.Point(6, 83);
            this.passwordSignInLabel.Name = "passwordSignInLabel";
            this.passwordSignInLabel.Size = new System.Drawing.Size(54, 15);
            this.passwordSignInLabel.TabIndex = 2;
            this.passwordSignInLabel.Text = "Password";
            // 
            // nickSignInTextBox
            // 
            this.nickSignInTextBox.Location = new System.Drawing.Point(6, 49);
            this.nickSignInTextBox.Name = "nickSignInTextBox";
            this.nickSignInTextBox.Size = new System.Drawing.Size(127, 23);
            this.nickSignInTextBox.TabIndex = 3;
            // 
            // passwordSignInTextBox
            // 
            this.passwordSignInTextBox.Location = new System.Drawing.Point(6, 99);
            this.passwordSignInTextBox.Name = "passwordSignInTextBox";
            this.passwordSignInTextBox.PasswordChar = '*';
            this.passwordSignInTextBox.Size = new System.Drawing.Size(127, 23);
            this.passwordSignInTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fbSignInButton);
            this.groupBox1.Controls.Add(this.signInButton);
            this.groupBox1.Controls.Add(this.nickSignInTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nickSignInLabel);
            this.groupBox1.Controls.Add(this.passwordSignInLabel);
            this.groupBox1.Controls.Add(this.passwordSignInTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 270);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sign In";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fbSignUpButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.signUpButton);
            this.groupBox2.Controls.Add(this.passwordSignUpTextBox);
            this.groupBox2.Controls.Add(this.mailSignUpTextBox);
            this.groupBox2.Controls.Add(this.nickSignUpTextBox);
            this.groupBox2.Controls.Add(this.passwordSignUpLabel);
            this.groupBox2.Controls.Add(this.mailSignUpLabel);
            this.groupBox2.Controls.Add(this.nickSignUpLabel);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(183, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 269);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sign Up";
            // 
            // nickSignUpLabel
            // 
            this.nickSignUpLabel.AutoSize = true;
            this.nickSignUpLabel.Location = new System.Drawing.Point(6, 31);
            this.nickSignUpLabel.Name = "nickSignUpLabel";
            this.nickSignUpLabel.Size = new System.Drawing.Size(32, 15);
            this.nickSignUpLabel.TabIndex = 0;
            this.nickSignUpLabel.Text = "Nick";
            // 
            // mailSignUpLabel
            // 
            this.mailSignUpLabel.AutoSize = true;
            this.mailSignUpLabel.Location = new System.Drawing.Point(10, 82);
            this.mailSignUpLabel.Name = "mailSignUpLabel";
            this.mailSignUpLabel.Size = new System.Drawing.Size(39, 15);
            this.mailSignUpLabel.TabIndex = 1;
            this.mailSignUpLabel.Text = "E-mail";
            // 
            // passwordSignUpLabel
            // 
            this.passwordSignUpLabel.AutoSize = true;
            this.passwordSignUpLabel.Location = new System.Drawing.Point(10, 130);
            this.passwordSignUpLabel.Name = "passwordSignUpLabel";
            this.passwordSignUpLabel.Size = new System.Drawing.Size(54, 15);
            this.passwordSignUpLabel.TabIndex = 2;
            this.passwordSignUpLabel.Text = "Password";
            // 
            // nickSignUpTextBox
            // 
            this.nickSignUpTextBox.Location = new System.Drawing.Point(6, 48);
            this.nickSignUpTextBox.Name = "nickSignUpTextBox";
            this.nickSignUpTextBox.Size = new System.Drawing.Size(126, 23);
            this.nickSignUpTextBox.TabIndex = 3;
            // 
            // mailSignUpTextBox
            // 
            this.mailSignUpTextBox.Location = new System.Drawing.Point(7, 97);
            this.mailSignUpTextBox.Name = "mailSignUpTextBox";
            this.mailSignUpTextBox.Size = new System.Drawing.Size(125, 23);
            this.mailSignUpTextBox.TabIndex = 4;
            // 
            // passwordSignUnTextBox
            // 
            this.passwordSignUpTextBox.Location = new System.Drawing.Point(6, 148);
            this.passwordSignUpTextBox.Name = "passwordSignUnTextBox";
            this.passwordSignUpTextBox.PasswordChar = '*';
            this.passwordSignUpTextBox.Size = new System.Drawing.Size(126, 23);
            this.passwordSignUpTextBox.TabIndex = 5;
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(39, 149);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 23);
            this.signInButton.TabIndex = 5;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // fbSignInButton
            // 
            this.fbSignInButton.Location = new System.Drawing.Point(7, 241);
            this.fbSignInButton.Name = "fbSignInButton";
            this.fbSignInButton.Size = new System.Drawing.Size(152, 23);
            this.fbSignInButton.TabIndex = 6;
            this.fbSignInButton.Text = "Login with Facebook";
            this.fbSignInButton.UseVisualStyleBackColor = true;
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(40, 177);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 6;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "or";
            // 
            // fbSignUpButton
            // 
            this.fbSignUpButton.Location = new System.Drawing.Point(9, 240);
            this.fbSignUpButton.Name = "fbSignUpButton";
            this.fbSignUpButton.Size = new System.Drawing.Size(151, 23);
            this.fbSignUpButton.TabIndex = 8;
            this.fbSignUpButton.Text = "Sign Up with Facebook";
            this.fbSignUpButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 294);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Sign In/Up";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nickSignInLabel;
        private System.Windows.Forms.Label passwordSignInLabel;
        private System.Windows.Forms.TextBox nickSignInTextBox;
        private System.Windows.Forms.TextBox passwordSignInTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button fbSignInButton;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button fbSignUpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.TextBox passwordSignUpTextBox;
        private System.Windows.Forms.TextBox mailSignUpTextBox;
        private System.Windows.Forms.TextBox nickSignUpTextBox;
        private System.Windows.Forms.Label passwordSignUpLabel;
        private System.Windows.Forms.Label mailSignUpLabel;
        private System.Windows.Forms.Label nickSignUpLabel;
    }
}