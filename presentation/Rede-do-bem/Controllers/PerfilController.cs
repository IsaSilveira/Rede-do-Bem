using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Adicionado para buscas no banco
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims; // Adicionado para identificar quem está logado

namespace Rede_do_bem.Controllers
{
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PerfilController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        // ---> NOVO MÉTODO ROTEADOR <---
        public async Task<IActionResult> Redirecionar()
        {
            // Pega o email do usuário atualmente logado
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Home"); // Se não estiver logado, manda para a Home

            // Busca os dados deste usuário na tabela principal de Usuarios
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            // Verifica o Tipo usando o membro do enum TipoUsuario
            if (usuario.Tipo == TipoUsuario.Instituicao)
            {
                // Manda para a tela da Instituição
                return RedirectToAction("Editar", "PerfilInstituicao");
            }
            else
            {
                // Manda para a tela do Doador (que é o Editar logo abaixo neste mesmo arquivo)
                return RedirectToAction("Editar", "Perfil");
            }
        }

        // ---> SEUS MÉTODOS ORIGINAIS CONTINUAM INTACTOS ABAIXO <---
        
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Editar()
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email)) return Redirect("/Account/Login");

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null) return Redirect("/Account/Login");

            var minhasCampanhas = _context.Campanhas
                .Where(c => c.InstituicaoId == usuario.Id.ToString())
                .ToList();

            var hoje = DateTime.Today;

            ViewBag.CampanhasAtivas = minhasCampanhas
                .Where(c => c.DataFim.HasValue && c.DataFim.Value.Date >= hoje)
                .ToList();

            ViewBag.CampanhasCriadas = minhasCampanhas
                .Where(c => !c.DataFim.HasValue || c.DataFim.Value.Date < hoje)
                .ToList();

            var idsCampanhas = minhasCampanhas.Select(c => c.IdCampanha).ToList();

            ViewBag.ContagemDoacoes = _context.Doacoes
                .Where(d => idsCampanhas.Contains(d.CampanhaId) && d.Status == StatusDoacao.Validada)
                .GroupBy(d => d.CampanhaId)
                .ToDictionary(g => g.Key, g => g.Count());

            return View(usuario);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Editar(Usuario model, IFormFile? fotoArquivo)
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email)) return Redirect("/Account/Login");

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
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
                    {
                        fotoArquivo.CopyTo(stream);
                    }

                    usuario.Foto = "/imagens/" + nomeArquivo;
                }

                if (!string.IsNullOrWhiteSpace(model.Nome))
                {
                    usuario.Nome = model.Nome;
                }
                
                usuario.Telefone = model.Telefone;
                usuario.EnderecoCompleto = model.EnderecoCompleto;
                usuario.DataNascimento = model.DataNascimento;

                if (usuario.Tipo == TipoUsuario.Instituicao)
                {
                    usuario.Site = model.Site;
                    usuario.Descricao = model.Descricao;
                    usuario.ItensAceitos = model.ItensAceitos ?? new List<string>();
                }

                _context.Usuarios.Update(usuario);
                _context.SaveChanges();

                TempData["Mensagem"] = "Perfil atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                // In a production scenario, log the exception.
                TempData["Mensagem"] = "Erro ao atualizar o perfil. Tente novamente.";
            }

            return RedirectToAction("Editar");
        }
    }
}