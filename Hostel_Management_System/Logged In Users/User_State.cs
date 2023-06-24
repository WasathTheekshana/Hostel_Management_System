using Hostel_Management_System.Database_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management_System.Logged_In_Users
{
    internal class User_State
    {
        private string userName;
        private string password;

        private bool isUserSettings;
        private bool isStudentSettings;
        private bool isFood;
        private bool isRental;

        


        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        public string getUserName()
        {
            return userName;
        }

        public void checkPrivi(string userName, string password)
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string query = "";
        }
    }
}
