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

            //get top 5 of each board size lists
            ScoreBoard smallSortedScores = scoreBoard.SmallTop5();
            ScoreBoard mediumSortedScores = scoreBoard.MediumTop5();
            ScoreBoard largeSortedScores = scoreBoard.LargeTop5();

            //display each list on the scoreboard form
            SmallLabel.Text = smallSortedScores.Display();
            MediumLabel.Text = mediumSortedScores.Display();
            LargeLabel.Text = largeSortedScores.Display();
        }
    }
}
