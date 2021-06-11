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

namespace Lab2
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Defining the radius for the circles
            const int radius = 10;

            foreach(Point points in this.coordinates)
            {
                // Each circle is red and 20 by 20
                g.FillEllipse(Brushes.Red, points.X - radius, points.Y - radius, 2 * radius, 2 * radius);

                // Print the coordinates of the centre of the circle
                Point txt = new Point(points.X + radius, points.Y - radius / 2);
                g.DrawString("{X=" + points.X + ", Y=" + points.Y + "}", Font, Brushes.Black, txt);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Left mouse click saves the coordinates of the click
            if(e.Button == MouseButtons.Left)
            {
                Point points = new Point(e.X, e.Y);
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
