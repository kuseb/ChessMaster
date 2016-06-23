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
    class Queen:Piece
    {
        public Queen(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard)
            : base(model, coordinates, chessColor,chessBoard)
        { 
            Group.Children.Add(new TranslateTransform3D(-0.6, 0, 0));
            Model.Transform = Group;
            bounds = Model.Bounds;
        }

        protected Queen(Queen piece, ChessBoard chessBoard) :this(piece.Model.Clone(),piece.Coordinates,piece.ChessColor,chessBoard)
        {
        }

        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list = new List<Point>();
            for (int i = (int)(Coordinates.X) + 1; i < 8; i++)
            {
                SquareValue value = CheckSquare(square, i - (int) (Coordinates.X), 0);
                if (value==SquareValue.Free)
                    list.Add(new Point(i, Coordinates.Y));
                else if (value==SquareValue.Fight)
                {
                    list.Add(new Point(i, Coordinates.Y));
                    break;
                }
                else break;

            }

            for (int i = (int)(Coordinates.X) - 1; i >= 0; i--)
            {
                SquareValue value = CheckSquare(square, i - (int) (Coordinates.X), 0);
                if (value==SquareValue.Free)
                    list.Add(new Point(i, Coordinates.Y));
                else if (value==SquareValue.Fight)
                {
                    list.Add(new Point(i, Coordinates.Y));
                    break;
                }
                else break;
            }

            for (int i = (int)(Coordinates.Y) - 1; i >= 0; i--)
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

            for (int i = (int)(Coordinates.Y) + 1; i < 8; i++)
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

            for (int i = 1; i <= Coordinates.X; i++)
            {
             
                if (Coordinates.X - i >= 0 && Coordinates.Y - i >= 0)
                {
                    SquareValue value = CheckSquare(square, -i, -i);
                    if (value==SquareValue.Free)
                    list.Add(new Point(Coordinates.X - i, Coordinates.Y - i));
                    else if (value == SquareValue.Fight)
                    {
                        list.Add(new Point(Coordinates.X - i, Coordinates.Y - i)); 
                        break;
                    }
                    else break;
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
                    else
                    {
                        break;
                    }
                }
                else
                    break;
            }


            for (int i = 1; i < 8 - Coordinates.X; i++)
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

            for (int i = 1; i < 8 - Coordinates.X; i++)
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
            return new Queen(this,actualBoard);
        }

    }
}
