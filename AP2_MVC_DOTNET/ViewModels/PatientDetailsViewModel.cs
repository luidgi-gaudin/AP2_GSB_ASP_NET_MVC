using AP2_MVC_DOTNET.Models;

namespace AP2_MVC_DOTNET.ViewModels;

public class PatientDetailsViewModel
{
    public Patient Patient { get; set; }

    public Ordonnance? Ordonnances { get; set; }
    public List<Allergie> Allergies { get; set; } = new();
    public List<Antecedent> Antecedents { get; set; } = new();
}