using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMatesBobrov
{
    class Cell
    {
        public Figure figure { get; set; }
        public int Index0 { get; }
        public int Index1 { get; }
        public float Top { get; }
        public float Left { get; }
        public float Right { get; }
        public float Bottom { get; }
        public bool IsHot { get; }

        public Cell(int Index0, int Index1, float Left, float Top, float Right, float Bottom, bool IsHot)
        {
            this.Top = 20 + Top;
            this.Left = Left;
            this.Right = Right;
            this.Bottom = 20 + Bottom;
            this.IsHot = IsHot;
        }
    }
}
