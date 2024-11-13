using AP2_MVC_DOTNET.data;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.Controllers;
[Authorize]
public class AllergieController : Controller
{
  private readonly ApplicationDbContext _dbContext;

  public AllergieController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public IActionResult Index()
  {
    var allergies = _dbContext.Allergies
      .Include(a => a.Patients)
      .Include(a => a.Medicaments)
      .Select(a=> new AllergieViewModel
      {
        Allergie = a,
        Patients = a.Patients.ToList(),
        Medicaments = a.Medicaments.ToList()
      });
    return View(allergies);
  }
  
  [HttpGet]
  public IActionResult Add()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Add(Allergie allergie)
  {
    if(!ModelState.IsValid)
    {
      return View(allergie);
    }
    _dbContext.Allergies.Add(allergie);
    _dbContext.SaveChanges();
    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var allergie = _dbContext.Allergies
      .Include(a=>a.Patients)
      .Include(a=>a.Medicaments)
      .FirstOrDefault(a=>a.AllergieId == id);

    if (allergie == null)
    {
      return NotFound();
    }

    var viewModel = new AllergieViewModel()
    {
      Allergie = allergie,
      Patients = allergie.Patients.ToList(),
      Medicaments = allergie.Medicaments.ToList()
    };

    return View(viewModel);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(AllergieViewModel viewModel)
  {
    if (ModelState.IsValid)
    {
      var allergie = _dbContext.Allergies.Find(viewModel.Allergie.AllergieId);
      if (allergie == null)
      {
        return NotFound();
      }

      allergie.Libelle_al = viewModel.Allergie.Libelle_al;
      _dbContext.SaveChanges();

      return RedirectToAction("Index");
    }

    return View(viewModel);
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var allergie = _dbContext.Allergies.Find(id);
    return View(allergie);
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeleteConfirmed(int id)
  {
    var allergie = _dbContext.Allergies.Find(id);
    if (allergie == null)
    {
      return NotFound();
    }

    _dbContext.Allergies.Remove(allergie);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}