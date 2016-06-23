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
    class Rook:Piece
    {
        public Rook(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard) : base(model, coordinates, chessColor,chessBoard) { }
        protected Rook(Rook piece, ChessBoard chessBoard) :this(piece.Model.Clone(),piece.Coordinates,piece.ChessColor,chessBoard)
        {
        }

        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list=new List<Point>();
            for (int i = (int) (Coordinates.X)+1; i < 8; i++)
            {
                SquareValue value = CheckSquare(square, i - (int) Coordinates.X, 0);
                if (value==SquareValue.Free)
                    list.Add(new Point(i, Coordinates.Y));
                else if (value == SquareValue.Fight)
                {
                    list.Add(new Point(i, Coordinates.Y));
                    break;
                }
                else
                {
                    break;
                }

            }

            for (int i = (int) (Coordinates.X) - 1; i >= 0; i--)
            {
                SquareValue value = CheckSquare(square, i - (int) Coordinates.X, 0);
                if (value==SquareValue.Free)
                    list.Add(new Point(i, Coordinates.Y));
                else if (value == SquareValue.Fight)
                {
                    list.Add(new Point(i, Coordinates.Y));
                    break;
                }
                else break;
            }

            for (int i = (int) (Coordinates.Y) - 1; i >= 0; i--)
            {
                SquareValue value = CheckSquare(square, 0, i - (int) Coordinates.Y);
                if (value==SquareValue.Free)
                    list.Add(new Point(Coordinates.X, i));
                else if (value == SquareValue.Fight)
                {
                    list.Add(new Point(Coordinates.X, i));
                    break;
                }
                else break;
            }

            for (int i = (int) (Coordinates.Y) + 1; i < 8; i++)
            {
                SquareValue value = CheckSquare(square, 0, i - (int) Coordinates.Y);
                if (value==SquareValue.Free)
                    list.Add(new Point(Coordinates.X, i));
                else if (value == SquareValue.Fight)
                {
                    list.Add(new Point(Coordinates.X, i));
                    break;
                }
                else break;
            }

            if (first)
            {
                int j = 1;
                if (Coordinates.Y > 4)
                    j = -1;

                for (int i =(int)Coordinates.Y+j; i < 4; i += j)
                {
                    if (square[(int)Coordinates.X,i].IsFree == false)
                        return list;
                }

                if(actualBoard.GetPieceByCoordinates(new Point(Coordinates.X,4)).First)
                    list.Add(new Point(Coordinates.X,4));
            }


            return list;
        }

        public override object Clone()
        {
            return new Rook(this,actualBoard);
        }

    }
}
