using System;
using System.Collections.Generic;

namespace Labb3Skolan.Models;

public partial class Employee
{
    public Employee(string firstName, string lastName, decimal salary, string personalNr, DateTime hireDate, int roleId)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        PersonalNr = personalNr;
        HireDate = hireDate;
        RoleId = roleId;
    }
    public Employee()
    {
        
    }
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Salary { get; set; }

    public string PersonalNr { get; set; } = null!;

    public DateTime? HireDate { get; set; }

    public int RoleId { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public virtual Role Role { get; set; } = null!;
}
