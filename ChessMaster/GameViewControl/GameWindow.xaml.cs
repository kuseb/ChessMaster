using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Media.Media3D;
using GameViewControl.Board;
using System.Threading;
using System.Timers;

namespace GameViewControl
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Model3DGroup chessSet;
        private ChessBoard board;
        private List<Point> actual;
        private int lastMarkId=-1;
        private int lastMoveId = -1;
        private bool lastTwice = false;
        private ChessBoard.Color actualColor=ChessBoard.Color.White;

        private string player1Name;
        private string player2Name;
        private int timeout;
        private System.Timers.Timer player1Timer;
        private System.Timers.Timer player2Timer;
        private int player1Seconds;
        private int player2Seconds;
        private bool first = true;

        private readonly string[,] squareStrings = new string[,]
        {
            {"a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1"},
            {"a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2"},
            {"a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3"},
            {"a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4"},
            {"a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5"},
            {"a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6"},
            {"a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7"},
            {"a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"},
        };

        public GameWindow()
        {
            InitializeComponent();
            LoadChessSet();
            board = new ChessBoard(ref chessSet,ChessBoard.Color.White);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(MouseUp_Event);
            
        }

        public GameWindow(String player1, String player2, int timeout)
        {
            InitializeComponent();
            LoadChessSet();
            board = new ChessBoard(ref chessSet, ChessBoard.Color.White);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(MouseUp_Event);

            player1Name = player1;
            player2Name = player2;
            this.timeout = timeout;

            InitializeLabels();
            InitializeTimers();
        }

        private void InitializeLabels()
        {
            player1Nick.Content = "Nick: " + player1Name;
            player2Nick.Content = "Nick: " + player2Name;
            player1TimeLabel.Content = (timeout/60).ToString("00") + ":" + timeout.ToString("00") + ":" + "00";
            player2TimeLabel.Content = (timeout / 60).ToString("00") + ":" + timeout.ToString("00") + ":" + "00";
            player1Seconds = timeout*60;
            player2Seconds = timeout*60;
        }

        private void InitializeTimers()
        {
            player1Timer=new System.Timers.Timer(1000);
            player2Timer=new System.Timers.Timer(1000);
            player1Timer.Elapsed+=new ElapsedEventHandler(OnTimeEvent1);
            player2Timer.Elapsed+=new ElapsedEventHandler(OnTimeEvent2);
        }

        private  void OnTimeEvent1(Object source, System.Timers.ElapsedEventArgs e)
        {
            player1Seconds--;
            int time = Math.Abs(player1Seconds);
            this.Dispatcher.Invoke(new Action(() =>
            {
                player1TimeLabel.Content = (time/3600).ToString() + ":" + (time/60).ToString("00") + ":" + (time%60).ToString("00");
            }));

            if (player1Seconds == 0)
            {
                MessageBox.Show("Game over! \n Player 1 lost!", "Timeout", MessageBoxButton.OK);
                this.Dispatcher.Invoke(new Action(() => { this.Close(); }));
            }
        }

        private void OnTimeEvent2(Object source, System.Timers.ElapsedEventArgs e)
        {
            player2Seconds--;
            int time = Math.Abs(player2Seconds);
            this.Dispatcher.Invoke(new Action(() =>
            {
                player2TimeLabel.Content = (time / 3600).ToString() + ":" + (time / 60).ToString("00") + ":" + (time % 60).ToString("00");
            }));

            if (player2Seconds == 0)
            {
                MessageBox.Show("Game over! \n Player 2 lost!", "Timeout", MessageBoxButton.OK);
                this.Dispatcher.Invoke(new Action(() => { this.Close(); }));
            }

        }
        private void LoadChessSet()
        {
            ModelImporter importer = new ModelImporter();
            importer.DefaultMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Beige));
            chessSet = importer.Load("..\\..\\..\\Model\\chessFinal.3ds");

            chessSet.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 180));

            this.chess.Content = chessSet;
            DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(Colors.Green));

              Sort(0, 32);
              Sort(33,chessSet.Children.Count);
        }

        private void Sort(int start, int end)
        {
            GeometryModel3D[] squares = new GeometryModel3D[end-start];
            
            for (int i = start; i < end; i++)
                squares[i - start] = chessSet.Children[i] as GeometryModel3D;

            Array.Sort(squares, CompareGeometryModel3D);

            for (int i = 0; i < squares.Length; i++)
                chessSet.Children[i + start] = squares[i];
        }

    

        private static int CompareGeometryModel3D(GeometryModel3D model1, GeometryModel3D model2)
        {
            if (model1.Bounds.X > model2.Bounds.X && Math.Abs(model1.Bounds.X - model2.Bounds.X)>=0.2)
                return 1;
            else if (Math.Abs(model1.Bounds.X - model2.Bounds.X)<0.2)
            {
                if (model1.Bounds.Y > model2.Bounds.Y && Math.Abs(model1.Bounds.Y - model2.Bounds.Y) >= 0.2)
                    return 1;
                else if (Math.Abs(model1.Bounds.Y - model2.Bounds.Y) < 0.2)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }


        private void MouseUp_Event(object sender, MouseButtonEventArgs args)
        {
            if (first)
                player1Timer.Enabled = true;

            Point p = args.GetPosition(this);
            p.X -= leftStackPanel.ActualWidth;
            p.X -= (leftStackPanel.Margin.Left + leftStackPanel.Margin.Right);
            List<Viewport3DHelper.HitResult> list = (List<Viewport3DHelper.HitResult>)this.chess.GetViewport3D().FindHits(p);
            if (list.Count > 0)
            {
                Rect3D rect = list[0].Model.Bounds;
                int id = board.GetId(rect);
                if(id==lastMarkId)
                    return;

                Element element = board.GetElement(id);
                if (id >= 0 && id < ChessBoard.PiececesCount && element.ChessColor == actualColor)
                {
                    if(actual!=null)
                        board.UnMark(actual);

                    if(lastMarkId!=-1)
                    board.UnMark(lastMarkId);

                    board.Mark(id);
                    actual = board.GetAvailableMove(id);

                    Point special=new Point(-1,-1);
                    if (lastMoveId!=-1 && board.GetElement(lastMoveId) is Pawn && board.GetElement(id) is Pawn && lastTwice)
                    {
                        Pawn pawn = board.GetElement(id) as Pawn;
                        Pawn pawn2 = board.GetElement(lastMoveId) as Pawn;
                        if (pawn.Coordinates.X == 3 && pawn2.Coordinates.X == 3 &&
                            Math.Abs(pawn.Coordinates.X - pawn2.Coordinates.X) < 2)
                        {
                            actual.Add(new Point(pawn2.Coordinates.X - 1, pawn2.Coordinates.Y));
                            special = new Point(pawn2.Coordinates.X - 1, pawn2.Coordinates.Y);
                        }
                        else if (pawn.Coordinates.X == 4 && pawn2.Coordinates.X == 4 &&
                                 Math.Abs(pawn.Coordinates.X - pawn2.Coordinates.X) < 2)
                        {
                            actual.Add(new Point(pawn2.Coordinates.X + 1, pawn2.Coordinates.Y));
                            special = new Point(pawn2.Coordinates.X + 1, pawn2.Coordinates.Y);
                        }
                    }

                    lastMarkId = id;

                    if (actual.Count > 0)
                        board.Mark(actual,special);

                }
                else if (lastMarkId!=-1 && id > ChessBoard.PiececesCount)
                {
                    Piece piece = board.GetElement(lastMarkId) as Piece;
                    Rect3D oldRect3D = piece.Model.Bounds;
                    Point oldPoint = piece.Coordinates;
                    Square square=board.GetElement((id)) as Square;

                    foreach (var VARIABLE in actual)
                    {
                        if (square.Coordinates.X == VARIABLE.X && square.Coordinates.Y == VARIABLE.Y)
                        {
                            if (piece is Rook)
                            {
                                Piece tmpPiece = board.GetPieceByCoordinates(square.Coordinates);
                                if (tmpPiece != null && tmpPiece.ChessColor == piece.ChessColor)
                                    UpdateItems(piece, square.Coordinates, true);
                                else
                                    UpdateItems(piece, square.Coordinates, false);
                            }
                            else
                                UpdateItems(piece, square.Coordinates, false);

                            lastTwice = false;

                            if (piece is Pawn && Math.Abs(square.Coordinates.X - piece.Coordinates.X) == 2)
                                lastTwice = true;

                            board.SetSquareFree(piece.Coordinates);

                            if(piece is Pawn && square.IsFree && Math.Abs(piece.Coordinates.Y-square.Coordinates.Y)==1)
                                piece.Move(board, new Point(square.Coordinates.X, square.Coordinates.Y),board.GetPieceByCoordinates(new Point(piece.Coordinates.X, square.Coordinates.Y)));
                            else
                                piece.Move(board, new Point(square.Coordinates.X, square.Coordinates.Y), board.GetPieceByCoordinates(square.Coordinates));

                            board.UnMark(actual);
                            board.UnMark(lastMarkId);
                            piece.First = false;
                            
                            actual = null;
                            lastMoveId = lastMarkId;
                            lastMarkId = -1;
                            
                            actualColor = actualColor == ChessBoard.Color.White
                                ? ChessBoard.Color.Black
                                : ChessBoard.Color.White;

                            if (actualColor == ChessBoard.Color.White)
                            {
                                player2Timer.Enabled = false;
                                player1Timer.Enabled = true;
                            }
                            else
                            {
                                player1Timer.Enabled = false;
                                player2Timer.Enabled = true;
                            }
                        

                            return;
                        }
                    }
                }
            }
        }

        private void UpdateItems(Piece piece, Point to,bool castling)
        {
            ListBox listBox = UserMoves;
            if (piece.ChessColor == ChessBoard.Color.Black)
                listBox = OpponentMoves;

            if (piece is Pawn)
                listBox.Items.Add((listBox.Items.Count+1).ToString() +". "+squareStrings[(int)to.X,(int)to.Y]);
            else if (piece is Rook)
            {
                if (!castling)
                    listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "R" +
                                        squareStrings[(int) to.X, (int) to.Y]);
                else
                {
                    if(Math.Abs(piece.Coordinates.Y-to.Y)==4)
                        listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "O-O-O");
                    else
                        listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "O-O");
                }
            }
            else if (piece is Knight)
                listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "N" +
                                    squareStrings[(int) to.X, (int) to.Y]);
            else if (piece is Bishop)
                listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "B" +
                                    squareStrings[(int) to.X, (int) to.Y]);
            else if (piece is King)
                listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "K" +
                                    squareStrings[(int) to.X, (int) to.Y]);
            else if (piece is Queen)
                listBox.Items.Add((listBox.Items.Count + 1).ToString() + ". " + "Q" +
                                    squareStrings[(int) to.X, (int) to.Y]);
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Message.Text != "")
                Chat.Items.Add("YOU: " + Message.Text);
        }
    }
}
