# <ins>Lab 6 - Drawing GUI</ins>

This assignment attempts to utilize most of the skills you have learned up to this point. It involves creating a simple drawing program.

1. Use an ArrayList or generic List<> to save each graphic object for painting.
2. You will draw rectangles with border and/or fill color.
3. Undo deletes the last graphics object in the list. Be sure the program doesn’t crash if you try to undo an empty list.Create a base class from which all graphics elements are derived.
4. The constructor for each rectangle object takes arguments of your choice such as the brush, pen, dimensions and location.You draw the objects with a foreach loop.
5. The form consists of a menu strip and drawing area.
6. All objects are drawn with two mouse clicks. This sets the boundaries of the box containing the object.
7. Borders must overlap the object so they must be drawn after the object.
8. If no fill or outline is specified then an object is not drawn and not added to the list. A message is also displayed to alert the user.
9. If there is a first click only then a black circle is drawn at the click's position, otherwise no circle is drown.
10. The object is added on the second click.
11. Be careful to implement the settings dialog the same as the example.
12. If cancel is clicked then the values in the controls are restored to their previous values.
13. Override the settings dialog base class OnShown to get control when the user opens the dialog.

//
