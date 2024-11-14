using System.Diagnostics;
using AP2_MVC_DOTNET.data;
using Microsoft.AspNetCore.Mvc;
using AP2_MVC_DOTNET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }

    public IActionResult Index()
    {
        var model = new DashboardViewModel
        {
            // Calcul du nombre total de patients
            TotalPatients = _context.Patients.Count(),

            // Calcul du nombre total d'ordonnances
            TotalOrdonnances = _context.Ordonnances.Count(),

            // Proportion de chaque médicament utilisé dans les ordonnances
            MedicamentProportion = _context.Ordonnances
                .SelectMany(o => o.Medicaments)
                .GroupBy(m => m.Libelle_med)
                .ToDictionary(g => g.Key, g => g.Count()),

            // Nombre de patients ayant chaque type d'allergie
            AllergieProportion = _context.Patients
                .SelectMany(p => p.Allergies)
                .GroupBy(a => a.Libelle_al)
                .ToDictionary(g => g.Key, g => g.Count()),

            // Nombre de patients ayant chaque type d'antécédent
            AntecedentProportion = _context.Patients
                .SelectMany(p => p.Antecedents)
                .GroupBy(a => a.Libelle_a)
                .ToDictionary(g => g.Key, g => g.Count())
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}