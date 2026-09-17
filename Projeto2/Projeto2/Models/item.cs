using System;
using System.Collections.Generic;

namespace Projeto2.Models;

public partial class item
{
    public int id { get; set; }

    public string nomeitem { get; set; } = null!;

    public int quantidade { get; set; }
}
