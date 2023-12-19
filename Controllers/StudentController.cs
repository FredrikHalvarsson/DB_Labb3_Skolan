using Labb3Skolan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class StudentController : BaseController
    {
        internal IOrderedEnumerable<Student> GetStudents(int order)
        {
            var allStudents = context.Set<Student>().ToList();
            var studentList = allStudents.OrderBy(x => x.LastName);
            if (order == 1/*"lastnameasc"*/)
            {
                studentList=allStudents.OrderBy(x => x.LastName);
            }
            if (order == 2/*"firstnameasc"*/)
            {
                studentList = allStudents.OrderBy(x => x.FirstName);
            }
            if (order == 3/*lastnamedesc*/)
            {
                studentList = allStudents.OrderByDescending(x => x.LastName);
            }
            if (order == 4/*"firstnamedesc"*/)
            {
                studentList = allStudents.OrderByDescending(x => x.FirstName);
            }
            return studentList;
        }
        internal void PrintStudents()
        {
            Console.WriteLine("Order List by: ");
            int order = MenuController.Menu("last name. ascending", "first name. ascending", "last name. descending", "first name. descending");
            var studentList = GetStudents(order);
            
            foreach (var item in studentList)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
        internal void AddStudent()
        {
            
            Console.Write("Input First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Input Surname: ");
            string lastName = Console.ReadLine();

            string personalNumber = SetPersonalNumber();

            //Console.WriteLine("Select Role: ");
            //int roleId = MenuController.Menu("Teacher", "Principal");

            Student student = new Student(firstName, lastName, personalNumber);
            context.Students.Add(student);
            Console.WriteLine("Student added!");
            context.SaveChanges();

            //Need to create another method to add student to existing courses 
        }
    }
}
