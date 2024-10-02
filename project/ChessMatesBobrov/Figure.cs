using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessMatesBobrov
{
    public abstract class Figure
    {
        public int Index0 { get; protected set; }
        public int Index1 { get; protected set; }
        public Image Sprite { get; protected set; }
        public bool IsWhite { get; protected set; }

        public Figure()
        {
            this.Index0 = -1;
            this.Index1 = -1;
            this.Sprite = new Bitmap(1, 1);
            IsWhite = true;
        }
        public bool TryMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> white, List<Figure> black) {
            if(CheckMove(newIndex0, newIndex1, ref whiteTurn, white, black))
            {
                this.Index0 = newIndex0;
                this.Index1 = newIndex1;
                whiteTurn = !whiteTurn;
                return true;
                
            }
            return false;
        }
        public bool CheckFigurePosition(Figure figure, int newIndex0, int newIndex1)
        {
            return newIndex0 == figure.Index0 && newIndex1 == figure.Index1? true : false;
        }
        public bool CheckListFigurePosition(List<Figure> figures, int newIndex0, int newIndex1)
        {
            foreach(Figure figure in figures)
            {
                if (CheckFigurePosition(figure, newIndex0, newIndex1))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> White, List<Figure> Black)
        {
            if (whiteTurn && IsWhite && CheckCanWhiteMove(newIndex0, newIndex1, White, Black))
                return true;
            else if (!whiteTurn && !IsWhite && CheckCanBlackMove(newIndex0, newIndex1, White, Black))
                return true;
            return false;
        }
        public virtual bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black) { return false; }
        public virtual bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black) { return false; }
        public bool CheckListHorizontalFigurePosition(List<Figure>figures, int newIndex0, int lastIndex1, int newIndex1)
        {
            for(int i = lastIndex1 + lastIndex1>newIndex1? -1 : 1; i <= newIndex1; i++)
            {
                if (CheckListFigurePosition(figures, newIndex0, i))
                {
                    return true;
                }
            }
            return false;
        }
        public bool EatFigure(List<Figure> figures, int newIndex0, int newIndex1)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].Index0 == newIndex0 && figures[i].Index1 == newIndex1 && i == figures.Count - 1)
                {
                    DialogResult res = MessageBox.Show("Начать сначала? - Yes \nВыйти - No", "Игра закончилась!!!", MessageBoxButtons.YesNo);
                    switch (res)
                    {
                        case DialogResult.Yes:
                            Application.Restart();
                            break;
                        case DialogResult.No:
                            Application.Exit();
                            break;
                    }
                }
                if (figures[i].Index0 == newIndex0 && figures[i].Index1 == newIndex1)
                {
                    figures.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
    public class Pawn : Figure
    {
        public Pawn(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/pawn.png") : new Bitmap("image/black/pawn.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if(!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1)){
                if (this.Index0 == 6 &&
                    !CheckListFigurePosition(White, 5, newIndex1) &&
                    !CheckListFigurePosition(Black, 5, newIndex1) &&
                    newIndex0 == this.Index0 - 2 &&
                    newIndex1 == this.Index1)
                {
                    return true;
                }
                if (newIndex0 >= 0 &&
                    newIndex0 == this.Index0 - 1 &&
                    newIndex1 == this.Index1)
                {
                    return true;
                }
            }      
            else
            {
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                if (this.Index0 - 1 == newIndex0 &&
                    (this.Index1 + 1 == newIndex1 || this.Index1 - 1 == newIndex1))
                {
                    return EatFigure(Black, newIndex0, newIndex1);
                }
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if (!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1)){
                if (this.Index0 == 1 &&
                    !CheckListFigurePosition(White, 2, newIndex1) &&
                    !CheckListFigurePosition(Black, 2, newIndex1) &&
                    newIndex0 == this.Index0 + 2 &&
                    newIndex1 == this.Index1)
                {
                    return true;
                }
                if (newIndex0 <= 7 &&
                    newIndex0 == this.Index0 + 1 &&
                    newIndex1 == this.Index1)
                {
                    return true;
                }
            }
            else
            {
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                if (this.Index0 + 1 == newIndex0 &&
                    (this.Index1 + 1 == newIndex1 || this.Index1 - 1 == newIndex1))
                {
                    return EatFigure(White, newIndex0, newIndex1);
                }
            }
            return false;
        }
    }
    public class Hourse : Figure
    {
        public Hourse(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/hourse.png") : new Bitmap("image/black/hourse.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black) 
        {
            if (!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if ((newIndex0 == this.Index0 - 2 && (newIndex1 == this.Index1 - 1 || newIndex1 == this.Index1 + 1)) ||
                    (newIndex0 == this.Index0 + 2 && (newIndex1 == this.Index1 - 1 || newIndex1 == this.Index1 + 1)) ||
                    (newIndex1 == this.Index1 - 2 && (newIndex0 == this.Index0 - 1 || newIndex0 == this.Index0 + 1)) ||
                    (newIndex1 == this.Index1 + 2 && (newIndex0 == this.Index0 - 1 || newIndex0 == this.Index0 + 1)))
                {
                    return true;
                }
            }
            else
            {
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                return EatFigure(Black, newIndex0, newIndex1);
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black) 
        {
            if (!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if ((newIndex0 == this.Index0 - 2 && (newIndex1 == this.Index1 - 1 || newIndex1 == this.Index1 + 1)) ||
                    (newIndex0 == this.Index0 + 2 && (newIndex1 == this.Index1 - 1 || newIndex1 == this.Index1 + 1)) ||
                    (newIndex1 == this.Index1 - 2 && (newIndex0 == this.Index0 - 1 || newIndex0 == this.Index0 + 1)) ||
                    (newIndex1 == this.Index1 + 2 && (newIndex0 == this.Index0 - 1 || newIndex0 == this.Index0 + 1)))
                {
                    return true;
                }
            }
            else
            {
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                return EatFigure(White, newIndex0, newIndex1);
            }
            return false;
        }
    }
    public class Rook : Figure
    {
        public Rook(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/rook.png") : new Bitmap("image/black/rook.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if (newIndex0 == this.Index0 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i >= newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index1 + 1; i <= newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else if (newIndex1 == this.Index1 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i >= newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index0 + 1; i <= newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i > newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index1 + 1; i < newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i > newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index0 + 1; i < newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(Black, newIndex0, newIndex1) && (newIndex0 == this.Index0 || newIndex1 == this.Index1))
                {
                    return EatFigure(Black, newIndex0, newIndex1);
                }
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if (newIndex0 == this.Index0 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i >= newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index1 + 1; i <= newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else if (newIndex1 == this.Index1 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i >= newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index0 + 1; i <= newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i > newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index1 + 1; i < newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i > newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index0 + 1; i < newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(White, newIndex0, newIndex1) && (newIndex0 == this.Index0 || newIndex1 == this.Index1))
                {
                    return EatFigure(White, newIndex0, newIndex1);
                }
            }
            return false;
        }
    }
    public class Bishop : Figure
    {
        public Bishop(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/Bishop.png") : new Bitmap("image/black/Bishop.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            int checkPosX = this.Index0,
                checkPosY = this.Index1;
            if(Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 + newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 + newIndex1) ||
               Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 - newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 - newIndex1))
            {
                if(this.Index0 < newIndex0)
                {
                    if (this.Index1 < newIndex1)
                    {
                        for(int i = 1; i < newIndex0-this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY += i;
                            if(CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                else
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return EatFigure(Black, newIndex0, newIndex1);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            int checkPosX = this.Index0,
                checkPosY = this.Index1;
            if (Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 + newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 + newIndex1) ||
               Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 - newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 - newIndex1))
            {
                if (this.Index0 < newIndex0)
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                else
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return EatFigure(White, newIndex0, newIndex1);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Queen : Figure
    {
        public Queen(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/queen.png") : new Bitmap("image/black/queen.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            int checkPosX = this.Index0,
                checkPosY = this.Index1;
            if (Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 + newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 + newIndex1) ||
               Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 - newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 - newIndex1))
            {
                if (this.Index0 < newIndex0)
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                else
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return EatFigure(Black, newIndex0, newIndex1);
                }
                else
                {
                    return true;
                }
            }
            if (newIndex0 == this.Index0 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i >= newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index1 + 1; i <= newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else if (newIndex1 == this.Index1 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i >= newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index0 + 1; i <= newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i > newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index1 + 1; i < newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i > newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index0 + 1; i < newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(Black, newIndex0, newIndex1) && (newIndex0 == this.Index0 || newIndex1 == this.Index1))
                {
                    return EatFigure(Black, newIndex0, newIndex1);
                }
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            int checkPosX = this.Index0,
                checkPosY = this.Index1;
            if (Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 + newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 + newIndex1) ||
               Math.Abs(this.Index0 + this.Index1) == Math.Abs(newIndex0 - newIndex1) || Math.Abs(this.Index0 - this.Index1) == Math.Abs(newIndex0 - newIndex1))
            {
                if (this.Index0 < newIndex0)
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < newIndex0 - this.Index0; i++)
                        {
                            checkPosX += i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                else
                {
                    if (this.Index1 < newIndex1)
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY += i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                    else
                    {
                        for (int i = 1; i < this.Index0 - newIndex0; i++)
                        {
                            checkPosX -= i;
                            checkPosY -= i;
                            if (CheckListFigurePosition(White, checkPosX, checkPosY) || CheckListFigurePosition(Black, checkPosX, checkPosY))
                            {
                                return false;
                            }
                        }
                        checkPosX = this.Index0;
                        checkPosY = this.Index1;
                    }
                }
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return EatFigure(White, newIndex0, newIndex1);
                }
                else
                {
                    return true;
                }
            }
            if (newIndex0 == this.Index0 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i >= newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index1 + 1; i <= newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else if (newIndex1 == this.Index1 && !CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i >= newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    for (int i = this.Index0 + 1; i <= newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (newIndex1 < this.Index1)
                {
                    for (int i = this.Index1 - 1; i > newIndex1; i--)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index1 + 1; i < newIndex1; i++)
                    {
                        if (CheckListFigurePosition(White, newIndex0, i) || CheckListFigurePosition(Black, newIndex0, i))
                        {
                            return false;
                        }
                    }
                }
                if (newIndex0 < this.Index0)
                {
                    for (int i = this.Index0 - 1; i > newIndex0; i--)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = this.Index0 + 1; i < newIndex0; i++)
                    {
                        if (CheckListFigurePosition(White, i, newIndex1) || CheckListFigurePosition(Black, i, newIndex1))
                        {
                            return false;
                        }
                    }
                }
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (CheckListFigurePosition(White, newIndex0, newIndex1) && (newIndex0 == this.Index0 || newIndex1 == this.Index1))
                {
                    return EatFigure(White, newIndex0, newIndex1);
                }
            }
            return false;
        }
    }
    public class King : Figure
    {
        public King(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/king.png") : new Bitmap("image/black/king.png");
        }
        public override bool CheckCanWhiteMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if (!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if ((newIndex0 == this.Index0 - 1 && newIndex1 == this.Index1 - 1) || (newIndex0 == this.Index0 - 1 &&  newIndex1 == this.Index1 + 1) || (newIndex0 == this.Index0 - 1 && newIndex1 == this.Index1) ||
                    (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1 - 1) || (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1 + 1) || (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1) ||
                    (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 + 1) ||
                    (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0) || (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0 + 1) ||
                    (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0))
                {
                    return true;
                }
            }
            else
            {
                if (CheckListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                return EatFigure(Black, newIndex0, newIndex1);
            }
            return false;
        }
        public override bool CheckCanBlackMove(int newIndex0, int newIndex1, List<Figure> White, List<Figure> Black)
        {
            if (!CheckListFigurePosition(White, newIndex0, newIndex1) && !CheckListFigurePosition(Black, newIndex0, newIndex1))
            {
                if ((newIndex0 == this.Index0 - 1 && newIndex1 == this.Index1 - 1) || (newIndex0 == this.Index0 - 1 && newIndex1 == this.Index1 + 1) || (newIndex0 == this.Index0 - 1 && newIndex1 == this.Index1) ||
                    (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1 - 1) || (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1 + 1) || (newIndex0 == this.Index0 + 1 && newIndex1 == this.Index1) ||
                    (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0 + 1) ||
                    (newIndex1 == this.Index1 - 1 && newIndex0 == this.Index0) || (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0 - 1) || (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0 + 1) ||
                    (newIndex1 == this.Index1 + 1 && newIndex0 == this.Index0))
                {
                    return true;
                }
            }
            else
            {
                if (CheckListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                return EatFigure(White, newIndex0, newIndex1);
            }
            return false;
        }
    }
}