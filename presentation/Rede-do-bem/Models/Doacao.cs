using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rede_do_bem.Models
{
    public enum StatusDoacao
    {
        Pendente,
        Validada
    }

    public class Doacao
    {
        [Key]
        public int Id { get; set; }

        public int CampanhaId { get; set; }

        [ForeignKey("CampanhaId")]
        public Campanha? Campanha { get; set; }

        public string DoadorId { get; set; } = string.Empty;

        public string DoadorNome { get; set; } = string.Empty;

        [StringLength(2)]
        public string Codigo { get; set; } = string.Empty;

        public StatusDoacao Status { get; set; } = StatusDoacao.Pendente;

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public DateTime? DataValidacao { get; set; }

        // Controla se o doador já visualizou a confirmação de validação
        public bool NotificadoValidacao { get; set; } = false;
    }
}
