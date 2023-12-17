using Labb3Skolan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class StudentCourseGradeController : BaseController
    {
        internal CourseController courseController = new CourseController();
        internal List<StudentCourseGrade> GetStudentGrades(int studentId, int order)
        {
            var studentGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkstudentId == studentId)
                .ToList();
            if (order == 1/*"gradeasc"*/)
            {
                studentGrades.OrderBy(x => x.Fkgrade.GradeName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                studentGrades.OrderByDescending(x => x.Fkgrade.GradeName);
            }
            if (order == 3/*courseasc*/)
            {
                studentGrades.OrderBy(x => x.Fkcourse.CourseName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                studentGrades.OrderByDescending(x => x.Fkcourse.CourseName);
            }
            return studentGrades;
        }
        internal List<StudentCourseGrade> GetStudentGradesInCourse(int courseId, int order)
        {
            var courseGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkcourseId == courseId)
                .ToList();
            if (order == 1/*"gradeasc"*/)
            {
                courseGrades.OrderBy(x => x.Fkgrade.GradeName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                courseGrades.OrderByDescending(x => x.Fkgrade.GradeName);
            }
            if (order == 3/*courseasc*/)
            {
                courseGrades.OrderBy(x => x.Fkcourse.CourseName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                courseGrades.OrderByDescending(x => x.Fkcourse.CourseName);
            }
            return courseGrades;
        }
        internal List<StudentCourseGrade> GetGradesAndCourses()
        {
            var courseGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .ToList();
            return courseGrades;
        }
        internal List<StudentCourseGrade> GetStudentsInCourse(int courseId, int order)
        {
            var studentsInCourse = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkcourseId == courseId)
                .ToList();
            if (order == 1/*"gradeasc"*/)
            {
                studentsInCourse.OrderBy(x => x.Fkgrade.GradeName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                studentsInCourse.OrderByDescending(x => x.Fkgrade.GradeName);
            }
            if (order == 3/*courseasc*/)
            {
                studentsInCourse.OrderBy(x => x.Fkcourse.CourseName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                studentsInCourse.OrderByDescending(x => x.Fkcourse.CourseName);
            }
            return studentsInCourse;
        }
        internal List<StudentCourseGrade> GetRecentGrades()
        {
            var recentGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.GradeDate > DateTime.Now.AddMonths(-1))
                .ToList();
            recentGrades.OrderBy(x => x.Fkcourse.CourseName);
           
            return recentGrades;
        }
        internal void PrintStudentGrades(int studentId)
        {
            Console.WriteLine("Order List by: ");
            int order = MenuController.Menu("Grade Ascending","Grade Descending","Course Ascending","Course Descending");
            var grades = GetStudentGrades(studentId,order);
            Console.WriteLine("Name: " + grades[0].Fkstudent.FirstName);
            foreach (var item in grades)
            {
                Console.WriteLine(item.Fkcourse.CourseName + "\t" + item.Fkgrade.GradeName);
            }
        }
        internal void PrintAverageCourseGrades()
        {
            decimal totalGrades=0;
            var courseGrades = GetGradesAndCourses();
            var groupedGrades = courseGrades.GroupBy(x => x.Fkcourse.CourseId);
            foreach (var course in groupedGrades)
            {
                totalGrades = 0;
                var x = course.ToList();
                Console.WriteLine(x.First().Fkcourse.CourseName);
                
                foreach (var grade in course)
                {
                    if (grade.Fkgrade.GradeName != "N/A")
                    {
                        totalGrades += GradeToDecimal(grade.Fkgrade.GradeName);
                    }
                }
                string avgGrade = GradeToString(Math.Round(totalGrades / x.Count()));
                Console.WriteLine("Average grade: "+avgGrade +"\n"); 
            }
        }
        internal void PrintRecentGrades()
        {
            var recentGrades = GetRecentGrades();
            foreach (var item in recentGrades)
            {
                Console.WriteLine("Course: "+item.Fkcourse.CourseName+" | Student: "+item.Fkstudent.FirstName+" "+item.Fkstudent.LastName+" | Grade: "+item.Fkgrade.GradeName);
            }
        }
        internal void PrintStudentsInCourse()
        {
            Console.WriteLine("Courses:");
            foreach (var item in context.Courses) 
            {
                Console.WriteLine("ID: " + item.CourseId + " Name: " + item.CourseName);
            }
            Console.Write("Please enter course ID: ");
            int courseId;
            int.TryParse(Console.ReadLine(), out courseId);
            if(courseController.GetCourses().Select(x => x.CourseId).Contains(courseId))
            {
                int order = MenuController.Menu("last name. ascending", "first name. ascending", "last name. descending", "first name. descending");
                var students = GetStudentsInCourse(courseId, order);
                Console.WriteLine("Course: " + students[0].Fkcourse.CourseName);
                foreach (var item in students)
                {
                    Console.WriteLine(item.Fkstudent.FirstName + " " + item.Fkstudent.LastName);
                }
            }
            else { Console.WriteLine("Selected Course NOT FOUND"); }
        }
    }
}
