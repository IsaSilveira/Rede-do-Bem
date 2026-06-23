using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Models;

public enum TipoUsuario
{
    Doador,
    Instituicao
}

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty; // Armazenar Hash
    public TipoUsuario Tipo { get; set; }

    // Campos para Doador
    public string? CPF { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }

    // Campos para Instituicao
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Descricao { get; set; }
    public string? Foto { get; set; }
    
    // RF17 - Localizacao
    public string? CEP { get; set; }
    public string? EnderecoCompleto { get; set; }
    public string? Telefone { get; set; }
    public string? Site { get; set; }
    public List<string> ItensAceitos { get; set; } = new();
}
