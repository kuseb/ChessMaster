using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.View;

namespace Client
{
    public partial class MainForm : Form
    {
        private User user;
        public MainForm()
        {
            InitializeComponent();

            user = new User();
        }

        private void loginForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (DataBuffer.actualUser != null)
            {
                user = DataBuffer.actualUser;
                DataBuffer.actualUser = null;
                nickLabel.Text = user.Nick;
                if (user.Avatar != null)
                {
                    try
                    {
                        facePictureBox.Image = Image.FromFile(user.Avatar);
                    }
                    catch { facePictureBox.Image = global::Client.Properties.Resources.avatar; }
                }
            }
        }
        private void facePictureBox_Click(object sender, EventArgs e)
        {
            if(user.IsAnonymous)
            {
               DialogResult dr=MessageBox.Show("Do you want to sign up/in?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    UserForm userForm = new UserForm();
                    userForm.Show();         
                }
                else if(dr==DialogResult.Yes)
                {
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    loginForm.FormClosed += new FormClosedEventHandler(this.loginForm_Closed);

                }
            }
            else
            {
                UserForm userForm = new UserForm(user);
                userForm.Show();
                userForm.FormClosed+= new FormClosedEventHandler(this.loginForm_Closed);
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void singleplayerButton_Click(object sender, EventArgs e)
        {
            SingleplayerForm sp = new SingleplayerForm();
            sp.Show();
        }

        private void multiplayerButton_Click(object sender, EventArgs e)
        {
            MultiplayerForm mp=new MultiplayerForm();
            mp.Show();
        }
    }
}
