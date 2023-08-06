﻿using Microsoft.VisualBasic.ApplicationServices;
using MinesweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Timer = System.Threading.Timer;

namespace CST_250_MilstoneApp
{
    public partial class GameForm : Form
    {
        Board GameBoard;
        private Button[,] ButtonGrid;
        ScoreBoard scoreBoard;
        int BoardSizeInt;
        int BoardDifficulty;
        string Difficulty;
        string BoardSizeString;
        bool Win = false;
        bool GameOver = false;
        static Stopwatch stopwatch = new Stopwatch();
        long MaxScore;

        public GameForm(string size, string difficulty, ScoreBoard scoreBoard)
        {
            InitializeComponent();
            PopulateGrid(size, difficulty);
            this.Difficulty = difficulty;
            this.BoardSizeString = size;
            this.scoreBoard = scoreBoard;
            stopwatch.Reset();
            stopwatch.Start();
            timer1.Enabled = true;
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
                        BoardSizeInt = 10;
                        break;
                    }
                case "Medium":
                    {
                        this.Size = new Size(597, 720);
                        BoardSizeInt = 20;
                        break;
                    }
                case "Large":
                    {
                        this.Size = new Size(858, 970);
                        BoardSizeInt = 30;
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
                        MaxScore = 100;
                        break;
                    }
                case "Moderate":
                    {
                        BoardDifficulty = 10;
                        MaxScore = 100_000;
                        break;
                    }
                case "Hard":
                    {
                        BoardDifficulty = 15;
                        MaxScore = 100_000_000;
                        break;
                    }
                default:
                    break;
            }

            GameBoard = new Board(BoardSizeInt, BoardDifficulty);//construct new board
            ButtonGrid = new Button[BoardSizeInt, BoardSizeInt];//set the ButtonGrid dimensions
            panel1.Width = this.Width - 10;//set the size of the panel to fit inside the form
            panel1.Height = panel1.Width; // make square grid
            int buttonSize = panel1.Width / BoardSizeInt; // calculate the width of each button

            //loop to create and place buttons in the panel
            for (int row = 0; row < BoardSizeInt; row++)
            {
                for (int col = 0; col < BoardSizeInt; col++)
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
                    ButtonGrid[row, col].BackgroundImageLayout = ImageLayout.Zoom;
                    ButtonGrid[row, col].Font = new Font("Arial", float.Parse(buttonSize.ToString()) / 2, FontStyle.Bold);
                    ButtonGrid[row, col].MouseDown += Grid_Button_MouseDown;
                    //ButtonGrid[row, col].Click += Grid_Button_Click;// add click event to each button
                    panel1.Controls.Add(ButtonGrid[row, col]);// place button on panel
                    ButtonGrid[row, col].Location = new Point(buttonSize * row, buttonSize * col);// position buttons

                    // Use Tag attribute to hold row, col numbers in a string
                    ButtonGrid[row, col].Tag = row.ToString() + "|" + col.ToString();
                }
            }
        }

        //The method has an important
        //parameter called object sender. This
        //refers to the control that caused this
        //method to be called. We can refer to
        //this parameter later as (sender as
        //Button)
        private void Grid_Button_MouseDown(object? sender, MouseEventArgs e)
        {
            //only perform button click event if game is not over
            if (!GameOver)
            {
                // get the row and col number of the button just clicked
                string[] stringArray = (sender as Button).Tag.ToString().Split('|');
                int row = int.Parse(stringArray[0]);
                int col = int.Parse(stringArray[1]);

                Cell currentCell = GameBoard.Grid[row, col];

                //if right button was clicked, then alternate adding/removing a flag
                if (e.Button == MouseButtons.Right)
                {
                    if (!GameBoard.Grid[row, col].Flag)
                    {
                        GameBoard.Grid[row, col].Flag = true;
                    }
                    else
                        GameBoard.Grid[row, col].Flag = false;

                    ShowInGameBoard();
                }

                //else if left click
                else
                {
                    //live bomb clicked, game over
                    if (GameBoard.Grid[row, col].Live && !GameBoard.Grid[row, col].Flag)
                    {
                        Win = false;
                        timer1.Enabled = false;
                        ShowBoard();
                        MessageBox.Show("Boom!");
                        GameOver = true;
                    }

                    //continue game
                    else
                    {
                        GameBoard.FloodFill(currentCell);
                        ShowInGameBoard();
                    }

                    //if winner, game over, send to Player name form and then add the player to the scoreboard file
                    if (GameBoard.CheckForWinner())
                    {
                        stopwatch.Stop();
                        Win = true;
                        ShowBoard();
                        GameOver = true;
                        MessageBox.Show($"You Win! \nTime: {stopwatch.Elapsed.ToString(@"mm\:ss\.ff")}");
                        PlayerStats newPlayer = new PlayerStats();
                        PlayerNameForm playerNameForm = new PlayerNameForm();
                        if(playerNameForm.ShowDialog() == DialogResult.OK)
                        {
                            newPlayer.Name = playerNameForm.PlayerNameTextBox.Text;//get the player's name from the PlayerNameForm
                            newPlayer.Score = MaxScore - stopwatch.ElapsedMilliseconds / 1000;
                            newPlayer.Time = stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
                            newPlayer.Date = DateTime.Now;
                            newPlayer.Difficulty = Difficulty;
                            newPlayer.BoardSize = BoardSizeString;
                            scoreBoard.Add(newPlayer);                            
                        }
                        ScoreBoardForm scoreBoardForm = new ScoreBoardForm(scoreBoard);
                        scoreBoardForm.ShowDialog();
                    }
                }
            }
        }

        //print updated board for gameplay
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!TODO adjust so that only the cells that were changed get repopulated.  Currently all cells get repopulated after every move.  There is a lag issue.
        //also adjust FloodFill method in Board class to return a List of cells that were altered.
        private void ShowInGameBoard()
        {
            foreach (var cell in GameBoard.Grid)
            {
                if (cell.Visited)
                {
                    ButtonGrid[cell.Row, cell.Col].FlatAppearance.BorderSize = 0;
                    //only print numbers of live neighbors != 0; leave 0s blank
                    if (GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors != 0)
                    {
                        ButtonGrid[cell.Row, cell.Col].Text = GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors.ToString();
                    }
                }

                //check for flags
                else if (cell.Flag)
                    ButtonGrid[cell.Row, cell.Col].BackgroundImage = new Bitmap(Resource1.flag);

                else
                    ButtonGrid[cell.Row, cell.Col].BackgroundImage = null;
            }
        }

        //print full board
        private void ShowBoard()
        {
            foreach (var cell in GameBoard.Grid)
            {
                if (cell.Live && !Win)
                {
                    //show bombs if loss
                    ButtonGrid[cell.Row, cell.Col].BackgroundImage = new Bitmap(Resource1.bomb);
                    ButtonGrid[cell.Row, cell.Col].BackColor = Color.Red;
                    ButtonGrid[cell.Row, cell.Col].FlatAppearance.MouseOverBackColor = Color.DarkRed;
                }
                else if (cell.Live && Win)
                {
                    //show flags if win
                    ButtonGrid[cell.Row, cell.Col].BackgroundImage = new Bitmap(Resource1.flag);
                }
                else
                {
                    //only print numbers of live neighbors != 0, leave 0s blank
                    if (GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors != 0)
                        ButtonGrid[cell.Row, cell.Col].Text = GameBoard.Grid[cell.Row, cell.Col].LiveNeighbors.ToString();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
        }
    }
}
