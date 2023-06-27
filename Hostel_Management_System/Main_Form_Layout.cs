using Guna.UI2.WinForms;
using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Logged_In_Users;
using Hostel_Management_System.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Main_Form_Layout : Form
    {
        public Main_Form_Layout()
        {
            InitializeComponent();


        }

        public string loggedInUser;
        public string userPrivi;

        private bool checkRental;

        public void setRental(bool isRenatl)
        {
            checkRental = isRenatl;
        }
        public void setUserName(string loggedInUser, string userPrivi)
        {
            this.loggedInUser = loggedInUser;
            this.userPrivi = userPrivi;
        }

        bool addStudentPrivi;
        public void setaddStudentPrivi(bool privi)
        {
            addStudentPrivi = privi;
        }

        Form_StudentList std = new Form_StudentList();
        
       public void container(object _form)
        {
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(fm);
            panel_container.Tag = fm;
            fm.Show();
        }


            Form_Dashboard dashboard = new Form_Dashboard();

        private void Main_Form_Layout_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today;
            int dayOfMonth = currentDate.Day;

            if (dayOfMonth == 1)
            {
                if (!Properties.Settings.Default.rentalAdd)
                {
                    try
                    {
                        Connection_Sting objConnectionString = new Connection_Sting();
                        string connStr = objConnectionString.getConnectionString();

                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();

                            string query = @"UPDATE student
                SET rental = rental - @RentalValue
                WHERE NIC IN (SELECT NIC FROM student_slot)";

                            SqlCommand command = new SqlCommand(query, conn);
                            command.Parameters.AddWithValue("@RentalValue", Properties.Settings.Default.rental);
                            command.ExecuteNonQuery();

                            Properties.Settings.Default.rentalAdd = true;
                            Properties.Settings.Default.Save();

                            MessageBox.Show("Rentals updated successfully.");
                        }
                        Properties.Settings.Default.rentalAdd = true;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating rentals: " + ex.Message);
                    }
                }
            }

            txt_logged_user.Text = loggedInUser;
            lbl_privi.Text = userPrivi;

            dashboard.setUserName(loggedInUser);
            dashboard.setRentalPrivi(checkRental);
            btn_dashboard.Checked = true;
            container(dashboard);

            if(userPrivi == "User")
            {
                btn_settings.Enabled = false;
                btn_addNew.Enabled = false;
            }

            std.setUserPrivi(userPrivi);
        }

      
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            dashboard.setUserName(loggedInUser);
            dashboard.updateDashBoard();
            dashboard.setRentalPrivi(checkRental);
            container(dashboard);
     
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            container(new Form_Food());

        }

        private void btn_studnetList_Click(object sender, EventArgs e)
        {
            Form_StudentList form_StudentList = new Form_StudentList();
            form_StudentList.getpermission(addStudentPrivi);
            container(form_StudentList);
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm(); 
            detailForm.ShowDialog();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            container(new Form_Settings());
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            User_State user_State = new User_State();

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Logout_Popup logout = new Logout_Popup();
            logout.ShowDialog();

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Logout_Popup logout = new Logout_Popup();
            logout.ShowDialog();
        }
    }
}
