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
        private bool permission;
        public void getpermission(bool addPersmission)
        {
            permission = addPersmission;
        }

        public string userPrivi;
        public void setUserPrivi(string userPrivi)
        {
            this.userPrivi = userPrivi;
        }

        int studentCount;
        private void Form_StudentList_Load(object sender, EventArgs e)
        {
            if (!permission)
            {
                gunaLabel7.Visible = true;
                guna2Panel1.Visible = true;
                guna2ShadowPanel2.Cursor=Cursors.Default;
            }
            showGroundStudent();

        }

        private void showGroundStudent()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            SqlConnection conn = new SqlConnection(connStr);
            string queryground = @"SELECT s.Room_No AS Room, st.NIC, st.FName, st.Batch, st.MobileNo
                 FROM slot s
                 INNER JOIN student_slot ss ON s.slotID = ss.slotID
                 INNER JOIN student st ON ss.NIC = st.NIC
                 WHERE s.Floor = 'g'";


            string queryCount = @"SELECT COUNT(*) FROM student";

            try
            {
                conn.Open();

                SqlCommand commandCount = new SqlCommand(queryCount, conn);

                int studentCount = (int)commandCount.ExecuteScalar();
                lblCurrentStudentCount.Text = studentCount.ToString();

                SqlDataAdapter adapterg = new SqlDataAdapter(queryground, conn);
                DataSet dsg = new DataSet();

                adapterg.Fill(dsg, "student");
                guna2DataGridView1.DataSource = dsg.Tables["student"];


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

        private void showFirstStudent()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            SqlConnection conn = new SqlConnection(connStr);
            string queryfirst = @"SELECT s.Room_No AS Room, st.NIC, st.FName, st.Batch, st.MobileNo
                 FROM slot s
                 INNER JOIN student_slot ss ON s.slotID = ss.slotID
                 INNER JOIN student st ON ss.NIC = st.NIC
                 WHERE s.Floor = '1'";


            string queryCount = @"SELECT COUNT(*) FROM student";

            try
            {
                conn.Open();

                SqlCommand commandCount = new SqlCommand(queryCount, conn);

                int studentCount = (int)commandCount.ExecuteScalar();
                lblCurrentStudentCount.Text = studentCount.ToString();

                SqlDataAdapter adapter1 = new SqlDataAdapter(queryfirst, conn);
                DataSet ds1 = new DataSet();

                adapter1.Fill(ds1, "student");
                guna2DataGridView1.DataSource = ds1.Tables["student"];


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

        private void showSecondStudent()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            SqlConnection conn = new SqlConnection(connStr);
            string querysecond = @"SELECT s.Room_No AS Room, st.NIC, st.FName, st.Batch, st.MobileNo
                 FROM slot s
                 INNER JOIN student_slot ss ON s.slotID = ss.slotID
                 INNER JOIN student st ON ss.NIC = st.NIC
                 WHERE s.Floor = '2'";


            string queryCount = @"SELECT COUNT(*) FROM student";

            try
            {
                conn.Open();

                SqlCommand commandCount = new SqlCommand(queryCount, conn);

                int studentCount = (int)commandCount.ExecuteScalar();
                lblCurrentStudentCount.Text = studentCount.ToString();

                SqlDataAdapter adapter2 = new SqlDataAdapter(querysecond, conn);
                DataSet ds2 = new DataSet();

                adapter2.Fill(ds2, "student");
                guna2DataGridView1.DataSource = ds2.Tables["student"];


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
            showFirstStudent();
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            secondUnderLine.Visible = true;
            showSecondStudent();
        }

        private void groundTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            groundUnderLine.Visible = true;
            showGroundStudent();
        }

        private void guna2ShadowPanel2_MouseEnter(object sender, EventArgs e)
        {
            if (permission)
            {
                guna2ShadowPanel2.ShadowDepth = 15;
            }
            
        }

        private void guna2ShadowPanel2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void guna2ShadowPanel2_MouseLeave(object sender, EventArgs e)
        {
            if (permission)
            {
                guna2ShadowPanel2.ShadowDepth = 5;
            }
            
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                string studentNIC = selectedRow.Cells["NIC"].Value.ToString();
                DetailForm details = new DetailForm();
                details.getNIC(studentNIC);
                details.setprivi(permission);
                details.changetoUpdate();
                details.Show();
            }
        }

    }
}
