namespace AP2_MVC_DOTNET.Models;

public class MedicamentViewModel
{
    public Medicament Medicament { get; set; }
    public List<Allergie> Allergies { get; set; } = new();
    public List<int> SelectedAllergies { get; set; } = new();
}