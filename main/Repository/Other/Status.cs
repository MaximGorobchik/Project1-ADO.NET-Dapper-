using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using main.Models.Status;
using main.Interface;

namespace main.Repository.Other
{
    public class StatusRepository : IStatusRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public StatusRepository(SqlConnection connection)
        {
            sqlConnection = connection;
        }
        public IEnumerable<Status> StatusModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Status>("ShowAllStatus", commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllStatus() //метод для перебору данних у колекції
        {
            foreach (Status item in StatusModel())
            {
                item.Info(); //метод Info, моделі Status
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}