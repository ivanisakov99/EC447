using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        // Array of rectangles
        ArrayList rectangles = new ArrayList();
        // Settings dialog
        Settings sDialog = new Settings();

        // Corners of the rectangles
        Point corner1 = new Point(-1, -1), corner2 = new Point(-1, -1);

        // Global selection for the pen and the brush
        Pen myPen = null;
        Brush myBrush = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 6 by Ivan Isakov";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
           
            // Draw each rectangle in the list
            foreach (RectPB rect in rectangles)
            {
                rect.DrawRectangles(g);
            }

            // Draw the point where the mouse was clicked
            if (corner1.X != -1 && corner1.Y != -1)
            {
                g.FillEllipse(Brushes.Black, corner1.X - 10 / 2, corner1.Y - 10 / 2, 10, 10);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the array
            rectangles.Clear();
            Invalidate();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Pop up the settings dialog
            sDialog.ShowDialog();
            if(sDialog.DialogResult == DialogResult.OK)
            {
                // Set the colour and the width of the pen
                switch (sDialog.listBoxOutlinePenC.SelectedIndex)
                {
                    case 0:
                        myPen = null;
                        break;
                    case 1:
                        myPen = new Pen(Brushes.Black, sDialog.listBoxPenWidth.SelectedIndex + 1);
                        break;
                    case 2:
                        myPen = new Pen(Brushes.Red, sDialog.listBoxPenWidth.SelectedIndex + 1);
                        break;
                    case 3:
                        myPen = new Pen(Brushes.Blue, sDialog.listBoxPenWidth.SelectedIndex + 1);
                        break;
                    case 4:
                        myPen = new Pen(Brushes.Green, sDialog.listBoxPenWidth.SelectedIndex + 1);
                        break;
                }

                // Set the colour of the fill
                switch (sDialog.listBoxFillC.SelectedIndex)
                {
                    case 0:
                        myBrush = null;
                        break;
                    case 1:
                        myBrush = Brushes.Black;
                        break;
                    case 2:
                        myBrush = Brushes.Red;
                        break;
                    case 3:
                        myBrush = Brushes.Blue;
                        break;
                    case 4:
                        myBrush = Brushes.Green;
                        break;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kill the programme with exit code
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                // First click/coordinate
                if (corner1.X == -1 && corner1.Y == -1)
                {
                    corner1 = new Point(e.X, e.Y);
                    Invalidate();
                }
                // Second click/coordinate
                else
                {
                    // Check if the settings are chosen
                    if(myBrush == null && myPen == null)
                    {
                        MessageBox.Show("Fill and or pen/outline colour must be selected.", "", MessageBoxButtons.OK);
                        
                        // Reset the point
                        corner1.X = corner1.Y = -1;
                        Invalidate();
                    }
                    else
                    {
                        corner2 = new Point(e.X, e.Y);

                        int width = Math.Abs(corner1.X - corner2.X);
                        int height = Math.Abs(corner1.Y - corner2.Y);

                        // Determine the top left corner of the rectangle
                        Point topLeft;
                        // Same or corner1 is the top left one and corner2 is the bottom right one
                        if((corner1 == corner2) || (corner1.X < corner2.X && corner1.Y < corner2.Y))
                        {
                            topLeft = corner1;
                        }
                        // Corner1 is the bottom right one and corner2 is the top left one
                        else if (corner1.X > corner2.X && corner1.Y > corner2.Y){
                            topLeft = corner2;
                        }
                        // Corner1 is the bottom left one and corner2 is the top right one
                        else if (corner1.X < corner2.X && corner1.Y > corner2.Y)
                        {
                            topLeft = new Point(corner2.X - width, corner2.Y);
                        }
                        // Corner1 is the top right one and corner2 is the bottom left one
                        else if (corner1.X > corner2.X && corner1.Y < corner2.Y)
                        {
                            topLeft = new Point(corner2.X, corner2.Y - height);
                        }
                        // Otherwise
                        else
                        {
                            topLeft = corner1;
                        }

                        Rectangle myRectangle = new Rectangle(topLeft.X, topLeft.Y, width, height);
                        RectPB rect = new RectPB(myPen, myBrush, myRectangle);
                        rectangles.Add(rect);

                        // Reset the point, so that the dot dissapears
                        corner1.X = corner1.Y = -1;
                        Invalidate();
                    }
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there are shapes to remove, so that no exception occurs
            if (rectangles.Count > 0)
            {
                rectangles.RemoveAt(rectangles.Count - 1);
                Invalidate();
            }
        }
    }
}
