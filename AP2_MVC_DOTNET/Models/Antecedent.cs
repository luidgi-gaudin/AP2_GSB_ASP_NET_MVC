using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models;

public class Antecedent
{
    [Key]
    public int AntecedentId { get; set; }
    public required string Libelle_a { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}