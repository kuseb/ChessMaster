using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;


namespace Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (nickSignInTextBox.Text == "" || passwordSignInTextBox.Text == "")
            {
                MessageBox.Show("Wrong nick or password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataBuffer.actualUser = new User(nickSignInTextBox.Text);
            this.Close();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (nickSignUpTextBox.Text == "" || passwordSignUpTextBox.Text == "" || mailSignUpTextBox.Text == "")
            {
                MessageBox.Show("Existing nick or wrong format of password or e-mail", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SecureString ss = new SecureString();
            foreach (char c in passwordSignUpTextBox.Text)
                ss.AppendChar(c);

            DataBuffer.actualUser = new User(nickSignUpTextBox.Text, mailSignUpTextBox.Text,ss);
            this.Close();
        }
    }
}
