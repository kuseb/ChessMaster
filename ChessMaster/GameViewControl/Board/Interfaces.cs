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
    interface IPieceInterface
    {
        void Mark();
        void UnMark();
        void Move(ChessBoard board,Point coordinates,Piece beatPiece);
        List<Point> GetAvailablePoints(Square[,] squares);
    }

    interface ISquareInterface
    {
        void Mark();
    }
}
