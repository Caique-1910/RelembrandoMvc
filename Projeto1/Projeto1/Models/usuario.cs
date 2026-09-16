using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto1.Models;

[Index("email", Name = "UQ__usuario__AB6E6164A8C1ACF6", IsUnique = true)]
public partial class usuario
{
    [Key]
    public Guid id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string email { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string senha { get; set; } = null!;
}
