using System;
using System.Collections.Generic;

namespace Labb3Skolan.Models;

public partial class TeacherCourse
{
    public int FkteacherId { get; set; }

    public int FkcourseId { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Employee Fkteacher { get; set; } = null!;
}
