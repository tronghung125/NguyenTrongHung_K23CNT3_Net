using System;
using System.Collections.Generic;

namespace NguyenTrongHung_2310900039.Models;

public partial class NthEmployee
{
    public int NthEmpId { get; set; }

    public string? NthEmpName { get; set; }

    public string? NthEmpLevel { get; set; }

    public DateOnly? NthEmpStartDate { get; set; }

    public bool? NthEmpStatus { get; set; }
}
