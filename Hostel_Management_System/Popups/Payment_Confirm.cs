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
    public partial class Payment_Confirm : Form
    {
        public Payment_Confirm()
        {
            InitializeComponent();
        }

        string studentNIC;

        public void getNIC(string NIC)
        {
            studentNIC = NIC;
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            int payemnt = int.Parse(txt_payment.Text);

            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE student
                SET rental = rental + @Payment
                WHERE NIC IN (SELECT NIC FROM student_slot)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Payment", payemnt);
                command.ExecuteNonQuery();

                Properties.Settings.Default.rentalAdd = true;
                Properties.Settings.Default.Save();

                MessageBox.Show("Rentals updated successfully.");
            }
        }
    }
}
