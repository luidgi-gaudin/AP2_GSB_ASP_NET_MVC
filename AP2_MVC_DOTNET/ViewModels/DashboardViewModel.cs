namespace AP2_MVC_DOTNET.Models
{
    public class DashboardViewModel
    {
        public int TotalPatients { get; set; }
        public int TotalOrdonnances { get; set; }
        public Dictionary<string, int> MedicamentProportion { get; set; } = new();
        public Dictionary<string, int> AllergieProportion { get; set; } = new();
        public Dictionary<string, int> AntecedentProportion { get; set; } = new();
    }
}