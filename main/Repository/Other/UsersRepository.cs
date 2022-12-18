using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using main.Models.Users;
using main.Interface;

namespace main.Repository.Other
{
    public class UsersRepository : IUsersRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public UsersRepository(SqlConnection connection)
        {
            sqlConnection = connection;
        }
        public IEnumerable<Users> UsersModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Users>("ShowAllUsers", commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllUsers() //метод для перебору данних у колекції
        {
            foreach (Users item in UsersModel())
            {
                item.Info(); //метод Info, моделі Users
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
        public void AddNewUser() //додати юзера
        {
            int id = 0; string username = ""; string name = ""; string password = ""; string birthdate = ""; int age = 0; string email = "";
            Console.WriteLine("Enter userID (>21): "); id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter username: "); username = Console.ReadLine();
            Console.WriteLine("Enter name: "); name = Console.ReadLine();
            Console.WriteLine("Enter password: "); password = Console.ReadLine();
            Console.WriteLine("Enter birthdate (yyyy-mm-dd): "); birthdate = Console.ReadLine();
            Console.WriteLine("Enter age: "); age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email: "); email = Console.ReadLine();
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@username", username);
            param.Add("@name", name);
            param.Add("@password", password);
            param.Add("@birthdate", birthdate);
            param.Add("@age", age);
            param.Add("@email", email);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("AddNewUser", param, commandType: CommandType.StoredProcedure);
        }
        public void UpdateUserPassword() //оновити пароль юзера
        {
            Console.WriteLine("Enter userID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new password: ");
            string newpassword = Console.ReadLine();
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);
            param.Add("password", newpassword);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("UpdateUserPassword", param, commandType:CommandType.StoredProcedure);
        }
        public void DeleteUserByID() //видалити юзера
        {
            Console.WriteLine("Enter userID: ");
            int id = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("DeleteUser", param, commandType: CommandType.StoredProcedure);
        }
        public void UpdateUserEmail() //оновити пошту юзера
        {
            Console.WriteLine("Enter userID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new email: ");
            string newemail = Console.ReadLine();
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@email", newemail);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("UpdateUserEmail", param, commandType: CommandType.StoredProcedure);
        }
    }
}