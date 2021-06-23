﻿using System;
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
        private ArrayList coordinates = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Ivan Isakov - Lab 3";
            AutoScrollMinSize = new Size(2000, 1000);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int s_x = this.AutoScrollPosition.X;
            int s_y = this.AutoScrollPosition.Y;

            // Defining the radius for the circles
            const int size = 15;

            Graphics g = e.Graphics;

            Pen black_pen = new Pen(Color.Black, 1);
            Point p1 = new Point(-1, -1);
            Point p2 = new Point(-1, -1);
            

            if (button1.Text.Equals("Hide Lines"))
            {
                foreach(Point p in this.coordinates)
                {
                    Point p3 = new Point(s_x + p.X, s_y + p.Y);

                    if (p1.X == -1 && p1.Y == -1)
                    {
                        p1 = p3;
                    }
                    else
                    {
                        p2 = p3;

                        g.DrawLine(black_pen, p1, p2);

                        p1 = p2;
                    }
                }
            }

            foreach (Point p in this.coordinates)
            {
                g.FillEllipse(Brushes.Red, p.X - size / 2 + s_x, p.Y - size / 2 + s_y, size, size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            int s_x = this.AutoScrollPosition.X;
            int s_y = this.AutoScrollPosition.Y;

            // Left mouse click saves the coordinates of the click
            if (e.Button == MouseButtons.Left)
            {
            
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