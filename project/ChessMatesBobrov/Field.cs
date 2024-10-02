using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMatesBobrov
{
    class Field
    {
        bool whiteTurn = true;
        public Cell[,] Cells { get; }
        public Image Sprite { get; }
        public Image HoveredSprite { get; }
        public Image SelectedSprite { get; }
        public Image NiceHoveredSprite { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public float BorderWidth { get; }
        public float CellWidth { get; }
        public Point CellIndexHovered { get; private set; }
        public Point CellIndexSelected { get; private set; }
        public List<Figure> Black { get; }
        public List<Figure> White { get; }
        public bool WhiteTurn() { return whiteTurn; }

        public Field()
        {
            BorderWidth = 18;
            CellWidth = 77.5f;
            CellIndexHovered = new Point(-1, -1);
            CellIndexSelected = new Point(-1, -1);
            Sprite = new Bitmap("image/field.jpg");
            HoveredSprite = new Bitmap("image/CellHovered.png");
            SelectedSprite = new Bitmap("image/CellSelected.png");
            NiceHoveredSprite = new Bitmap("image/CellCanGo.png");
            SizeX = 1035;
            SizeY = 656;
            
            White = new List<Figure>();
            Black = new List<Figure>();
            for(int i = 0; i < 8; i++)
            {
                White.Add(new Pawn(6, i, true));
                Black.Add(new Pawn(1, i, false));
            }
           
            White.Add(new Hourse(7, 1, true));//✓
            White.Add(new Hourse(7, 6, true));//✓
            Black.Add(new Hourse(0, 1, false));//✓
            Black.Add(new Hourse(0, 6, false));//✓
            White.Add(new Rook(7, 0, true));//✓
            White.Add(new Rook(7, 7, true));//✓
            Black.Add(new Rook(0, 0, false));//✓
            Black.Add(new Rook(0, 7, false));//✓
            White.Add(new Bishop(7, 2, true));//✓
            White.Add(new Bishop(7, 5, true));//✓
            Black.Add(new Bishop(0, 2, false));//✓
            Black.Add(new Bishop(0, 5, false));//✓
            White.Add(new Queen(7, 3, true));//✓
            Black.Add(new Queen(0, 3, false));//✓
            White.Add(new King(7, 4, true));//✓ шах и мат
            Black.Add(new King(0, 4, false));//✓ шах и мат
            Cells = new Cell[8, 8];
            for(int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int a = 0; a < Cells.GetLength(1); a++)
                {
                    float Top = BorderWidth + CellWidth * i;
                    float Bottom = Top + CellWidth;
                    float Left = BorderWidth + CellWidth * a;
                    float Right = Left + CellWidth;
                    Cells[i, a] = new Cell(i, a, Left, Top, Right, Bottom, false);
                }
            }
            

        }
        public void SwitchPlay()
        {
            whiteTurn = whiteTurn? false : true;
        }
        public void HoverCell(int X, int Y)
        {
            bool isHovered = false;
            for (int i = 0; i < Cells.GetLength(0) && !isHovered; i++)
            {
                for (int a = 0; a < Cells.GetLength(1); a++)
                {
                    if (Cells[i, a].Top <= Y &&
                        Cells[i, a].Bottom >= Y &&
                        Cells[i, a].Left <= X &&
                        Cells[i, a].Right >= X)
                    {
                        CellIndexHovered = new Point(i, a);
                        isHovered = true;
                        break;
                    }
                }
            }
            if (!isHovered)
            {
                CellIndexHovered = new Point(-1, -1);
            }
        }
        public void SelectCell()
        {
            if(CellIndexSelected == CellIndexHovered)
            {
                CellIndexSelected = new Point(-1, -1);
            }
            else
            {
                CellIndexSelected = CellIndexHovered;
            }
        }
        public bool CallMove()
        {
            int Index0 = CellIndexSelected.X;
            int Index1 = CellIndexSelected.Y;
            if (CellIndexSelected != new Point(-1, -1) &&
                CellIndexHovered != new Point(-1, -1) &&
                CellIndexHovered != CellIndexSelected)
            {
                int NewIndex0 = CellIndexHovered.X;
                int NewIndex1 = CellIndexHovered.Y;
                foreach(Figure figure in White)
                {
                    if(figure.Index0 == Index0 && figure.Index1 == Index1)
                    {
                        this.CellIndexSelected = new Point(-1, -1);
                        return figure.TryMove(NewIndex0, NewIndex1, ref whiteTurn, White, Black);
                    }
                }
                foreach (Figure figure in Black)
                {
                    if (figure.Index0 == Index0 && figure.Index1 == Index1)
                    {
                        this.CellIndexSelected = new Point(-1, -1);
                        return figure.TryMove(NewIndex0, NewIndex1, ref whiteTurn, White, Black);
                    }
                }
            }
            return false;
        }

    }
}
