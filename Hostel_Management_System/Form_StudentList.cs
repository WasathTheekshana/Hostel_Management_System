using Hostel_Management_System.Database_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            SqlConnection conn = new SqlConnection(connStr);
            string query = "SELECT NIC,FName,Lname,MobileNo,DOB from student";


            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "student");
                guna2DataGridView1.DataSource = ds.Tables["student"];

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }
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

            DetailForm detailForm = new DetailForm();
        private void guna2ShadowPanel2_Click(object sender, EventArgs e)
        {
            detailForm.ShowDialog();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            detailForm.ShowDialog();

        }
    }
}
