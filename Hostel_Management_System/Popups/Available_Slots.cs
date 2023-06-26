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

namespace Hostel_Management_System.Popups
{
    public partial class Available_Slots : Form
    {
        public Available_Slots()
        {
            InitializeComponent();
        }

        private void getDataGroundFloor()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string queryGround = @"SELECT s.Room_NO AS Room, s.slotID AS [Slot ID]
                FROM slot s
                LEFT JOIN student_slot ss ON s.slotID = ss.slotID
                WHERE ss.slotID IS NULL AND s.Floor = 'g'";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapterground = new SqlDataAdapter(queryGround, conn);
                    DataSet dsg = new DataSet();

                    adapterground.Fill(dsg, "unassigned_slots");

                    DataTable dtg = dsg.Tables["unassigned_slots"];
                    dtg.Columns["Room"].ColumnName = "Room";
                    dtg.Columns["Slot ID"].ColumnName = "Slot ID";

                    availableSlotDataGrid.DataSource = dtg;
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

        }

        private void getDataFirstFloor()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string queryFirst = @"SELECT s.Room_NO AS Room, s.slotID AS [Slot ID]
                FROM slot s
                LEFT JOIN student_slot ss ON s.slotID = ss.slotID
                WHERE ss.slotID IS NULL AND s.Floor = '1'";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapterfirst = new SqlDataAdapter(queryFirst, conn);
                    DataSet ds1 = new DataSet();

                    adapterfirst.Fill(ds1, "unassigned_slots");

                    DataTable dt1 = ds1.Tables["unassigned_slots"];
                    dt1.Columns["Room"].ColumnName = "Room";
                    dt1.Columns["Slot ID"].ColumnName = "Slot ID";

                    availableSlotDataGrid.DataSource = dt1;
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
        }

        private void getDatasecondFloor()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string querySecond = @"SELECT s.Room_NO AS Room, s.slotID AS [Slot ID]
                FROM slot s
                LEFT JOIN student_slot ss ON s.slotID = ss.slotID
                WHERE ss.slotID IS NULL AND s.Floor = '2'";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapterSecond = new SqlDataAdapter(querySecond, conn);
                    DataSet ds2 = new DataSet();

                    adapterSecond.Fill(ds2, "unassigned_slots");

                    DataTable dt2 = ds2.Tables["unassigned_slots"];
                    dt2.Columns["Room"].ColumnName = "Room";
                    dt2.Columns["Slot ID"].ColumnName = "Slot ID";

                    availableSlotDataGrid.DataSource = dt2;
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
        }


        private void Available_Slots_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);


            getDataGroundFloor();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            FirstUnderLine.Visible = true;

            getDataFirstFloor();

        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            secondUnderLine.Visible = true;

            getDatasecondFloor();
        }

        private void groundTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            groundUnderLine.Visible = true;

            getDataGroundFloor();

        }

        private void availableSlotDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < availableSlotDataGrid.Rows.Count)
            {
                DataGridViewRow selectedRow = availableSlotDataGrid.Rows[e.RowIndex];
                string slotID = selectedRow.Cells["Slot ID"].Value.ToString();

                Room_Available objroomAvailable = new Room_Available();
                objroomAvailable.getSlotID(slotID);
                objroomAvailable.ShowDialog();
                this.Close();
            }
        }
    }
}
