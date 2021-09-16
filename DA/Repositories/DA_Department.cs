using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;

namespace DA.Repositories
{
    public class DA_Department
    {
        protected void DA_Insert(string departmentName, string departmentDescription)
        {
            Models.DatabaseContext db = new Models.DatabaseContext();
            Models.Department department = new Models.Department();

            department.DepartmentName = departmentName;
            department.DepartmentDescription = departmentDescription;

            db.Department.Add(department);
            db.SaveChanges();
        }

        protected void DA_Update(Guid id, string departmentName, string departmentDescription)
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            var dep = db.Department.Where(d => d.ID == id).First();

            dep.DepartmentName = departmentName;
            dep.DepartmentDescription = departmentDescription;

            db.SaveChanges();
        }

        protected void DA_Delete(Guid id)
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            var dep = db.Department.Where(d => d.ID == id).First();

            db.Department.Remove(dep);

            db.SaveChanges();
        }

        protected Array DA_SelectForCombo()
        {
            DatabaseContext db = new DatabaseContext();

            var dep = db.Department.Select(x => x.DepartmentName ).ToArray();

            return dep;
        }

        protected List<Models.Department> DA_ShowAllDepartments()
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            return db.Department.OrderBy(dep => dep.DepartmentName).ToList();
        }

        protected bool DA_DepartmentValidation(string depName)
        {
            DA.Models.DatabaseContext db = new Models.DatabaseContext();

            return db.Department.Any(department => department.DepartmentName == depName);
        }
    }
}