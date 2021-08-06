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
            // Draw the fill first, if there is any
            if(myBrush != null)
            {
                g.FillRectangle(myBrush, myRect);
            }
            
            // Then draw the border
            if (myPen != null)
            {
                g.DrawRectangle(myPen, myRect);
            }
        }
    }
}
