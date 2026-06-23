using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Rede_do_bem.Pages
{
    public class DashboardModel : PageModel
    {
        public string TipoUsuario { get; set; } = "";

        public int Card1 { get; set; }
        public int Card2 { get; set; }
        public int Card3 { get; set; }

        public void OnGet()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            Console.WriteLine($"ROLE: {role}");

            TipoUsuario = role ?? "";

            if (TipoUsuario == "Instituicao")
            {
                Card1 = 42;
                Card2 = 18;
                Card3 = 207;
            }
            else
            {
                Card1 = 42;
                Card2 = 3;
                Card3 = 98;
            }
        }
    }
}