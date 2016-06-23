using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UserForm : Form
    {
        private User user;
        public UserForm()
        {
            InitializeComponent();
            user = new User();
        }

        public UserForm(User user)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(this.UserForm_Closed);
            this.user = user;
            Initialize();
        }

        private void Initialize()
        {
            nickLabel.Text = user.Nick;
            userMailLabel.Text = user.Mail;
            userRankingLabel.Text = user.Ranking.ToString();
            userPointsLabel.Text = user.Points.ToString();
            userDesignationLabel.Text = user.Designation;
            if(user.Password!=null)
                userPasswordLabel.Text = new String('*', user.Password.Length);
        }

        private void userMailLabel_Click(object sender, EventArgs e)
        {
            ChangeForm cf = new ChangeForm("new mail:", false, user);
            cf.Show();
            cf.FormClosed += new FormClosedEventHandler(this.ChangeForm_FormClosed);
           
        }

        private void userPasswordLabel_Click(object sender, EventArgs e)
        {
            ChangeForm cf = new ChangeForm("new password:", true, user);
            cf.Show();
            cf.FormClosed += new FormClosedEventHandler(this.ChangeForm_FormClosed);
        }

        private void ChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DataBuffer.actualUser != null)
            {
                user.Mail = DataBuffer.actualUser.Mail;
                user.Password = DataBuffer.actualUser.Password;
                userMailLabel.Text = user.Mail;
                userPasswordLabel.Text = new String('*', user.Password.Length);
            }
        }

        private void avatarPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Browse your avatar";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    user.Avatar = openFileDialog1.FileName;
                    avatarPictureBox.Image = Image.FromFile(user.Avatar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    avatarPictureBox.Image = global::Client.Properties.Resources.avatar;
                }
            }
        }

        private void UserForm_Closed(object sender, FormClosedEventArgs e)
        {
            DataBuffer.actualUser = user;
        }
    }
}
