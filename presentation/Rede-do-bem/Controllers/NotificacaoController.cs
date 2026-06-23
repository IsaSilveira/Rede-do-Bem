using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Rede_do_bem.Controllers
{
    public class NotificacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
                return RedirectToPage("/Account/Login");

            var notificacoes = await _context.Notificacoes
                .Where(n => n.UsuarioEmail == email)
                .OrderByDescending(n => n.DataCriacao)
                .ToListAsync();

            // Retroativamente popula Link de notificações antigas
            var semLink = notificacoes.Where(n => string.IsNullOrEmpty(n.Link)).ToList();
            if (semLink.Any())
            {
                bool houveMudanca = false;
                foreach (var n in semLink)
                {
                    string? nomeCampanha = null;

                    // "Nova campanha ...: Nome da Campanha"
                    var mNova = Regex.Match(n.Mensagem, @"^Nova campanha [^:]+:\s+(.+)$");
                    if (mNova.Success) nomeCampanha = mNova.Groups[1].Value.Trim();

                    // '... campanha "Nome da Campanha"...'
                    if (nomeCampanha == null)
                    {
                        var mAspas = Regex.Match(n.Mensagem, @"campanha ""(.+?)""");
                        if (mAspas.Success) nomeCampanha = mAspas.Groups[1].Value.Trim();
                    }

                    if (nomeCampanha != null)
                    {
                        var campanha = await _context.Campanhas
                            .FirstOrDefaultAsync(c => c.NomeDaCampanha == nomeCampanha);
                        if (campanha != null)
                        {
                            n.Link = Url.Action("Details", "Campanhas", new { id = campanha.IdCampanha });
                            houveMudanca = true;
                        }
                    }
                }
                if (houveMudanca)
                    await _context.SaveChangesAsync();
            }

            return View(notificacoes);
        }

        [HttpPost]
        public async Task<IActionResult> MarcarComoLida(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(n => n.Id == id && n.UsuarioEmail == email);

            if (notificacao != null)
            {
                notificacao.Lida = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MarcarTodasComoLidas()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var pendentes = await _context.Notificacoes
                .Where(n => n.UsuarioEmail == email && !n.Lida)
                .ToListAsync();

            foreach (var n in pendentes)
                n.Lida = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(n => n.Id == id && n.UsuarioEmail == email);

            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Marca como lida e redireciona para a tela correspondente
        public async Task<IActionResult> Ir(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(n => n.Id == id && n.UsuarioEmail == email);

            if (notificacao == null)
                return RedirectToAction(nameof(Index));

            if (!notificacao.Lida)
            {
                notificacao.Lida = true;
                await _context.SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(notificacao.Link))
                return Redirect(notificacao.Link);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> LimparLidas()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var lidas = await _context.Notificacoes
                .Where(n => n.UsuarioEmail == email && n.Lida)
                .ToListAsync();

            if (lidas.Any())
            {
                _context.Notificacoes.RemoveRange(lidas);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}