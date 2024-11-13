using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models;

public class Medicament
{
    [Key]
    public int MedicamentId { get; set; }
    public required string Libelle_med { get; set; }
    public required string Contr_indication { get; set; }
    public int Stock { get; set; }

    public List<Allergie> Allergies { get; set; } = new();
    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
