using AP2_MVC_DOTNET.Models;

namespace AP2_MVC_DOTNET.ViewModels;

public class AllergieViewModel
{
    public Allergie Allergie { get; set; }
    public List<Patient> Patients { get; set; } = new();
    public List<Medicament> Medicaments { get; set; } = new();
}