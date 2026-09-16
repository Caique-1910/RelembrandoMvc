using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto1.Models;

public partial class livro
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? nome { get; set; }

    public DateTime? dtLivro { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? descricao { get; set; }

    [MaxLength(1)]
    public byte[]? img { get; set; }
}
