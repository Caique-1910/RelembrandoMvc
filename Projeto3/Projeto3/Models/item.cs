using System;
using System.Collections.Generic;

namespace Projeto3.Models;

public partial class item
{
    public int id { get; set; }

    public string? nomeItem { get; set; }

    public decimal? preco { get; set; }

    public string? descricao { get; set; }
}
