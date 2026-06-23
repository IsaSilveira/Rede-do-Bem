using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Models
{


    public class Dashboard
    {

        [Key]
        public int Id { get; set; }

        public int PerfilSalvo { get; set; }

        public int CampanhasCriadas { get; set; }

        public int DoacoesRecebidas { get; set; }
    }
}
