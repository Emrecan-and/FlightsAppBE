using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlightsAppBE.Repository.Models;

[Table("Airr$")]
public partial class Airr
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    public string? Airport { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }
}
