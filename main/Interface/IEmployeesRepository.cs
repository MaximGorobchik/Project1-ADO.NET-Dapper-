using main.Models.Departments;
using main.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface IEmployeesRepository
    {
        public IEnumerable<Employees> EmployeesModel();
    }
}
