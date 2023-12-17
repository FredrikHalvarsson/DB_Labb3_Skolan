using Labb3Skolan.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class RunController
    {
        internal StudentCourseGradeController sCGController = new StudentCourseGradeController();
        internal StudentController studentController = new StudentController();
        internal EmployeeController employeeController = new EmployeeController();
        internal void Run()
        {
            do
            {
                switch (MenuController.Menu("Lists", "Add"))
                {
                    case 1:
                        Console.WriteLine("List... ");
                        switch (MenuController.Menu("All Employes", "Employees by role", "All Students", "Students by course", "Grades from latest month", "Course with avg. Grades"))
                        {
                            case 1:
                                employeeController.Print();
                                break;
                            case 2:
                                employeeController.PrintByRole();
                                break;
                            case 3:
                                studentController.PrintStudents();
                                break;
                            case 4:
                                sCGController.PrintStudentsInCourse();
                                break;
                            case 5:
                                sCGController.PrintRecentGrades();
                                break;
                            case 6:
                                sCGController.PrintAverageCourseGrades();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Add...");
                        switch (MenuController.Menu("New Employee", "New Student","Return"))
                        {
                            case 1:
                                employeeController.AddEmployee();
                                break;
                            case 2:
                                studentController.AddStudent();
                                break;
                            case 3:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
