using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlightsAppBE.Repository.Models;

public partial class Airport
{
    [Key]
    [StringLength(4)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("Airport")]
    [StringLength(100)]
    [Unicode(false)]
    public string Airport1 { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Country { get; set; } = null!;
}
