using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    class RectPB
    {
        public Pen myPen;
        public Brush myBrush;
        public Rectangle myRect;

        public RectPB(Pen p, Brush b, Rectangle r)
        {
            myPen = p;
            myBrush = b;
            myRect = r;
        }

        public virtual void DrawRectangles(Graphics g)
        {
            if(myBrush != null)
            {
                g.FillRectangle(myBrush, myRect);
            }

            if (myPen != null)
            {
                g.DrawRectangle(myPen, myRect);
            }
        }
    }
}
