using main.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Models.Users
{
    public class Users
    {
        public int ID { get; set; }
        public string ?Username { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }

        public void Info()
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(ID + "\t" + Username.PadRight(20) + "\t" + Name.PadRight(20) + "\t" + Password.PadRight(15) + Birthdate + " " + Age + " " + Email );
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
