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
    public partial class Food_List : Form
    {
        public Food_List()
        {
            InitializeComponent();
        }

        private void UpdateFoodList(DateTime orderDate, string type)
        {
            Connection_Sting connection_Sting = new Connection_Sting();
            string connStr = connection_Sting.getConnectionString();

            // Retrieve the data from the database for the given OrderDate
            string query = "SELECT s.Room_No, st.FName, fo.OrderDate, fo.paid, fo.given " +
                           "FROM student_slot ss " +
                           "INNER JOIN student st ON ss.NIC = st.NIC " +
                           "INNER JOIN food_order fo ON ss.NIC = fo.NIC " +
                           "INNER JOIN slot s ON ss.slotID = s.slotID " +
                           "WHERE fo.type = @Type AND CONVERT(date, fo.OrderDate) = @OrderDate " +
                           "ORDER BY fo.OrderDate";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@OrderDate", orderDate.Date);
                conn.Open();

                // Create DataTable to store the retrieved data
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());

                // Bind the DataTable to the GunaDataGridView
                guna2DataGridView1_FoodList.DataSource = dt;
            }
        }


        private void guna2DataGridView1_FoodList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Connection_Sting connection_Sting = new Connection_Sting();
            string connStr = connection_Sting.getConnectionString();

            // Check if the checkbox column is clicked
            if (e.ColumnIndex == guna2DataGridView1_FoodList.Columns["Given"].Index && e.RowIndex >= 0)
            {
                // Update the value in the underlying data source
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)guna2DataGridView1_FoodList.Rows[e.RowIndex].Cells["Given"];
                bool given = Convert.ToBoolean(checkboxCell.Value);
                checkboxCell.Value = !given;

                // Update the database with the new value
                string roomNo = guna2DataGridView1_FoodList.Rows[e.RowIndex].Cells["Room_No"].Value.ToString();
                DateTime orderDate = Convert.ToDateTime(guna2DataGridView1_FoodList.Rows[e.RowIndex].Cells["OrderDate"].Value);
                bool newGivenValue = !given;

                // Update the database with the new value using an update query
                string updateQuery = "UPDATE food_order SET Given = @Given WHERE Room_No = @RoomNo AND OrderDate = @OrderDate";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(updateQuery, conn);
                    command.Parameters.AddWithValue("@Given", newGivenValue);
                    command.Parameters.AddWithValue("@RoomNo", roomNo);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
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
            UpdateFoodList(orderDay, "chicken");
        }

        private void firstTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            fishUnderLine.Visible = true;
            UpdateFoodList(orderDay, "fish");
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            eggUnderLine.Visible = true;
            UpdateFoodList(orderDay, "egg");
        }

        private void thirdTab_Click(object sender, EventArgs e)
        {
            hideAllUnderLines();
            vegUnderLine.Visible = true;
            UpdateFoodList(orderDay, "veg");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DateTime orderDay;
        public void getOrderDay(DateTime orderDate)
        {
            orderDay = orderDate;
        }
        private void Food_List_Load(object sender, EventArgs e)
        {
            UpdateFoodList(orderDay,"chicken");
        }
    }
}
