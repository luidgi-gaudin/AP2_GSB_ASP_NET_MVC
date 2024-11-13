using System.ComponentModel.DataAnnotations;
using AP2_MVC_DOTNET.Models;

namespace AP2_MVC_DOTNET.ViewModels;

public class OrdonnanceViewModel
{
   public int? OrdonnanceId { get; set; }

   [Required(ErrorMessage = "La posologie est obligatoire")]
   public string  Posologie { get; set; }

   [Required(ErrorMessage = "La durée de traitement est obligatoire")]
   public string Duree_traitement { get; set; }

   [Required(ErrorMessage = "Les instructions spécifiques sont obligatoires")]
   public  string Instructions_specifique { get; set; }

   [Required(ErrorMessage = "Le patient est obligatoire")]
   public  int PatientId { get; set; }
   public Patient? Patient { get; set; }

   public Medecin? Medecin { get; set; }
    public List<Patient>? Patients { get; set; } 
    public List<Medicament> Medicaments { get; set; } = new();
    public List<int> SelectedMedicamentsId { get; set; } = new List<int>();
}