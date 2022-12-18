using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace main.Models.Employees
{
    public class Employees
    {
        public int ID { get; set; }
        public string ?Firstname { get; set; }
        public string ?Lastname { get; set; }
        public DateTime ?Birthdate { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ID + "\t" + Firstname.PadRight(20) + "\t" + Lastname.PadRight(20) + "\t" + Birthdate + "\t" + Age + "\t" + DepartmentID);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
