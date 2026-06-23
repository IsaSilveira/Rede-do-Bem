namespace Rede_do_bem.Models
{
    public class Denuncia
    {
        public int Id { get; set; }

        public int CampanhaId { get; set; }

        public string UsuarioId { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;

        public DateTime DataDenuncia { get; set; } = DateTime.Now;

        public bool Visualizada { get; set; } = false;

        public Campanha? Campanha { get; set; }
    }
}