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

namespace Looping___Math_Tricks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Figure figureRed;
        Figure figureBlue;
        Figure currentFigure = new Figure(1, 1, 0);
        public Button[,] buttonMatrix;
        bool[,] booleanMatrix;

        private void playingField_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < buttonMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < buttonMatrix.GetLength(1); k++)
                {
                    buttonMatrix[i, k].Enabled = false;
                }
            }

            int clickedBtnX = 0;
            int clickedBtnY = 0;
            setClickedButtonCoordinates(ref clickedBtnX, ref clickedBtnY, sender);

            currentFigure.MoveAndSum(buttonMatrix, clickedBtnX, clickedBtnY);

            playerRedScore.Text = "Player Red: " + figureRed.Sum.ToString();
            playerBlueScore.Text = "Player Blue: " + figureBlue.Sum.ToString();

            booleanMatrix[clickedBtnX, clickedBtnY] = false;

            if (currentFigure == figureRed)
            {
                buttonMatrix[clickedBtnX, clickedBtnY].BackColor = Color.LightCoral;
            }
            else
            {
                buttonMatrix[clickedBtnX, clickedBtnY].BackColor = Color.Aquamarine;
            }

            buttonMatrix[currentFigure.X, currentFigure.Y].BackgroundImage = null;

            currentFigure = currentFigure == figureRed ? figureBlue : figureRed;
            ShowAllowedMoves(currentFigure.X, currentFigure.Y);

            buttonMatrix[1, 1].Enabled = false;
            buttonMatrix[buttonMatrix.GetLength(0) - 2, buttonMatrix.GetLength(1) - 2].Enabled = false;

            if (IsGameOver(currentFigure.X, currentFigure.Y))
            {
                string winner = String.Empty;
                if (figureRed.Sum > figureBlue.Sum)
                {
                    winner = "Red";
                }
                else if (figureBlue.Sum > figureRed.Sum)
                {
                    winner = "Blue";
                }
                else
                {
                    winner ="Nobody";
                }

                MessageBox.Show(winner + " wins!");
            }
        }

        private void setClickedButtonCoordinates(ref int clickedBtnX, ref int clickedBtnY, object sender)
        {
            for (int i = 0; i < buttonMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < buttonMatrix.GetLength(1); k++)
                {
                    if ((object)buttonMatrix[i, k] == sender)
                    {
                        clickedBtnX = i;
                        clickedBtnY = k;
                    }
                }
            }
        }

        private void pawnAtStartGame_Click(object sender, EventArgs e)
        {
            currentFigure = ((Button)sender).Tag.ToString() == "redPlayer" ? figureRed : figureBlue;
            buttonMatrix[1, 1].Enabled = false;
            buttonMatrix[buttonMatrix.GetLength(0) - 2, buttonMatrix.GetLength(1) - 2].Enabled = false;
            ShowAllowedMoves(currentFigure.X, currentFigure.Y);
        }


        private void startGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(mInputBox.Text);
                if (n > 30) throw new Exception();

                int m = int.Parse(nInputBox.Text);
                if (m > 16) throw new Exception();

                booleanMatrix = new bool[n + 2, m + 2];
                buttonMatrix = InitializeButtonMatrix(n, m);

                startGameBtn.Enabled = false;

                DisableBorder(n, m);
                DisplayMatrixToBoard();
                InitializeFigures();

                mInputBox.ReadOnly = true;
                nInputBox.ReadOnly = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input!");
                mInputBox.Text = "";
                nInputBox.Text = "";
            }


        }

        private void InitializeFigures()
        {

            figureRed = new Figure(1, 1, 0);
            buttonMatrix[1, 1].Enabled = true;
            buttonMatrix[1, 1].BackgroundImageLayout = ImageLayout.Stretch;
            buttonMatrix[1, 1].BackColor = Color.LightCoral;
            buttonMatrix[1, 1].Text = "0";
            buttonMatrix[1, 1].Tag = "redPlayer";

            int bottomRightX = buttonMatrix.GetLength(0) - 2;
            int bottomRightY = buttonMatrix.GetLength(1) - 2;

            figureBlue = new Figure(bottomRightX, bottomRightY, 0);
            buttonMatrix[bottomRightX, bottomRightY].Enabled = true;
            buttonMatrix[bottomRightX, bottomRightY].BackgroundImageLayout = ImageLayout.Stretch;
            buttonMatrix[bottomRightX, bottomRightY].BackColor = Color.Aquamarine;
            buttonMatrix[bottomRightX, bottomRightY].Text = "0";
            buttonMatrix[bottomRightX, bottomRightY].Tag = "bluePlayer";

            MessageBox.Show("Choose first player by clicking on a pawn!");
        }

        private Button[,] InitializeButtonMatrix(int widthCount, int heightCount)
        {
            Random r = new Random();
            int buttonSize = 30;
            int locX = 0, locY = 0;

            buttonMatrix = new Button[widthCount + 2, heightCount + 2];
            for (int i = 0; i < buttonMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < buttonMatrix.GetLength(1); k++)
                {

                    buttonMatrix[i, k] = new Button();
                    buttonMatrix[i, k].Size = new Size(buttonSize, buttonSize);
                    buttonMatrix[i, k].Location = new Point(locX, locY);
                    GeneratePlayfieldAction(ref buttonMatrix[i, k], r);
                    buttonMatrix[i, k].Enabled = false;
                    if ((i == 1 && k == 1) || (i == buttonMatrix.GetLength(0) - 2 && k == buttonMatrix.GetLength(0) - 2))
                    {
                        buttonMatrix[i, k].Click += new EventHandler(pawnAtStartGame_Click);
                    }
                    else
                    {
                        buttonMatrix[i, k].Click += new EventHandler(playingField_Click);
                    }
                    booleanMatrix[i, k] = true;
                    locX += 30;
                }
                locX = 0;
                locY += 30;
            }

            return buttonMatrix;
        }

        private void DisplayMatrixToBoard()
        {
            for (int i = 0; i < buttonMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < buttonMatrix.GetLength(1); k++)
                {
                    boardPanel.Controls.Add(buttonMatrix[i, k]);
                }
            }
        }

        private void GeneratePlayfieldAction(ref Button button, Random r)
        {
            char[] mathOperators = { '+', '-', '*', '/' };
            char choosenOperator = mathOperators[r.Next(0, 4)];
            int choosenNumber = choosenOperator == '/' ? r.Next(1, 7) : r.Next(0, 7);
            button.Text = choosenOperator.ToString() + choosenNumber;
        }


        private void DisableBorder(int N, int M)
        {
            //BUTTON VISIBLE = FALSE
            for (int i = 0; i < M + 2; i++) { buttonMatrix[0, i].Visible = false; buttonMatrix[0, i].Enabled = false; }
            for (int i = 0; i < N + 2; i++) { buttonMatrix[i, M + 1].Visible = false; buttonMatrix[i, M + 1].Enabled = false; }
            for (int i = M + 1; i > 0; i--) { buttonMatrix[N + 1, i].Visible = false; buttonMatrix[N + 1, i].Enabled = false; }
            for (int i = N + 1; i > 0; i--) { buttonMatrix[i, 0].Visible = false; buttonMatrix[i, 0].Enabled = false; }
        }

        private void ShowAllowedMoves(int buttonX, int buttonY)
        {

            for (int i = buttonY - 1; i < buttonY + 1; i++)
            {
                if (booleanMatrix[buttonX - 1, i] == true)
                {
                    buttonMatrix[buttonX - 1, i].Enabled = true;
                }
            }
            for (int i = buttonX - 1; i < buttonX + 1; i++)
            {
                if (booleanMatrix[i, buttonY + 1] == true)
                {
                    buttonMatrix[i, buttonY + 1].Enabled = true;
                }
            }
            for (int i = buttonY + 1; i > buttonY - 1; i--)
            {
                if (booleanMatrix[buttonX + 1, i] == true)
                {
                    buttonMatrix[buttonX + 1, i].Enabled = true;
                }
            }
            for (int i = buttonX + 1; i > buttonX - 1; i--)
            {
                if (booleanMatrix[i, buttonY - 1] == true)
                {
                    buttonMatrix[i, buttonY - 1].Enabled = true;
                }
            }


        }
        private bool IsGameOver(int currentFigureX, int currentFigureY)
        {
            int counter = 0;
            for (int i = currentFigureY - 1; i < currentFigureY + 1; i++)
            {
                if (buttonMatrix[currentFigureX - 1, i].Enabled == false)
                {
                    counter += 1;
                }

            }
            for (int i = currentFigureX - 1; i < currentFigureX + 1; i++)
            {
                if (buttonMatrix[i, currentFigureY + 1].Enabled == false)
                {
                    counter += 1;
                }
            }
            for (int i = currentFigureY + 1; i > currentFigureY - 1; i--)
            {
                if (buttonMatrix[currentFigureX + 1, i].Enabled == false)
                {
                    counter += 1;
                }
            }
            for (int i = currentFigureX + 1; i > currentFigureX - 1; i--)
            {
                if (buttonMatrix[i, currentFigureY - 1].Enabled == false)
                {
                    counter += 1;
                }
            }
            if (counter == 8)
            {
                return true;
            }
            else return false;
        }

    }
}

