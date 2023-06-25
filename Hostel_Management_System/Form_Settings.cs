using Hostel_Management_System.Settings_Details;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
        }
        private void ShowPopup()
        {
            AddNewUser popup = new AddNewUser();

            // Calculate the position for the popup form to be centered
            int x = (Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2;

            // Set the position of the popup form
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(x, y);

            // Show the popup form
            popup.ShowDialog();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

      


        private void AddNewUserPanel_MouseClick(object sender, MouseEventArgs e)
        {
            AddNewUser popup = new AddNewUser();

            // Calculate the position for the popup form to be centered
            int x = (Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2;

            // Set the position of the popup form
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(x, y);

            // Show the popup form
            popup.ShowDialog();
        }

        private void guna2ShadowPanel4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        

        private void guna2ShadowPanel2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void guna2ShadowPanel2_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void AddNewUserPanel_MouseEnter(object sender, EventArgs e)
        {
            AddNewUserPanel.ShadowDepth = 15;
         
        }

        private void AddNewUserPanel_MouseLeave(object sender, EventArgs e)
        {
            AddNewUserPanel.ShadowDepth = 10;
            
        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void EditFoodPenel_MouseClick(object sender, MouseEventArgs e)
        {
            AddDeleteFoddItem popup = new AddDeleteFoddItem();

            // Calculate the position for the popup form to be centered
            int x = (Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2;

            // Set the position of the popup form
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(x, y);

            // Show the popup form
            popup.ShowDialog();
        }

        private void EditRentalPanel_MouseClick(object sender, MouseEventArgs e)
        {
            EditRental popup = new EditRental();

            // Calculate the position for the popup form to be centered
            int x = (Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2;

            // Set the position of the popup form
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(x, y);

            // Show the popup form
            popup.ShowDialog();
        }

        private void EditUserPanel_MouseEnter(object sender, EventArgs e)
        {
            EditUserPanel.ShadowDepth = 15;
        }

        private void EditUserPanel_MouseLeave(object sender, EventArgs e)
        {
            EditUserPanel.ShadowDepth = 10;
        }

        private void EditFoodPenel_MouseEnter(object sender, EventArgs e)
        {
            EditFoodPenel.ShadowDepth = 15;
        }

        private void EditFoodPenel_MouseLeave(object sender, EventArgs e)
        {
            EditFoodPenel.ShadowDepth = 10;
        }

        private void EditRentalPanel_MouseEnter(object sender, EventArgs e)
        {
            EditRentalPanel.ShadowDepth = 15;
        }

        private void EditRentalPanel_MouseLeave(object sender, EventArgs e)
        {
           EditRentalPanel.ShadowDepth = 10;
        }

        private void EditFoodPenel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditUserPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Users popup = new Users();

            // Calculate the position for the popup form to be centered
            int x = (Screen.PrimaryScreen.WorkingArea.Width - popup.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - popup.Height) / 2;

            // Set the position of the popup form
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(x, y);

            // Show the popup form
            popup.ShowDialog();
        }
    }
}
