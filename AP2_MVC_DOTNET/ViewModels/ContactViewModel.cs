using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Votre nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom doit contenir au maximum 50 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Votre email est requis.")]
        [EmailAddress(ErrorMessage = "Adresse email non valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Un sujet est requis.")]
        [StringLength(100, ErrorMessage = "Le sujet doit contenir au maximum 100 caractères.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Un message est requis.")]
        [StringLength(1000, ErrorMessage = "Le message doit contenir au maximum 1000 caractères.")]
        public string Message { get; set; }
    }
}