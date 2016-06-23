using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Media.Media3D;

namespace GameViewControl.Board
{
    public class Square:Element,ISquareInterface
    {
        public Square(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, bool isFree) : base(model, coordinates, chessColor) { this.IsFree = isFree; }

        public bool IsFree { get; set; }
        public Board.ChessBoard.Color PieceColor { get; set; }
        public void Mark()
        {
            double amount = 0.5;
            Color surfaceColor = ChessColor == ChessBoard.Color.Black ? Colors.Black : Colors.White;

            byte r = (byte) (surfaceColor.R*amount + MarkColor.R*(1 - amount));
            byte g = (byte) (surfaceColor.G*amount + MarkColor.G*(1 - amount));
            byte b = (byte) (surfaceColor.B*amount + MarkColor.B*(1 - amount));


            Model.Material = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(r, g, b)));
        }

        public void BattleMark()
        {
            double amount = 0.5;
            Color surfaceColor = ChessColor == ChessBoard.Color.Black ? Colors.Black : Colors.White;

            byte r = (byte)(surfaceColor.R * amount + BattleColor.R * (1 - amount));
            byte g = (byte)(surfaceColor.G * amount + BattleColor.G * (1 - amount));
            byte b = (byte)(surfaceColor.B * amount + BattleColor.B * (1 - amount));


            Model.Material = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(r, g, b)));
        }

        public void UnMark()
        {
            Model.Material = defaultMaterial;
        }

    }
}
