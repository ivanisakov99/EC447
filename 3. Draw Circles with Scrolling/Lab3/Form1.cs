using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {
        // ArrayList for the coordinates
        private ArrayList coordinates = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            // Lab 3 title
            this.Text = "Ivan Isakov - Lab 3";
            // Virtual client area
            AutoScrollMinSize = new Size(2000, 1000);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // For scrolling
            int s_x = this.AutoScrollPosition.X;
            int s_y = this.AutoScrollPosition.Y;

            // Defining the radius for the circles
            const int size = 15;

            Graphics g = e.Graphics;

            // Translate the origin
            g.TranslateTransform(s_x, s_y);

            // Initialising a black pen and the start/end points to draw the lines
            Pen black_pen = new Pen(Color.Black, 1);
            Point p1 = new Point(-1, -1);
            Point p2 = new Point(-1, -1);
            
            // If "Show Lines" is clicked, then draw the lines
            if (button1.Text.Equals("Hide Lines"))
            {
                // Draw the lines from one circle to the next one in the array order
                foreach(Point p in this.coordinates)
                {
                    if (p1.X == -1 && p1.Y == -1)
                    {
                        p1 = p;
                    }
                    else
                    {
                        p2 = p;

                        g.DrawLine(black_pen, p1, p2);

                        p1 = p2;
                    }
                }
            }

            // Draw the circles
            foreach (Point p in this.coordinates)
            {
                g.FillEllipse(Brushes.Red, p.X - size / 2, p.Y - size / 2, size, size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Changing the state of the button to show/hide the lines
            if(button1.Text.Equals("Show Lines"))
            {
                button1.Text = "Hide Lines";
            }
            else
            {
                button1.Text = "Show Lines";
            }
            this.Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // For scrolling
            int s_x = this.AutoScrollPosition.X;
            int s_y = this.AutoScrollPosition.Y;

            // Left mouse click saves the coordinates of the click
            if (e.Button == MouseButtons.Left)
            {
                // Add the coordinates with the scrolling offset
                Point points = new Point(e.X - s_x, e.Y - s_y);
                this.coordinates.Add(points);
                this.Invalidate();
            }
            // Right mouse click deletes all of the coordinates 
            else
            {
                this.coordinates.Clear();
                this.Invalidate();
            }
        }
    }
}
