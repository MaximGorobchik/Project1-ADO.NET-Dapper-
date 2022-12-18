using main.Models.Departments;
using main.Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface IStatusRepository
    {
        public IEnumerable<Status> StatusModel();
    }
}
