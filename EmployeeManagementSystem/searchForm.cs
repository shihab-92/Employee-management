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
using EmployeeManagementSystem.Framework;
using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem
{
    public partial class searchForm : Form
    {
        sqlDataAccess db = new sqlDataAccess();
        List<Employee> Employeelist = new List<Employee>();
        DataAccess.EmployeeData ld = new DataAccess.EmployeeData();

        public searchForm()
        {
            InitializeComponent();
        }



        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection(sqlDataAccess.ConnectionString))
                {
                    if (comboBox1.Text.Length > 0)
                    {
                        if (comboBox1.Text == "EmployeeName")
                        {
                            //using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee where EmployeeName like '%" + textBox1.Text + "%'", con))
                            //{
                            //    con.Open();

                            //    DataTable dt = new DataTable();
                            //    da.Fill(dt);

                            //    con.Close();
                            //    dataGridView3.DataSource = dt;
                            //}

                            dataGridView3.DataSource = ld.GetEmployeeByName(textBox1.Text);
                        }
                        else
                        {
                            //using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee where EmployeeID like '%" + textBox1.Text + "%'", con))
                            //{
                            //    con.Open();

                            //    DataTable dt = new DataTable();
                            //    da.Fill(dt);

                            //    con.Close();
                            //    dataGridView3.DataSource = dt;
                            //}
                            dataGridView3.DataSource = ld.GetEmployeeByID(int.Parse(textBox1.Text));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select valid category!!");
                    }

                }
            }
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            Employee obj = dataGridView3.Rows[e.RowIndex].DataBoundItem as Employee;

            txtID.Text = obj.ID.ToString();
            txtEmployeeID.Text = obj.EmployeeID.ToString();
            txtEmployeeName.Text = obj.EmployeeName;
            txtGender.Text = obj.Gender;
            txtEmail.Text = obj.Email;
            txtPhoneNumber.Text = obj.PhoneNumber.ToString();
            txtAge.Text = obj.Age.ToString();
            txtAddress.Text = obj.Address;
            JoinDate.Text = obj.JoinDate.ToString();
            txtStatus.Text = obj.Status;
            LeaveDate.Text = obj.LeaveDate.ToString();
            txtSalary.Text = obj.Salary.ToString();
        }

        

   
        

       
    }
}
