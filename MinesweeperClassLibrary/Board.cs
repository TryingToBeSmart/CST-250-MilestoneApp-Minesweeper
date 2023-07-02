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

        //primary constructor that sets up the board completely
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
            // Print column numbers
            Console.Write("   ");
            for (int col = 0; col < Size; col++)
            {
                Console.Write(col + "   ");
            }
            Console.WriteLine();

            // Print top border line
            Console.WriteLine("  +" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");

            // Print board rows
            for (int row = 0; row < Size; row++)
            {
                Console.Write(row + " |"); // Print row number and left border

                for (int col = 0; col < Size; col++)
                {
                    Cell cell = Grid[row, col];
                    if (cell.Live)
                    {
                        Console.Write(" X "); // Print a live cell as "X"
                    }
                    else
                    {
                        Console.Write(" " + cell.LiveNeighbors + " "); // Print the count of live neighbors
                    }
                    Console.Write("|"); // Print cell separator
                }
                Console.WriteLine();

                // Print inner horizontal line
                Console.WriteLine("  +" + string.Join("+", Enumerable.Repeat("---", Size)) + "+");
            }
        }
    }
}
