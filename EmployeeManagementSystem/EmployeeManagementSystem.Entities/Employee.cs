using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Entities
{
    public class Employee
    {
        public int? ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; }
        public DateTime? LeaveDate { get; set; }
        public int Salary { get; set; }
        
    }
}
