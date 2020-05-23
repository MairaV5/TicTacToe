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

        private void InitializeCells()
        {
            string labelName;
            for(int i = 1; i <=9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
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
            CheckForWin();
            XplayerTurn = !XplayerTurn;
        }

        private void CheckForWin()
        {
            if (
                  (label1.Text == label2.Text && label2.Text == label3.Text && label1.Text != string.Empty) ||
                  (label4.Text == label5.Text && label5.Text == label6.Text && label4.Text != string.Empty) ||
                  (label7.Text == label8.Text && label8.Text == label9.Text && label7.Text != string.Empty) ||
                  (label1.Text == label4.Text && label4.Text == label7.Text && label1.Text != string.Empty) ||
                  (label2.Text == label5.Text && label5.Text == label8.Text && label2.Text != string.Empty) ||
                  (label3.Text == label6.Text && label6.Text == label9.Text && label3.Text != string.Empty) ||
                  (label1.Text == label5.Text && label5.Text == label9.Text && label1.Text != string.Empty) ||
                  (label3.Text == label5.Text && label5.Text == label7.Text && label3.Text != string.Empty)
               )
            {
                GameOver();
            }
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
            MessageBox.Show(winner + "wins!");
        }
    }
}
