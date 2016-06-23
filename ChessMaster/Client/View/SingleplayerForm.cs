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

namespace Client
{
    public partial class SingleplayerForm : Form
    {
        public SingleplayerForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            var gameWindow = new GameViewControl.GameWindow();
            ElementHost.EnableModelessKeyboardInterop(gameWindow);
            gameWindow.Show();
            //GameForm gf = new GameForm();
            //gf.Show();
        }
    }
}
