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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            MenuChose();
            mainToolStripMenuItem.Checked = true;
        }

        private void MenuChose()
        {
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = true;
            label1.Text = "Resolution:";
            resolutionTrackBar.Visible = true;
        }

        private void MultiplayerChose()
        {
            label2.Visible = true;
            label2.Text = "Server port:";
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label1.Text = "Server IP:";
            resolutionTrackBar.Visible = false;
        }

        private void SingleplayerChose()
        {
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = true;
            label1.Text = "Difficulty:";
            resolutionTrackBar.Visible = true;
        }

        private void singleplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multiplayerToolStripMenuItem.Checked = mainToolStripMenuItem.Checked = false;
            singleplayerToolStripMenuItem.Checked = true;
            SingleplayerChose();
        }

        private void multiplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            singleplayerToolStripMenuItem.Checked = mainToolStripMenuItem.Checked = false;
            multiplayerToolStripMenuItem.Checked = true;
            MultiplayerChose();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multiplayerToolStripMenuItem.Checked = singleplayerToolStripMenuItem.Checked = false;
            multiplayerToolStripMenuItem.Checked = true;
            MenuChose();
        }
    }
}
