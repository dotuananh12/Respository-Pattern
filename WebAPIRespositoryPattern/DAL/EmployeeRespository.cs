using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRespository : RespositoryBase<Employee>, IEmployeeRespository
    {
        public EmployeeRespository(AppDbContext appDbContext)
             : base(appDbContext)
        {

        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public List<Employee> GetEmployees()
        {
            return FindAll().ToList();
        }

        public Employee GetEmployee(int id)
        {
            return FindbyCondition(e => e.Id == id).FirstOrDefault();
        }


    }
}
