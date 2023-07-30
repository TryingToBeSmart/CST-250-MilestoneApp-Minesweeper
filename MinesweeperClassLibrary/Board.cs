//Written by Jess Larson
//7/2/23

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MinesweeperClassLibrary
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public int Difficulty { get; set; }

        public Board() 
        {
        }

        //primary constructor that sets up the board completely: size and difficulty(0%-100% bombs)
        public Board(int size, int difficulty)
        {
            //check for correct difficulty parameters
            if (difficulty < 0 || difficulty > 100) throw new ArgumentOutOfRangeException("Difficulty must be between 0 and 100");

            else
            {
                Size = size;
                Difficulty = difficulty;

                //Grid initialized so that a Cell object is stored at each location.
                Grid = new Cell[size, size];

                //Set up cells
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        Cell cell = new Cell(i, j);
                        Grid[i, j] = cell;
                        SetupLiveCell(cell);
                    }
                }

                //Calculate and set the LiveNeighbors cell numbers
                CalculateLiveNeighbors();

            }
            
        }

        //A method to randomly initialize the cell with live bombs.
        //The method should utilize the Difficulty property to determine
        //what percentage of the cells in the grid will be set to "live" status.
        public void SetupLiveCell(Cell cell)
        {
            Random random = new Random();
            if(random.Next(100) < Difficulty) cell.Live = true;
        }

        //A method to calculate the live neighbors for every cell on the grid.
        //A cell should have between 0 and 8 live neighbors. If a cell itself is "live,"
        //then you can set the neighbor count to 9.
        public void CalculateLiveNeighbors()
        {
            foreach (Cell cell in Grid)
            {
                int liveNeighbors = 0;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        try
                        {
                            //check if surrounding cells are live
                            if (Grid[cell.Row + i, cell.Col + j].Live) liveNeighbors++;
                        }
                        catch (Exception)
                        {
                            //continue without throwing out of bounds exception if the cell is on an edge
                            continue;
                        }
                    }
                }
                cell.LiveNeighbors = liveNeighbors;
            }
        }

        //print board to console
        //for console testing
        //Got help from ChatGPT on creating the boarders
        public void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            // Print column numbers
            for (int col = 0; col < Size; col++)
            {
                if (col < 10) Console.Write($"  {col} ");
                else Console.Write($"  {col}");
            }
            Console.WriteLine();

            // Print top border line
            Console.WriteLine("+" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");

            // Print board rows
            for (int row = 0; row < Size; row++)
            {
                Console.Write("|"); // Print left border

                for (int col = 0; col < Size; col++)
                {
                    Cell cell = Grid[row, col];
                    if (cell.Live)
                    {
                        //change console color
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" X "); // Print a live cell as "X"
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    else if (cell.LiveNeighbors == 0) Console.Write("   ");//leave cells blank that have 0 live neighbors for better visibility
                    else
                    {
                        //change console color
                        Console.ForegroundColor = ConsoleColor.Blue; 
                        Console.Write(" " + cell.LiveNeighbors + " "); // Print the count of live neighbors
                        Console.ForegroundColor = ConsoleColor.Gray;
                        
                    }
                    
                    Console.Write("|"); // Print cell separator
                }
                Console.WriteLine($" {row}");

                // Print inner horizontal line
                Console.WriteLine("+" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");
            }
        }

        //for console game
        //display either the number of live neighbors or an empty square if there are no live neighbors.
        //If a cell has not been visited, print a question mark.
        public void PrintBoardDuringGame()
        {
            // Print column numbers
            for (int col = 0; col < Size; col++)
            {
                if (col < 10) Console.Write($"  {col} ");
                else Console.Write($"  {col}");
            }
            Console.WriteLine();

            // Print top border line
            Console.WriteLine("+" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");

            for (int row = 0; row < Size; row++)
            {
                Console.Write("|"); // Print left border

                for (int col = 0; col < Size; col++)
                {
                    if (Grid[row, col].Visited)
                    {
                        //if cell is visited and live neighbors = 0, then leave blank, else print the live neighbors number
                        if (Grid[row, col].LiveNeighbors == 0) Console.Write("   ");
                        else if (!Grid[row, col].Live)
                        {
                            //change console color
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($" {Grid[row, col].LiveNeighbors} ");

                            //change color back to normal
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    //if not visited print '?'
                    else if (!Grid[row, col].Visited)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" ? ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write("|"); // Print cell separator
                }
                Console.WriteLine($" {row}");

                // Print inner horizontal line
                Console.WriteLine("+" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");
            }
 
        }

        //Check if selected cell is a live bomb
        //not using right now
        public bool CheckForLiveBomb(Cell cell)
        {
            if(cell.Live) return true;
            return false;
        }

        //recursive method to show all of the surrounding cells that boarder the recent cell that was visited
        //and continue to mark them as visited as long as they boarder a cell that has 0 live neighbors
        //!!!!!!!!!!!!!!!!!!!TODO there is a lag issue in game play. Try to adjust this method to return a List of Cells that were altered so that the ShowInGameBoard method only needs to repopulate the cells that were altered.
        public void FloodFill(Cell cell)
        {
            //only perform if cell does not have a flag
            if (!cell.Flag)
            {

                //first, mark the cell as visited
                cell.Visited = true;

                //if the cell has any live neighbors, then return
                if (cell.LiveNeighbors != 0) return;

                //else continue to call the FloodFill on the surrounding cells
                for (int row = cell.Row - 1; row <= cell.Row + 1; row++)
                {
                    for (int col = cell.Col - 1; col <= cell.Col + 1; col++)
                    {
                        //ensure row and col are within board paramaters,
                        //it is not comparing the cell to itself, and it is was not visited before
                        if (row >= 0 && row < Size && col >= 0 && col < Size &&
                            Grid[row, col] != cell && Grid[row, col].Visited == false)

                            //call FloodFill again
                            FloodFill(Grid[row, col]);
                    }
                } 
            }
        }

        //check for winner
        public bool CheckForWinner()
        {
            bool win = false;

            foreach (var cell in Grid)
            {
                if (cell.Live) continue;//skip bombs
                if (!cell.Visited) return false;//if not visited, then no winner yet
            }

            //otherwise all cells are either visited or are bombs: return Winner == true;
            return true;
        }
    }
}
