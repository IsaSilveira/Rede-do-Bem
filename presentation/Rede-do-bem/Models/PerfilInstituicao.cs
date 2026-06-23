using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Models
{
    public class PerfilInstituicao
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string? Site { get; set; }

        public string? Descricao { get; set; }

        public string? Foto { get; set; }

        // Campo para a nota das estrelinhas (ex: 5.0)
        public double Avaliacao { get; set; } = 5.0;
    }
}