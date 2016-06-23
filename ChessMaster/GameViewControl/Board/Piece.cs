using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Media.Media3D;

namespace GameViewControl.Board
{ 
    public class Piece:Element,IPieceInterface, ICloneable
    {
        public Transform3DGroup Group { set; get; }

        protected int colorFactor;
        protected Rect3D bounds;
        protected Piece attactedPiece;
        protected ChessBoard actualBoard;
        protected Point destinationCoordinates;
        protected bool first = true;
        protected bool special = false;

        public bool First { set { first = value; } get { return first; } }

        protected enum SquareValue
        {
            Free, Fight, Occupied
        }

        protected Piece(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor, ChessBoard chessBoard)
            : base(model, coordinates, chessColor)
        {
            Group = new Transform3DGroup();
            if (ChessColor == ChessBoard.Color.Black)
                colorFactor = -1;
            else
                colorFactor = 1;

            bounds = Model.Bounds;
            actualBoard = chessBoard;
        }

        protected Piece(Piece piece, ChessBoard chessBoard) :this(piece.Model.Clone(),piece.Coordinates,piece.ChessColor,chessBoard)
        {
        }

        /// <summary>
        /// Przesuwa this do coordinates, jeśli istnieje pojedynek to wykonuje się animacja pojedynku
        /// </summary>
        /// <param name="board"></param>
        /// <param name="coordinates"></param>
        /// <param name="beatPiece"></param>
        public void Move(ChessBoard board, Point coordinates, Piece beatPiece = null)
        {
            actualBoard = board;

            if (this is Rook && beatPiece!=null && beatPiece.ChessColor==this.ChessColor)
            {
                if (Coordinates.Y < coordinates.Y)
                {
                    beatPiece.Move(actualBoard, new Point(coordinates.X,2));
                    Animation(new Point(coordinates.X,3), false);
                }
                else
                {
                    beatPiece.Move(actualBoard, new Point(coordinates.X, 6));
                    Animation(new Point(coordinates.X, 5), false);
                }
            }
            else if (this is Pawn && beatPiece != null && coordinates != beatPiece.Coordinates)
            {
                attactedPiece = beatPiece;
                Animation(beatPiece.Coordinates,true);
                destinationCoordinates = coordinates;
            }
            else if (beatPiece != null)
            {
                attactedPiece = beatPiece;

                Animation(coordinates, true);
            }
            else
                Animation(coordinates, false);

        }

        public virtual List<Point> GetAvailablePoints(Square[,] squares) { return new List<Point>();}
        protected void Animation(Point coordinates, bool action)
        {
            Point point = coordinates;
            DoubleAnimation animationX = new DoubleAnimation();

            if (action)
            {
                destinationCoordinates = coordinates;
                point = FindPoint(coordinates);
            }
            animationX.Completed += AnimationX_Completed;

            animationX.From = 0;
            animationX.To = 0.6 * (point.Y - Coordinates.Y);
            animationX.Duration = new Duration(TimeSpan.FromSeconds(2));

            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = 0;
            animationY.To = 0.6 * (point.X - Coordinates.X);
            animationY.Duration = new Duration(TimeSpan.FromSeconds(2));

            var oldCoordinates = Coordinates;

            Transform3D transform3D = new TranslateTransform3D(0.6 * (point.Y - Coordinates.Y),
                0.6 * (point.X - Coordinates.X), 0);
            Group.Children.Add(transform3D);
            Model.Transform = Group;

            Coordinates = new Point(point.X, point.Y);
            actualBoard.SetSquareFree(oldCoordinates);
            actualBoard.SetPointDictionary(oldCoordinates, Coordinates, this);
            actualBoard.SetSquareOccupied(Coordinates, ChessColor);
            actualBoard.SetBoundsDictionary(bounds, Model.Bounds,actualBoard.GetId(bounds));
            bounds = Model.Bounds;

            transform3D.BeginAnimation(TranslateTransform3D.OffsetXProperty, animationX);
            transform3D.BeginAnimation(TranslateTransform3D.OffsetYProperty, animationY);

        }

        public void MoveWithoutAnimation(Point coordinates)
        {
            var oldCoordinates = Coordinates;

            Transform3D transform3D = new TranslateTransform3D(0.6 * (coordinates.Y - Coordinates.Y),
               0.6 * (coordinates.X - Coordinates.X), 0);
            Group.Children.Add(transform3D);
            Model.Transform = Group;

            Coordinates = new Point(coordinates.X, coordinates.Y);
            actualBoard.SetSquareFree(oldCoordinates);
            actualBoard.SetPointDictionary(oldCoordinates, Coordinates, this);
            actualBoard.SetSquareOccupied(Coordinates, ChessColor);
            actualBoard.SetBoundsDictionary(bounds, Model.Bounds, actualBoard.GetId(bounds));
            bounds = Model.Bounds;

        }

        public void InitMove(Point coordinates)
        {
            Transform3D transform3D = new TranslateTransform3D(0.6 * (coordinates.Y - Coordinates.Y),
              0.6 * (coordinates.X - Coordinates.X), 0);
            Group.Children.Add(transform3D);
            Model.Transform = Group;
            
            Coordinates = new Point(coordinates.X, coordinates.Y);
            actualBoard.SetPointDictionary(Coordinates, this);
            actualBoard.SetSquareOccupied(Coordinates, ChessColor);
            bounds = Model.Bounds;
            actualBoard.SetBoundsDictionary(bounds, actualBoard.GetId(bounds));
        }

        private void AnimationX_Completed(object sender, EventArgs e)
        {
            if (attactedPiece != null)
                AttackAnimation(false);
            else
            {
                if (this is Pawn)
                 actualBoard.CheckPromotion(this);
            }
        }

        protected void AttackAnimation(bool reverse)
        {
            int dx = 0;
            int dy = 0;

            if (Coordinates.X - destinationCoordinates.X > 0.1)
                dx = -1;
            else if(Coordinates.X-destinationCoordinates.X<-0.1)
                dx = 1;

            if (Coordinates.Y - destinationCoordinates.Y > 0.1)
                dy = 1;
            else if(Coordinates.Y-destinationCoordinates.Y<-0.1)
                dy = -1;

            Rotation3DAnimation animation = new Rotation3DAnimation();
            animation.From = new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 0);
            animation.To = reverse? new AxisAngleRotation3D(new Vector3D(dx, dy, 0),-60): new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 60);
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            if(!reverse)
                animation.Completed += new EventHandler(AttackFinished);

            var oldCoordinates = Coordinates;

            Rotation3D rotation3D = reverse? new AxisAngleRotation3D(new Vector3D(dx, dy, 0), -60): new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 60);
            RotateTransform3D transform3D = new RotateTransform3D(rotation3D, new Point3D(Model.Bounds.X+Model.Bounds.SizeX/2, Model.Bounds.Y+Model.Bounds.SizeY/2, Model.Bounds.Z +Model.Bounds.SizeZ/2));
            Group.Children.Add(transform3D);
            Model.Transform = Group;

            actualBoard.SetSquareFree(oldCoordinates);
            actualBoard.SetPointDictionary(oldCoordinates, Coordinates, this);
            actualBoard.SetSquareOccupied(Coordinates, ChessColor);
            actualBoard.SetBoundsDictionary(bounds, Model.Bounds, actualBoard.GetId(bounds));
            bounds = Model.Bounds;

            transform3D.BeginAnimation(RotateTransform3D.RotationProperty, animation);
        }

        protected void LastAnimation(Piece piece)
        {
            int dx = 0;
            int dy = 0;

            if (Coordinates.X - destinationCoordinates.X > 0.1)
                dx = 1;
            else if (Coordinates.X - destinationCoordinates.X < -0.1)
                dx = -1;

            if (Coordinates.Y - destinationCoordinates.Y > 0.1)
                dy = 1;
            else if (Coordinates.Y - destinationCoordinates.Y < -0.1)
                dy = 1;

            Rotation3DAnimation animation = new Rotation3DAnimation();
            animation.From = new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 0);
            animation.To = new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 90);
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            animation.Completed+=new EventHandler(LastAnimationFinished);

            piece.bounds = piece.Model.Bounds;
            Rotation3D rotation3D = new AxisAngleRotation3D(new Vector3D(dx, dy, 0), 90);
            RotateTransform3D transform3D = new RotateTransform3D(rotation3D, new Point3D(piece.Model.Bounds.X+piece.Model.Bounds.Size.X/2, piece.Model.Bounds.Y+piece.Model.Bounds.SizeY/2, piece.Model.Bounds.Z));
            piece.Group.Children.Add(transform3D);
            piece.Model.Transform = piece.Group;
            transform3D.BeginAnimation(RotateTransform3D.RotationProperty, animation);

            actualBoard.SetBoundsDictionary(piece.bounds,piece.Model.Bounds,actualBoard.GetId(piece.bounds));
            piece.bounds = piece.Model.Bounds;
        }

        protected void AttackFinished(object sender, EventArgs e)
        {
           AttackAnimation(true);
           LastAnimation(attactedPiece);
         
         
            //actualBoard.UnMark(actualBoard.GetId(Model.Bounds));
            //actualBoard.UnMark(actualBoard.GetId(attactedPiece.Model.Bounds));

        }

        protected void LastAnimationFinished(object sender, EventArgs e)
        {
            actualBoard.RemovePiece(attactedPiece.Coordinates);
            Animation(destinationCoordinates,false);
            attactedPiece = null;
           
         
        }

        protected Point FindPoint(Point coordinates)
        {
            Point point = new Point();
            double dx = coordinates.X - Coordinates.X;
            double dy = coordinates.Y - Coordinates.Y;
            if (dx != 0)
            {
                point = dx > 0 ? new Point(coordinates.X - 0.5, dy / dx * coordinates.X + Coordinates.Y - dy / dx * Coordinates.X) : new Point(coordinates.X + 0.5, dy / dx * coordinates.X + Coordinates.Y - dy / dx * Coordinates.X);
            }
            else
            {
                point = dy > 0 ? new Point(coordinates.X, coordinates.Y - 0.5) : new Point(coordinates.X, coordinates.Y + 0.5);
            }

            return point;
        }
        public void Mark()
        {
            Model.Material = new DiffuseMaterial(new SolidColorBrush(MarkColor));
            Model.BackMaterial = new DiffuseMaterial(new SolidColorBrush(MarkColor));
        }

        public void UnMark()
        {
            Model.Material = defaultMaterial;
            Model.BackMaterial = defaultBackMaterial;
        }

        protected SquareValue CheckSquare(Square[,] squares, int i, int j)
        {
            if (squares[(int) (Coordinates.X) + i, (int) (Coordinates.Y) + j].IsFree)
                return SquareValue.Free;
            else if (!squares[(int) (Coordinates.X) + i, (int) (Coordinates.Y) + j].IsFree &&
                     squares[(int) (Coordinates.X) + i, (int) (Coordinates.Y) + j].PieceColor != ChessColor)
                return SquareValue.Fight;
            else
                return SquareValue.Occupied;
        }

        public ChessBoard ActualBoard { set { actualBoard = value; } }

        public virtual object Clone()
        {
            return new Piece(this,actualBoard);
        }
       
    }
}
