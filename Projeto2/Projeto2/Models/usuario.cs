namespace Projeto2.Models;

public partial class usuario
{
    public Guid usuarioid { get; set; }

    public string email { get; set; } = null!;

    public string senha { get; set; } = null!;
}
