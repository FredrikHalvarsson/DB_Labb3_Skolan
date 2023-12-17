using System;
using System.Collections.Generic;

namespace Labb3Skolan.Models;

public partial class StudentCourseGrade
{
    public int FkstudentId { get; set; }

    public int FkcourseId { get; set; }

    public int FkgradeId { get; set; }

    public DateTime? GradeDate { get; set; }

    public string? GradeTeacher { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Grade Fkgrade { get; set; } = null!;

    public virtual Student Fkstudent { get; set; } = null!;
}
