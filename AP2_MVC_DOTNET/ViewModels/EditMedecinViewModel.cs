// Dans AP2_MVC_DOTNET/ViewModels/EditMedecinViewModel.cs

using System;
using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.ViewModels
{
    public class EditMedecinViewModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom_m { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom_m { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime Date_naissance_m { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adresse email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }
    }
}