using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Contato { get; set; }

        public string Endereco { get; set; }
        // ---> NOVA<---
        public DateTime? DataNascimento { get; set; }

        public string? Foto { get; set; }

        public string Email { get; set; }
    }
}