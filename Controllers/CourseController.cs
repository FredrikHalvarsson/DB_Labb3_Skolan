using Labb3Skolan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class CourseController : BaseController
    {
        internal List<Course> GetCourses()
        {
            var courses = context.Set<Course>().ToList();
            return courses;
        }
    }
}
