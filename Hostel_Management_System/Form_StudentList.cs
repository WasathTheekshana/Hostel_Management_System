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
    public partial class Form_StudentList : Form
    {
        public Form_StudentList()
        {
            InitializeComponent();
        }

        private void Form_StudentList_Load(object sender, EventArgs e)
        {
            
        }

        private void hideAllUnderLines()
        {
            groundUnderLine.Visible = false;
            FirstUnderLine.Visible = false;
            secondUnderLine.Visible = false;
        }

        private void firstTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            FirstUnderLine.Visible=true;
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            secondUnderLine.Visible = true;
        }

        private void groundTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            groundUnderLine.Visible = true;
        }

        private void guna2ShadowPanel2_MouseEnter(object sender, EventArgs e)
        {
            guna2ShadowPanel2.ShadowDepth = 15;
            
        }

        private void guna2ShadowPanel2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void guna2ShadowPanel2_MouseLeave(object sender, EventArgs e)
        {
            guna2ShadowPanel2.ShadowDepth = 5;
            
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
