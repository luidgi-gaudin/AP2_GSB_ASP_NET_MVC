using AP2_MVC_DOTNET.Models;

namespace AP2_MVC_DOTNET.ViewModels;

public class AntecedentViewModel
{
    public Antecedent Antecedent { get; set; }
    public List<Patient> Patients { get; set; } = new();
}