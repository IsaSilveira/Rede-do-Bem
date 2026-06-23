using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rede_do_bem.Data;
using Rede_do_bem.Models;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Rede_do_bem.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "O campo Nome é obrigatório.")]
            [Display(Name = "Nome")]
            public string Nome { get; set; } = string.Empty;

            [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
            [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço de e-mail válido.")]
            [Display(Name = "E-mail")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "O campo Senha é obrigatório.")]
            [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar senha")]
            [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            [Required(ErrorMessage = "O campo Tipo de Perfil é obrigatório.")]
            [Display(Name = "Tipo de Perfil")]
            public TipoUsuario Tipo { get; set; }

            // Campos Doador
            [Display(Name = "CPF")]
            [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido (use 000.000.000-00)")]
            public string? CPF { get; set; }

            // Campos Instituição
            [Display(Name = "CNPJ")]
            [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido (use 00.000.000/0000-00)")]
            public string? CNPJ { get; set; }

            [Display(Name = "Razão Social")]
            public string? RazaoSocial { get; set; }

            [Display(Name = "Descrição")]
            public string? Descricao { get; set; }

            [Display(Name = "Endereço completo")]
            public string? EnderecoCompleto { get; set; }

            [Display(Name = "Telefone de contato")]
            [Phone(ErrorMessage = "Telefone inválido.")]
            public string? Telefone { get; set; }

            [Display(Name = "Link de site")]
            [Url(ErrorMessage = "Site inválido.")]
            public string? Site { get; set; }

            [Display(Name = "Itens que aceita")]
            public List<string> ItensAceitos { get; set; } = new();
        }

        public void OnGet(TipoUsuario? tipo)
        {
            if (tipo.HasValue)
            {
                Input.Tipo = tipo.Value;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validação de segurança no servidor para os campos específicos de cada tipo de usuário
            if (Input.Tipo == TipoUsuario.Doador && string.IsNullOrWhiteSpace(Input.CPF))
            {
                ModelState.AddModelError("Input.CPF", "O campo CPF é obrigatório para Doadores.");
            }

            if (Input.Tipo == TipoUsuario.Instituicao)
            {
                if (string.IsNullOrWhiteSpace(Input.CNPJ))
                {
                    ModelState.AddModelError("Input.CNPJ", "O campo CNPJ é obrigatório para Instituições.");
                }
                if (string.IsNullOrWhiteSpace(Input.RazaoSocial))
                {
                    ModelState.AddModelError("Input.RazaoSocial", "O campo Razão Social é obrigatório para Instituições.");
                }
            }

            if (ModelState.IsValid)
            {
                var userExists = _context.Usuarios.Any(u => u.Email == Input.Email);
                if (userExists)
                {
                    ModelState.AddModelError(string.Empty, "Este e-mail já está cadastrado.");
                    return Page();
                }

                var user = new Usuario
                {
                    Nome = Input.Nome,
                    Email = Input.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(Input.Password),
                    Tipo = Input.Tipo,
                    CPF = Input.Tipo == TipoUsuario.Doador ? Input.CPF : null,
                    CNPJ = Input.Tipo == TipoUsuario.Instituicao ? Input.CNPJ : null,
                    RazaoSocial = Input.Tipo == TipoUsuario.Instituicao ? Input.RazaoSocial : null,
                    Descricao = Input.Tipo == TipoUsuario.Instituicao ? Input.Descricao : null,
                    EnderecoCompleto = Input.Tipo == TipoUsuario.Instituicao ? Input.EnderecoCompleto : null,
                    Telefone = Input.Tipo == TipoUsuario.Instituicao ? Input.Telefone : null,
                    Site = Input.Tipo == TipoUsuario.Instituicao ? Input.Site : null,
                    ItensAceitos = Input.Tipo == TipoUsuario.Instituicao ? Input.ItensAceitos : new List<string>()
                };

                try
                {
                    _context.Usuarios.Add(user);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao criar o cadastro. Tente novamente.");
                    return Page();
                }

                // Fazer login automático após o registro
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserType", user.Tipo.ToString()),
                    new Claim(ClaimTypes.Role, user.Tipo.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
