using MinesweeperClassLibrary;

namespace CST_250_MilstoneApp
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //get the text from the radio buttons
            string size = SizeGroupBox.Controls.Cast<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            string difficulty = DifficultyGroupBox.Controls.Cast<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            GameForm gameForm = new GameForm(size, difficulty);

            if (gameForm.DialogResult != DialogResult.Cancel)
            {
                this.Hide();
                gameForm.ShowDialog();
            }

            this.Show();
        }
    }
}