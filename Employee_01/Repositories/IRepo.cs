using Employee_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_01.Repositories
{
    public interface IRepo
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeId);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int employeeId);

    }
}
