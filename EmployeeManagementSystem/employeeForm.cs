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
    public partial class employeeForm : Form
    {
        sqlDataAccess db = new sqlDataAccess();
        List<Employee> Employeelist = new List<Employee>();
        DataAccess.EmployeeData ld = new DataAccess.EmployeeData();

        public employeeForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            createForm frm = new createForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

       

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateForm frm = new updateForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            Control[] ctlgrid = frm.Controls.Find("dataGridView1", true);
            DataGridView grid = (DataGridView)ctlgrid[0];
            grid.DataSource = ld.GetEmployeeList();
            frm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchForm frm = new searchForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            viewForm frm = new viewForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            Control[] ctlgrid = frm.Controls.Find("dataGridView1", true);
            DataGridView grid = (DataGridView)ctlgrid[0];
            grid.DataSource = ld.GetEmployeeList();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
