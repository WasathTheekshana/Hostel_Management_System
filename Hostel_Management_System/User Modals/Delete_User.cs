using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System.User_Modals
{
    public partial class Delete_User : Form
    {
        public Delete_User()
        {
            InitializeComponent();
        }

        private void Delete_User_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            try
            {
                LoadFoodDataIntoDataGridView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateFood(string foodName, string mealType, int foodPrice)
        {
            if (string.IsNullOrEmpty(foodName))
            {
                MessageBox.Show("Please fill in the Food Name.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (string.IsNullOrEmpty(mealType))
            {
                MessageBox.Show("Please select a meal type.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (foodPrice <= 0)
            {
                MessageBox.Show("Please enter a valid food price.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

           
        }

        private void LoadFoodDataIntoDataGridView()
        {
            // Connect to the database
            Connection_Sting connString = new Connection_Sting();
            SqlConnection connection = new SqlConnection(connString.getConnectionString());
            connection.Open();

            // Retrieve only "type" and "price" columns from the "food" table
            string query = "SELECT type AS 'Food Item', price AS 'Price (Rs.)' FROM food";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Create a DataTable to store the retrieved data
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            // Set the DataTable as the DataSource of the Guna2DataGridView control
            guna2DataGridView1.DataSource = dataTable;

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

            // Close the connections
            reader.Close();
            connection.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == guna2DataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                string foodItem = guna2DataGridView1.Rows[e.RowIndex].Cells["Food Item"].Value.ToString();
                DeleteFoodItem(foodItem);
                RefreshDataGridView();
            }
        }

        private void DeleteFoodItem(string foodItem)
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();
            SqlConnection conn = new SqlConnection(connStr);
            string deleteQuery = "DELETE FROM food WHERE type = @FoodItem";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
            deleteCommand.Parameters.AddWithValue("@FoodItem", foodItem);
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
                string query = "SELECT type AS 'Food Item', price AS 'Price (Rs.)' FROM food";

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "food");

                    guna2DataGridView1.DataSource = ds.Tables["food"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        private void btn_addFood_item_Click(object sender, EventArgs e)
        {
            string foodName = txt_FoodName.Text;
            string meal = comBox_meal.Text;
            int foodPrice;

            if (!int.TryParse(txtBox_food_price.Text, out foodPrice))
            {
                MessageBox.Show("Please enter a valid food price.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (validateFood(foodName, meal, foodPrice))
            {
                Connection_Sting conStr = new Connection_Sting();

                string query = "INSERT INTO food VALUES('" + foodName + "','" + meal + "','" + foodPrice + "')";

                SqlConnection conn = new SqlConnection(conStr.getConnectionString());
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Base_Successfull_Popup successPop = new Base_Successfull_Popup();
                    successPop.setPopup("New Food Added!");
                    successPop.setFoodImage();
                    successPop.ShowDialog();
                    this.Close();
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
    }
}
