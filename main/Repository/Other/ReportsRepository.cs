using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using main.Models.Reports;
using main.Interface;

namespace main.Repository.Other
{
    public class ReportsRepository : IReportsRepository
    {
        private static SqlConnection sqlConnection; //підключення
        public ReportsRepository(SqlConnection connection)
        {
            sqlConnection = connection;
        }
        public IEnumerable<Reports> ReportsModel() //перелічуємо усі данні
        {
            var get = sqlConnection.Query<Reports>("ShowAllReports", commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            return get;
        }
        public void GetAllReports() //метод для перебору данних у колекції
        {
            foreach (Reports item in ReportsModel())
            {
                item.Info(); //метод Info, моделі Reports
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
        public void AddReport() //Додати рапорт
        {
            int id = 0; int categoryid = 0; int statusid = 0; string opendate = ""; string closedate = ""; string description = ""; int userid = 0; int employeeid = 0;
            Console.WriteLine("Enter reportID (> 40): "); id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter categoryID (1<=18): "); categoryid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter statusID (1<=4): "); statusid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter opendate (yyyy-mm-dd): "); opendate = Console.ReadLine();
            Console.WriteLine("Enter closedate (yyyy-mm-dd): "); closedate = Console.ReadLine();
            Console.WriteLine("Enter description (adress): "); description = Console.ReadLine();
            Console.WriteLine("Enter userID (1<=20): "); userid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter employeeID (1<=30): "); employeeid = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@categoryid", categoryid);
            param.Add("@statusid", statusid);
            param.Add("@opendate", opendate);
            param.Add("@closedate", closedate);
            param.Add("@description", description);
            param.Add("@userid", userid);
            param.Add("@employeeid", employeeid);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("AddNewReport", param, commandType: CommandType.StoredProcedure);
        }
        public void UpdateReport() //Оновити рапорт
        {
            int id = 0; int categoryid = 0; int statusid = 0; string opendate = ""; string closedate = ""; string description = ""; int userid = 0; int employeeid = 0;
            Console.WriteLine("Enter reportID (>1): "); id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter categoryID (1<=18): "); categoryid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter statusID (1<=4): "); statusid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter opendate (yyyy-mm-dd): "); opendate = Console.ReadLine();
            Console.WriteLine("Enter closedate (yyyy-mm-dd): "); closedate = Console.ReadLine();
            Console.WriteLine("Enter description (adress): "); description = Console.ReadLine();
            Console.WriteLine("Enter userID (1<=20): "); userid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter employeeID (1<=30): "); employeeid = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@categoryid", categoryid);
            param.Add("@statusid", statusid);
            param.Add("@opendate", opendate);
            param.Add("@closedate", closedate);
            param.Add("@description", description);
            param.Add("@userid", userid);
            param.Add("@employeeid", employeeid);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("UpdateReportsDate", param, commandType: CommandType.StoredProcedure);
        }
        public void DeleteReport() //видалити рапорт
        {
            int id = 0;
            Console.WriteLine("Enter reportID (>1): "); id = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            //Викликаємо збережену процедуру з параметрами
            sqlConnection.Execute("DeleteReports", param, commandType: CommandType.StoredProcedure);
        }
        public void ViewByID() //подивитися рапорти за допомогою айді
        {
            int id = 0;
            Console.WriteLine("Enter reportID (>1): "); id = int.Parse(Console.ReadLine());
            //Додаємо параметри (такі ж як і в процедурі)
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            var getByID = sqlConnection.Query<Reports>("ViewByID", param, commandType: CommandType.StoredProcedure); //отримуємо данні за допомою методу Query та збереженої процедури
            foreach (Reports item in getByID) //перебираємо данні
            {
                item.Info(); //метод Info, моделі Reports
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}