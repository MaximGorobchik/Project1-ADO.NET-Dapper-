using main.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace main.Models.Status
{
    public class Status
    {
        public int ID { get; set; }
        public string ?Label { get; set; }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ID + "\t" + Label);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
