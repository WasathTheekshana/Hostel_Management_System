using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management_System.Database_Connection
{
    internal class Connection_Sting
    {
        public string getConnectionString()
        {
            string serverName = "serverhms.database.windows.net";
            string databaseName = "hostel-management-system";
            string username = "hmsadmin";
            string password = "Hostelms@123";

            string connectionString = $"Server={serverName};Database={databaseName};User Id={username};Password={password};";

            return connectionString;
        }
    }
}
