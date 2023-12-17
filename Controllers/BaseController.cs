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
        internal string SetPersonalNumber()
        {
            DateTime date;
            int i;
            string personalNumber;
            bool success = false;
            do
            {
                Console.WriteLine("""Please input personal number (12 digits) with a "-" separating date of birth and the final four digits""");
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
        internal string GradeToString(decimal grade)
        {
            return grade switch
            {
                0 => "Not yet graded",
                1 => "IG",
                2 => "G",
                3=>"VG",
                4=>"MVG"
            };
        }
    }
}
