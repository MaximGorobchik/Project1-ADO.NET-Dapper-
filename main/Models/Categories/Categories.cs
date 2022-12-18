using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Models.Categories
{
    public class Categories
    {
        public int ID { get; set; }
        public string ?Name { get; set; }    
        public int DepartmentID { get; set; }

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ID + "\t" + Name.PadRight(20) + "\t" + DepartmentID);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
