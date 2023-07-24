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

namespace CST_250_MilstoneApp
{
    public partial class GameForm : Form
    {
        Board GameBoard;
        private Button[,] ButtonGrid;
        int BoardSize;
        int BoardDifficulty;

        public GameForm(string size, string difficulty)
        {
            InitializeComponent();
            PopulateGrid(size, difficulty);
        }

        private void PopulateGrid(string size, string difficulty)
        {
            //set size of form and how many cells in the board
            //Only works if the form.autosize is set to 'false'
            switch (size)
            {
                case "Small":
                    {
                        this.Size = new Size(427, 550);
                        BoardSize = 10;
                        break;
                    }
                case "Medium":
                    {
                        this.Size = new Size(597, 720);
                        BoardSize = 20;
                        break;
                    }
                case "Large":
                    {
                        this.Size = new Size(858, 970);
                        BoardSize = 30;
                        break;
                    }
                default:
                    break;
            }


            //set difficulty of board
            switch (difficulty)
            {
                case "Easy":
                    {
                        BoardDifficulty = 5;
                        break;
                    }
                case "Moderate":
                    {
                        BoardDifficulty = 15;
                        break;
                    }
                case "Hard":
                    {
                        BoardDifficulty = 30;
                        break;
                    }
                default:
                    break;
            }

            GameBoard = new Board(BoardSize, BoardDifficulty);//construct new board
            ButtonGrid = new Button[BoardSize, BoardSize];//set the ButtonGrid dimensions
            panel1.Width = this.Width - 10;//set the size of the panel to fit inside the form
            panel1.Height = panel1.Width; // make square grid
            int buttonSize = panel1.Width / BoardSize; // calculate the width of each button

            //loop to create and place buttons in the panel
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    ButtonGrid[row, col] = new Button();
                    //square buttons
                    ButtonGrid[row, col].Width = buttonSize;
                    ButtonGrid[row, col].Height = buttonSize;

                    //design buttons
                    ButtonGrid[row, col].FlatStyle = FlatStyle.Flat;
                    ButtonGrid[row, col].FlatAppearance.BorderColor = Color.Lime;
                    ButtonGrid[row, col].FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
                    ButtonGrid[row, col].FlatAppearance.MouseDownBackColor = Color.DarkSeaGreen;
                    ButtonGrid[row, col].ForeColor = Color.Lime;
                    ButtonGrid[row, col].Font = new Font("Arial", float.Parse(buttonSize.ToString()) / 2, FontStyle.Bold);

                    ButtonGrid[row, col].Click += Grid_Button_Click;// add click event to each button
                    panel1.Controls.Add(ButtonGrid[row, col]);// place button on panel
                    ButtonGrid[row, col].Location = new Point(buttonSize * row, buttonSize * col);// position buttons

                    // Use Tag attribute to hold row, col numbers in a string
                    ButtonGrid[row, col].Tag = row.ToString() + "|" + col.ToString();
                }
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            //The method has an important
            //parameter called object sender. This
            //refers to the control that caused this
            //method to be called. We can refer to
            //this parameter later as (sender as
            //Button)

            // get the row and col number of the button just clicked
            string[] stringArray = (sender as Button).Tag.ToString().Split('|');
            int row = int.Parse(stringArray[0]);
            int col = int.Parse(stringArray[1]);

            Cell currentCell = GameBoard.Grid[row, col];

            if (GameBoard.Grid[row, col].Live)
            {
                ShowBoard();
                MessageBox.Show("Boom!");
            }

            else 
            {
                GameBoard.FloodFill(currentCell);
                ShowInGameBoard();
            }

            if (GameBoard.CheckForWinner())
            {
                ShowBoard();
                MessageBox.Show("You Win!");
            }
        }

        //print updated board for gameplay
        private void ShowInGameBoard()
        {
            foreach (var cell in GameBoard.Grid)
            {
                if (cell.Visited)
                {
                    ButtonGrid[cell.Row, cell.Col].FlatAppearance.BorderColor = Color.Black;
                    //only print numbers of live neighbors != 0, leave 0s blank
                    if (GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors != 0)
                    {
                        ButtonGrid[cell.Row, cell.Col].Text = GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors.ToString();
                    }
                        
                }

            }
        }

        //print full board
        private void ShowBoard()
        {
            foreach (var cell in GameBoard.Grid)
            {
                if (cell.Live)
                    ButtonGrid[cell.Row, cell.Col].Text = "X";
                else
                {
                    //only print numbers of live neighbors != 0, leave 0s blank
                    if (GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors != 0)
                        ButtonGrid[cell.Row, cell.Col].Text = GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors.ToString();
                }
                    
            }
        }
    }
}
