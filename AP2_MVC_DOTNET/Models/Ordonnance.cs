using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace AP2_MVC_DOTNET.Models;

public class Ordonnance
{
    [Key]
    public int OrdonnanceId { get; set; }
    public required string Posologie { get; set; }
    public required DateTime DateCréation { get; set; }
    public required string Duree_traitement { get; set; }
    public required string Instructions_specifique { get; set; }

    public required string MedecinId { get; set; }
    public Medecin Medecin { get; set; }

    public required int PatientId { get; set; }
    public Patient Patient { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
}