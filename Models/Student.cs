using System;
using System.Collections.Generic;

namespace Labb3Skolan.Models;

public partial class Student
{
    public Student()
    {
        
    }
    public Student(string firstName, string lastName, string personalNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalNr = personalNumber;
    }
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string PersonalNr { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }
}
