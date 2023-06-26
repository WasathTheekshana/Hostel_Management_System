using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Pending_Payments : Form
    {
        public Pending_Payments()
        {
            InitializeComponent();
        }
        private DataTable originalData;

        private void Pending_Payments_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            Connection_Sting objConnection = new Connection_Sting();
            string connStr = objConnection.getConnectionString();


            SqlConnection conn = new SqlConnection(connStr);
            string query = "SELECT s.Room_No, st.NIC AS StudentNIC, st.FName, st.rental FROM slot s INNER JOIN student_slot ss ON s.slotID = ss.slotID INNER JOIN student st ON ss.NIC = st.NIC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                originalData = new DataTable();
                adapter.Fill(originalData);
                conn.Close();
            }

            table_payments.DataSource = originalData;
        }

        private void txtStudentSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string searchText = txtStudentSearch.Text.Trim();

            DataTable filteredData = originalData.Copy();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string filterExpression = string.Format("FName LIKE '%{0}%'", searchText);
                filteredData.DefaultView.RowFilter = filterExpression;
            }

            // Check if search text is empty, and if so, display all the data
            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredData = originalData.Copy();
            }

            table_payments.DataSource = filteredData;
        }

        private void table_payments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the value of the StudentNIC column in the clicked row
                    string studentNIC = table_payments.Rows[e.RowIndex].Cells["StudentNIC"].Value.ToString();

                Payment_Confirm pay = new Payment_Confirm();
                pay.getNIC(studentNIC);
                }   
        }
    }
}
