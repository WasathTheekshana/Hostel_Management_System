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

namespace Hostel_Management_System.User_Modals
{
    public partial class Edit_User : Form
    {
        public Edit_User()
        {
            InitializeComponent();
        }

        private void Edit_User_Load(object sender, EventArgs e)
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();
            guna2ShadowForm1.SetShadowForm(this);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT username as Username from admin";

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "admin");

                    guna2DataGridView1.DataSource = ds.Tables["admin"];
                    bool deleteColumnExists = false;
                    foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                    {
                        if (column.Name == "Delete")
                        {
                            deleteColumnExists = true;
                            break;
                        }
                    }
                    if (!deleteColumnExists)
                    {
                        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                        deleteButtonColumn.Name = "Delete";
                        deleteButtonColumn.HeaderText = "Delete";
                        deleteButtonColumn.Text = "Delete";
                        deleteButtonColumn.UseColumnTextForButtonValue = true;
                        guna2DataGridView1.Columns.Add(deleteButtonColumn);
                    }
                    guna2DataGridView1.CellClick += DataGridView1_CellClick;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == guna2DataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                string username = guna2DataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString(); 
                DeleteUser(username);
                RefreshDataGridView();
            }
        }

        private void DeleteUser(string username)
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();
            SqlConnection conn = new SqlConnection(connStr);
            string deleteQuery = "DELETE FROM admin WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
            deleteCommand.Parameters.AddWithValue("@username", username);
            conn.Open();
            deleteCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void RefreshDataGridView()
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT username as Username from admin";

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "admin");

                    guna2DataGridView1.DataSource = ds.Tables["admin"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
