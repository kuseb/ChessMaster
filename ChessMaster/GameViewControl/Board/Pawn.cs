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

using System.Windows.Media.Animation;

namespace GameViewControl.Board
{
    public class Pawn:Piece
    {
        public Pawn(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard) : base(model, coordinates, chessColor,chessBoard) { }
    
        public bool LastTwice { get; set; }

        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list = new List<Point>();
          
            if (first)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (Coordinates.X+i*colorFactor<8 && Coordinates.X+i*colorFactor>=0 && square[(int)(Coordinates.X + i*colorFactor+colorFactor), (int)(Coordinates.Y)].IsFree)
                        list.Add(new Point(Coordinates.X + i*colorFactor+colorFactor, Coordinates.Y));
                    else
                        break;
                }
            }
            else
            {
                if (Coordinates.X +colorFactor< 8 &&  Coordinates.X-colorFactor>=0 && square[(int) (Coordinates.X + colorFactor), (int) (Coordinates.Y)].IsFree)
                    list.Add(new Point(Coordinates.X+colorFactor,Coordinates.Y));
            }

         

            if (!(Coordinates.X + colorFactor < 8) || !(Coordinates.X + colorFactor >= 0)) return list;

            if (
                Coordinates.Y + colorFactor < 8 && Coordinates.Y + colorFactor >= 0 &&
                !square[(int) (Coordinates.X) + colorFactor, (int) (Coordinates.Y) + colorFactor].IsFree &&
                square[(int) (Coordinates.X) + colorFactor, (int) (Coordinates.Y) + colorFactor].PieceColor !=
                ChessColor)
                list.Add(new Point(Coordinates.X + colorFactor, Coordinates.Y + colorFactor));

            if (Coordinates.Y - colorFactor >= 0 && Coordinates.Y - colorFactor < 8 &&
                !square[(int) (Coordinates.X + colorFactor), (int) (Coordinates.Y) - colorFactor].IsFree &&
                square[(int) (Coordinates.X + colorFactor), (int) (Coordinates.Y) - colorFactor].PieceColor != ChessColor)
                list.Add(new Point(Coordinates.X + colorFactor, Coordinates.Y - colorFactor));

           
            return list;
        }

       
    }
}
