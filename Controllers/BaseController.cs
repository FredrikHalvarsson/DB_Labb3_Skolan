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
        /// Handles input of personal number and checks to see if it's valid
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
                Console.WriteLine("Please input personal number (12 digits, no special characters)");
                personalNumber = Console.ReadLine();

                if (personalNumber.Length==12)
                {
                    //separate date and compose into valid date form
                    string year = personalNumber.Substring(0, 4);
                    string month = personalNumber.Substring(4, 2);
                    string day = personalNumber.Substring(6, 2);
                    string composedDate = year+"-"+month+"-"+day;
                    //separate final 4 digits
                    string final4 = personalNumber.Substring(8, 4);
                    Console.WriteLine(composedDate+"-"+final4);

                    //check if parsable to date and int
                    if (DateTime.TryParse(composedDate, out date)
                    && int.TryParse(final4, out i))
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
        /// <param name="grade">average grade as decimal (0-4)</param>
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
