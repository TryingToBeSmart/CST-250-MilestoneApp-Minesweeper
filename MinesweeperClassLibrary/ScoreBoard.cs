using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using MinesweeperClassLibrary;

/// <summary>
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
            this.scoreBoard = ReadFromFile();
        }

        //Read Scoreboard from a file
        public List<PlayerStats> ReadFromFile()
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
            return playerStatsList;
        }

        //displays the scoreboard in order by score
        public string Display()
        {
            var sortedScoreBoard = scoreBoard.OrderBy(x => x);

            string displayString = "";
            foreach (var item in sortedScoreBoard)
            {
                displayString += "\n" + item.Display();
            }
            return displayString;
        }

        //add individual player to scoreboard and writes to the file
        public void Add(PlayerStats player)
        {
            scoreBoard.Add(player);
            using (StreamWriter writer = new StreamWriter(@".\ScoreBoard.resources", true))
            {
                writer.WriteLine(player.FileDisplay());
            }
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

