# <ins>Lab 3: Draw Circles with Scrolling</ins>

Create an application that draws circles similar to the example from class that stores the coordinates in an ArrayList. Make the circles 15 x 15 pixels. 
This is the same as lab 2 without the coordinate display.

An option is to draw lines from the first dot to the second, and the second to the third etc. A button initially labeled "Show Lines" is placed in the 
upper left corner of the form. Lines are not initially drawn. If the button is clicked the lines are drawn and the button label is set to "Hide Lines." If 
clicked the lines are not drawn and the label reverts to "Show Lines."

A right mouse click clears all the dots and lines.

### Scrolling

The ability to scroll a virtual client area 2000 by 1000 must be provided. You must be able to add circles in an area uncovered by scrolling. 
Lines must be drawn correctly.

The folling requirements must be met:

1. The form title must be your name and lab 3.
2. You must use an override of the base class OnPaint
3. The circles are red and NOT black.
4. The lines are black.
5. The circles must cover the line if one is displayed.
6. The circles must FULLY cover the lines.

//
