using main.Interface;
using main.Repository.Other;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Repository
{
    //Репозиторій представляє патерн, завдання якого полягає у керуванні доступом до джерела даних.
    //Як правило, репозиторій прив'язаний до однієї конкретної сутності чи моделі, даними якої він управляє.
    class Main_Repositoriy : IMain_Repositoriy
    {
        //рядок підключення
        static string connectionString = @"Data Source=FSB\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection connection = new SqlConnection(connectionString);
        //ініціалізація репозиторів для управління над моделями
        CategoriesRepository categoriesRepository = new CategoriesRepository(connection);
        DepartmentRepository departmentRepository = new DepartmentRepository(connection);
        EmployeesRepository employeesRepository = new EmployeesRepository(connection);
        ReportsRepository reportsRepository = new ReportsRepository(connection);
        StatusRepository statusRepository = new StatusRepository(connection);
        UsersRepository usersRepository = new UsersRepository(connection);
        public Main_Repositoriy()
        {
            connection.Open(); //відкриваємо підключення
        }
        public void Start() //функція для запуску
        {
            while (true)
            {
                Console.WriteLine("a. Show all categories\n" + "b. Show all departments\n" + "c. Show all employees\n" +"d. Show all reports\n" + "e. Show all status\n" +
                    "f. Show all users\n" + "g. Add new report\n" + "k. Update report\n" + "m. Delete report\n" + "n. View report by ID\n"+ "q. Add new employee\n"+
                    "w. Update employee departmentID\n"+ "r. Delete employee by ID\n"+ "t. Add new user\n"+ "y. Update user password\n"+ "u. Delete user by ID\n"+
                    "i. Update userEmail\n");
                char chose = char.Parse(Console.ReadLine());
                switch(chose)
                {
                    case 'a': 
                        categoriesRepository.GetAllCategories();
                        break;
                    case 'b':
                        departmentRepository.GetAllDepartments();
                        break;
                    case 'c':
                        employeesRepository.GetAllEmployees();
                        break;
                    case 'd':
                        reportsRepository.GetAllReports();
                        break;
                    case 'e':
                        statusRepository.GetAllStatus();
                        break;
                    case 'f':
                        usersRepository.GetAllUsers();
                        break;
                    case 'g':
                        reportsRepository.AddReport();
                        break;
                    case 'k':
                        reportsRepository.UpdateReport();
                        break;
                    case 'm':
                        reportsRepository.DeleteReport();
                        break;
                    case 'n':
                        reportsRepository.ViewByID();
                        break;
                    case 'q':
                        employeesRepository.AddNewEmployee();
                        break;
                    case 'w':
                        employeesRepository.UpdateEmplDepartID();
                        break;
                    case 'r':
                        employeesRepository.DeleteEmployee();
                        break;
                    case 't':
                        usersRepository.AddNewUser();
                        break;
                    case 'y':
                        usersRepository.UpdateUserPassword();
                        break;
                    case 'u':
                        usersRepository.DeleteUserByID();
                        break;
                    case 'i':
                        usersRepository.UpdateUserEmail();
                        break;

                }
            }
        }
    }
}
