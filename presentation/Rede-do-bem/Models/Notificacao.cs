namespace Rede_do_bem.Models;

public class Notificacao
{
    public int Id { get; set; }
    public string UsuarioEmail { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public bool Lida { get; set; } = false;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public string? Link { get; set; }
}
