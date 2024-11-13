using System.ComponentModel.DataAnnotations;

namespace AP2_MVC_DOTNET.Models;

public class Allergie
{
    [Key]
    public int AllergieId { get; set; }
    public required string Libelle_al { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}