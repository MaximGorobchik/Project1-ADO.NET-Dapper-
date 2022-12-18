using main.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface IDepartmentsRepository
    {
        public IEnumerable<Departments> DepartmentModel();
    }
}
