using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameViewControl.Promotion
{
    public partial class PromotionForm : Form
    {
        public PromotionPiece Value { get; private set; }

        public enum PromotionPiece
        {
            ROOK=0, KNIGHT, BISHOP, QUEEN
        }

        public PromotionForm()
        {
            InitializeComponent();
        }

        private void rookButton_Click(object sender, EventArgs e)
        {
            Value = PromotionPiece.ROOK;
            this.Close();
        }

        private void knightButton_Click(object sender, EventArgs e)
        {
            Value=PromotionPiece.KNIGHT;
            this.Close();
        }

        private void bishopButton_Click(object sender, EventArgs e)
        {
            Value=PromotionPiece.BISHOP;
            this.Close();
        }

        private void queenButton_Click(object sender, EventArgs e)
        {
            Value=PromotionPiece.QUEEN;
            this.Close();
        }
    }
}
