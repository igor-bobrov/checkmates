using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMatesBobrov
{
    public partial class F_Chess : Form
    {
        Field field = new Field();
        public F_Chess()
        {
            InitializeComponent();
            this.ClientSize = new Size(field.SizeX, field.SizeY + 20);
            FrameTimer.Start();
        }
        private void F_Chess_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(field.Sprite, 0, 20, field.SizeX, field.SizeY);
            if(field.CellIndexHovered != new Point(-1, -1))
            {
                int X = field.CellIndexHovered.X,
                    Y = field.CellIndexHovered.Y;
                gr.DrawImage(field.HoveredSprite, field.Cells[X, Y].Left, field.Cells[X, Y].Top, 
                    field.CellWidth + 0.5f, field.CellWidth + 0.5f);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            if (field.CellIndexSelected != new Point(-1, -1))
            {
                int X = field.CellIndexSelected.X,
                    Y = field.CellIndexSelected.Y;
                gr.DrawImage(field.SelectedSprite, field.Cells[X, Y].Left, field.Cells[X, Y].Top,
                    field.CellWidth + 0.5f, field.CellWidth + 0.5f);
            }
            foreach(Figure figure in field.White)
            {
                float X = field.Cells[figure.Index0, figure.Index1].Left;
                float Y = field.Cells[figure.Index0, figure.Index1].Top;
                gr.DrawImage(figure.Sprite, X, Y, field.CellWidth, field.CellWidth);
            }
            foreach (Figure figure in field.Black)
            {
                float X = field.Cells[figure.Index0, figure.Index1].Left;
                float Y = field.Cells[figure.Index0, figure.Index1].Top;
                gr.DrawImage(figure.Sprite, X, Y, field.CellWidth, field.CellWidth);
            }
            gr.DrawImage(Image.FromFile(field.WhiteTurn() ? "image/white/pawn.png" : "image/black/pawn.png"), 660, 45, field.CellWidth, field.CellWidth);
            
        }

        private void F_Chess_MouseMove(object sender, MouseEventArgs e)
        {
            field.HoverCell(e.X, e.Y);
            //this.Text = $"{e.X}; {e.Y}";
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void F_Chess_MouseClick(object sender, MouseEventArgs e)
        {
            //field.SelectCell(e.X, e.Y);
            if (!field.CallMove())
            {
                field.SelectCell();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quwiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://qiwi.com/p/79126704834");
        }

        private void сберToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/");
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D1%88%D0%B0%D1%85%D0%BC%D0%B0%D1%82");
        }

        private void новваяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ктоХодитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            field.SwitchPlay();
        }

        private void вкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/igor.bobr");
        }
    }
}
