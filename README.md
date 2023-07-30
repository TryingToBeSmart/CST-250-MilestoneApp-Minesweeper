# CST-250 MilstoneApp Minesweeper
## Milestone 1
7/2/23
Board class creates a 2-dimensional array of Cell objects.  It sets the Cells as bombs depending on the difficulty that was selected.  Then, it sets the LiveNeighbors number of each cell after counting how many neighbors are bombs.  For now, this first commit is just a console app that constructs a board and prints it out.

## Milestone 2
7/9/23
Added CheckForWinner() method.
Added SearchForSurroundingZeros() method: sets the Cell that was sent as the parameter as Visited, then if it has 0 neighbors with live bombs, mark all the surrounding Cells as Visited and recursively continue to call the method for the surrounding Cells.
Added PrintBoardDuringGame() method: is called every time a new cell is explored to print out the current board as the game progresses.  Non-visited cells have '?', cells that are visited have either the number of surrounding live bombs or are blank if there are no neighbors with live bombs.  Also added different colors.
Added loop to play the console game.

## Milestone 4
7/23/23
Added GUI using a Windows Forms app.  All of the methods from the console app were implemented into the GUI app.  The cells were dynamically created using a for loop that first checks the size of the form to get them to fit equally.

## Milestone 5
Added a stopwatch timer to keep track of gameplay time. Also added the bomb and flag images to a Resource so that they will stay with the application when published.
Need to fix a lagging issue when gameplay progresses.  I think it's a problem with the ShowInGameBoard() method.  It currently re-populates the entire board after every move.  I'll change it to only make changes to the cells that were modified and that should help with the lag.  I'll try adjusting the FloodFill method to return cells that were modified.
