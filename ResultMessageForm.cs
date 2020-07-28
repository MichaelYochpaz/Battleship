using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class ResultMessageForm : Form
    {
        private MainForm frm;

        public ResultMessageForm(MainForm frm, Player.PlayerType type)
        {
            this.frm = frm;
            InitializeComponent();

            if (type == Player.PlayerType.Player)
            {
                pictureBox.Image = Properties.Resources.won;
                label.Text = "You Won!";
                label.ForeColor = Color.DodgerBlue;
            }

            else
            {
                pictureBox.Image = Properties.Resources.lost;
                label.Text = "You Lost!";
                label.ForeColor = Color.Firebrick;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            frm.DebugMode(false);
            this.Close();
            frm.StartGame();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            frm.Close();
        }
    }
}
