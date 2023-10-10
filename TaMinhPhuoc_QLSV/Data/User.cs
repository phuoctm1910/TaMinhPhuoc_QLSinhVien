using System;
using System.Collections.Generic;

namespace TaMinhPhuoc_QLSV.Data;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
