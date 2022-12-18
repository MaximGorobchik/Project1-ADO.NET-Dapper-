using main.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace main.Models.Reports
{
    public class Reports
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public DateTime ?OpenDate { get; set; }
        public DateTime ?CloseDate { get; set; }
        public string ?Description { get; set; }
        public int UserID { get; set; }
        public int EmployeeID { get; set; }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ID + " "+ CategoryID + " "+ StatusID + " "+ OpenDate + " " + CloseDate + "\n" + Description + " " + UserID + " " + EmployeeID);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
