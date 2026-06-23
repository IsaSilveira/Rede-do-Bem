using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rede_do_bem.Models
{
    [Table("Campanhas")]
    public class Campanha : IValidatableObject
    {
        [Key]
        public int IdCampanha { get; set; }
        // REMOVER
        // public string InstituicaoId { get; set; }
        // public Usuario Instituicao { get; set; }

        public string? InstituicaoId { get; set; }
        public Usuario? Instituicao { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome pode ter no máximo 100 caracteres.")]
        [Display(Name = "Nome da Campanha")]
        public string NomeDaCampanha { get; set; }

        [Required(ErrorMessage = "O Nome do Responsável é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome do Responsável pode ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do Responsável")]
        public string? NomeResponsavel { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [Phone(ErrorMessage = "O formato do telefone é inválido.")]
        [StringLength(20, ErrorMessage = "O Telefone pode ter no máximo 20 caracteres.")]
        [Display(Name = "Telefone de Contato")]
        public string? TelefoneContato { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Endereço pode ter no máximo 200 caracteres.")]
        [Display(Name = "Endereço de Recebimento")]
        public string? EnderecoRecebimento { get; set; }

        [Required(ErrorMessage = "O Tipo de Doação é obrigatório.")]
        [StringLength(50)]
        [Display(Name = "Tipo de Doação")]
        public string? TipoDoacao { get; set; }

        [Required(ErrorMessage = "A Data Inicial é obrigatória.")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "A Data Final é obrigatória.")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        [Required(ErrorMessage = "O Horário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Horário pode ter no máximo 50 caracteres.")]
        [Display(Name = "Horário de Recebimento")]
        public string? HorarioRecebimento { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A Descrição pode ter no máximo 500 caracteres.")]
        [Display(Name = "Descrição da Ação")]
        public string? DescricaoAcao { get; set; }

        [Display(Name = "Campanha Favoritada?")]
        public bool CampanhaFavoritada { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataInicio.HasValue && DataFim.HasValue && DataFim.Value < DataInicio.Value)
            {
                yield return new ValidationResult(
                    "A Data Final não pode ser anterior à Data Inicial.",
                    new[] { nameof(DataFim) });
            }
        }
    }
}
