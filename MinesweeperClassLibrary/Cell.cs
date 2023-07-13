//Written by Jess Larson
//7/2/23

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary
{
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }

        //if the cell has been visited
        public bool Visited { get; set; }

        //if the cell is a bomb then live = true
        public bool Live { get; set; }

        //+1 for every neighbor that is a bomb
        public int LiveNeighbors { get; set; }

        //primary constructor that is called by the Board class
        public Cell(int row = -1, int col = -1, bool visited = false, bool live = false, int liveNeighbors = 0)
        {
            Row = row;
            Col = col;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }
    }
}
