using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AP2_MVC_DOTNET.Models;

public class Medecin : IdentityUser
{
    public required string Nom_m { get; set; }
    public required string Prenom_m { get; set; }
    public DateTime Date_naissance_m { get; set; }

    public List<Ordonnance> Ordonnances { get; set; } = new();
}
