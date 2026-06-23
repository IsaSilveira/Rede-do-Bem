using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        public int InstituicaoId { get; set; }

        public string UsuarioEmail { get; set; }

        public int Nota { get; set; }

        public DateTime DataAvaliacao { get; set; } = DateTime.Now;
    }
}