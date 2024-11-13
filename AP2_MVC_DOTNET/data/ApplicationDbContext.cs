using Microsoft.EntityFrameworkCore;
using AP2_MVC_DOTNET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace AP2_MVC_DOTNET.data
{
    public class ApplicationDbContext : IdentityDbContext<Medecin>
    {
        // DbSet pour chaque table de la base de données
        public DbSet<ErrorViewModel> ErrorViewModels { get; set; }
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Allergie> Allergies => Set<Allergie>();
        public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
        public DbSet<Medicament> Medicaments => Set<Medicament>();
        public DbSet<Antecedent> Antecedents => Set<Antecedent>();

        // Constructeur
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // Configuration de l'ORM et insertion de données mock
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation Many-to-Many entre Patient et Allergies
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Allergies)
                .WithMany(a => a.Patients);

            // Relation Many-to-Many entre Patient et Antecedents
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Antecedents)
                .WithMany(a => a.Patients);

            // Relation Many-to-Many entre Allergie et Medicament
            modelBuilder.Entity<Allergie>()
                .HasMany(a => a.Medicaments)
                .WithMany(m => m.Allergies);

            // Relation Many-to-Many entre Antecedent et Medicament
            modelBuilder.Entity<Antecedent>()
                .HasMany(a => a.Medicaments)
                .WithMany(m => m.Antecedents);

            // Relation One-to-Many entre Patient et Ordonnances (si un patient peut avoir plusieurs ordonnances)
            modelBuilder.Entity<Ordonnance>()
                .HasOne(o => o.Patient)
                .WithMany(p => p.Ordonnances) // Remplacez `WithOne` par `WithMany`
                .HasForeignKey(o => o.PatientId);

            // Données Mock
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
        }
    }
}
