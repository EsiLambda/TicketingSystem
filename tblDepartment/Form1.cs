using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tblDepartment
{
    public partial class frmDepartment : Form
    {
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.DatabaseContext db = new Models.DatabaseContext();
            Models.Department department = new Models.Department();

            try
            {
                department.DepartmentName = txtDepartmentName.Text;
                department.DepartmentDescription = txtDepartmentDescription.Text;

                db.Department.Add(department);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowAll()
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            var allDepartments
        }
    }
}
