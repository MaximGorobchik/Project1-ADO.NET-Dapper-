using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using main.Models.Departments;
using main.Interface;

namespace main.Repository.Other
{
    public class DepartmentRepository : IDepartmentsRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public DepartmentRepository(SqlConnection connection)
        {
            sqlConnection = connection;
        }
        public IEnumerable<Departments> DepartmentModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Departments>("ShowAllDepartments", commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllDepartments() //метод для перебору данних у колекції
        {
            foreach (Departments item in DepartmentModel())
            {
                item.Info(); //метод Info, моделі Departments
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
