using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rede_do_bem.Data;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace Rede_do_bem.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ResetPasswordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string AccountName { get; set; } = string.Empty;

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "A nova senha é obrigatória.")]
            [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nova Senha")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar nova senha")]
            [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public IActionResult OnGet(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("./Login");
            }

            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return RedirectToPage("./Login");
            }

            AccountName = user.Nome;
            Input.Email = email;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == Input.Email);
            if (user == null)
            {
                return RedirectToPage("./Login");
            }

            AccountName = user.Nome;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            user.Senha = BCrypt.Net.BCrypt.HashPassword(Input.Password);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Senha alterada com sucesso!";
            return RedirectToPage("./Login");
        }
    }
}
