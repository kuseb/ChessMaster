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
    public abstract class Element
    {
        public Point Coordinates { get; set; }
        public GeometryModel3D Model { get; }
        public Color MarkColor { get; } = Colors.LawnGreen;
        public Color BattleColor { get; } = Colors.Red;
        public ChessBoard.Color ChessColor { get; }

        protected Material defaultMaterial;
        protected Material defaultBackMaterial;
        protected Element(GeometryModel3D model, Point coordinates, ChessBoard.Color chessColor)
        {
            this.Model = model;
            this.Coordinates = coordinates;
            this.ChessColor = chessColor;
            defaultMaterial = model.Material;
            defaultBackMaterial = model.BackMaterial;
        }
    }
}
