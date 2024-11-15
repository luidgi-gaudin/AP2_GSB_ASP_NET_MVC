﻿// <auto-generated />
using System;
using AP2_MVC_DOTNET.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AP2_MVC_DOTNET.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Allergie", b =>
                {
                    b.Property<int>("AllergieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AllergieId"));

                    b.Property<string>("Libelle_al")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AllergieId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Antecedent", b =>
                {
                    b.Property<int>("AntecedentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AntecedentId"));

                    b.Property<string>("Libelle_a")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AntecedentId");

                    b.ToTable("Antecedents");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.ErrorViewModel", b =>
                {
                    b.Property<string>("RequestId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("RequestId");

                    b.ToTable("ErrorViewModels");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Medecin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date_naissance_m")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nom_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Prenom_m")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MedicamentId"));

                    b.Property<string>("Contr_indication")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Libelle_med")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Ordonnance", b =>
                {
                    b.Property<int>("OrdonnanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrdonnanceId"));

                    b.Property<DateTime>("DateCréation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Duree_traitement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instructions_specifique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MedecinId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Posologie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrdonnanceId");

                    b.HasIndex("MedecinId");

                    b.HasIndex("PatientId");

                    b.ToTable("Ordonnances");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Nom_p")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Num_secu")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Prenom_p")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sexe_p")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            Nom_p = "Doe",
                            Num_secu = "001838529835",
                            Prenom_p = "John",
                            Sexe_p = "H"
                        });
                });

            modelBuilder.Entity("AllergieMedicament", b =>
                {
                    b.Property<int>("AllergiesAllergieId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesAllergieId", "MedicamentsMedicamentId");

                    b.HasIndex("MedicamentsMedicamentId");

                    b.ToTable("AllergieMedicament");
                });

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.Property<int>("AllergiesAllergieId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesAllergieId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("AllergiePatient");
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "MedicamentsMedicamentId");

                    b.HasIndex("MedicamentsMedicamentId");

                    b.ToTable("AntecedentMedicament");
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("AntecedentPatient");
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("OrdonnancesOrdonnanceId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentsMedicamentId", "OrdonnancesOrdonnanceId");

                    b.HasIndex("OrdonnancesOrdonnanceId");

                    b.ToTable("MedicamentOrdonnance");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Ordonnance", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Medecin", "Medecin")
                        .WithMany("Ordonnances")
                        .HasForeignKey("MedecinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Patient", "Patient")
                        .WithMany("Ordonnances")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medecin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AllergieMedicament", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Allergie", null)
                        .WithMany()
                        .HasForeignKey("AllergiesAllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Allergie", null)
                        .WithMany()
                        .HasForeignKey("AllergiesAllergieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Ordonnance", null)
                        .WithMany()
                        .HasForeignKey("OrdonnancesOrdonnanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AP2_MVC_DOTNET.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AP2_MVC_DOTNET.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Medecin", b =>
                {
                    b.Navigation("Ordonnances");
                });

            modelBuilder.Entity("AP2_MVC_DOTNET.Models.Patient", b =>
                {
                    b.Navigation("Ordonnances");
                });
#pragma warning restore 612, 618
        }
    }
}
