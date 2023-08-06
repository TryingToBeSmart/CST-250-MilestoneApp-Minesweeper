using MinesweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace CST_250_MilstoneApp
{
    public partial class ScoreBoardForm : Form
    {
        public ScoreBoardForm(ScoreBoard scoreBoard)
        {
            InitializeComponent();

            //move scoreboard to a List so that Linq can be used
            List<PlayerStats> playerList = scoreBoard.ToList();

            //use Linq to get top 5 of each board size lists
            var smallSortedScores = playerList.Where(player => player.BoardSize == "Small").Order().Take(5);
            var mediumSortedScores = playerList.Where(player => player.BoardSize == "Medium").Order().Take(5);
            var largeSortedScores = playerList.Where(player => player.BoardSize == "Large").Order().Take(5);

            //display each list on the scoreboard form
            int count = 1;
            foreach ( var player in smallSortedScores )
            {
                SmallLabel.Text += $"{count}. {player.Display()}\n";
                count++;
            }
            count = 1;
            foreach (var player in mediumSortedScores)
            {
                MediumLabel.Text += $"{count}. {player.Display()}\n";
                count++;
            }
            count = 1;
            foreach (var player in largeSortedScores)
            {
                LargeLabel.Text += $"{count}. {player.Display()}\n";
                count++;
            }
        }
    }
}
