using AP2_MVC_DOTNET.data;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AP2_MVC_DOTNET.Controllers;
[Authorize]
public class PatientController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public PatientController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View(_dbContext.Patients);
    }

    public IActionResult Details(int id)
    {
        var patient = _dbContext.Patients
            .Include(p => p.Antecedents)
            .Include(p => p.Allergies)
            .Include(p => p.Ordonnances)
            .FirstOrDefault(p => p.PatientId == id);
        if (patient == null)
        {
            return NotFound();
        }

        var viewModel = new PatientDetailsViewModel
        {
          Patient = patient,
          Allergies = patient.Allergies,
          Antecedents = patient.Antecedents
        };
        return View(viewModel);
    }

    public IActionResult Add()
    {
        var viewModel = new PatientDetailsViewModel
        {
          Allergies = _dbContext.Allergies.ToList(),
          Antecedents = _dbContext.Antecedents.ToList()
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Add(PatientDetailsViewModel viewModel, int[] selectedAntecedents, int[] selectedAllergies)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Allergies = _dbContext.Allergies.ToList();
            viewModel.Antecedents = _dbContext.Antecedents.ToList();
            return View(viewModel);
        }

        var patient = viewModel.Patient;

        patient.Allergies = _dbContext.Allergies
            .AsEnumerable()  
            .Where(a => selectedAllergies.Contains(a.AllergieId))
            .ToList();

        patient.Antecedents = _dbContext.Antecedents
            .AsEnumerable()
            .Where(a => selectedAntecedents.Contains(a.AntecedentId))
            .ToList();

        _dbContext.Patients.Add(patient);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var patient = _dbContext.Patients
            .Include(p => p.Antecedents)
            .Include(p => p.Allergies)
            .FirstOrDefault(p => p.PatientId == id);

        if (patient != null)
        {
            var viewModel = new PatientDetailsViewModel
            {
                Patient = patient,
                Allergies = _dbContext.Allergies.ToList(),
                Antecedents = _dbContext.Antecedents.ToList()
            };
            return View(viewModel);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(PatientDetailsViewModel viewModel, int[] selectedAntecedents, int[] selectedAllergies)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Allergies = _dbContext.Allergies.ToList();
            viewModel.Antecedents = _dbContext.Antecedents.ToList();
            return View(viewModel);
        }

        var patient = _dbContext.Patients
            .Include(p => p.Antecedents)
            .Include(p => p.Allergies)
            .FirstOrDefault(p => p.PatientId == viewModel.Patient.PatientId);

        if (patient != null)
        {
            patient.Prenom_p = viewModel.Patient.Prenom_p;
            patient.Nom_p = viewModel.Patient.Nom_p;
            patient.Num_secu = viewModel.Patient.Num_secu;

            patient.Allergies.Clear();
            patient.Antecedents.Clear();

            patient.Allergies = _dbContext.Allergies
                .AsEnumerable()
                .Where(a => selectedAllergies.Contains(a.AllergieId))
                .ToList();

            patient.Antecedents = _dbContext.Antecedents
                .AsEnumerable()
                .Where(a => selectedAntecedents.Contains(a.AntecedentId))
                .ToList();

            _dbContext.Patients.Update(patient);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Patient non trouvé.");
        return View(viewModel);
    }
   

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var patient = _dbContext.Patients
            .Include(p => p.Antecedents)
            .Include(p => p.Allergies)
            .FirstOrDefault(p => p.PatientId == id);

        if (patient != null)
        {
            var viewModel = new PatientDetailsViewModel
            {
                Patient = patient,
                Allergies = _dbContext.Allergies.ToList(),
                Antecedents = _dbContext.Antecedents.ToList()
            };
            return View(viewModel);
        }

        return NotFound();
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var patient = _dbContext.Patients
            .Include(p => p.Antecedents)
            .Include(p => p.Allergies)
            .FirstOrDefault(p => p.PatientId == id);

        if (patient != null)
        {
            _dbContext.Patients.Remove(patient);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }


}