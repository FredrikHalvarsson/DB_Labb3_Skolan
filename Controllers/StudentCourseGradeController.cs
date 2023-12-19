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
        internal IOrderedEnumerable<StudentCourseGrade> GetStudentGrades(int studentId, int order)
        {
            var allStudentGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkstudentId == studentId)
                .ToList();

            var studentGrades = allStudentGrades.OrderBy(x => x.Fkgrade.GradeName);
            if (order == 1/*"gradeasc"*/)
            {
                studentGrades=allStudentGrades.OrderBy(x => x.Fkgrade.GradeName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                studentGrades=allStudentGrades.OrderByDescending(x => x.Fkgrade.GradeName);
            }
            if (order == 3/*courseasc*/)
            {
                studentGrades=allStudentGrades.OrderBy(x => x.Fkcourse.CourseName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                studentGrades=allStudentGrades.OrderByDescending(x => x.Fkcourse.CourseName);
            }
            return studentGrades;
        }
        //Created for possible future use
        internal IOrderedEnumerable<StudentCourseGrade> GetStudentGradesInCourse(int courseId, int order)
        {
            var allCourseGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkcourseId == courseId)
                .ToList();

            var courseGrades=allCourseGrades.OrderBy(x => x.Fkgrade.GradeName);
            if (order == 1/*"gradeasc"*/)
            {
                courseGrades=allCourseGrades.OrderBy(x => x.Fkgrade.GradeName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                courseGrades=allCourseGrades.OrderByDescending(x => x.Fkgrade.GradeName);
            }
            if (order == 3/*courseasc*/)
            {
                courseGrades=allCourseGrades.OrderBy(x => x.Fkcourse.CourseName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                courseGrades=allCourseGrades.OrderByDescending(x => x.Fkcourse.CourseName);
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
        internal IOrderedEnumerable<StudentCourseGrade> GetStudentsInCourse(int courseId, int order)
        {
            var allStudentsInCourse = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(X => X.Fkcourse)
                .Where(x => x.FkcourseId == courseId)
                .ToList();

            var studentsInCourse=allStudentsInCourse.OrderBy(x => x.Fkstudent.LastName);
            if (order == 1/*"gradeasc"*/)
            {
                studentsInCourse=allStudentsInCourse.OrderBy(x => x.Fkstudent.LastName);
            }
            if (order == 2/*"gradedesc"*/)
            {
                studentsInCourse=allStudentsInCourse.OrderBy(x => x.Fkstudent.FirstName);
            }
            if (order == 3/*courseasc*/)
            {
                studentsInCourse=allStudentsInCourse.OrderByDescending(x => x.Fkstudent.LastName);
            }
            if (order == 4/*"coursedesc"*/)
            {
                studentsInCourse=allStudentsInCourse.OrderByDescending(x => x.Fkstudent.FirstName);
            }
            return studentsInCourse;
        }
        internal IOrderedEnumerable<StudentCourseGrade> GetRecentGrades()
        {
            var allRecentGrades = context.Set<StudentCourseGrade>()
                .Include(x => x.Fkstudent)
                .Include(x => x.Fkgrade)
                .Include(X => X.Fkcourse)
                .Where(x => x.GradeDate > DateTime.Now.AddMonths(-1))
                .ToList();
            var recentGrades=allRecentGrades.OrderBy(x => x.Fkcourse.CourseName);
           
            return recentGrades;
        }
        //Created for possible future use
        internal void PrintStudentGrades(int studentId)
        {
            Console.WriteLine("Order List by: ");
            int order = MenuController.Menu("Grade Ascending","Grade Descending","Course Ascending","Course Descending");
            var grades = GetStudentGrades(studentId,order);
            Console.WriteLine("Name: " +grades.FirstOrDefault().Fkstudent.FirstName);
            foreach (var item in grades)
            {
                Console.WriteLine(item.Fkcourse.CourseName + "\t" + item.Fkgrade.GradeName);
            }
        }
        internal void PrintAverageCourseGrades()
        {
            
            var courseGrades = GetGradesAndCourses();
            var groupedGrades = courseGrades.GroupBy(x => x.Fkcourse.CourseId);
            foreach (var course in groupedGrades)
            {
                decimal totalGrades = 0;
                decimal decimalGrade;
                decimal lowestGrade = 5;
                decimal highestGrade = 0;
                var x = course.ToList();
                Console.WriteLine(x.First().Fkcourse.CourseName);
                
                foreach (var grade in course)
                {
                    if (grade.Fkgrade.GradeName != "N/A")
                    {
                        totalGrades += GradeToDecimal(grade.Fkgrade.GradeName);
                        decimalGrade = GradeToDecimal(grade.Fkgrade.GradeName);
                        if (decimalGrade <= lowestGrade) { lowestGrade = decimalGrade; }
                        if (decimalGrade >= highestGrade) { highestGrade = decimalGrade; }
                    }
                }
                string avgGrade = GradeToString(Math.Round(totalGrades / x.Count()));
                if (lowestGrade < 5 && lowestGrade!=0) { Console.WriteLine($"Lowest grade: {GradeToString(lowestGrade)}"); }
                if (highestGrade > 0) { Console.WriteLine($"Highest grade: {GradeToString(highestGrade)}"); }
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
                Console.WriteLine("Course: " + students.FirstOrDefault().Fkcourse.CourseName);
                foreach (var item in students)
                {
                    Console.WriteLine(item.Fkstudent.FirstName + " " + item.Fkstudent.LastName);
                }
            }
            else { Console.WriteLine("Selected Course NOT FOUND"); }
        }
    }
}
