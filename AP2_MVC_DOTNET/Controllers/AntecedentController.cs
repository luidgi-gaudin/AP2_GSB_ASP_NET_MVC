using AP2_MVC_DOTNET.data;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.Controllers;

public class AntecedentController : Controller
{

    private readonly ApplicationDbContext _dbContext;

    public AntecedentController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var antecedents = _dbContext.Antecedents
            .Include(a => a.Patients)
            .Select(a => new AntecedentViewModel
            {
                Antecedent = a,
                Patients = a.Patients.ToList()
            });

        return View(antecedents);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Antecedent antecedent)
    {
        if (!ModelState.IsValid)
        {
            View(antecedent);
        }
        _dbContext.Antecedents.Add(antecedent);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var antecedent = _dbContext.Antecedents.Find(id);
        if (antecedent == null)
        {
            return NotFound();
        }
        return View(antecedent);
    }

    [HttpPost]
    public IActionResult Edit(Antecedent antecedent)
    {
        if (!ModelState.IsValid)
        {
            return View(antecedent);
        }
        _dbContext.Antecedents.Update(antecedent);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var antecedent = _dbContext.Antecedents.Find(id);
        if (antecedent == null)
        {
            return NotFound();
        }
        return View(antecedent);
    }

    [HttpPost]
    public IActionResult Delete(Antecedent antecedent)
    {
        _dbContext.Antecedents.Remove(antecedent);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}