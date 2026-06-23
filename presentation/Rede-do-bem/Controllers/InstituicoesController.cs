using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;
using System.Security.Claims;
using Rede_do_bem.Models;

namespace Rede_do_bem.Controllers
{
    public class InstituicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstituicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var instituicao = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);

            if (instituicao == null)
                return NotFound();

            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.InstituicaoId == id)
                .ToListAsync();

            ViewBag.TotalAvaliacoes = avaliacoes.Count;

            ViewBag.MediaAvaliacao =
                avaliacoes.Any()
                    ? Math.Round(avaliacoes.Average(a => a.Nota), 1)
                    : 0;

            var hoje = DateTime.Today;
            var campanhas = await _context.Campanhas
                .Where(c => c.InstituicaoId == id.ToString())
                .ToListAsync();

            ViewBag.CampanhasAtivas = campanhas
                .Where(c => c.DataFim.HasValue && c.DataFim.Value.Date >= hoje)
                .ToList();

            // Verifica se o usuário logado já salvou esta instituição
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.JaSalvou = false;
            ViewBag.EstaLogado = !string.IsNullOrEmpty(usuarioId);

            if (!string.IsNullOrEmpty(usuarioId))
            {
                ViewBag.JaSalvou = await _context.InstituicoesSalvas
                    .AnyAsync(x => x.UsuarioId == usuarioId && x.InstituicaoId == id);
                
                var email = User.FindFirstValue(ClaimTypes.Email);
                var minhaAvaliacao = avaliacoes.FirstOrDefault(a => a.UsuarioEmail == email);
                ViewBag.MinhaAvaliacao = minhaAvaliacao?.Nota ?? 0;
                
                ViewBag.IsOwner = (usuarioId == id.ToString());
            }

            return View(instituicao);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(int instituicaoId)
        {
            var usuarioId =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(usuarioId))
                return Redirect("/Account/Login");

            bool jaSalvou =
                await _context.InstituicoesSalvas
                    .AnyAsync(x =>
                        x.UsuarioId == usuarioId &&
                        x.InstituicaoId == instituicaoId);

            if (!jaSalvou)
            {
                _context.InstituicoesSalvas.Add(
                    new InstituicaoSalva
                    {
                        UsuarioId = usuarioId,
                        InstituicaoId = instituicaoId
                    });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details",
                new { id = instituicaoId });
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int instituicaoId)
        {
            var usuarioId =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(usuarioId))
                return Redirect("/Account/Login");

            var registro = await _context.InstituicoesSalvas
                .FirstOrDefaultAsync(x =>
                    x.UsuarioId == usuarioId &&
                    x.InstituicaoId == instituicaoId);

            if (registro != null)
            {
                _context.InstituicoesSalvas.Remove(registro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details",
                new { id = instituicaoId });
        }
    }
}
