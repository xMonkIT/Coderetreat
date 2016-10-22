using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifecoderetreat.Domain
{
    class Cell
    {
        public int X;
        public int Y;

        public override bool Equals(object obj)
        {
            var cell = obj as Cell;
            return cell != null && cell.X == X && cell.Y == Y;
        }

        public override int GetHashCode()
        {
            return $"{X}{Y}".GetHashCode();
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
