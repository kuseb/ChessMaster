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
    class Bishop:Piece
    {
        public Bishop(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard) : base(model, coordinates, chessColor,chessBoard) { }

        protected Bishop(Bishop piece, ChessBoard chessBoard) :this(piece.Model.Clone(),piece.Coordinates,piece.ChessColor,chessBoard)
        {
        }

        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list=new List<Point>();
            for (int i = 1; i <= Coordinates.X; i++)
            {
                if (Coordinates.X - i >= 0 && Coordinates.Y - i >= 0)
                {
                    SquareValue value = CheckSquare(square, -i, -i);
                    if (value==SquareValue.Free)
                        list.Add(new Point(Coordinates.X-i,Coordinates.Y-i));
                    else if (value == SquareValue.Fight)
                    {
                        list.Add(new Point(Coordinates.X - i, Coordinates.Y - i));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                    break;
            }

            for (int i = 1; i <= Coordinates.X; i++)
            {
                if (Coordinates.X - i >= 0 && Coordinates.Y + i < 8)
                {
                    SquareValue value = CheckSquare(square, -i, i);
                    if (value==SquareValue.Free)
                        list.Add(new Point(Coordinates.X - i, Coordinates.Y + i));
                    else if (value == SquareValue.Fight)
                    {
                        list.Add(new Point(Coordinates.X - i, Coordinates.Y + i));
                        break;
                    }
                    else break;
                }
                else
                    break;
            }


            for (int i = 1; i < 9-Coordinates.X; i++)
            {
                if (Coordinates.X + i < 8 && Coordinates.Y - i >= 0)
                {
                    SquareValue value = CheckSquare(square, i, -i);
                    if (value==SquareValue.Free)
                        list.Add(new Point(Coordinates.X + i, Coordinates.Y - i));
                    else if (value == SquareValue.Fight)
                    {
                        list.Add(new Point(Coordinates.X + i, Coordinates.Y - i));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                    break;
            }

            for (int i = 1; i < 9 - Coordinates.X; i++)
            {
                if (Coordinates.X + i < 8 && Coordinates.Y + i < 8)
                {
                    SquareValue value = CheckSquare(square, i, i);
                    if (value==SquareValue.Free)
                    list.Add(new Point(Coordinates.X + i, Coordinates.Y + i));
                    else if (value == SquareValue.Fight)
                    {
                        list.Add(new Point(Coordinates.X + i, Coordinates.Y + i));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                    break;
            }

            return list;
        }

        public override object Clone()
        {
            return new Bishop(this,actualBoard);
        }


    }
}
