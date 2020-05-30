using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool XplayerTurn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }

        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightPink;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
        }

        private void InitializeCells()
        {
            string labelName;
            for(int i = 1; i <=9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
                Grid.Controls[labelName].BackColor = Color.Transparent;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            //so we can not change the !empty label
            if(label.Text != string.Empty)
            {
                return;
            }

            if (XplayerTurn)
            {
                label.Text = "X";
            }
            else
            {
                label.Text = "O";
            }
            turnCount++;
            PlaySound();
            CheckForWin();
            CheckForDraw();
            XplayerTurn = !XplayerTurn;
        }

        private void CheckForWin()
        {
            if (
                  (label1.Text == label2.Text && label2.Text == label3.Text && label1.Text != String.Empty) ||
                  (label4.Text == label5.Text && label5.Text == label6.Text && label4.Text != String.Empty) ||
                  (label7.Text == label8.Text && label8.Text == label9.Text && label7.Text != String.Empty) ||
                  (label1.Text == label4.Text && label4.Text == label7.Text && label1.Text != String.Empty) ||
                  (label2.Text == label5.Text && label5.Text == label8.Text && label2.Text != String.Empty) ||
                  (label3.Text == label6.Text && label6.Text == label9.Text && label3.Text != String.Empty) ||
                  (label1.Text == label5.Text && label5.Text == label9.Text && label1.Text != String.Empty) ||
                  (label3.Text == label5.Text && label5.Text == label7.Text && label3.Text != String.Empty)
               )
            {
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label2, label3, Color.DeepSkyBlue);
            }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                ChangeCellColors(label4, label5, label6, Color.DeepSkyBlue);
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                ChangeCellColors(label7, label8, label9, Color.DeepSkyBlue);
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label4, label7, Color.DeepSkyBlue);
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                ChangeCellColors(label2, label5, label8, Color.DeepSkyBlue);
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label6, label9, Color.DeepSkyBlue);
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label5, label9, Color.DeepSkyBlue);
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label5, label7, Color.DeepSkyBlue);
            }
        }

        private void CheckForDraw()
        {
            if(turnCount == 9)
            {
                MessageBox.Show("Ou well it is a draw!");
                RestartGame();
            }
        }

        private void ChangeCellColors(Label firstLabel, Label secondLabel, Label thirdLabel, Color color)
        {
            firstLabel.BackColor = color;
            secondLabel.BackColor = color;
            thirdLabel.BackColor = color;
        }

        private void GameOver()
        {
            string winner;
            if (XplayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            WinnerCellsChangeColor();
            MessageBox.Show(winner + " wins! ");
            RestartGame();
        }

        private void PlaySound()
        {
            System.IO.Stream str = Properties.Resources.click_sound_wav;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
    }
}
