using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientBackendNoAuth.Models;

public partial class Event
{
    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? Country { get; set; }

    public decimal[]? Capacity { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
