using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Media.Media3D;

namespace GameViewControl.Board
{
    class Knight:Piece
    {
        public Knight(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard) : base(model, coordinates, chessColor,chessBoard) { }

        protected Knight(Knight piece, ChessBoard chessBoard):this(piece.Model.Clone(),piece.Coordinates,piece.ChessColor,chessBoard)
        {
        }
        public override List<Point> GetAvailablePoints(Square[,] square)
        {
            List<Point> list=new List<Point>();

            if (Coordinates.X + 2 < 8 && Coordinates.Y + 1 < 8)
            {
                SquareValue value = CheckSquare(square, 2, 1);
                if (value==SquareValue.Free || value==SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) + 2, (int)(Coordinates.Y) + 1));
                   
            }

            if (Coordinates.X + 2 < 8 && Coordinates.Y - 1 >= 0)
            {
                SquareValue value = CheckSquare(square, 2, -1);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) + 2, (int)(Coordinates.Y) - 1));
            }

            if (Coordinates.X - 2 >=0 && Coordinates.Y + 1 < 8)
            {
                SquareValue value = CheckSquare(square, -2, 1);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) - 2, (int)(Coordinates.Y) + 1));
            }

            if (Coordinates.X - 2 >=0 && Coordinates.Y - 1 >= 0)
            {
                SquareValue value = CheckSquare(square, -2, -1);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) - 2, (int)(Coordinates.Y) - 1));
            }

            if (Coordinates.X + 1 < 8 && Coordinates.Y + 2 < 8)
            {
                SquareValue value = CheckSquare(square, 1, 2);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) + 1, (int)(Coordinates.Y) + 2));
            }

            if (Coordinates.X + 1 < 8 && Coordinates.Y - 2 >= 0)
            {
                SquareValue value= CheckSquare(square, 1, -2);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) + 1, (int)(Coordinates.Y) - 2));
            }

            if (Coordinates.X - 1 >= 0 && Coordinates.Y + 2 < 8)
            {
                SquareValue value= CheckSquare(square, -1, 2);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) - 1, (int)(Coordinates.Y) + 2));
            }

            if (Coordinates.X - 1 >=0 && Coordinates.Y - 2 >=0)
            {
                SquareValue value = CheckSquare(square, -1, -2);
                if (value == SquareValue.Free || value == SquareValue.Fight)
                    list.Add(new Point((int)(Coordinates.X) - 1, (int)(Coordinates.Y) - 2));
            }

            return list;
        }

       
        public virtual void Move(Point coordinates, Piece beatPiece = null)
        {
            Animation(coordinates, this);
            Coordinates = new Point(coordinates.X, coordinates.Y);
         
        }

        protected virtual void Animation(Point coordinates, Piece beatPiece = null)
        {
            DoubleAnimation animationX = new DoubleAnimation();
            animationX.From = 0;
            animationX.To = 0.6 * (coordinates.Y - Coordinates.Y);
            animationX.Duration = new Duration(TimeSpan.FromSeconds(2));

            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = 0;
            animationY.To = 0.6 * (coordinates.X - Coordinates.X);
            animationY.Duration = new Duration(TimeSpan.FromSeconds(2));

            DoubleAnimation animationZ = new DoubleAnimation();
            animationY.From = 0;
            animationY.To = 2;
            animationY.Duration = new Duration(TimeSpan.FromSeconds(2));

            Transform3D transform3D = new TranslateTransform3D(0.6 * (coordinates.Y - Coordinates.Y)/2,
                0.6 * (coordinates.X - Coordinates.X)/2, 2);
            Group.Children.Add(transform3D);
            Model.Transform = Group;
            transform3D.BeginAnimation(TranslateTransform3D.OffsetXProperty, animationX);
            transform3D.BeginAnimation(TranslateTransform3D.OffsetYProperty, animationY);
            transform3D.BeginAnimation(TranslateTransform3D.OffsetZProperty,animationZ);

        }

        public override object Clone()
        {
            return new Knight(this,actualBoard);
        }

    }
}
