using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Framework
{
    public class sqlDataAccess
    {
       static public string ConnectionString = "Data Source=localhost;Initial Catalog=EMS;Integrated Security=True";

        public SqlCommand BuildCommand(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }

        public SqlCommand GetCommand(string query)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}
