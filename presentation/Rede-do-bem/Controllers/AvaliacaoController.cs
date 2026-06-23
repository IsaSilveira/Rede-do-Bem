using Microsoft.AspNetCore.Mvc;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims;

namespace Rede_do_bem.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Avaliar(int instituicaoId, int nota)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");
                
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdStr == instituicaoId.ToString())
            {
                return RedirectToAction("Details", "Instituicoes", new { id = instituicaoId });
            }

            var avaliacaoExistente = _context.Avaliacoes
                .FirstOrDefault(a =>
                    a.InstituicaoId == instituicaoId &&
                    a.UsuarioEmail == email);

            if (avaliacaoExistente != null)
            {
                avaliacaoExistente.Nota = nota;
            }
            else
            {
                _context.Avaliacoes.Add(new Avaliacao
                {
                    InstituicaoId = instituicaoId,
                    UsuarioEmail = email,
                    Nota = nota
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(
                "Details",
                "Instituicoes",
                new { id = instituicaoId });
        }
    }
}