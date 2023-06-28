using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Food_List : Form
    {
        public Food_List()
        {
            InitializeComponent();
        }

        private void hideAllUnderLines()
        {
            chickenUnderLine.Visible = false;
            fishUnderLine.Visible = false;
            eggUnderLine.Visible = false;
            vegUnderLine.Visible = false;
        }

        private void groundTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            chickenUnderLine.Visible = true;
        }

        private void firstTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            fishUnderLine.Visible = true;
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            eggUnderLine.Visible = true;
        }

        private void thirdTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            vegUnderLine.Visible = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
