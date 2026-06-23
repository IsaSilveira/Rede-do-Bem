using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;

namespace Rede_do_bem.Controllers
{
    public class QueroDoarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueroDoarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? filtroCidade, string? filtroTipo, string visualizacao = "lista")
        {
            // ---------------- CAMPANHAS ----------------
            var campanhas = _context.Campanhas
                .AsQueryable();

            // Filtro por cidade (campanhas)
            if (!string.IsNullOrEmpty(filtroCidade))
            {
                campanhas = campanhas.Where(c =>
                    c.EnderecoRecebimento != null &&
                    c.EnderecoRecebimento.Contains(filtroCidade));
            }

            // Filtro por tipo de doação
            if (!string.IsNullOrEmpty(filtroTipo))
            {
                campanhas = campanhas.Where(c =>
                    c.TipoDoacao != null &&
                    c.TipoDoacao.Contains(filtroTipo));
            }

            // ---------------- INSTITUIÇÕES ----------------
            var instituicoesQuery = _context.Usuarios
                .Where(u => u.Tipo == Rede_do_bem.Models.TipoUsuario.Instituicao)
                .AsQueryable();

            // Filtro por cidade (instituições)
            if (!string.IsNullOrEmpty(filtroCidade))
            {
                instituicoesQuery = instituicoesQuery.Where(u =>
                    u.EnderecoCompleto != null &&
                    u.EnderecoCompleto.Contains(filtroCidade));
            }

            var instituicoes = await instituicoesQuery.ToListAsync();

            // ---------------- VIEWBAG ----------------
            ViewBag.FiltroCidade = filtroCidade;
            ViewBag.FiltroTipo = filtroTipo;
            ViewBag.Visualizacao = visualizacao;
            ViewBag.Instituicoes = instituicoes;

            // ---------------- RESULTADO FINAL ----------------
            var resultado = await campanhas.ToListAsync();

            return View(resultado);
        }
    }
}
