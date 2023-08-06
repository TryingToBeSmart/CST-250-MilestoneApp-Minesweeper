using System;
using System.ComponentModel;
using System.Diagnostics;

/// <summary>
/// Keep each Player's score
/// </summary>
namespace MinesweeperClassLibrary
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string Name { get; set; }
        public long Score { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Difficulty { get; set; }
        public string BoardSize { get; set; }

        public PlayerStats() { }

        public PlayerStats(string name, long score, string time, DateTime date, string difficulty, string boardSize)
        {
            this.Name = name;
            this.Score = score;
            this.Time = time;
            this.Date = date;
            this.Difficulty = difficulty;
            this.BoardSize = boardSize;
        }

        //display string of player stats
        public string Display()
        {
            return $"{this.Score.ToString("N0")} {this.Name} {this.Time} {this.Difficulty} {this.Date.ToString("MM/dd/y")}";
        }

        //to write to file format
        public string FileDisplay()
        {
            return $"{this.Name},{this.Score},{this.Time},{this.Date},{this.Difficulty},{this.BoardSize}";
        }

        //Sort by High Score.  If tie, then oldest date
        public int CompareTo(PlayerStats? obj)
        {
            if(obj.Score == this.Score) { return this.Date.CompareTo(obj.Date); }
            return obj.Score.CompareTo(this.Score);
        }
    }

}
