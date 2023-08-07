using MinesweeperClassLibrary;
using System.Linq;
using System.Resources;

namespace CST_250_MilstoneApp
{
    public partial class MenuForm : Form
    {
        //Construct Scoreboard
        ScoreBoard scoreBoard = new ScoreBoard();
        public MenuForm()
        {
            InitializeComponent();
            scoreBoard.ReadFromFile();
        }

        //click start button
        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "Loading...";
            Application.DoEvents(); // Force UI update

            //get the text from the radio buttons
            string size = SizeGroupBox.Controls.Cast<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            string difficulty = DifficultyGroupBox.Controls.Cast<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            GameForm gameForm = new GameForm(size, difficulty, scoreBoard);

            if (gameForm.DialogResult != DialogResult.Cancel)
            {
                this.Hide();
                gameForm.ShowDialog();
            }
            StartButton.Text = "Start";
            this.Show();
        }

        private void ScoreBoardButton_Click(object sender, EventArgs e)
        {
            ScoreBoardForm scoreBoardForm = new ScoreBoardForm(scoreBoard);
            scoreBoardForm.Show();
        }
    }
}