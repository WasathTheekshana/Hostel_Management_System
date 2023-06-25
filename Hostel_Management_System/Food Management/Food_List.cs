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
            groundUnderLine.Visible = false;
            FirstUnderLine.Visible = false;
            secondUnderLine.Visible = false;
            thirdUnderLine.Visible = false;
        }

        private void groundTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            groundUnderLine.Visible = true;
        }

        private void firstTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            FirstUnderLine.Visible = true;
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            secondUnderLine.Visible = true;
        }

        private void thirdTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            thirdUnderLine.Visible = true;
        }
    }
}
