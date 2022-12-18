using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using main.Models.Categories;
using Dapper;
using System.Data;
using main.Interface;

namespace main.Repository.Other
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public CategoriesRepository(SqlConnection connection) 
        {
            sqlConnection= connection;
        }
        public IEnumerable<Categories> CategoriesModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Categories>("ShowAllCategories",commandType:CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllCategories() //метод для перебору данних у колекції
        {
            foreach (Categories item in CategoriesModel())
            {
                item.Info(); //метод Info, моделі Categories
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
