-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 22 nov. 2024 à 20:19
-- Version du serveur : 10.4.32-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `ap2_gsb`
--

-- --------------------------------------------------------

--
-- Structure de la table `allergiemedicament`
--

CREATE TABLE `allergiemedicament` (
  `AllergiesAllergieId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `allergiemedicament`
--

INSERT INTO `allergiemedicament` (`AllergiesAllergieId`, `MedicamentsMedicamentId`) VALUES
(1, 1),
(2, 3);

-- --------------------------------------------------------

--
-- Structure de la table `allergiepatient`
--

CREATE TABLE `allergiepatient` (
  `AllergiesAllergieId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `allergiepatient`
--

INSERT INTO `allergiepatient` (`AllergiesAllergieId`, `PatientsPatientId`) VALUES
(1, 1),
(2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `allergies`
--

CREATE TABLE `allergies` (
  `AllergieId` int(11) NOT NULL,
  `Libelle_al` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `allergies`
--

INSERT INTO `allergies` (`AllergieId`, `Libelle_al`) VALUES
(1, 'Paracétamole'),
(2, 'Codéine'),
(3, 'Acharien');

-- --------------------------------------------------------

--
-- Structure de la table `antecedentmedicament`
--

CREATE TABLE `antecedentmedicament` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentpatient`
--

CREATE TABLE `antecedentpatient` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `antecedents`
--

CREATE TABLE `antecedents` (
  `AntecedentId` int(11) NOT NULL,
  `Libelle_a` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `antecedents`
--

INSERT INTO `antecedents` (`AntecedentId`, `Libelle_a`) VALUES
(1, 'AVC'),
(2, 'Malaise'),
(3, 'Tacicardie');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `Nom_m` longtext NOT NULL,
  `Prenom_m` longtext NOT NULL,
  `Date_naissance_m` datetime(6) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `Nom_m`, `Prenom_m`, `Date_naissance_m`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('b621e890-2c88-44cc-bf25-3506d0a7ec7d', 'GAUDIN', 'Luidgi', '2005-07-16 00:00:00.000000', 'Luidgi.G', 'LUIDGI.G', 'ultime69.yt@gmail.com', 'ULTIME69.YT@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAECIWTjSD7c8uqiHwFPB/SNz0aj2+gp8BcGUXDnN2KPecUKGCY60Y+tfe5iwTW2QUYg==', 'SP32O52GM4MN74PEWBY4JDH24NJVIQA5', '4922db29-afdd-4c7f-83be-6c8ac01e2e91', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `errorviewmodels`
--

CREATE TABLE `errorviewmodels` (
  `RequestId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `medicamentordonnance`
--

CREATE TABLE `medicamentordonnance` (
  `MedicamentsMedicamentId` int(11) NOT NULL,
  `OrdonnancesOrdonnanceId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `medicamentordonnance`
--

INSERT INTO `medicamentordonnance` (`MedicamentsMedicamentId`, `OrdonnancesOrdonnanceId`) VALUES
(2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `medicaments`
--

CREATE TABLE `medicaments` (
  `MedicamentId` int(11) NOT NULL,
  `Libelle_med` longtext NOT NULL,
  `Contr_indication` longtext NOT NULL,
  `Stock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `medicaments`
--

INSERT INTO `medicaments` (`MedicamentId`, `Libelle_med`, `Contr_indication`, `Stock`) VALUES
(1, 'Paracétamol', 'aee', 1200),
(2, 'Doliprane', 'zaf', 1233),
(3, 'sirop pour la toux', 'sqf', 1350);

-- --------------------------------------------------------

--
-- Structure de la table `ordonnances`
--

CREATE TABLE `ordonnances` (
  `OrdonnanceId` int(11) NOT NULL,
  `Posologie` longtext NOT NULL,
  `DateCréation` datetime(6) NOT NULL,
  `Duree_traitement` longtext NOT NULL,
  `Instructions_specifique` longtext NOT NULL,
  `MedecinId` varchar(255) NOT NULL,
  `PatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `ordonnances`
--

INSERT INTO `ordonnances` (`OrdonnanceId`, `Posologie`, `DateCréation`, `Duree_traitement`, `Instructions_specifique`, `MedecinId`, `PatientId`) VALUES
(1, 'kjh', '2024-11-13 21:43:19.648920', 'jkhk', 'hjkhjk', 'b621e890-2c88-44cc-bf25-3506d0a7ec7d', 1);

-- --------------------------------------------------------

--
-- Structure de la table `patients`
--

CREATE TABLE `patients` (
  `PatientId` int(11) NOT NULL,
  `Nom_p` varchar(50) NOT NULL,
  `Prenom_p` varchar(50) NOT NULL,
  `Sexe_p` longtext NOT NULL,
  `Num_secu` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `patients`
--

INSERT INTO `patients` (`PatientId`, `Nom_p`, `Prenom_p`, `Sexe_p`, `Num_secu`) VALUES
(1, 'Doe', 'John', 'H', '001838529835');

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241113102234_firstmigration', '8.0.8'),
('20241113203934_first', '8.0.8');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `allergiemedicament`
--
ALTER TABLE `allergiemedicament`
  ADD PRIMARY KEY (`AllergiesAllergieId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AllergieMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `allergiepatient`
--
ALTER TABLE `allergiepatient`
  ADD PRIMARY KEY (`AllergiesAllergieId`,`PatientsPatientId`),
  ADD KEY `IX_AllergiePatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `allergies`
--
ALTER TABLE `allergies`
  ADD PRIMARY KEY (`AllergieId`);

--
-- Index pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AntecedentMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`PatientsPatientId`),
  ADD KEY `IX_AntecedentPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `antecedents`
--
ALTER TABLE `antecedents`
  ADD PRIMARY KEY (`AntecedentId`);

--
-- Index pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Index pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Index pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Index pour la table `errorviewmodels`
--
ALTER TABLE `errorviewmodels`
  ADD PRIMARY KEY (`RequestId`);

--
-- Index pour la table `medicamentordonnance`
--
ALTER TABLE `medicamentordonnance`
  ADD PRIMARY KEY (`MedicamentsMedicamentId`,`OrdonnancesOrdonnanceId`),
  ADD KEY `IX_MedicamentOrdonnance_OrdonnancesOrdonnanceId` (`OrdonnancesOrdonnanceId`);

--
-- Index pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD PRIMARY KEY (`MedicamentId`);

--
-- Index pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD PRIMARY KEY (`OrdonnanceId`),
  ADD KEY `IX_Ordonnances_MedecinId` (`MedecinId`),
  ADD KEY `IX_Ordonnances_PatientId` (`PatientId`);

--
-- Index pour la table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`PatientId`);

--
-- Index pour la table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `allergies`
--
ALTER TABLE `allergies`
  MODIFY `AllergieId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `antecedents`
--
ALTER TABLE `antecedents`
  MODIFY `AntecedentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `medicaments`
--
ALTER TABLE `medicaments`
  MODIFY `MedicamentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  MODIFY `OrdonnanceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `patients`
--
ALTER TABLE `patients`
  MODIFY `PatientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `allergiemedicament`
--
ALTER TABLE `allergiemedicament`
  ADD CONSTRAINT `FK_AllergieMedicament_Allergies_AllergiesAllergieId` FOREIGN KEY (`AllergiesAllergieId`) REFERENCES `allergies` (`AllergieId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AllergieMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `allergiepatient`
--
ALTER TABLE `allergiepatient`
  ADD CONSTRAINT `FK_AllergiePatient_Allergies_AllergiesAllergieId` FOREIGN KEY (`AllergiesAllergieId`) REFERENCES `allergies` (`AllergieId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AllergiePatient_Patients_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD CONSTRAINT `FK_AntecedentMedicament_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD CONSTRAINT `FK_AntecedentPatient_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentPatient_Patients_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `medicamentordonnance`
--
ALTER TABLE `medicamentordonnance`
  ADD CONSTRAINT `FK_MedicamentOrdonnance_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_MedicamentOrdonnance_Ordonnances_OrdonnancesOrdonnanceId` FOREIGN KEY (`OrdonnancesOrdonnanceId`) REFERENCES `ordonnances` (`OrdonnanceId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD CONSTRAINT `FK_Ordonnances_AspNetUsers_MedecinId` FOREIGN KEY (`MedecinId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ordonnances_Patients_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
