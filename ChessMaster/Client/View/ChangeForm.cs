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
    public partial class ChangeForm : Form
    {
        private bool isPassword;
        private User user;
        public ChangeForm()
        {
            InitializeComponent();
        }

        public ChangeForm(string label, bool isPassword, User user)
        {
            InitializeComponent();

            changeLabel.Text = label;
            if (isPassword)
                changeTextBox.PasswordChar = '*';

            this.isPassword = isPassword;
            this.user = user;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(isPassword)
            {
                SecureString ss = new SecureString();

                foreach (char c in changeTextBox.Text)
                    ss.AppendChar(c);

                user.Password = ss;
            }
            else
            {
                user.Mail = changeTextBox.Text;
            }
            DataBuffer.actualUser = user;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
