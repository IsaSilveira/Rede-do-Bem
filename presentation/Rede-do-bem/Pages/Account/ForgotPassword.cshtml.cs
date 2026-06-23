using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Rede_do_bem.Data;
using Rede_do_bem.Services;
using System.ComponentModel.DataAnnotations;

namespace Rede_do_bem.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;

        public ForgotPasswordModel(ApplicationDbContext context, IEmailSender emailSender, IWebHostEnvironment env)
        {
            _context = context;
            _emailSender = emailSender;
            _env = env;
        }

        [BindProperty]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        public bool EmailSent { get; set; }

        public string? ResetLink { get; set; }
        public string? SmtpWarning { get; set; }
        public bool IsDevMode => _env.IsDevelopment();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Usuarios.FirstOrDefault(u => u.Email == Email);
                    if (user != null)
                    {
                        var resetLink = Url.Page(
                            "/Account/ResetPassword",
                            pageHandler: null,
                            values: new { email = Email },
                            protocol: Request.Scheme);

                        ResetLink = resetLink;

                        string emailBody = $@"
                            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 40px; border-radius: 20px; background-color: #2a4b7c; color: #ffffff; text-align: center;'>
                                <div style='margin-bottom: 30px;'>
                                    <h1 style='color: #e9f0b5; font-size: 28px; letter-spacing: 2px; margin: 0;'>REDE DO BEM</h1>
                                </div>
                                <h2 style='color: #e9f0b5; margin-bottom: 20px;'>Recuperação de Senha</h2>
                                <p style='font-size: 16px; line-height: 1.6; color: #ffffff; margin-bottom: 30px;'>
                                    Olá!<br><br>
                                    Vimos que você solicitou a recuperação de sua senha. 
                                    Clique no botão abaixo para criar uma nova senha e continuar transformando vidas.
                                </p>
                                <div style='margin-top: 40px; margin-bottom: 40px;'>
                                    <a href='{resetLink}' style='background-color: #e9f0b5; color: #2a4b7c; padding: 15px 35px; border-radius: 50px; text-decoration: none; font-weight: bold; font-size: 18px; display: inline-block;'>Redefinir Senha</a>
                                </div>
                                <p style='font-size: 14px; opacity: 0.7; color: #ffffff;'>
                                    Se você não solicitou essa alteração, basta ignorar este e-mail.
                                </p>
                                <hr style='border: 0; border-top: 1px solid rgba(233, 240, 181, 0.3); margin: 30px 0;'>
                                <p style='font-size: 12px; opacity: 0.5; color: #ffffff;'>
                                    &copy; 2026 Rede do Bem. Unindo mãos que doam.
                                </p>
                            </div>";

                        try
                        {
                            await _emailSender.SendEmailAsync(
                                Email,
                                "Rede do Bem - Recuperação de Senha",
                                emailBody);
                        }
                        catch (Exception) when (_env.IsDevelopment())
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEVELOPMENT ONLY] SMTP failed. Reset link: {resetLink}");
                            SmtpWarning = "O envio de e-mail falhou (servidor SMTP local não configurado). Como você está em modo de Desenvolvimento, você pode redefinir a senha usando o botão de teste abaixo.";
                        }
                    }

                    EmailSent = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao enviar e-mail: " + ex.Message);
                    return Page();
                }

                return Page();
            }

            return Page();
        }
    }
}
