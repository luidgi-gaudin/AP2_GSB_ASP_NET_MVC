using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.ViewModels;

public class RegisterViewModel
{
    [Required (ErrorMessage = "veuillez rempir le Nom D'utilisateur")]
    public string UserName { get; set; }

    [Required (ErrorMessage = "Veuillez remplir le mail")]
    public string Email { get; set; }

    [Required (ErrorMessage = "Veuillez remplir le mot de passe")]
    public string PasswordHash { get; set; }

    [Required (ErrorMessage = "Veuillez remplir le nom")]
    public string Nom_m { get; set; }

    [Required(ErrorMessage = "Veuillez remplir le prenom")]
    public string Prenom_m { get; set; }

    [Required(ErrorMessage = "Veuillez remplir la date de naissance")]
    public DateTime Date_naissance_m { get; set; }
}