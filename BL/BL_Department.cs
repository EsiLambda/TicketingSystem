using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Repositories;

namespace BL
{
    public class BL_Department : DA_Department
    {
        public Guid id;
        public string departmentName, departmentDescription;
        
        public bool BL_Insert()
        {
            if (BL_DepartmentValidation(this.departmentName) == true)
            {
                DA_Insert(departmentName, departmentDescription);

                return true;
            }

            return false;
        }

        public void BL_Update()
        {
            DA_Update(id, departmentName, departmentDescription);
        }

        public void BL_Delete()
        {
            DA_Delete(id);
        }

        public Array BL_SelectForCombo()
        {
            return DA_SelectForCombo();
        }

        public List<DA.Models.Department> BL_ShowAllDepartments()
        {
            return DA_ShowAllDepartments();
        }

        private bool BL_DepartmentValidation(string depName)
        {
            if (DA_DepartmentValidation(this.departmentName) == false)
                return true;

            return false;
        }
    }
}
