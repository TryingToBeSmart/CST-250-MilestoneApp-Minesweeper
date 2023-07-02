using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary
{
    public class Cell
    {
        //primary constructor that is called by the Board class
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }

        public Cell()
        {
            Row = -1;
            Col = -1;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }

        public Cell(int row, int col, bool visited, bool live, int liveNeighbors)
        {
            Row = row;
            Col = col;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        //if the cell has been visited
        public bool Visited { get; set; }

        //if the cell is a bomb then live = true
        public bool Live { get; set; }

        //+1 for every neighbor that is a bomb
        public int LiveNeighbors { get; set; }

    }
}
