using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.IO.Image;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using Microsoft.AspNetCore.Mvc;
using AP2_MVC_DOTNET.data;
using Microsoft.AspNetCore.Identity;
using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.Controllers;
[Authorize]
public class OrdonnanceController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<Medecin> _userManager;

    public OrdonnanceController(ApplicationDbContext dbContext, UserManager<Medecin> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string patientId = null)
    {
        var query = _dbContext.Ordonnances
            .Include(o => o.Medecin)
            .Include(o => o.Patient)
            .Include(o => o.Medicaments)
            .OrderByDescending(o => o.OrdonnanceId)
            .AsQueryable();

        if (!string.IsNullOrEmpty(patientId))
        {
            query = query.Where(o => o.PatientId == int.Parse(patientId));
        }

        var ordonnances = await query.ToListAsync();
        ViewBag.Patients = await _dbContext.Patients.ToListAsync();
        
        return View(ordonnances);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();

        var viewModel = new OrdonnanceViewModel
        {
            Medecin = user,
            Patients = await _dbContext.Patients.Include(p => p.Allergies).ToListAsync(),
            Medicaments = await _dbContext.Medicaments.Include(m => m.Allergies).ToListAsync()
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<JsonResult> GetPatientAllergies(int patientId)
    {
        var patient = await _dbContext.Patients
            .Include(p => p.Allergies)
            .FirstOrDefaultAsync(p => p.PatientId == patientId);

        return Json(patient?.Allergies.Select(a => a.AllergieId).ToList());
    }

    [HttpPost]
    public async Task<IActionResult> Add(OrdonnanceViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();

        var patient = await _dbContext.Patients
            .Include(p => p.Allergies)
            .FirstOrDefaultAsync(p => p.PatientId == viewModel.PatientId);
        
        if (patient == null)
        {
            ModelState.AddModelError("Patient", "Patient non trouvé.");
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }

        var selectedMedicaments = await _dbContext.Medicaments
            .Where(m => viewModel.SelectedMedicamentsId.Contains(m.MedicamentId))
            .Include(m => m.Allergies)
            .ToListAsync();

        if (!selectedMedicaments.Any())
        {
            ModelState.AddModelError("", "Veuillez sélectionner au moins un médicament.");
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }

        // Vérification des allergies
        foreach (var medicament in selectedMedicaments)
        {
            if (medicament.Allergies.Any(a => patient.Allergies.Any(pa => pa.AllergieId == a.AllergieId)))
            {
                ModelState.AddModelError("", $"Le patient est allergique au médicament {medicament.Libelle_med}");
                await PrepareViewModel(viewModel);
                return View(viewModel);
            }
        }

        var ordonnance = new Ordonnance
        {
            Posologie = viewModel.Posologie,
            Duree_traitement = viewModel.Duree_traitement,
            Instructions_specifique = viewModel.Instructions_specifique,
            DateCréation = DateTime.Now,
            MedecinId = user.Id,
            PatientId = patient.PatientId
        };

        // Ajout des médicaments
        ordonnance.Medicaments = new List<Medicament>();
        foreach (var medicament in selectedMedicaments)
        {
            ordonnance.Medicaments.Add(medicament);
        }

        _dbContext.Ordonnances.Add(ordonnance);
        
        try 
        {
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Une erreur s'est produite lors de la sauvegarde. " + ex.InnerException?.Message);
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var ordonnance = await _dbContext.Ordonnances
            .Include(o => o.Medecin)
            .Include(o => o.Patient)
            .Include(o => o.Medicaments)
            .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

        if (ordonnance == null) return NotFound();

        var viewModel = new OrdonnanceViewModel
        {
            OrdonnanceId = ordonnance.OrdonnanceId,
            PatientId = ordonnance.PatientId,
            Posologie = ordonnance.Posologie,
            Duree_traitement = ordonnance.Duree_traitement,
            Instructions_specifique = ordonnance.Instructions_specifique,
            Patients = await _dbContext.Patients.Include(p => p.Allergies).ToListAsync(),
            Medicaments = await _dbContext.Medicaments.Include(m => m.Allergies).ToListAsync(),
            SelectedMedicamentsId = ordonnance.Medicaments.Select(m => m.MedicamentId).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(OrdonnanceViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }

        var ordonnance = await _dbContext.Ordonnances
            .Include(o => o.Medicaments)
            .FirstOrDefaultAsync(o => o.OrdonnanceId == viewModel.OrdonnanceId);

        if (ordonnance == null) return NotFound();

        var patient = await _dbContext.Patients
            .Include(p => p.Allergies)
            .FirstOrDefaultAsync(p => p.PatientId == viewModel.PatientId);

        var selectedMedicaments = await _dbContext.Medicaments
            .Where(m => viewModel.SelectedMedicamentsId.Contains(m.MedicamentId))
            .Include(m => m.Allergies)
            .ToListAsync();

        if (!selectedMedicaments.Any())
        {
            ModelState.AddModelError("", "Veuillez sélectionner au moins un médicament.");
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }

        // Vérification des allergies
        foreach (var medicament in selectedMedicaments)
        {
            if (medicament.Allergies.Any(a => patient.Allergies.Any(pa => pa.AllergieId == a.AllergieId)))
            {
                ModelState.AddModelError("", $"Le patient est allergique au médicament {medicament.Libelle_med}");
                await PrepareViewModel(viewModel);
                return View(viewModel);
            }
        }

        ordonnance.Posologie = viewModel.Posologie;
        ordonnance.Duree_traitement = viewModel.Duree_traitement;
        ordonnance.Instructions_specifique = viewModel.Instructions_specifique;
        
        // Mise à jour des médicaments
        ordonnance.Medicaments.Clear();
        foreach (var medicament in selectedMedicaments)
        {
            ordonnance.Medicaments.Add(medicament);
        }

        try 
        {
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Une erreur s'est produite lors de la sauvegarde. " + ex.InnerException?.Message);
            await PrepareViewModel(viewModel);
            return View(viewModel);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var ordonnance = await _dbContext.Ordonnances
            .Include(o => o.Medecin)
            .Include(o => o.Patient)
            .Include(o => o.Medicaments)
            .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

        if (ordonnance == null) return NotFound();

        return View(ordonnance);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var ordonnance = await _dbContext.Ordonnances.FindAsync(id);
        if (ordonnance == null)
        {
            return NotFound();
        }

        return View(ordonnance); // Affiche une vue de confirmation
    }

    // Action POST pour confirmer et exécuter la suppression
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ordonnance = await _dbContext.Ordonnances.FindAsync(id);
        if (ordonnance == null)
        {
            return NotFound();
        }

        _dbContext.Ordonnances.Remove(ordonnance);
        await _dbContext.SaveChangesAsync();
   
        return RedirectToAction(nameof(Index));
    }
   
    public async Task<IActionResult> ExportToPdf(int id)
    {
        var ordonnance = await _dbContext.Ordonnances
            .Include(o => o.Patient)
            .Include(o => o.Medicaments)
            .Include(o=>o.Medecin)
            .FirstOrDefaultAsync(o => o.OrdonnanceId == id);

        if (ordonnance == null)
        {
            return NotFound();
        }

        using (var tempStream = new MemoryStream())
        {
            
            var pdfWriter = new PdfWriter(tempStream);
                var pdfDoc = new PdfDocument(pdfWriter);
                var document = new Document(pdfDoc);

                var logoImagePath = "./wwwroot/GSB.png";
                var logo = new Image(ImageDataFactory.Create(logoImagePath)).SetWidth(50);
                logo.SetFixedPosition(40, pdfDoc.GetDefaultPageSize().GetTop() - 50);
                document.Add(logo);

                var titleFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                var regularFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                var boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                var title = new Paragraph("Ordonnance")
                    .SetFont(titleFont)
                    .SetFontSize(24)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20);
                document.Add(title);

                var infoTable = new Table(2).UseAllAvailableWidth();
                infoTable.AddCell(new Cell().Add(new Paragraph("Date :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(ordonnance.DateCréation.ToShortDateString())).SetFont(regularFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph("Médecin :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph($"{ordonnance.Medecin.Nom_m} {ordonnance.Medecin.Prenom_m}")).SetFont(regularFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph("Patient :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph($"{ordonnance.Patient.Prenom_p} {ordonnance.Patient.Nom_p}")).SetFont(regularFont).SetFontSize(12).SetPadding(5).SetBorder(Border.NO_BORDER));
                document.Add(infoTable);

                var treatmentInfoHeader = new Paragraph("Informations de traitement")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginTop(20)
                    .SetMarginBottom(10);
                document.Add(treatmentInfoHeader);

                var treatmentTable = new Table(2).UseAllAvailableWidth();
                treatmentTable.AddCell(new Cell().Add(new Paragraph("Posologie :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                treatmentTable.AddCell(new Cell().Add(new Paragraph(ordonnance.Posologie)).SetFont(regularFont).SetFontSize(12).SetPadding(5));
                treatmentTable.AddCell(new Cell().Add(new Paragraph("Durée du traitement :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                treatmentTable.AddCell(new Cell().Add(new Paragraph(ordonnance.Duree_traitement)).SetFont(regularFont).SetFontSize(12).SetPadding(5));
                treatmentTable.AddCell(new Cell().Add(new Paragraph("Instructions spécifiques :")).SetFont(boldFont).SetFontSize(12).SetPadding(5).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                treatmentTable.AddCell(new Cell().Add(new Paragraph(ordonnance.Instructions_specifique)).SetFont(regularFont).SetFontSize(12).SetPadding(5));
                document.Add(treatmentTable);

                var medicationHeader = new Paragraph("Médicaments prescrits")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetMarginTop(20)
                    .SetMarginBottom(10);
                document.Add(medicationHeader);

                var medicationTable = new Table(2).UseAllAvailableWidth();
                medicationTable.AddHeaderCell(new Cell().Add(new Paragraph("Nom du médicament")).SetFont(boldFont).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetPadding(5));
                medicationTable.AddHeaderCell(new Cell().Add(new Paragraph("Contre-indications")).SetFont(boldFont).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetPadding(5));

                foreach (var medicament in ordonnance.Medicaments)
                {
                    medicationTable.AddCell(new Cell().Add(new Paragraph(medicament.Libelle_med)).SetFont(regularFont).SetFontSize(12).SetPadding(5));
                    medicationTable.AddCell(new Cell().Add(new Paragraph(medicament.Contr_indication)).SetFont(regularFont).SetFontSize(12).SetPadding(5));
                }

                document.Add(medicationTable);
                document.Close();

            var memoryStream = new MemoryStream(tempStream.ToArray());
            memoryStream.Position = 0;

            return File(memoryStream, "application/pdf", $"Ordonnance_{ordonnance.OrdonnanceId}.pdf");
        }
    }

    private async Task PrepareViewModel(OrdonnanceViewModel viewModel)
    {
        viewModel.Patients = await _dbContext.Patients.Include(p => p.Allergies).ToListAsync();
        viewModel.Medicaments = await _dbContext.Medicaments.Include(m => m.Allergies).ToListAsync();
    }


}