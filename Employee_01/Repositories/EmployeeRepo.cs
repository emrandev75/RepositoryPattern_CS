using Employee_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_01.Repositories
{
    public class EmployeeRepo : IRepo
    {
        public void Delete(int employeeId)
        {
            Employee employee = EmployeeDB.EmployeeList.FirstOrDefault(x => x.EmployeeId == employeeId);
            EmployeeDB.EmployeeList.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeeDB.EmployeeList;
        }

        public Employee GetById(int EmployeeId)
        {
            Employee employee = EmployeeDB.EmployeeList.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            return employee;
        }

        public void Insert(Employee employee)
        {
           EmployeeDB.EmployeeList.Add(employee);
        }

        public void Update(Employee employee)
        {
            Employee _employee = EmployeeDB.EmployeeList.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (employee.EmployeeName != null)
            {
                _employee.EmployeeName = employee.EmployeeName;
            }
            if (employee.Age != 0)
            {
                _employee.Age = employee.Age;
            }
            if(employee.Gender != null)
            {
                _employee.Gender = employee.Gender;
            }
            if(employee.Address!= null)
            {
                _employee.Address = employee.Address;
            }
        }
    }
}
