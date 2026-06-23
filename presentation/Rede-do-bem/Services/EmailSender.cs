using System.Net;
using System.Net.Mail;

namespace Rede_do_bem.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            var smtpEmail = emailSettings["Email"];
            var smtpPassword = emailSettings["Password"]; 
            var host = emailSettings["Host"] ?? "smtp.gmail.com";
            var portString = emailSettings["Port"] ?? "587";

            if (string.IsNullOrEmpty(smtpEmail) || string.IsNullOrEmpty(smtpPassword))
            {
                throw new InvalidOperationException("Configuração de e-mail (Email ou Password) não encontrada. Verifique os User Secrets.");
            }

            try
            {
                var port = int.Parse(portString);

                using (var client = new SmtpClient(host, port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpEmail, smtpPassword);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Timeout = 20000; // 20 segundos

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpEmail, "Rede do Bem Support"),
                        Subject = subject,
                        Body = htmlMessage,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(email);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new InvalidOperationException($"Erro SMTP ({host}:{portString}): {errorMsg}", ex);
            }
        }
    }
}
