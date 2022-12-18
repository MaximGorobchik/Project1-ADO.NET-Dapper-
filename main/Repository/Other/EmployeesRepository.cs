using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using main.Models.Employees;
using main.Interface;

namespace main.Repository.Other
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public EmployeesRepository(SqlConnection connection)
        {
            sqlConnection = connection;
        }
        public IEnumerable<Employees> EmployeesModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Employees>("ShowAllEmployees", commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllEmployees() //метод для перебору данних у колекції
        {
            foreach (Employees item in EmployeesModel())
            {
                item.Info(); //метод Info, моделі Employees
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
        public void AddNewEmployee() //Додати нового робітника
        {
            int id = 0; string firstname = ""; string lastname = ""; string birthdate = ""; int age = 0; int departmentid = 0;
            Console.WriteLine("Enter ID (>30): "); id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter firstname: "); firstname = Console.ReadLine();
            Console.WriteLine("Enter lastname: "); lastname = Console.ReadLine();
            Console.WriteLine("Enter birthdate (yyyy-mm-dd): "); birthdate = Console.ReadLine();
            Console.WriteLine("Enter age: "); age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter departmentID (1<=10): "); departmentid = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@firtsname", firstname);
            param.Add("@lastsname", lastname);
            param.Add("@birthdate", birthdate);
            param.Add("@age", age);
            param.Add("@departmentid", departmentid);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("AddNewEmployee", param, commandType: CommandType.StoredProcedure);
        }
        public void UpdateEmplDepartID() //Оновити департамент у робітника
        {
            Console.WriteLine("Enter employeeLastname: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter departmentID: ");
            int departmentid = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@departmentid", departmentid);
            param.Add("@lastname", lastname);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("UpdateEmployeeDepartmentID", param, commandType: CommandType.StoredProcedure);
        }
        public void DeleteEmployee() //Видалити робітника
        {
            Console.WriteLine("Enter employeeID: ");
            string employeeid = Console.ReadLine();
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@employeeid", employeeid);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("DeleteEmployee", param, commandType: CommandType.StoredProcedure);
        }
    }
}
