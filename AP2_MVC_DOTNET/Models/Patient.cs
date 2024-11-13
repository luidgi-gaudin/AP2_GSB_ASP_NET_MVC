using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models;

public class Patient
{
    [Key]
    public int PatientId { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(50)]
    public string Nom_p { get; set; } = null!;

    [Required(ErrorMessage = "Le prénom est obligatoire")]
    [StringLength(50)]
    public string Prenom_p { get; set; } = null!;

    [Required(ErrorMessage = "Le sexe est obligatoire")]
    public string Sexe_p { get; set; } = null!;

    [Required(ErrorMessage = "Le numéro de sécurité sociale est obligatoire")]
    [StringLength(15, ErrorMessage = "Le numéro de sécurité sociale doit contenir au maximum 15 caractères")]
    public string Num_secu { get; set; } = null!;

    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Allergie> Allergies { get; set; } = new();
    public ICollection<Ordonnance>? Ordonnances { get; set; }
}

