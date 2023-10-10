using System;
using System.Collections.Generic;

namespace TaMinhPhuoc_QLSV.Data;

public partial class Grade
{
    public int Id { get; set; }

    public string? Masv { get; set; }

    public int? Tienganh { get; set; }

    public int? Tinhoc { get; set; }

    public int? Gdtc { get; set; }

    public virtual Student? MasvNavigation { get; set; }
}
