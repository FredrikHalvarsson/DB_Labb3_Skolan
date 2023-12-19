using Labb3Skolan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class EmployeeController : BaseController
    {
        internal IOrderedEnumerable<Employee> GetEmployeesByRole(int order, string role)
        {
            var allEmployees = context.Set<Employee>()
                .Include(x=>x.Role)
                .Where(x=>x.Role.RoleName.Contains($"{role}"))
                .ToList();

            var employeesByRole = allEmployees.OrderBy(x => x.LastName);
            if (order == 1/*"lastnameasc"*/)
            {
                employeesByRole=allEmployees.OrderBy(x => x.LastName);
            }
            if (order == 2/*"firstnameasc"*/)
            {
                employeesByRole = allEmployees.OrderBy(x => x.FirstName);
            }
            if (order == 3/*lastnamedesc*/)
            {
                employeesByRole = allEmployees.OrderByDescending(x => x.LastName);
            }
            if (order == 4/*"firstnamedesc"*/)
            {
                employeesByRole = allEmployees.OrderByDescending(x => x.FirstName);
            }
            return employeesByRole;
        }
        internal IOrderedEnumerable<Employee> GetAllEmployees(int order)
        {
            var allEmployees = context.Set<Employee>()
                .ToList();

            var employeeList = allEmployees.OrderBy(x => x.LastName);
            if (order == 1/*"lastnameasc"*/)
            {
                employeeList=allEmployees.OrderBy(x => x.LastName);
            }
            if (order == 2/*"firstnameasc"*/)
            {
                employeeList = allEmployees.OrderBy(x => x.FirstName);
            }
            if (order == 3/*lastnamedesc*/)
            {
                employeeList = allEmployees.OrderByDescending(x => x.LastName);
            }
            if (order == 4/*"firstnamedesc"*/)
            {
                employeeList = allEmployees.OrderByDescending(x => x.FirstName);
            }
            return employeeList;
        }
        internal void Print()
        {
            Console.WriteLine("Order List by: ");
            int order = MenuController.Menu("last name. ascending", "first name. ascending", "last name. descending", "first name. descending");
            var employeelist = GetAllEmployees(order);
            foreach (var item in employeelist)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
        internal void PrintByRole()
        {
            Console.Write("Input Role Name: ");
            string role = Console.ReadLine();
            Console.WriteLine("Order List by: ");
            int order = MenuController.Menu("last name. ascending", "first name. ascending", "last name. descending", "first name. descending");
            var employeeList = GetEmployeesByRole(order,role);
            foreach(var item in employeeList)
            {
                Console.WriteLine(item.FirstName+" "+item.LastName+" "+item.Role.RoleName);
            }
        }

        internal void AddEmployee()
        {
            Console.Write("Input First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Input Surname: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Input starting Salary: ");
            decimal salary;
            decimal.TryParse(Console.ReadLine(), out salary);

            DateTime hireDate = DateTime.Now;
            string personalNumber = SetPersonalNumber();

            Console.WriteLine("Select Role: ");
            int roleId = MenuController.Menu("Teacher", "Principal");

            Employee employee = new Employee(firstName, lastName, salary, personalNumber, hireDate, roleId);
            context.Employees.Add(employee);
            Console.WriteLine("Employee added!");
            context.SaveChanges();
        }
    }
}
