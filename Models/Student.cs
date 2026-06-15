using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Student
{
    public int StudId { get; set; }

    public string StudName { get; set; } = null!;

    public string StudGen { get; set; } = null!;

    public DateOnly StudDob { get; set; }

    public string StudPhon { get; set; } = null!;

    public int? CourseId { get; set; }

   

    public virtual Course? Course { get; set; }
}
