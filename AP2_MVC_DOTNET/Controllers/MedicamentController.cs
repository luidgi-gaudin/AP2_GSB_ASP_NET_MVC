using AP2_MVC_DOTNET.data;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.Controllers;
[Authorize]
public class MedicamentController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public MedicamentController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var medicaments = _dbContext.Medicaments
            .Include(m => m.Allergies)
            .Select(m => new MedicamentViewModel
            {
                Medicament = m,
                Allergies = m.Allergies.ToList()
            });
        return View(medicaments);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var viewModel = new MedicamentViewModel
        {
            Allergies = _dbContext.Allergies.ToList()
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Add(MedicamentViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Allergies = _dbContext.Allergies.ToList();
            return View(viewModel);
        }

        var medicament = viewModel.Medicament;
        medicament.Allergies = _dbContext.Allergies
            .Where(a => viewModel.SelectedAllergies.Contains(a.AllergieId))
            .ToList();

        _dbContext.Medicaments.Add(medicament);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var medicament = _dbContext.Medicaments
            .Include(m => m.Allergies)
            .FirstOrDefault(m => m.MedicamentId == id);

        if (medicament == null)
        {
            return NotFound();
        }

        var viewModel = new MedicamentViewModel
        {
            Medicament = medicament,
            Allergies = _dbContext.Allergies.ToList(),
            SelectedAllergies = medicament.Allergies.Select(a => a.AllergieId).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(MedicamentViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var medicament = _dbContext.Medicaments
                .Include(m => m.Allergies)
                .FirstOrDefault(m => m.MedicamentId == viewModel.Medicament.MedicamentId);

            if (medicament == null)
            {
                return NotFound();
            }

            medicament.Libelle_med = viewModel.Medicament.Libelle_med;
            medicament.Contr_indication = viewModel.Medicament.Contr_indication;
            medicament.Stock = viewModel.Medicament.Stock;

            medicament.Allergies.Clear();
            medicament.Allergies = _dbContext.Allergies
                .Where(a => viewModel.SelectedAllergies.Contains(a.AllergieId))
                .ToList();

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        viewModel.Allergies = _dbContext.Allergies.ToList();
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var medicament = _dbContext.Medicaments.Find(id);
        return View(medicament);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var medicament = _dbContext.Medicaments.Find(id);
        if (medicament == null)
        {
            return NotFound();
        }

        _dbContext.Medicaments.Remove(medicament);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}