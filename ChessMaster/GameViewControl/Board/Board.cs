
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Media.Media3D;
using GameViewControl.Promotion;


namespace GameViewControl.Board
{
    public class ChessBoard
    {
        private Model3DGroup model;

        private readonly Dictionary<int, Square> idSquareDictionary;
        private Dictionary<Point, Square> pointSquareDictionary;
        private Square[,] squares;

        private readonly Dictionary<int, Piece> idPieceDictionary;
        private Dictionary<Point, Piece> pointPieceDictionary;
        private Dictionary<Rect3D, int> boundsIdDictionary;

        private Piece[,] extraPieces;

        private Piece tmpPiece;

        public static readonly int PiececesCount = 32;
        public Color PlayerColor { get; set; }

        public enum Color
        {
            Black = 0,
            White = 1
        }

        public ChessBoard(ref Model3DGroup chessSet, ChessBoard.Color playerColor)
        {
            PlayerColor = playerColor;
            model = chessSet;
            InitializeDataStructures(out idSquareDictionary, out idPieceDictionary);
            BoardInitialize(chessSet.Children);
            PieceInitialize(chessSet.Children);
            ExtraPieceInitialize();

        }

        private void InitializeDataStructures(out Dictionary<int, Square> idSquareDictionary,
            out Dictionary<int, Piece> idPieceDictionary)
        {
            idSquareDictionary = new Dictionary<int, Square>();
            pointSquareDictionary = new Dictionary<Point, Square>();
            idPieceDictionary = new Dictionary<int, Piece>();
            pointPieceDictionary = new Dictionary<Point, Piece>();
            boundsIdDictionary = new Dictionary<Rect3D, int>();
            squares = new Square[8, 8];
        }

        private void BoardInitialize(Model3DCollection chessSet)
        {
            for (var i = ChessBoard.PiececesCount + 1; i < chessSet.Count; i++)
            {
                GeometryModel3D model = chessSet[i] as GeometryModel3D;
                var j = i - ChessBoard.PiececesCount - 1;
                var mod = j%8;
                var free = !(mod == 0 || mod == 1 || mod == 7 || mod == 6);

                var square = (mod + (int) (j/8))%2 == 0
                    ? new Square(model, new Point(mod, (int) (j/8)), ChessBoard.Color.Black, free)
                    : new Square(model, new Point(mod, (int) (j/8)), ChessBoard.Color.White, free);
                squares[j%8, j/8] = square;
                idSquareDictionary.Add(i, square);
                pointSquareDictionary.Add(new Point((int) (j%8), (int) (j/8)), square);
                boundsIdDictionary.Add(model.Bounds, i);
            }
        }

        private void PieceInitialize(Model3DCollection chessSet)
        {
            for (var i = 0; i < ChessBoard.PiececesCount; i++)
            {
                GeometryModel3D model = chessSet[i] as GeometryModel3D;
                if (model == null) continue;
                Piece piece = ConstructPiece(model, i);
                idPieceDictionary.Add(i, piece);
                pointPieceDictionary.Add(piece.Coordinates, piece);
                boundsIdDictionary.Add(model.Bounds, i);

                squares[(int) (piece.Coordinates.X), (int) piece.Coordinates.Y].PieceColor = piece.ChessColor;
            }
        }

        private void ExtraPieceInitialize()
        {
            extraPieces = new Piece[4,4];
            extraPieces[(int)ChessBoard.Color.White ,(int) PromotionForm.PromotionPiece.QUEEN] =
                (Piece) pointPieceDictionary[new Point(0, (int) PromotionForm.PromotionPiece.QUEEN)].Clone();
            extraPieces[(int)ChessBoard.Color.White, (int) PromotionForm.PromotionPiece.BISHOP] =
                (Piece) pointPieceDictionary[new Point(0, (int) PromotionForm.PromotionPiece.BISHOP)].Clone();
            extraPieces[(int)ChessBoard.Color.White,(int) PromotionForm.PromotionPiece.KNIGHT] =
                (Piece) pointPieceDictionary[new Point(0, (int) PromotionForm.PromotionPiece.KNIGHT)].Clone();
            extraPieces[(int)ChessBoard.Color.White,(int) PromotionForm.PromotionPiece.ROOK] =
                (Piece) pointPieceDictionary[new Point(0, (int) PromotionForm.PromotionPiece.ROOK)].Clone();

            extraPieces[(int)ChessBoard.Color.Black, (int)PromotionForm.PromotionPiece.QUEEN] =
               (Piece)pointPieceDictionary[new Point(7, (int)PromotionForm.PromotionPiece.QUEEN)].Clone();
            extraPieces[(int)ChessBoard.Color.Black, (int)PromotionForm.PromotionPiece.BISHOP] =
                (Piece)pointPieceDictionary[new Point(7, (int)PromotionForm.PromotionPiece.BISHOP)].Clone();
            extraPieces[(int)ChessBoard.Color.Black, (int)PromotionForm.PromotionPiece.KNIGHT] =
                (Piece)pointPieceDictionary[new Point(7, (int)PromotionForm.PromotionPiece.KNIGHT)].Clone();
            extraPieces[(int)ChessBoard.Color.Black, (int)PromotionForm.PromotionPiece.ROOK] =
                (Piece)pointPieceDictionary[new Point(7, (int)PromotionForm.PromotionPiece.ROOK)].Clone();
        }

        public bool IsFree(Point point)
        {
            return squares[(int) (point.X), (int) (point.Y)].IsFree;
        }

        public int GetId(Rect3D bounds)
        {
            int id;
            if (boundsIdDictionary.TryGetValue(bounds, out id))
                return id;

            return -1;
        }

        public void CheckPromotion(Piece piece)
        {
            if (((piece.Coordinates.X > 6 && piece.ChessColor == Color.White) || (piece.Coordinates.X < 1 && piece.ChessColor == Color.Black))&& piece is Pawn)
            {
                tmpPiece = piece;
                PromotionForm pf = new PromotionForm();
                pf.Show();
                pf.FormClosing+=new FormClosingEventHandler(Pf_FormClosing);
                
            }
        }

        private void Pf_FormClosing(object sender, EventArgs e)
        {
            PromotionForm pf=sender as PromotionForm;
            PromotionForm.PromotionPiece pp = pf.Value;
            PromotionToPromotionType(tmpPiece,pp);
        }

        private void PromotionToPromotionType(Piece piece, PromotionForm.PromotionPiece promotionType)
        {
            int id = boundsIdDictionary[piece.Model.Bounds];
            RemovePieceBoundsDictionary(piece);
            RemovePiecePointDictionary(piece);
            Piece newPiece =(Piece)extraPieces[(int)piece.ChessColor, (int) promotionType].Clone();
            newPiece.ActualBoard = this;
            newPiece.InitMove(piece.Coordinates);
            newPiece.Coordinates = piece.Coordinates;
            model.Children[id] = newPiece.Model;
            idPieceDictionary[id] = newPiece;
            pointPieceDictionary[newPiece.Coordinates] = newPiece;
            boundsIdDictionary[newPiece.Model.Bounds] = id;
        }

      

        public Element GetElement(int id)
        {
            if (id>=0 && id < 32)
                return idPieceDictionary[id];
            else if (id > 32)
                return idSquareDictionary[id];

            return null;
        }
        public void Mark(int id)
        {
            if (id>=0 && id < ChessBoard.PiececesCount)
                idPieceDictionary[id].Mark();
            else
                idSquareDictionary[id].Mark();
        }

        public void Mark(List<Point> list,Point specialPoint)
        {
            foreach(Point p in list)
            {
                Square square = squares[(int) (p.X), (int) p.Y];
                if (!square.IsFree || p==specialPoint)
                    pointSquareDictionary[p].BattleMark();
                else
                    pointSquareDictionary[p].Mark();
            }
        }

        public void UnMark(List<Point> list)
        {
            foreach (var p in list)
            {
                pointSquareDictionary[p].UnMark();
            }
        }

        public void UnMark(int id)
        {
           idPieceDictionary[id].UnMark();
        }

        public void SetBoundsDictionary(Rect3D old, Rect3D actual, int id)
        {
            boundsIdDictionary.Remove(old);
            boundsIdDictionary.Add(actual,id);
        }

        public void SetBoundsDictionary(Rect3D actual, int id)
        {
            boundsIdDictionary.Add(actual,id);
        }

        public void SetPointDictionary(Point old, Point actual, Piece piece)
        {
            pointPieceDictionary.Remove(old);
            if (pointPieceDictionary.ContainsKey(actual))
                pointPieceDictionary.Remove(actual);
            pointPieceDictionary.Add(actual,piece);
        }

        public void SetPointDictionary(Point actual, Piece piece)
        {
            pointPieceDictionary.Add(actual, piece);
        }
        public void SetSquareFree(Point coordinates)
        {
            if(coordinates.X-(int)coordinates.X<0.1 && coordinates.Y-(int)coordinates.Y<0.1)
            squares[(int)(coordinates.X),(int)(coordinates.Y)].IsFree = true;
        }

        public void SetSquareOccupied(Point coordinates, ChessBoard.Color color)
        {
            if (coordinates.X - (int)coordinates.X > 0.1 || coordinates.Y - (int)coordinates.Y > 0.1)
                return;

            squares[(int) (coordinates.X), (int) (coordinates.Y)].IsFree = false;
            squares[(int) coordinates.X, (int) coordinates.Y].PieceColor = color;
        }

        public void RemovePieceBoundsDictionary(Piece piece)
        {
            boundsIdDictionary.Remove(piece.Model.Bounds);
        }

        public void RemovePiecePointDictionary(Piece piece)
        {
            pointPieceDictionary.Remove(piece.Coordinates);
        }

        

        public List<Point> GetAvailableMove(int id)
        {
            return id < ChessBoard.PiececesCount ? idPieceDictionary[id].GetAvailablePoints(squares) : new List<Point>();
        }

        public void RemovePiece(Point point)
        {
            Piece piece = pointPieceDictionary[point];
            pointPieceDictionary.Remove(point);
            int id = -1;
            boundsIdDictionary.TryGetValue(piece.Model.Bounds,out id);
            if (id > 0)
            {
                boundsIdDictionary.Remove(piece.Model.Bounds);
                idPieceDictionary.Remove(id);
            }
            model.Children[id] = new Model3DGroup();
            squares[(int)point.X, (int)point.Y].IsFree = true;
           
        }

       
        public Square GetSquareById(Point point)
        {
            Square square;
            pointSquareDictionary.TryGetValue(point, out square);
            return square;
        }

        public Piece GetPieceByCoordinates(Point coordinates)
        {
            Piece result = null;
            pointPieceDictionary.TryGetValue(coordinates, out result);
            return result;
        }
        private Piece ConstructPiece(GeometryModel3D model, int i)
        {
            Piece result=null;
            int mod = i%4;

            ChessBoard.Color color=ChessBoard.Color.Black;
            if (mod == 0 || mod == 1)
                color = ChessBoard.Color.White;
            
        
            switch (i%4)
            {
                case 1:
                    result = new Pawn(model, new Point(1, (int)(i / 4)),color,this);
                    break;
                case 2:
                    result = new Pawn(model, new Point(6, (int)(i / 4)),color,this);
                    break;
                default:
                    if (i/4 == 0)
                    {
                        result = i%4==0 ? new Rook(model, new Point(0, 0), color,this) : new Rook(model,new Point(7,0), color,this);
                    }
                    else if (i/4 == 1)
                    {
                        result = i%4==0 ? new Knight(model, new Point(0, 1), color,this) : new Knight(model,new Point(7,1),color,this);
                    }
                    else if (i/4 == 2)
                    {
                        result = i%4==0 ? new Bishop(model, new Point(0, 2), color,this) : new Bishop(model, new Point(7, 2), color,this);
                    }
                    else if (i/4 == 3)
                    {
                        result = i % 4 == 0 ? new King(model, new Point(0, 4), color,this) : new King(model, new Point(7, 4), color,this);
                    }
                    else if (i/4 == 4)
                    {
                        result = i % 4 == 0 ? new Queen(model, new Point(0, 3), color,this) : new Queen(model, new Point(7, 3), color,this);
                    }
                    else if (i/4 == 5)
                    {
                        result = i % 4 == 0 ? new Bishop(model, new Point(0, 5), color,this) : new Bishop(model, new Point(7, 5), color,this);
                    }
                    else if (i/4 == 6)
                    {
                        result = i % 4 == 0 ? new Knight(model, new Point(0, 6), color,this) : new Knight(model, new Point(7, 6), color,this);
                    }
                    else if (i/4 == 7)
                    {
                        result = i % 4 == 0 ? new Rook(model, new Point(0, 7), color,this) : new Rook(model, new Point(7, 7), color,this);
                    }
                    break;
            }

            return result;

        }
    }
}
