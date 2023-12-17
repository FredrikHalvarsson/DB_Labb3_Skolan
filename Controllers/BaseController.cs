using Labb3Skolan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Skolan.Controllers
{
    internal class BaseController
    {
        protected readonly SlotteGymnasietContext context = new SlotteGymnasietContext();
        /// <summary>
        /// Checks to see if Personal number is valid, separating date of birth and final four digits
        /// </summary>
        /// <returns>PersonalNumber</returns>
        internal string SetPersonalNumber()
        {
            DateTime date;
            int i;
            string personalNumber;
            bool success = false;
            do
            {
                //Console.WriteLine("""Please input personal number (12 digits) with a "-" separating date of birth and the final four digits""");
                Console.WriteLine("Please input personal number in they form of (yyyy-mm-dd:xxxx)");
                personalNumber = Console.ReadLine();

                if (personalNumber.Contains(":"))
                {
                    string[] sub = personalNumber.Split(":");

                    if (sub[0].Length == 10
                    && sub[1].Length == 4
                    && DateTime.TryParse(sub[0], out date)
                    && int.TryParse(sub[1], out i))
                    {
                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                }
            } while (!success);
            return personalNumber;
        }
        /// <summary>
        /// Translates named grades to numeric values, used to calculate average
        /// </summary>
        /// <param name="grade">string as grade from database</param>
        /// <returns>grade as int</returns>
        internal decimal GradeToDecimal(string grade)
        {
            return grade.Trim() switch
            {
                "MVG" => 4,
                "VG" => 3,
                "G" => 2,
                "IG" => 1,
                "N/A" => 0
            };
        }
        /// <summary>
        ///Transfers numeric grades back to a named grade, after calculating average
        /// </summary>
        /// <param name="grade">average grade as int (0-4)</param>
        /// <returns>Named grade as in database</returns>
        internal string GradeToString(decimal grade)
        {
            return grade switch
            {
                0 => "Not yet graded",
                1 => "IG",
                2 => "G",
                3=> "VG",
                4=> "MVG"
            };
        }
    }
}
