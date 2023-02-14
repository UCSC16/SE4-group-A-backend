using System;
using System.Collections.Generic;

namespace SE4_group_A_backend.Entities;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? GuardianName { get; set; }

    public string? GuardianContact { get; set; }

    public DateTime AdmissionDate { get; set; }

    public DateTime? GraduationDate { get; set; }

    public string CurrentGrade { get; set; } = null!;

    public virtual ICollection<Achievement>? Achievements { get; } = new List<Achievement>();
}
