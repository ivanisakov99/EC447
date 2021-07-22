# <ins>Lab 5 - Tic-Tac-Toe</ins>

In this assignment you will program the game of tic-tac-toe using a standard 3 x 3 grid (no border). You will play against the computer. Either the computer or player has the option of making the first move.

All the game playing logic **must** be in a separate game engine class in a <ins>separate file</ins>. The game engine cannot have any code that is specific to the user interface. In other words the game engine deals only with grid squares and moves in the form [i,j] where i and j are 0, 1, or 2. It never deals with client coordinates, mouse click handlers or the graphics object.

### <ins> User Interface</ins>

* Your grid **must** resize to the current client area.
* A left mouse click in a grid square will draw an X. Your program must check (using the game engine) to make sure that you are not trying to select a grid square that already has an X or O. In this case the click is ignored and a <ins>message box</ins> is displayed alerting the user that they tried to make a bad move.
* The computer will play the O's.
* When you start the program you have the option of making the first move or letting the computer go first. By default you move first.
* Create a menu with a top level item called "Game." Create two menu items on the drop down:
    1. **New** - starts a new game at any time. A new game is started automatically at program entry.
    2. **Computer Starts** - Causes the program to make the first move. <ins>Disabled after clicking or after user makes the first move.</ins>
* When the game ends, an appropriate message box should be displayed, e.g., "You lose!" . After closing the message box the user must initiate a new game using the menu. No further moves are allowed.
* The user interface passes mouse clicks to the game engine as a cell coordinate, not a display coordinate, and displays the current grid. Hit testing is NOT done by the game engine. This is an important part of objected oriented design. You will need to define the interface between the graphics and the game engine. Do this first. Don’t just start writing code.

### <ins>Game Engine</ins>

 The algorithm you design for the computer’s side of the game does not have to be sophisticated, but it must make correct moves. The internet has many articles on the game. You might want to take a look at some. These are the minimum requirements of the game engine:
 
  * It is a separate class.
  * It **must** block a winning move if one or more exist.
  * It **must** make a winning move if one exists.
  * If neither of the above are true then any legal move can be made subject to how clever your algorithm is.
  * The game engine validates a move by a user to make sure it is legal.
  * The game engine detects the end game conditions, i.e., one party wins or a draw.
  * The graphical interface should **not** be performing **ANY** game related tasks.

![Снимок экрана (11)](https://user-images.githubusercontent.com/60196280/126642032-d18d9894-e3ec-49dd-83e9-32605f537254.png)
