using System;
using System.Collections.Generic;

namespace ConsoleApp3.Models;

public partial class Task
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? IdUser { get; set; }

    public string? Status { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
