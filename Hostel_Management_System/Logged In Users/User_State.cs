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

        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        public string getUserName()
        {
            return userName;
        }
    }
}
