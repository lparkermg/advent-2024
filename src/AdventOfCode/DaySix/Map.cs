using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DaySix
{
    internal class Map
    {
        public Vector2 StartPosition { get; set; }

        public IList<Cell> MapGrid { get; set; } = new List<Cell>();
    }

    internal class Cell
    {
        public readonly string CellId;

        public readonly bool HasObject;

        public readonly int X;

        public readonly int Y;

        public Cell(bool hasObject, int x, int y)
        {
            CellId = $"{x}_{y}";
            HasObject = hasObject;
            X = x;
            Y = y;
        }
    }
}
