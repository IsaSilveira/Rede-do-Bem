using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims;

namespace Rede_do_bem.Controllers
{
    public class PerfilInstituicaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PerfilInstituicaoController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Authorize]
        public async Task<IActionResult> Editar()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email)) return Redirect("/Account/Login");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null) return Redirect("/Account/Login");

            await CarregarViewBag(usuario.Id);

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Editar(Usuario model, IFormFile? fotoArquivo)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email)) return Redirect("/Account/Login");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null) return Redirect("/Account/Login");

            try
            {
                if (fotoArquivo != null)
                {
                    string pasta = Path.Combine(_environment.WebRootPath, "imagens");
                    if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(fotoArquivo.FileName);
                    string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        await fotoArquivo.CopyToAsync(stream);

                    usuario.Foto = "/imagens/" + nomeArquivo;
                }

                if (!string.IsNullOrWhiteSpace(model.Nome)) usuario.Nome = model.Nome;
                usuario.Telefone = model.Telefone;
                usuario.EnderecoCompleto = model.EnderecoCompleto;
                usuario.Site = model.Site;
                usuario.Descricao = model.Descricao;
                usuario.ItensAceitos.Clear();
                if (model.ItensAceitos?.Count > 0)
                    usuario.ItensAceitos.AddRange(model.ItensAceitos);

                await _context.SaveChangesAsync();

                TempData["Mensagem"] = "Perfil atualizado com sucesso!";
            }
            catch
            {
                TempData["Mensagem"] = "Erro ao atualizar o perfil. Tente novamente.";
            }

            return RedirectToAction("Editar");
        }

        private async Task CarregarViewBag(int instituicaoId)
        {
            var campanhas = await _context.Campanhas
                .Where(c => c.InstituicaoId == instituicaoId.ToString())
                .ToListAsync();

            var hoje = DateTime.Today;

            ViewBag.CampanhasAtivas = campanhas
                .Where(c => c.DataFim.HasValue && c.DataFim.Value.Date >= hoje)
                .ToList();

            ViewBag.CampanhasCriadas = campanhas
                .Where(c => !c.DataFim.HasValue || c.DataFim.Value.Date < hoje)
                .ToList();

            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.InstituicaoId == instituicaoId)
                .ToListAsync();

            ViewBag.MediaAvaliacao = avaliacoes.Any()
                ? Math.Round(avaliacoes.Average(a => (double)a.Nota), 1)
                : 0.0;
        }
    }
}
