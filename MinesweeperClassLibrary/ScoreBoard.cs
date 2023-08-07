using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Resources;
using MinesweeperClassLibrary;

/// <summary>
/// Jess Larson
/// keep list of PlayerScores to keep track of a scoreboard/leaderboard
/// File IO added for local storage
/// </summary>
namespace MinesweeperClassLibrary
{
    
    public class ScoreBoard : IEnumerable<PlayerStats>
    {
        public List<PlayerStats> scoreBoard { get; set; }

        //construct scoreboard by reading from the local file
        public ScoreBoard()
        {
            this.scoreBoard = new List<PlayerStats>();
        }

        //Read Scoreboard from a file
        public void ReadFromFile()
        {
            List<PlayerStats> playerStatsList = new List<PlayerStats>();
            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(@".\ScoreBoard.resources").ToList();//use the txt file in the resources to load the scoreboard data
            }
            catch (Exception) { }

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 6)
                //construct a new PlayerStats using the line text
                {
                    playerStatsList.Add(new PlayerStats(parts[0], Int32.Parse(parts[1]),
                        parts[2], DateTime.Parse(parts[3]), parts[4], parts[5]));
                }
            }
            this.scoreBoard = playerStatsList;
        }

        //displays the scoreboard in order by score
        public string Display()
        {
            //might already be sorted, but just in case it's not
            var sortedScoreBoard = scoreBoard.Order();

            string displayString = "";
            int count = 1;
            foreach (var player in sortedScoreBoard)
            {
                displayString += $"{count}. {player.Display()}\n";
                count++;
            }
            return displayString;
        }

        //add individual player to scoreboard
        public void Add(PlayerStats player)
        {
            scoreBoard.Add(player);
        }

        //write one player to scoreboard file
        public void WriteToFile(PlayerStats player)
        {
            using (StreamWriter writer = new StreamWriter(@".\ScoreBoard.resources", true))
                {
                    writer.WriteLine(player.FileDisplay());
            }
        }

        //use Linq to get top 5 of Small board 
        public ScoreBoard SmallTop5()
        {
            var scoreBoard = this.Where(player => player.BoardSize == "Small").Order().Take(5);

            //convert to ScoreBoard
            ScoreBoard newBoard = new ScoreBoard();
            foreach (var player in scoreBoard)
            {
                newBoard.Add(player);
            }
            return newBoard;
        }

        //use Linq to get top 5 of Medium board
        public ScoreBoard MediumTop5()
        {
            var scoreBoard = this.Where(player => player.BoardSize == "Medium").Order().Take(5);

            //convert to ScoreBoard
            ScoreBoard newBoard = new ScoreBoard();
            foreach (var player in scoreBoard)
            {
                newBoard.Add(player);
            }
            return newBoard;
        }
        
        //use Linq to get top 5 of Large board
        public ScoreBoard LargeTop5()
        {
            var scoreBoard = this.Where(player => player.BoardSize == "Large").Order().Take(5);
            
            //convert to ScoreBoard
            ScoreBoard newBoard = new ScoreBoard();
            foreach (var player in scoreBoard)
            {
                newBoard.Add(player);
            }
            return newBoard;
        }

        //use Linq to get top 5 of any board
        public ScoreBoard Top5()
        {
            scoreBoard.Order().Take(5);//sort and then get top 5
            ScoreBoard newBoard = new ScoreBoard();
            foreach (var player in scoreBoard)
            {
                newBoard.Add(player);
            }
            return newBoard;
        }

        //implement IEnumerator so that other classes can iterate through the Scoreboard
        //https://stackoverflow.com/questions/11296810/how-do-i-implement-ienumerablet
        public PlayerStats this[int index]
        {
            get { return scoreBoard[index]; }
            set { scoreBoard.Insert(index, value); }
        }

        public IEnumerator<PlayerStats> GetEnumerator()
        {
            return scoreBoard.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

