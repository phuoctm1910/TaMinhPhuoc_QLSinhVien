using System;
using System.Collections.Generic;

namespace TaMinhPhuoc_QLSV.Data;

public partial class Student
{
    public string Masv { get; set; } = null!;

    public string? Hoten { get; set; }

    public string? Email { get; set; }

    public string? SoDt { get; set; }

    public string? Gioitinh { get; set; }

    public string? Diachi { get; set; }

    public string? Hinh { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
