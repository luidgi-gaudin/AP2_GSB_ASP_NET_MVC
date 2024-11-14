using Microsoft.AspNetCore.Mvc;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.Services;
using System.Threading.Tasks;

namespace AP2_MVC_DOTNET.Controllers
{
    public class ContactController : Controller
    {
        private readonly EmailService _emailService;

        public ContactController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = $"Nom : {model.Name}\nEmail : {model.Email}\n\nMessage :\n{model.Message}";
                
                // Appel de SendEmailAsync et stockage du résultat
                string result = await _emailService.SendEmailAsync("contact@luidgi-gaudin.fr", model.Subject, message);

                if (result == "Email envoyé avec succès.")
                {
                    TempData["Message"] = "Merci pour votre message. Nous vous répondrons bientôt !";
                }
                else
                {
                    TempData["Message"] = $"Erreur lors de l'envoi de votre message : {result}";
                }

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}