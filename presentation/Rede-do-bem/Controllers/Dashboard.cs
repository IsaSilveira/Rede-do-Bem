using Microsoft.AspNetCore.Mvc;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims;

namespace Rede_do_bem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarioId =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.TotalCampanhas = 0;
            ViewBag.TotalDoacoesRecebidas = 0;

            if (!string.IsNullOrEmpty(usuarioId))
            {
                ViewBag.TotalCampanhas =
                    _context.Campanhas.Count(c =>
                        c.InstituicaoId == usuarioId);

                ViewBag.TotalDoacoesRecebidas =
                    _context.Doacoes.Count(d =>
                        d.Status == StatusDoacao.Validada &&
                        d.Campanha != null &&
                        d.Campanha.InstituicaoId == usuarioId);
                ViewBag.TotalDoacoesFeitas =
                    _context.Doacoes.Count(d =>
                        d.DoadorId == usuarioId &&
                        d.Status == StatusDoacao.Validada);
                
                ViewBag.PerfilSalvo = 0;

                if (int.TryParse(usuarioId, out int idUsuario))
                {
                    ViewBag.PerfilSalvo =
                        _context.InstituicoesSalvas
                            .Count(i => i.InstituicaoId == idUsuario);
                }
            }

            ViewBag.TipoUsuario =
                User.FindFirst(ClaimTypes.Role)?.Value;

            return View();
        }
    }
}