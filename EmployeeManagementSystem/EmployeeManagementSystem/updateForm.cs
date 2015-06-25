using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class updateForm : Form
    {
        sqlDataAccess db = new sqlDataAccess();
        List<Employee> Employeelist = new List<Employee>();
        DataAccess.EmployeeData ld = new DataAccess.EmployeeData();
        public updateForm()
        {
            InitializeComponent();
        }


            private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
            {
                Employee obj = dataGridView1.Rows[e.RowIndex].DataBoundItem as Employee;

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

            private void btnUpdate_Click(object sender, EventArgs e)
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
                ld.update(em);
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
       }
    }

