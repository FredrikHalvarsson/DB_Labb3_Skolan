using System;
using System.Collections.Generic;

namespace Labb3Skolan.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public int SortOrder { get; set; }
}
