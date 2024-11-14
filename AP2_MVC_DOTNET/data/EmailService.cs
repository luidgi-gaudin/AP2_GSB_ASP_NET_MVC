using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace AP2_MVC_DOTNET.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_configuration["EmailSettings:SenderName"], _configuration["EmailSettings:SenderEmail"]));
            email.To.Add(new MailboxAddress("", toEmail));
            email.Subject = subject;

            email.Body = new TextPart("plain")
            {
                Text = message
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    // Activer le logging dans un fichier pour voir ce qui se passe
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.ConnectAsync(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:Port"]), MailKit.Security.SecureSocketOptions.SslOnConnect).Wait();
                    client.AuthenticateAsync(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]).Wait();

                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }

                return "Email envoyé avec succès.";
            }
            catch (MailKit.ServiceNotConnectedException ex)
            {
                return $"Erreur de connexion au serveur SMTP : {ex.Message}";
            }
            catch (MailKit.ServiceNotAuthenticatedException ex)
            {
                return $"Erreur d'authentification SMTP : {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Erreur inconnue lors de l'envoi de l'email : {ex.Message}";
            }
        }
    }
}
