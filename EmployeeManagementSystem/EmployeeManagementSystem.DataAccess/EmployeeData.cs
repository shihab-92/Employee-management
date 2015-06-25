using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.DataAccess
{
    public class EmployeeData
    {
        public List<Employee> GetEmployeeByName(string name)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand command = da.BuildCommand("SELECT * FROM Employee where EmployeeName like '%" + name + "%'");
            //SqlParameter p1 = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50);
            //p1.Value = name;
            //command.Parameters.Add(p1);
            return GetData(command);
        }

        public List<Employee> GetEmployeeByID(int ID)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand command = da.BuildCommand("SELECT * FROM Employee where EmployeeID like '%" + ID + "%'");
            //SqlParameter p1 = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50);
            //p1.Value = name;
            //command.Parameters.Add(p1);
            return GetData(command);
        }
        
        public bool update(Employee obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("UPDATE [Employee] SET [EmployeeID]=@EmployeeID,[EmployeeName]=@EmployeeName,[Gender]=@Gender,[Email]=@Email,[PhoneNumber]=@PhoneNumber,[Age]=@Age,[Address]=@Address,[JoinDate]=@JoinDate,[Status]=@Status,[LeaveDate]=@LeaveDate,[Salary]=@Salary" + 
                                        " WHERE ID = @ID");

            SqlParameter p = new SqlParameter("@ID", System.Data.SqlDbType.Int);
            p.Value = obj.ID;

            SqlParameter p1 = new SqlParameter("@EmployeeID", System.Data.SqlDbType.Int);
            p1.Value = obj.EmployeeID;

            SqlParameter p2 = new SqlParameter("@EmployeeName", System.Data.SqlDbType.VarChar, 50);
            p2.Value = obj.EmployeeName;

            SqlParameter p3 = new SqlParameter("@Gender", System.Data.SqlDbType.VarChar, 50);
            p3.Value = obj.Gender;

            SqlParameter p4 = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50);
            p4.Value = obj.Email;

            SqlParameter p5 = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.Int);
            p5.Value = obj.PhoneNumber;

            SqlParameter p6 = new SqlParameter("@Age", System.Data.SqlDbType.Int);
            p6.Value = obj.Age;

            SqlParameter p7 = new SqlParameter("@Address", System.Data.SqlDbType.VarChar, 50);
            p7.Value = obj.Address;

            SqlParameter p8 = new SqlParameter("@JoinDate", System.Data.SqlDbType.DateTime);
            p8.Value = obj.JoinDate;
            SqlParameter p9 = new SqlParameter("@Status", System.Data.SqlDbType.VarChar, 50);
            p9.Value = obj.Status;

            SqlParameter p10 = new SqlParameter("@LeaveDate", System.Data.SqlDbType.DateTime2);
            p10.Value = obj.LeaveDate;

            SqlParameter p11 = new SqlParameter("@Salary", System.Data.SqlDbType.Int);
            p11.Value = obj.Salary;


            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);
            cmd.Parameters.Add(p11);
            

            cmd.Connection.Open();
            int val = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return val > 0;

        }
        

        public bool insert(Employee obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("INSERT INTO [dbo].[Employee] ([ID],[EmployeeID],[EmployeeName],[Gender],[Email],[PhoneNumber],[Age],[Address],[JoinDate],[Status],[LeaveDate],[Salary]) " +
                                        "VALUES (@ID , @EmployeeID, @EmployeeName,@Gender, @Email, @PhoneNumber,@Age,@address,@JoinDate,@Status,@leaveDate,@Salary)");

            SqlParameter p = new SqlParameter("@ID", System.Data.SqlDbType.Int);
            p.Value = obj.ID;

            SqlParameter p1 = new SqlParameter("@EmployeeID", System.Data.SqlDbType.Int);
            p1.Value = obj.EmployeeID;

            SqlParameter p2 = new SqlParameter("@EmployeeName", System.Data.SqlDbType.VarChar, 50);
            p2.Value = obj.EmployeeName;

            SqlParameter p3 = new SqlParameter("@Gender", System.Data.SqlDbType.VarChar, 50);
            p3.Value = obj.Gender;

            SqlParameter p4 = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50);
            p4.Value = obj.Email;

            SqlParameter p5 = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.Int);
            p5.Value = obj.PhoneNumber;

            SqlParameter p6 = new SqlParameter("@Age", System.Data.SqlDbType.Int);
            p6.Value = obj.Age;

            SqlParameter p7 = new SqlParameter("@Address", System.Data.SqlDbType.VarChar, 50);
            p7.Value = obj.Address;

            SqlParameter p8 = new SqlParameter("@JoinDate", System.Data.SqlDbType.DateTime);
            p8.Value = obj.JoinDate;
            SqlParameter p9 = new SqlParameter("@Status", System.Data.SqlDbType.VarChar, 50);
            p9.Value = obj.Status;

            SqlParameter p10 = new SqlParameter("@LeaveDate", System.Data.SqlDbType.DateTime);
            if (!obj.LeaveDate.HasValue)
               p10.Value = obj.LeaveDate;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@Salary", System.Data.SqlDbType.Int);
            p11.Value = obj.Salary;


            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);
            cmd.Parameters.Add(p11);


            cmd.Connection.Open();
            int val = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return val > 0;

        }



        
        public List<Employee> GetEmployeeList()
        {
            sqlDataAccess da = new sqlDataAccess();

            SqlCommand command = da.BuildCommand("SELECT * FROM Employee");

            return GetData(command);
        }

        
        public List<Employee> GetData(SqlCommand command)
        {

            command.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Employee> list = new List<Employee>();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.ID = reader.GetInt32(0);
                emp.EmployeeID = reader.GetInt32(1);
                emp.EmployeeName = reader.GetString(2);
                emp.Gender = reader.GetString(3);
                emp.Email = reader.GetString(4);
                emp.PhoneNumber = reader.GetInt32(5);
                emp.Age = reader.GetInt32(6);
                emp.Address = reader.GetString(7);
                emp.JoinDate = reader.GetDateTime(8);
                emp.Status = reader.GetString(9);

                if (reader.GetValue(10) == DBNull.Value)
                    emp.LeaveDate = null;
                else
                    emp.LeaveDate = reader.GetDateTime(10);

                emp.Salary = reader.GetInt32(11);


                list.Add(emp);
            }

            reader.Close();
            command.Connection.Close();

            return list;
        }
    }
}
