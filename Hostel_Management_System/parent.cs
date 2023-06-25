using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management_System
{
    internal class parent
    {
        student Student;
        string ParentName;
        string ParentContactNumber;
        string ParentNIC;
        string ParentEmail;
        string ParentJob;

        public parent(student student,string parentName, string parentContactNumber, string parentNIC, string parentEmail, string parentJob)
        {
            Student = student;
            ParentName = parentName;
            ParentContactNumber = parentContactNumber;
            ParentNIC = parentNIC;
            ParentEmail = parentEmail;
            ParentJob = parentJob;
        }



    }
}
