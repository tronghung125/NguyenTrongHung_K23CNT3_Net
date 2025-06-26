using System;
using System.Collections.Generic;

namespace nthLesson10.Models;

public partial class NthPost
{
    public int NthId { get; set; }

    public string? NthTitle { get; set; }

    public string? NthImage { get; set; }

    public string? NthContent { get; set; }

    public bool? NthStatus { get; set; }
}
