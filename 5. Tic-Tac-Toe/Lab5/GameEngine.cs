using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public class GameEngine
    {
        public const float LINELENGTH = 80;
        public const float BLOCK = LINELENGTH / 3;
        private const float DELTA = 5;
        public enum CellContent { N, O, X };

        // The state of the board
        public CellContent[,] grid = new CellContent[3, 3];

        // User graph of moves
        public int[] userGraph = new int[8];

        // Computer graph of moves
        public int[] compGraph = new int[8];

        // Number of moves
        public int numOfMoves;

        // The game is active
        public bool gameRunning;

        public enum gameState { userWon, computerWon, tie, running};
        // Who won the game
        public gameState winner;

        public enum whosMove { user, computer};
        // Who's turn is it
        public whosMove player;

        public enum startState { user, computer};
        // Who makes the first turn
        public startState startingPlayer;
        

        // Default constructor
        public GameEngine()
        {
            numOfMoves = 0;
            gameRunning = true;
            startingPlayer = startState.user;
            player = whosMove.user;
            winner = gameState.running;

            for(int i = 0; i < 8; i++)
            {
                compGraph[i] = 0;
                userGraph[i] = 0;
            }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    this.grid[i, j] = CellContent.N;
                }
            }
        }

        // User move logic
        public void userMove(MouseEventArgs e, PointF[] p, GameEngine currentGame)
        {
            if(p[0].X < 0 || p[0].Y < 0)
            {
                return;
            }

            int i = (int)(p[0].X / BLOCK);
            int j = (int)(p[0].Y / BLOCK);

            if(i > 2 || j > 2)
            {
                return;
            }

            if (!gameRunning)
            {
                return;
            }
            else if(gameRunning && player == whosMove.user)
            {
                // new
                if(currentGame.grid[i, j] == CellContent.N && e.Button == MouseButtons.Left)
                {
                    currentGame.grid[i, j] = CellContent.X;

                    if (i == 0)
                    {
                        userGraph[0]++;
                    }
                    if (i == 1)
                    {
                        userGraph[1]++;
                    }
                    if (i == 2)
                    {
                        userGraph[2]++;
                    }
                    if (j == 0)
                    {
                        userGraph[3]++;
                    }
                    if (j == 1)
                    {
                        userGraph[4]++;
                    }
                    if (j == 2)
                    {
                        userGraph[5]++;
                    }
                    if ((i == 0 && j == 0) || (i == 2 && j == 2))
                    {
                        userGraph[6]++;
                    }
                    if ((i == 0 && j == 2) && (i == 2 && j == 0))
                    {
                        userGraph[7]++;
                    }
                    if (i == 1 && j == 1)
                    {
                        userGraph[6]++;
                        userGraph[7]++;
                    }

                    this.numOfMoves++;
                    this.player = whosMove.computer;
                    this.isWinner(currentGame);
                    this.computerMove(currentGame);
                }
            }
            else
            {
                MessageBox.Show("Invalid! That cell is taken!");
            }
        }

        // Computer move logic
        public void computerMove(GameEngine currentGame)
        {
            if (!gameRunning)
            {
                player = whosMove.user;
                //isWinner(currentGame);
                return;
            }
            else if(startingPlayer == startState.user && gameRunning)
            {
                // Diagonal 1
                if(compGraph[6] == 2)
                {
                    if(currentGame.grid[0, 0] == currentGame.grid[1, 1] && currentGame.grid[0, 0] != CellContent.N)
                    {
                        if(currentGame.grid[2, 2] == CellContent.N)
                        {
                            currentGame.grid[2, 2] = CellContent.O;
                            compGraph[6]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }

                    if (currentGame.grid[0, 0] == currentGame.grid[2, 2] && currentGame.grid[0, 0] != CellContent.N)
                    {
                        if (currentGame.grid[1, 1] == CellContent.N)
                        {
                            currentGame.grid[1, 1] = CellContent.O;
                            compGraph[6]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }

                    if (currentGame.grid[2, 2] == currentGame.grid[1, 1] && currentGame.grid[2, 2] != CellContent.N)
                    {
                        if (currentGame.grid[0, 0] == CellContent.N)
                        {
                            currentGame.grid[0, 0] = CellContent.O;
                            compGraph[6]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                // Diagonal 2
                if (compGraph[7] == 2)
                {
                    if (currentGame.grid[2, 0] == currentGame.grid[1, 1] && currentGame.grid[2, 0] != CellContent.N)
                    {
                        if (currentGame.grid[0, 2] == CellContent.N)
                        {
                            currentGame.grid[0, 2] = CellContent.O;
                            compGraph[7]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }

                    }
                    if (currentGame.grid[2, 0] == currentGame.grid[0, 2] && currentGame.grid[2, 0] != CellContent.N)
                    {
                        if (currentGame.grid[1, 1] == CellContent.N)
                        {
                            currentGame.grid[1, 1] = CellContent.O;
                            compGraph[7]++;        //diag 2 possible
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }

                    }
                    if (currentGame.grid[1, 1] == currentGame.grid[0, 2] && currentGame.grid[1, 1] != CellContent.N)
                    {
                        if (currentGame.grid[2, 0] == CellContent.N)
                        {
                            currentGame.grid[2, 0] = CellContent.O;
                            compGraph[7]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }

                    }
                }

                // row zero
                if (compGraph[0] == 2)
                {
                    if ((currentGame.grid[0, 0] == currentGame.grid[0, 1]) && currentGame.grid[0, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 2] == CellContent.N)
                        {
                            currentGame.grid[0, 2] = CellContent.O;                          // finish row
                            compGraph[0]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[0, 0] == currentGame.grid[0, 2]) && currentGame.grid[0, 2] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 1] == CellContent.N)
                        {
                            currentGame.grid[0, 1] = CellContent.O;                          // finish row
                            compGraph[0]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[0, 1] == currentGame.grid[0, 2]) && currentGame.grid[0, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 0] == CellContent.N)
                        {
                            currentGame.grid[0, 0] = CellContent.O;                          // finish row
                            compGraph[0]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (compGraph[1] == 2)                  //  check row 1
                {
                    // row1
                    if ((currentGame.grid[1, 0] == currentGame.grid[1, 1]) && currentGame.grid[1, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 2] == CellContent.N)
                        {
                            currentGame.grid[1, 2] = CellContent.O;                          // finish row
                            compGraph[1]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[1, 0] == currentGame.grid[1, 2]) && currentGame.grid[1, 2] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 1] == CellContent.N)
                        {
                            currentGame.grid[1, 1] = CellContent.O;                          // finish row
                            compGraph[1]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    else if ((currentGame.grid[1, 1] == currentGame.grid[1, 2]) && currentGame.grid[1, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 0] == CellContent.N)
                        {
                            currentGame.grid[1, 0] = CellContent.O;                          // finish row
                            compGraph[1]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (compGraph[2] == 2)                                                  // row2
                {
                    if ((currentGame.grid[2, 0] == currentGame.grid[2, 1]) && currentGame.grid[2, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 2] == CellContent.N)
                        {
                            currentGame.grid[2, 2] = CellContent.O;                          // finish row
                            compGraph[2]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[2, 0] == currentGame.grid[2, 2]) && currentGame.grid[2, 2] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 1] == CellContent.N)
                        {
                            currentGame.grid[2, 1] = CellContent.O;                          // finish row
                            compGraph[2]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[2, 1] == currentGame.grid[2, 2]) && currentGame.grid[2, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 0] == CellContent.N)
                        {
                            currentGame.grid[2, 0] = CellContent.O;                          // finish row
                            compGraph[2]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (compGraph[3] == 2)
                {
                    // col0
                    if ((currentGame.grid[0, 0] == currentGame.grid[1, 0]) && currentGame.grid[1, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 0] == CellContent.N)
                        {
                            currentGame.grid[2, 0] = CellContent.O;                          // finish col
                            compGraph[3]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[0, 0] == currentGame.grid[2, 0]) && currentGame.grid[0, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 0] == CellContent.N)
                        {
                            currentGame.grid[1, 0] = CellContent.O;                          // finish col
                            compGraph[3]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[1, 0] == currentGame.grid[2, 0]) && currentGame.grid[1, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 0] == CellContent.N)
                        {
                            currentGame.grid[0, 0] = CellContent.O;                          // finish col
                            compGraph[3]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (compGraph[4] == 2)              // col1
                {
                    if ((currentGame.grid[0, 1] == currentGame.grid[1, 1]) && currentGame.grid[1, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 0] == CellContent.N)
                        {
                            currentGame.grid[2, 0] = CellContent.O;                          // finish col
                            compGraph[4]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[0, 1] == currentGame.grid[2, 1]) && currentGame.grid[0, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 1] == CellContent.N)
                        {
                            currentGame.grid[1, 1] = CellContent.O;                          // finish col
                            compGraph[4]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[1, 1] == currentGame.grid[2, 1]) && currentGame.grid[1, 1] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 1] == CellContent.N)
                        {
                            currentGame.grid[0, 1] = CellContent.O;                          // finish col
                            compGraph[4]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (compGraph[5] == 2)
                {
                    // col2
                    if ((currentGame.grid[0, 0] == currentGame.grid[1, 0]) && currentGame.grid[1, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[2, 0] == CellContent.N)
                        {
                            currentGame.grid[2, 0] = CellContent.O;                          // finish col
                            compGraph[5]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[0, 0] == currentGame.grid[2, 0]) && currentGame.grid[0, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[1, 0] == CellContent.N)
                        {
                            currentGame.grid[1, 0] = CellContent.O;                          // finish col
                            compGraph[5]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                    if ((currentGame.grid[1, 0] == currentGame.grid[2, 0]) && currentGame.grid[1, 0] != CellContent.N)            // first two are equal
                    {
                        if (currentGame.grid[0, 0] == CellContent.N)
                        {
                            currentGame.grid[0, 0] = CellContent.O;                          // finish col
                            compGraph[5]++;
                            player = whosMove.user;
                            this.numOfMoves++;
                            isWinner(currentGame);
                            return;
                        }
                    }
                }

                if (currentGame.grid[1, 1] == GameEngine.CellContent.N)  // if can't win, try to fill diagonals
                {           // center
                    currentGame.grid[1, 1] = GameEngine.CellContent.O;
                    compGraph[1]++;
                    compGraph[4]++;
                    compGraph[6]++;
                    compGraph[7]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[0, 0] == GameEngine.CellContent.N)
                {            // top left
                    currentGame.grid[0, 0] = GameEngine.CellContent.O;
                    compGraph[0]++;
                    compGraph[3]++;
                    compGraph[6]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[2, 2] == GameEngine.CellContent.N)
                {            // bottom right
                    currentGame.grid[2, 2] = GameEngine.CellContent.O;
                    compGraph[2]++;
                    compGraph[5]++;
                    compGraph[6]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[0, 2] == GameEngine.CellContent.N)
                {           // top right
                    currentGame.grid[0, 2] = GameEngine.CellContent.O;
                    compGraph[0]++;
                    compGraph[5]++;
                    compGraph[7]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[2, 0] == GameEngine.CellContent.N)
                {            // bottom left
                    currentGame.grid[2, 0] = GameEngine.CellContent.O;
                    compGraph[2]++;
                    compGraph[3]++;
                    compGraph[7]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                // fill the randos if the corners and center are filled
                if (currentGame.grid[0, 1] == GameEngine.CellContent.N)
                {            // top mid
                    currentGame.grid[0, 1] = GameEngine.CellContent.O;
                    compGraph[0]++;
                    compGraph[4]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[2, 1] == GameEngine.CellContent.N)
                {            // bottom mid
                    currentGame.grid[2, 1] = GameEngine.CellContent.O;
                    compGraph[2]++;
                    compGraph[4]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[1, 0] == GameEngine.CellContent.N)
                {            // mid left
                    currentGame.grid[1, 0] = GameEngine.CellContent.O;
                    compGraph[1]++;
                    compGraph[3]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                if (currentGame.grid[1, 2] == GameEngine.CellContent.N)
                {            // mid right
                    currentGame.grid[1, 2] = GameEngine.CellContent.O;
                    compGraph[1]++;
                    compGraph[5]++;
                    player = whosMove.user;
                    this.numOfMoves++;
                    isWinner(currentGame);
                    return;
                }

                /*if (userMove)
                {
                    compMove = false;
                    return;
                }*/
            }
            else if(startingPlayer == startState.computer && gameRunning)
            {
                currentGame.grid[1, 1] = GameEngine.CellContent.O;
                player = whosMove.user;
                startingPlayer = startState.user;
                currentGame.numOfMoves++;
                isWinner(currentGame);
                return;
            }
            else if (!gameRunning)
            {
                return;
            }
        }

        // Determine the winner
        public void isWinner(GameEngine currentGame)
        {
            if (gameRunning)
            {
                for(int i = 0; i < 8; i++)
                {
                    if(compGraph[i] == 3)
                    {
                        winner = gameState.computerWon;
                    }
                    
                    if(userGraph[i] == 3)
                    {
                        winner = gameState.userWon;
                    }
                }
            }

            if(winner == gameState.userWon)
            {
                gameRunning = false;
                MessageBox.Show("You Win!");
                return;
            }
            
            if(winner == gameState.computerWon)
            {
                gameRunning = false;
                MessageBox.Show("You Lose!");
                return;
            }

            if(currentGame.numOfMoves == 9 && gameRunning)
            {
                gameRunning = false;
                winner = gameState.tie;
                MessageBox.Show("Tie!");
                return;
            }
        }
    }
}
