using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;
using System.Security.Claims;

namespace Rede_do_bem.Controllers
{
    public class DoacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // RF13 - Lista as doações solicitadas pelo doador autenticado
        public async Task<IActionResult> MinhasDoacoes()
        {
            if (!(User.Identity?.IsAuthenticated ?? false))
                return Redirect("/Account/Login");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var doacoes = await _context.Doacoes
                .Include(d => d.Campanha)
                .Where(d => d.DoadorId == userId)
                .OrderByDescending(d => d.DataSolicitacao)
                .ToListAsync();

            return View(doacoes);
        }
    }
}
