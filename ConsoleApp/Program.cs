//Written by Jess Larson
//7/2/23

using MinesweeperClassLibrary;
internal static class Program
{
    static bool continueGame = true;

    static void Main()
    {
        Board board = new Board(11, 5);//initialize the game board size and difficulty
        //board.PrintBoard();//print the whole board with all cells revealed for testing

        //start the game
        while (continueGame)
        {
            board.PrintBoardDuringGame();//print the game board 
            int row = -1;
            int col = -1;

            //loop until correct row input is entered
            while(row < 0 || row >= board.Size)
            {
                Console.WriteLine($"Select Row: (0 - {board.Size - 1})");
                if (int.TryParse(Console.ReadLine(), out row));
                else row = -1;
            }

            //loop until correct col input is entered
            while (col < 0 || col >= board.Size)
            {
                Console.WriteLine($"Select Col: (0 - {board.Size - 1})");
                if (int.TryParse(Console.ReadLine(), out col));
                else col = -1;
            }

            //check if selected cell was a bomb
            if (board.Grid[row, col].Live)
            {
                board.PrintBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry there was a bomb there!");
                continueGame = false;
                break;
            }

            //if selected cell is zero, find all of the neighbor cells that are 0.
            //else just mark as visited.
            else
            {
                board.SearchForSurroundingZeros(board.Grid[row, col]);
            }
                        
            //check for winner
            if (board.CheckForWinner())
            {
                board.PrintBoard();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("!!!!!!!You Win!!!!!!");
                continueGame = false;
            }
        }
    }
}
