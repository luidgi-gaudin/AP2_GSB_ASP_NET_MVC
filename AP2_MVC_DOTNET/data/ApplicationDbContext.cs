using Microsoft.EntityFrameworkCore;
using AP2_MVC_DOTNET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AP2_MVC_DOTNET.data
{
    public class ApplicationDbContext : IdentityDbContext<Medecin>
    {
        public DbSet<ErrorViewModel> ErrorViewModels { get; set; }
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Allergie> Allergies => Set<Allergie>();
        public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
        public DbSet<Medicament> Medicaments => Set<Medicament>();
        public DbSet<Antecedent> Antecedents => Set<Antecedent>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Allergies)
                .WithMany(a => a.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PatientAllergie",
                    r => r.HasOne<Allergie>().WithMany().HasForeignKey("AllergieId"),
                    l => l.HasOne<Patient>().WithMany().HasForeignKey("PatientId"),
                    je =>
                    {
                        je.HasKey("PatientId", "AllergieId");
                        je.HasData(
                            new { PatientId = 1, AllergieId = 1 },
                            new { PatientId = 1, AllergieId = 3 }
                        );
                    }
                );

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Antecedents)
                .WithMany(a => a.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PatientAntecedent",
                    r => r.HasOne<Antecedent>().WithMany().HasForeignKey("AntecedentId"),
                    l => l.HasOne<Patient>().WithMany().HasForeignKey("PatientId"),
                    je =>
                    {
                        je.HasKey("PatientId", "AntecedentId");
                        je.HasData(
                            new { PatientId = 1, AntecedentId = 2 }
                        );
                    }
                );

            modelBuilder.Entity<Allergie>()
                .HasMany(a => a.Medicaments)
                .WithMany(m => m.Allergies)
                .UsingEntity<Dictionary<string, object>>(
                    "AllergieMedicament",
                    r => r.HasOne<Medicament>().WithMany().HasForeignKey("MedicamentId"),
                    l => l.HasOne<Allergie>().WithMany().HasForeignKey("AllergieId"),
                    je =>
                    {
                        je.HasKey("AllergieId", "MedicamentId");
                        je.HasData(
                            new { AllergieId = 3, MedicamentId = 4 }
                        );
                    }
                );

            modelBuilder.Entity<Antecedent>()
                .HasMany(a => a.Medicaments)
                .WithMany(m => m.Antecedents)
                .UsingEntity<Dictionary<string, object>>(
                    "AntecedentMedicament",
                    r => r.HasOne<Medicament>().WithMany().HasForeignKey("MedicamentId"),
                    l => l.HasOne<Antecedent>().WithMany().HasForeignKey("AntecedentId"),
                    je =>
                    {
                        je.HasKey("AntecedentId", "MedicamentId");
                        je.HasData(
                            new { AntecedentId = 2, MedicamentId = 5 }
                        );
                    }
                );

            modelBuilder.Entity<Ordonnance>()
                .HasOne(o => o.Patient)
                .WithMany(p => p.Ordonnances)
                .HasForeignKey(o => o.PatientId);

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientId = 1,
                    Prenom_p = "John",
                    Nom_p = "Doe",
                    Sexe_p = "H",
                    Num_secu = "001838529835"
                }
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { MedicamentId = 1, Libelle_med = "Aspirine", Contr_indication = "Aucune", Stock = 100 },
                new Medicament { MedicamentId = 2, Libelle_med = "Paracétamol", Contr_indication = "Aucune", Stock = 50 },
                new Medicament { MedicamentId = 3, Libelle_med = "Ibuprofène", Contr_indication = "Aucune", Stock = 75 },
                new Medicament { MedicamentId = 4, Libelle_med = "Pénicilline", Contr_indication = "Allergie", Stock = 25 },
                new Medicament { MedicamentId = 5, Libelle_med = "Lisinopril", Contr_indication = "Hypertension", Stock = 10 }
            );

            modelBuilder.Entity<Allergie>().HasData(
                new Allergie { AllergieId = 1, Libelle_al = "Pollen" },
                new Allergie { AllergieId = 2, Libelle_al = "Acariens" },
                new Allergie { AllergieId = 3, Libelle_al = "Pénicilline" }
            );

            modelBuilder.Entity<Antecedent>().HasData(
                new Antecedent { AntecedentId = 1, Libelle_a = "Diabète" },
                new Antecedent { AntecedentId = 2, Libelle_a = "Hypertension" },
                new Antecedent { AntecedentId = 3, Libelle_a = "Asthme" }
            );
        }
    }
}
