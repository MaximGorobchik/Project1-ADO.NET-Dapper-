using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Models.Departments
{
    public class Departments
    {
        public int ID { get; set; }
        public string ?Name { get; set; }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ID + "\t" + Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
