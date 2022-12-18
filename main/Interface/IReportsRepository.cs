using main.Models.Departments;
using main.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface IReportsRepository
    {
        public IEnumerable<Reports> ReportsModel();
    }
}
