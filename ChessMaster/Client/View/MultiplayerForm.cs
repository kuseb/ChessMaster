using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Client.View
{
    public partial class MultiplayerForm : Form
    {
        public MultiplayerForm()
        {
            InitializeComponent();
        }

        private void player1SignInUpButton_Click(object sender, EventArgs e)
        {
            LoginForm lf=new LoginForm();
            lf.Show();
        }

        private void player2SignInUpButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            int timeout = 0;
            if (limitedRadioButton.Checked)
                timeout = (int)numericUpDown.Value;

            var gameWindow = new GameViewControl.GameWindow(player1NickTextBox.Text,player2NickTextBox.Text,timeout);
            ElementHost.EnableModelessKeyboardInterop(gameWindow);
            gameWindow.Show();
        }
    }
}
