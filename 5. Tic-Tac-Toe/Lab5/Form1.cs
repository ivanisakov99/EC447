using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        // Cell enum
        public enum CellContent { N, O, X };

        // Dimesions
        private const float CLIENTSIZE = 100;
        private const float LINELENGTH = 80;
        private const float BLOCK = LINELENGTH / 3;
        private const float OFFSET = 10;
        private const float DELTA = 5;
        // Scale factor
        private float scale;

        // Initialise the game engine
        public GameEngine TicTacToeGame;

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
            this.Text = "Lab5 by Ivan Isakov";
            TicTacToeGame = new GameEngine();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Rescale
            ApplyTransform(g);

            // Draw the board
            g.DrawLine(Pens.Black, BLOCK, 0, BLOCK, LINELENGTH);
            g.DrawLine(Pens.Black, 2*BLOCK, 0, 2*BLOCK, LINELENGTH);
            g.DrawLine(Pens.Black, 0, BLOCK, LINELENGTH, BLOCK);
            g.DrawLine(Pens.Black, 0, 2 * BLOCK, LINELENGTH, 2 * BLOCK);

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    // Draw X
                    if (TicTacToeGame.grid[i, j] == GameEngine.CellContent.X)
                    {
                        drawX(i, j, g);
                    }
                    // Draw O
                    else if(TicTacToeGame.grid[i, j] == GameEngine.CellContent.O)
                    {
                        drawO(i, j, g);
                    }
                }
            }
        }

        // Rescaling to preserve the coordinates
        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / CLIENTSIZE, ClientRectangle.Height / CLIENTSIZE);
            
            if (scale == 0f)
            {
                return;
            }

            g.ScaleTransform(scale, scale);
            g.TranslateTransform(OFFSET, OFFSET);
        }

        // User clicks for his move
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, p);

            // User moves
            if(TicTacToeGame.player == GameEngine.whosMove.user)
            {
                this.Invalidate();
                TicTacToeGame.userMove(e, p, TicTacToeGame);
            }

            // After the first turn
            if(TicTacToeGame.numOfMoves >= 0)
            {
                computerStartsToolStripMenuItem.Enabled = false;
            }

            this.Invalidate();
        }

        // New Game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicTacToeGame = new GameEngine();
            computerStartsToolStripMenuItem.Enabled = true;
            this.Invalidate();
        }

        // Computer makes the first move
        private void computerStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computerStartsToolStripMenuItem.Enabled = false;
            TicTacToeGame.startingPlayer = GameEngine.startState.computer;
            TicTacToeGame.player = GameEngine.whosMove.computer;
            TicTacToeGame.computerMove(TicTacToeGame);
            this.Invalidate();
        }

        // Draw Xs
        public void drawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * BLOCK + DELTA, j * BLOCK + DELTA, (i * BLOCK) + BLOCK - DELTA, (j * BLOCK) + BLOCK - DELTA);

            g.DrawLine(Pens.Black, (i * BLOCK) + BLOCK - DELTA, j * BLOCK + DELTA, (i * BLOCK) + DELTA, (j * BLOCK) + BLOCK - DELTA);
        }

        // Draw O's
        public void drawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * BLOCK + DELTA, j * BLOCK + DELTA, BLOCK - 2 * DELTA, BLOCK - 2 * DELTA);
        }
    }
}
