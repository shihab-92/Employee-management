using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Framework;
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

namespace EmployeeManagementSystem
{
    public partial class createForm : Form
    {
        sqlDataAccess db = new sqlDataAccess();
        List<Employee> Employeelist = new List<Employee>();
        DataAccess.EmployeeData ld = new DataAccess.EmployeeData();

        public createForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


        private void createForm_Load(object sender, EventArgs e)
        {

            txtID.Text = "1";

            var connection = new SqlConnection(sqlDataAccess.ConnectionString);

                string s = "SELECT max(ID)+1 FROM Employee";
                SqlCommand com = new SqlCommand(s, connection);
                connection.Open();
                com.ExecuteNonQuery();
                SqlDataReader sd = com.ExecuteReader();
                while (sd.Read())
                {
                    if (sd.GetValue(0) != DBNull.Value)
                    {
                        int n = sd.GetInt32(0);
                        txtID.Text = n.ToString();
                    }

                }
                connection.Close();

            
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void deleteTab_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ld.GetEmployeeList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.ID = int.Parse(txtID.Text);
            em.EmployeeID = int.Parse(txtEmployeeID.Text);
            em.EmployeeName = txtEmployeeName.Text;
            em.Gender = txtGender.Text;
            em.Email = txtEmail.Text;
            em.PhoneNumber = int.Parse(txtPhoneNumber.Text);
            em.Age = int.Parse(txtAge.Text);
            em.Address = txtAddress.Text;
            em.JoinDate = JoinDate.Value.Date;
            em.Status = txtStatus.Text;
            if (!string.IsNullOrWhiteSpace(this.LeaveDate.Text))
            {
                em.LeaveDate = Convert.ToDateTime(LeaveDate.Text);
            }
            else
            {
                em.LeaveDate = Convert.ToDateTime(null);
            }
            em.Salary = int.Parse(txtSalary.Text);
            ld.insert(em);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Employee obj = dataGridView1.SelectedRows[0].DataBoundItem as Employee;


            using (var connection =
                   new SqlConnection("Data Source=localhost;Initial Catalog=EMS;Integrated Security=True"))
            {
                var cmd = new SqlCommand("DELETE [dbo].[Employee] WHERE [EmployeeID] = @EmployeeID", connection);

                SqlParameter p = new SqlParameter("@EmployeeID", SqlDbType.Int);
                p.Value = obj.EmployeeID;


                cmd.Parameters.Add(p);


                connection.Open();
                int val = cmd.ExecuteNonQuery();
                connection.Close();

            }

            dataGridView1.DataSource = ld.GetEmployeeList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Employee obj = dataGridView1.SelectedRows[0].DataBoundItem as Employee;


            using (var connection =
                   new SqlConnection("Data Source=localhost;Initial Catalog=EMS;Integrated Security=True"))
            {
                var cmd = new SqlCommand("DELETE [dbo].[Employee] WHERE [EmployeeID] = @EmployeeID", connection);

                SqlParameter p = new SqlParameter("@EmployeeID", SqlDbType.Int);
                p.Value = obj.EmployeeID;


                cmd.Parameters.Add(p);


                connection.Open();
                int val = cmd.ExecuteNonQuery();
                connection.Close();

            }

            dataGridView1.DataSource = ld.GetEmployeeList();
        }
    }
}
