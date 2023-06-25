﻿using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Logged_In_Users;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hostel_Management_System
{
    public partial class form_login : Form
    {

        public form_login()
        {
            InitializeComponent();
        }          
        

        private void btn_login_Click(object sender, EventArgs e)
        {
            Main_Form_Layout mainForm = new Main_Form_Layout();
            User_State userState = new User_State();

            string userName = txt_username.Text;
            string password = txt_password.Text;


            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM admin WHERE username = @Username AND password = @Password) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END AS authenticated;";


            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            SqlConnection conn = new SqlConnection(connStr);

       
            


            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    bool isAuthenticated = (bool)command.ExecuteScalar();
                    if (isAuthenticated)
                    {
                        this.Hide();
                        //userState.setUserName(userName);
                        mainForm.setUserName(userName);
                        mainForm.Show();


                        string queryUserSettings = "SELECT privi_User_Settings FROM admin WHERE username = @Username;";
                        SqlCommand userSettingsCmd = new SqlCommand(queryUserSettings, conn);
                        userSettingsCmd.Parameters.AddWithValue("@Username", userName);

                        bool isUserSettings = (bool)userSettingsCmd.ExecuteScalar();
                        if (isUserSettings)
                        {
                            MessageBox.Show("User settings are enabled.");
                        }
                        else
                        {
                            MessageBox.Show("User settings are disabled.");
                        }

                        string queryStudentSettings = "SELECT privi_Student_Settings FROM admin WHERE username = @Username;";
                        SqlCommand studentSettingsCmd = new SqlCommand(queryStudentSettings, conn);
                        studentSettingsCmd.Parameters.AddWithValue("@Username", userName);

                        bool isStudentSettings = (bool)studentSettingsCmd.ExecuteScalar();
                        if (isStudentSettings)
                        {
                            MessageBox.Show("Student settings are enabled.");
                        }
                        else
                        {
                            MessageBox.Show("Student settings are disabled.");
                        }

                        string queryRental = "SELECT privi_Collect_Rental FROM admin WHERE username = @Username;";
                        SqlCommand rentalCmd = new SqlCommand(queryRental, conn);
                        rentalCmd.Parameters.AddWithValue("@Username", userName);

                        bool isRental = (bool)studentSettingsCmd.ExecuteScalar();
                        if (isRental)
                        {
                            MessageBox.Show("Rental settings are enabled.");
                        }
                        else
                        {
                            MessageBox.Show("Rental settings are disabled.");
                        }

                    }
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

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
