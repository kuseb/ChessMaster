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
    class King:Piece
    {
        public King(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard)
            : base(model, coordinates, chessColor,chessBoard)
        {
            Group.Children.Add(new TranslateTransform3D(0.6, 0, 0));
            Model.Transform = Group;
            bounds = Model.Bounds;
        }

        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list=new List<Point>();

            if (Coordinates.Y - 1 >= 0)
            {
                for (int i = 0; i < 3; i++)
                    if (Coordinates.X-1+i>=0 && Coordinates.X-1+i<8 && (square[(int)Coordinates.X-1+i,(int)Coordinates.Y-1].IsFree || (!square[(int)Coordinates.X - 1 + i, (int)Coordinates.Y - 1].IsFree && square[(int)Coordinates.X - 1 + i, (int)Coordinates.Y - 1].PieceColor!=ChessColor)))
                        list.Add(new Point(Coordinates.X-1+i,Coordinates.Y-1));
            }

            if (Coordinates.Y + 1 >= 0)
            {
                for (int i = 0; i < 3; i++)
                    if (Coordinates.X - 1 + i >= 0 && Coordinates.X - 1 + i < 8 && (square[(int)Coordinates.X - 1 + i, (int)Coordinates.Y + 1].IsFree || (!square[(int)Coordinates.X - 1 + i, (int)Coordinates.Y + 1].IsFree && square[(int)Coordinates.X - 1 + i, (int)Coordinates.Y + 1].PieceColor!=ChessColor)))
                        list.Add(new Point(Coordinates.X - 1 + i, Coordinates.Y + 1));
            }

            if(Coordinates.X+1<8 && (square[(int)Coordinates.X+1,(int)Coordinates.Y].IsFree || (!square[(int)Coordinates.X + 1, (int)Coordinates.Y].IsFree && square[(int)Coordinates.X + 1, (int)Coordinates.Y].PieceColor!=ChessColor)))
                list.Add(new Point(Coordinates.X + 1, Coordinates.Y));


            if (Coordinates.X - 1 >=0 && (square[(int)Coordinates.X - 1, (int)Coordinates.Y].IsFree || (!square[(int)Coordinates.X - 1, (int)Coordinates.Y].IsFree && square[(int)Coordinates.X - 1, (int)Coordinates.Y].PieceColor!=ChessColor)))
                list.Add(new Point(Coordinates.X - 1, Coordinates.Y));

            return list;
        }

       
    }
}
