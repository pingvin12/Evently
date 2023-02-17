using System;
using System.Collections.Generic;

namespace ClientBackend.Models;

public partial class Event
{
    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? Country { get; set; }

    public decimal[]? Capacity { get; set; }

    public int Id { get; set; }
}
