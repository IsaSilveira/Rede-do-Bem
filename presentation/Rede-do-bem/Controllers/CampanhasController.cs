using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.Security.Claims;

namespace Rede_do_bem.Controllers
{
    public class CampanhasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampanhasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Campanhas.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Campanha campanha)
        {
            ModelState.Remove("Instituicao");
            ModelState.Remove("InstituicaoId");

            if (ModelState.IsValid)
            {
                campanha.InstituicaoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Campanhas.Add(campanha);
                await _context.SaveChangesAsync();

                var usuarios = await _context.Usuarios.ToListAsync();
                var notificacoes = usuarios.Select(u => new Notificacao
                {
                    UsuarioEmail = u.Email,
                    Mensagem = $"Nova campanha disponível: {campanha.NomeDaCampanha}",
                    DataCriacao = DateTime.Now,
                    Link = Url.Action("Details", "Campanhas", new { id = campanha.IdCampanha })
                }).ToList();

                if (notificacoes.Any())
                {
                    _context.Notificacoes.AddRange(notificacoes);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("/Index");
            }

            return View(campanha);
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.Campanhas.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (dados.InstituicaoId != userId)
            {
                return Forbid();
            }

            return View(dados);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Edit(int id, Campanha campanha)
        {
            if (id != campanha.IdCampanha)
            {
                return NotFound();
            }

            var existente = await _context.Campanhas.FirstOrDefaultAsync(c => c.IdCampanha == id);
            if (existente == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (existente.InstituicaoId != userId)
            {
                return Forbid();
            }

            ModelState.Remove("Instituicao");
            ModelState.Remove("InstituicaoId");

            if (ModelState.IsValid)
            {
                existente.NomeDaCampanha = campanha.NomeDaCampanha;
                existente.NomeResponsavel = campanha.NomeResponsavel;
                existente.TelefoneContato = campanha.TelefoneContato;
                existente.EnderecoRecebimento = campanha.EnderecoRecebimento;
                existente.TipoDoacao = campanha.TipoDoacao;
                existente.DataInicio = campanha.DataInicio;
                existente.DataFim = campanha.DataFim;
                existente.HorarioRecebimento = campanha.HorarioRecebimento;
                existente.DescricaoAcao = campanha.DescricaoAcao;

                await _context.SaveChangesAsync();

                return RedirectToAction("Redirecionar", "Perfil");
            }

            return View(campanha);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (campanha.InstituicaoId != userId)
            {
                return Forbid();
            }

            _context.Campanhas.Remove(campanha);
            await _context.SaveChangesAsync();

            return RedirectToAction("Redirecionar", "Perfil");
        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> ToggleFavorita(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            campanha.CampanhaFavoritada = !campanha.CampanhaFavoritada;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }

        // Action Favoritas
        public IActionResult Favoritas()
        {
            var favoritas = _context.Campanhas
                .Where(c => c.CampanhaFavoritada)
                .ToList();

            return View(favoritas);
        }

        // Action Detalhes
        public async Task<IActionResult> Details (int? id )
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);

            if (dados == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isOwner = !string.IsNullOrEmpty(userId) && userId == dados.InstituicaoId;
            ViewBag.IsOwner = isOwner;

            ViewBag.TotalValidadas = await _context.Doacoes
                .CountAsync(d => d.CampanhaId == id && d.Status == StatusDoacao.Validada);

            if (isOwner)
            {
                ViewBag.DoacoesPendentes = await _context.Doacoes
        .Where(d => d.CampanhaId == id && d.Status == StatusDoacao.Pendente)
        .OrderBy(d => d.DataSolicitacao)
        .ToListAsync();

                ViewBag.Denuncias = await _context.Denuncias
                    .Where(d => d.CampanhaId == id)
                    .OrderByDescending(d => d.DataDenuncia)
                    .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                ViewBag.MinhaDoacao = await _context.Doacoes
                    .FirstOrDefaultAsync(d => d.CampanhaId == id && d.DoadorId == userId);

                var doacaoValidadaAgora = await _context.Doacoes
                    .FirstOrDefaultAsync(d => d.CampanhaId == id && d.DoadorId == userId
                        && d.Status == StatusDoacao.Validada && !d.NotificadoValidacao);

                if (doacaoValidadaAgora != null)
                {
                    ViewBag.DoacaoValidadaAgora = doacaoValidadaAgora;
                    doacaoValidadaAgora.NotificadoValidacao = true;
                    await _context.SaveChangesAsync();
                }
            }

            ViewBag.NovoCodigo = TempData["NovaDoacaoCodigo"];

            return View(dados);
        }

        // RF13 - Doador solicita validação de doação
        [HttpPost]
        public async Task<IActionResult> SolicitarDoacao(int id)
        {
            if (!(User.Identity?.IsAuthenticated ?? false))
                return Redirect("/Account/Login");

            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (campanha.InstituicaoId == userId)
            {
                TempData["Erro"] = "Você não pode registrar uma doação para a sua própria campanha.";
                return RedirectToAction("Details", new { id });
            }

            var jaSolicitou = await _context.Doacoes
                .AnyAsync(d => d.CampanhaId == id && d.DoadorId == userId);

            if (!jaSolicitou)
            {
                var codigosUsados = await _context.Doacoes
                    .Where(d => d.CampanhaId == id && d.Status == StatusDoacao.Pendente)
                    .Select(d => d.Codigo)
                    .ToListAsync();

                string codigo;
                do
                {
                    codigo = Random.Shared.Next(0, 100).ToString("D2");
                } while (codigosUsados.Contains(codigo));

                var doacao = new Doacao
                {
                    CampanhaId = id,
                    DoadorId = userId ?? string.Empty,
                    DoadorNome = User.FindFirstValue(ClaimTypes.Name) ?? string.Empty,
                    Codigo = codigo,
                    Status = StatusDoacao.Pendente,
                    DataSolicitacao = DateTime.Now
                };

                _context.Doacoes.Add(doacao);
                await _context.SaveChangesAsync();

                // Notifica o recebedor (instituição) que há uma doação para validar
                if (!string.IsNullOrEmpty(campanha.InstituicaoId) &&
                    int.TryParse(campanha.InstituicaoId, out var instituicaoId))
                {
                    var instituicao = await _context.Usuarios.FindAsync(instituicaoId);
                    if (instituicao != null)
                    {
                        _context.Notificacoes.Add(new Notificacao
                        {
                            UsuarioEmail = instituicao.Email,
                            Mensagem = $"{doacao.DoadorNome} quer doar para a campanha \"{campanha.NomeDaCampanha}\". Acesse a campanha para validar a doação.",
                            DataCriacao = DateTime.Now,
                            Link = Url.Action("Details", "Campanhas", new { id = campanha.IdCampanha })
                        });
                        await _context.SaveChangesAsync();
                    }
                }

                TempData["NovaDoacaoCodigo"] = codigo;
            }

            return RedirectToAction("Details", new { id });
        }

        // RF13 - Recebedor valida o código de doação informado pelo doador
        [HttpPost]
        public async Task<IActionResult> ValidarDoacao(int doacaoId, int campanhaId)
        {
            var campanha = await _context.Campanhas.FindAsync(campanhaId);
            if (campanha == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (campanha.InstituicaoId != userId)
                return Forbid();

            var doacao = await _context.Doacoes
                .FirstOrDefaultAsync(d => d.Id == doacaoId && d.CampanhaId == campanhaId);

            if (doacao != null && doacao.Status == StatusDoacao.Pendente)
            {
                doacao.Status = StatusDoacao.Validada;
                doacao.DataValidacao = DateTime.Now;
                doacao.NotificadoValidacao = false;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = campanhaId });
        }

        [HttpPost]
        public async Task<IActionResult> Denunciar(int campanhaId, string motivo)
        {
            if (!(User.Identity?.IsAuthenticated ?? false))
                return Redirect("/Account/Login");

            var campanha = await _context.Campanhas.FindAsync(campanhaId);

            if (campanha == null)
                return NotFound();

            var denuncia = new Denuncia
            {
                CampanhaId = campanhaId,
                UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                Motivo = motivo,
                DataDenuncia = DateTime.Now,
                Visualizada = false
            };

            _context.Denuncias.Add(denuncia);

            // Criar notificação para o dono da campanha
            if (!string.IsNullOrEmpty(campanha.InstituicaoId))
            {
                var instituicao = await _context.Usuarios
                    .FirstOrDefaultAsync(u =>
                        u.Id.ToString() == campanha.InstituicaoId);

                if (instituicao != null)
                {
                    _context.Notificacoes.Add(new Notificacao
                    {
                        UsuarioEmail = instituicao.Email,
                        Mensagem = $"Sua campanha \"{campanha.NomeDaCampanha}\" recebeu uma denúncia.",
                        DataCriacao = DateTime.Now,
                        Link = Url.Action("Details", "Campanhas", new { id = campanhaId })
                    });
                }
            }

            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Denúncia enviada com sucesso.";

            return RedirectToAction("Details", new { id = campanhaId });
        }
    }
}