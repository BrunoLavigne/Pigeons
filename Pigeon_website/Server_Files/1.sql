-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Jeu 03 Décembre 2015 à 04:41
-- Version du serveur :  5.6.26
-- Version de PHP :  5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `locationvoiture`
--
CREATE DATABASE IF NOT EXISTS `locationvoiture` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `locationvoiture`;

-- --------------------------------------------------------

--
-- Structure de la table `administrateurs`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `administrateurs`;
CREATE TABLE IF NOT EXISTS `administrateurs` (
  `administrateurID` int(16) NOT NULL COMMENT 'La clé primaire de la table administrateur',
  `password` varchar(64) NOT NULL COMMENT 'Le mot de passe de l''administrateur',
  `nom` varchar(50) NOT NULL COMMENT 'Le nom de l''administrateur',
  `fonction` varchar(30) NOT NULL COMMENT 'La fonction occupée',
  `date_embauche` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'La date d''embauche de l''administrateur',
  `salaire_horaire` float DEFAULT NULL COMMENT 'Le taux horaire'
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `administrateurs`:
--

--
-- Contenu de la table `administrateurs`
--

INSERT INTO `administrateurs` (`administrateurID`, `password`, `nom`, `fonction`, `date_embauche`, `salaire_horaire`) VALUES
(1, '123456', 'administrateur', 'CEO', '2014-02-11 18:11:00', 34);

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `clientID` int(16) NOT NULL COMMENT 'Clé primaire de la table CLIENTS',
  `password` varchar(64) NOT NULL COMMENT 'Le mot de passe du client utilisé sur la page web',
  `nom` varchar(50) NOT NULL COMMENT 'Le nom du client ',
  `date_enregistrement` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT 'La date à laquelle le client s''est enregistré',
  `telephone` varchar(15) DEFAULT NULL COMMENT 'Le numéro de téléphone du client',
  `adresse_client` varchar(60) NOT NULL COMMENT 'L''adresse du client',
  `num_carte_credit` bigint(12) DEFAULT NULL COMMENT 'Le numéro de carte de crédit du client',
  `permis_conduire_num` varchar(50) NOT NULL COMMENT 'Le numéro de permis du client',
  `assurance` varchar(50) DEFAULT NULL COMMENT 'L''assurance prise par le client',
  `courriel` varchar(30) NOT NULL COMMENT 'Adresse courriel du client',
  `prenom` varchar(30) NOT NULL COMMENT 'Le prénom du client'
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `clients`:
--

--
-- Contenu de la table `clients`
--

INSERT INTO `clients` (`clientID`, `password`, `nom`, `date_enregistrement`, `telephone`, `adresse_client`, `num_carte_credit`, `permis_conduire_num`, `assurance`, `courriel`, `prenom`) VALUES
(9, '123456', 'Archambault', '2015-12-01 21:51:12', '514-495-2553', '3122 Chabot, Montreal, Quebec', NULL, '0000000000', '0000000000', 'bigcook@hotmail.com', 'Louis'),
(10, 'SimonBoisjolie16', 'Boisjolie', '2015-11-16 18:33:14', '450-844-1649', '43 Rue des Artisants, Longueil, Qc', NULL, '0000000000', '0000000000', 'simon.boijo@gmail.com', 'Simon'),
(11, 'brunolavigne16', 'Lavigne', '2015-11-25 20:01:58', '514-505-5511', '6303 Des Érables', NULL, '0000000000', '0000000000', 'bruno.lavigne@hotmail.com', 'Bruno'),
(12, 'philippeblanchette16', 'Blanchette', '2015-12-03 00:01:08', '514-433-4347', '2231 Des Ecureils', NULL, '0000000000', '0000000000', 'phil_blanchette@yahoo.com', 'Philippe'),
(13, 'joebloe23', 'Bloe', '2015-11-23 21:53:32', '514-911-9191', '911 Rue Gijoe', NULL, '0000000000', '0000000000', 'joeblow@gmail.com', 'Joe'),
(14, 'gilllill23', 'Lill', '2015-12-01 22:13:45', '514-221-1255', '9112 Des Gillies', NULL, '0000000000', '0000000000', 'gilllill@yahoo.fr', 'Gill'),
(15, 'jimmean23', 'Mean', '2015-11-23 23:31:15', '438-0122-2301', '8911 Des Clarinette', NULL, '0000000000', '0000000000', 'jim.mean@gmail.com', 'Jim'),
(16, 'pierretremblay23', 'Tremblay', '2015-11-24 02:07:18', '514-728-1533', '6442 Beaubien', NULL, '0000000000', '0000000000', 'pierre.tremblay@gmail.com', 'Pierre'),
(17, 'robertocuchone23', 'Cuchone', '2015-11-24 02:38:31', '514-221-5111', '5912 44ieme Avenue', NULL, '0000000000', '0000000000', 'rob.cuch@hotmail.com', 'Roberto'),
(18, 'wdqdsdsdsads26', 'sdsads', '2015-11-26 14:20:41', '3213123123', 'sadasdasda', NULL, '0000000000', '0000000000', 'ssdsdsad', 'wdqdsd'),
(19, 'bobgrattonn30', 'grattonn', '2015-11-30 17:32:42', '1231321', '12312312', NULL, '0000000000', '0000000000', '123123', 'bob'),
(20, 'brunolavigne2', 'Lavigne', '2015-12-02 23:47:09', '514-974-8946', '5499 Des Patates', NULL, '0000000000', '0000000000', 'brunolavigne@hotmail.com', 'Bruno'),
(21, 'jimmycroquette2', 'Croquette', '2015-12-03 01:06:12', '514-888-7744', '9764 McCroquette', NULL, '0000000000', '0000000000', 'jimmy.croquette@sympatico.ca', 'Jimmy');

-- --------------------------------------------------------

--
-- Structure de la table `constats_dommages`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `constats_dommages`;
CREATE TABLE IF NOT EXISTS `constats_dommages` (
  `constantID` int(16) NOT NULL COMMENT 'Clé primaire de la table CONSTATS_DOMMAGES',
  `reservationID` int(16) NOT NULL COMMENT 'Clé étrangère de la table RESERAVATION',
  `employeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table CLIENT. L''employé qui inscrit le constat de dommage',
  `date_constat` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'La date à laquelle le constat a eu lieu',
  `description_dommages` varchar(200) NOT NULL COMMENT 'Une description des dommages'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `constats_dommages`:
--   `employeID`
--       `employes` -> `employeID`
--   `reservationID`
--       `reservations` -> `reservationID`
--

-- --------------------------------------------------------

--
-- Structure de la table `employes`
--
-- Création :  Jeu 03 Décembre 2015 à 03:34
--

DROP TABLE IF EXISTS `employes`;
CREATE TABLE IF NOT EXISTS `employes` (
  `employeID` int(16) NOT NULL COMMENT 'Clé primaire de la table Employer. Identifiant unique de chaque employé',
  `password` varchar(64) NOT NULL COMMENT 'Le mot de passe de l''employé',
  `nom` varchar(30) NOT NULL COMMENT 'Le nom de l''employeé',
  `fonction` varchar(50) NOT NULL COMMENT 'La fonction occupée',
  `date_embauche` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'La date à laquelle il a été engager',
  `salaire_horaire` float DEFAULT NULL COMMENT 'Le taux horaire de l''employé',
  `succursaleID` int(4) NOT NULL COMMENT 'Clé étrangère qui provient de la table Succurales et qui représente la succursale où l''employé travail',
  `telephone` varchar(20) NOT NULL COMMENT 'Numéro de téléphone de l''employé',
  `adresse` varchar(60) NOT NULL COMMENT 'Adresse de l''employé',
  `username` varchar(64) NOT NULL COMMENT 'Nom d''usager pour le login de l''application'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `employes`:
--   `succursaleID`
--       `succursales` -> `succursaleID`
--

--
-- Contenu de la table `employes`
--

INSERT INTO `employes` (`employeID`, `password`, `nom`, `fonction`, `date_embauche`, `salaire_horaire`, `succursaleID`, `telephone`, `adresse`, `username`) VALUES
(1, '123456', 'Bobby', 'caissier', '2015-11-24 04:10:33', 10, 1, '', '', ''),
(4, '123456', 'Jim Basil', 'Commis', '2015-11-26 03:22:32', 10, 2, '438-411-1235', '77 Rang 12', 'jim'),
(5, '123456', 'Gille Tourette', 'Administrateur', '2015-11-26 03:33:57', 9, 4, '514-331-1266', '6522 Des Tiques', 'gille');

-- --------------------------------------------------------

--
-- Structure de la table `fabriquants`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `fabriquants`;
CREATE TABLE IF NOT EXISTS `fabriquants` (
  `fabriquantID` int(16) NOT NULL COMMENT 'Clé primaire de la table fabriquants',
  `nom_fabriquant` varchar(30) NOT NULL COMMENT 'Nom du fabriquant',
  `addresse_service` varchar(50) DEFAULT NULL COMMENT 'L''addresse de service du fabriquant',
  `telephone_service` varchar(15) DEFAULT NULL COMMENT 'Numéro de téléphone du fabriquant'
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `fabriquants`:
--

--
-- Contenu de la table `fabriquants`
--

INSERT INTO `fabriquants` (`fabriquantID`, `nom_fabriquant`, `addresse_service`, `telephone_service`) VALUES
(1, 'Infinity', '5290 Orbitor Drive Mississauga, ON L4W 4Z5', '1-800-268-0875'),
(2, 'Toyota', '1 Toyota Place, Toronto ON, M1H 1H9', '1-888-TOYOTA-8'),
(3, 'Mazda', '55 Vogell Road Richmond Hill, ON L4B 3K5', '1-800-263-4680'),
(4, 'Honda', '180 Honda Blvd Markham, ON L6C 0H9', '1-888-946-632'),
(5, 'Nissan', '2 Hunter Valley Road Orillia, (Ontario) L3V 6H2', '1-800-387-0122'),
(6, 'Volkswagen', '4865 Rue Marc Blain #300, Saint Laurent, QC H4R 3B', '1-800-822-898');

-- --------------------------------------------------------

--
-- Structure de la table `factures`
--
-- Création :  Jeu 03 Décembre 2015 à 03:24
--

DROP TABLE IF EXISTS `factures`;
CREATE TABLE IF NOT EXISTS `factures` (
  `factureID` int(16) NOT NULL,
  `clientID` int(16) NOT NULL,
  `date_facturation` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `montant` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- RELATIONS POUR LA TABLE `factures`:
--   `clientID`
--       `clients` -> `clientID`
--

-- --------------------------------------------------------

--
-- Structure de la table `locations`
--
-- Création :  Jeu 03 Décembre 2015 à 03:35
--

DROP TABLE IF EXISTS `locations`;
CREATE TABLE IF NOT EXISTS `locations` (
  `locationID` int(16) NOT NULL COMMENT 'La clé primaire de la table LOCATIONS',
  `date_debut` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'La date à laquelle le client part avec le véhicule',
  `date_fin` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT 'La date à laquelle le client rapporte le véhicule',
  `reservationID` int(16) DEFAULT NULL COMMENT 'Clé étrangère de la table RESERVATIONS. Si le client avait fait une réservation avant de faire une location',
  `vehiculeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table VEHICULE. Le ID du véhicule qui est loué par le client',
  `employeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table EMPLOYES. Représente l''employé qui effectue la location'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `locations`:
--   `employeID`
--       `employes` -> `employeID`
--   `reservationID`
--       `reservations` -> `reservationID`
--   `vehiculeID`
--       `vehicules` -> `vehiculeID`
--

-- --------------------------------------------------------

--
-- Structure de la table `modeles`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `modeles`;
CREATE TABLE IF NOT EXISTS `modeles` (
  `modeleID` int(16) NOT NULL COMMENT 'Clé primaire de la table MODELES',
  `typeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table TYPES',
  `nom_modele` varchar(25) NOT NULL COMMENT 'Nom du modèle',
  `nb_place` int(4) DEFAULT NULL COMMENT 'Le nombre de place maximum du modèle',
  `consommation_carburant` float DEFAULT NULL COMMENT 'La consommation par 100 litre de la voiture',
  `transmission` varchar(11) NOT NULL DEFAULT 'AUTOMATIQUE' COMMENT 'Automatique ou manuelle'
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `modeles`:
--   `typeID`
--       `types` -> `typeID`
--

--
-- Contenu de la table `modeles`
--

INSERT INTO `modeles` (`modeleID`, `typeID`, `nom_modele`, `nb_place`, `consommation_carburant`, `transmission`) VALUES
(1, 4, 'Camry', 4, 8.4, 'AUTOMATIQUE'),
(2, 1, 'Yaris', 4, 7.8, 'AUTOMATIQUE'),
(3, 2, 'Mazda 3', 4, 7.6, 'AUTOMATIQUE'),
(4, 10, 'CX-3', 5, 11.5, 'AUTOMATIQUE'),
(5, 1, 'Fit', 2, 7.6, 'AUTOMATIQUE'),
(6, 3, 'Civic', 4, 8.8, 'AUTOMATIQUE'),
(7, 4, 'Accord', 5, 8.4, 'MANUELLE'),
(8, 2, 'Golf', 4, 7.6, 'MANUELLE'),
(10, 3, 'Jetta', 4, 7.6, 'MANUELLE'),
(11, 10, 'Tiguan', 5, 8.8, 'AUTOMATIQUE');

-- --------------------------------------------------------

--
-- Structure de la table `reservations`
--
-- Création :  Jeu 03 Décembre 2015 à 02:59
--

DROP TABLE IF EXISTS `reservations`;
CREATE TABLE IF NOT EXISTS `reservations` (
  `reservationID` int(16) NOT NULL COMMENT 'Clé primaire de la table RESERVATION',
  `clientID` int(16) NOT NULL COMMENT 'Clé étrangère de la table CLIENTS',
  `employeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table EMPLOYES',
  `vehiculeID` int(16) NOT NULL COMMENT 'Clé étrangère de la table VEHICULES',
  `succursaleID` int(4) NOT NULL COMMENT 'Clé étrangère de la table SUCCURSALES',
  `factureID` int(16) DEFAULT NULL COMMENT 'Clé étrangère de la table FACTURES',
  `locationID` int(16) DEFAULT NULL,
  `date_appel_reservation` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'La date à laquelle la réservation a été placée',
  `date_debut_reservation` timestamp NULL DEFAULT NULL COMMENT 'La date pour laquelle le client désire réserver le véhicule',
  `date_fin_reservation` timestamp NULL DEFAULT NULL COMMENT 'La date à laquelle le client désire rapporter le véhicule'
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `reservations`:
--   `employeID`
--       `employes` -> `employeID`
--   `clientID`
--       `clients` -> `clientID`
--   `locationID`
--       `locations` -> `locationID`
--   `factureID`
--       `factures` -> `factureID`
--   `succursaleID`
--       `succursales` -> `succursaleID`
--   `vehiculeID`
--       `vehicules` -> `vehiculeID`
--

--
-- Contenu de la table `reservations`
--

INSERT INTO `reservations` (`reservationID`, `clientID`, `employeID`, `vehiculeID`, `succursaleID`, `factureID`, `locationID`, `date_appel_reservation`, `date_debut_reservation`, `date_fin_reservation`) VALUES
(6, 9, 1, 6, 1, NULL, NULL, '2015-11-24 04:11:16', '2015-11-18 14:00:00', '2015-11-19 14:00:00'),
(7, 9, 1, 13, 1, NULL, NULL, '2015-11-24 04:15:52', '2015-11-18 19:00:00', '2015-11-24 01:00:00'),
(8, 9, 1, 8, 2, NULL, NULL, '2015-11-25 15:19:44', '2015-11-25 20:00:00', '2015-11-26 23:00:00'),
(9, 14, 1, 5, 1, NULL, NULL, '2015-11-30 17:33:41', '2015-11-18 13:00:00', '2015-11-23 15:00:00'),
(10, 9, 1, 6, 1, NULL, NULL, '2015-12-01 22:36:23', '2015-12-01 18:00:00', '2015-12-03 00:00:00'),
(11, 21, 1, 11, 3, NULL, NULL, '2015-12-03 01:33:19', '2015-12-03 01:00:00', '2015-12-03 21:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `succursales`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `succursales`;
CREATE TABLE IF NOT EXISTS `succursales` (
  `succursaleID` int(4) NOT NULL COMMENT 'Clé primaire de la table SUCCURSALES',
  `addresse` varchar(50) NOT NULL COMMENT 'L''addresse de la succursale',
  `telephone` varchar(15) NOT NULL COMMENT 'Le numéro de téléphone de la succursale',
  `courriel` varchar(50) NOT NULL COMMENT 'Le courriel de la succursale',
  `nom` varchar(60) NOT NULL COMMENT 'Nom de la succursale'
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `succursales`:
--

--
-- Contenu de la table `succursales`
--

INSERT INTO `succursales` (`succursaleID`, `addresse`, `telephone`, `courriel`, `nom`) VALUES
(1, '4447 Rue Papineau, Montréal Québec, CA H2H 1T7', '514-521-2403', 'plateauMontRoyal@locomotion.com', 'Plateau Mont-Royal'),
(2, '607 Boulevard de Maisonneuve Ouest, Montréal, Qc', '514-286-1929', 'montrealCentreVille@locomotion.com', 'Montréal Centre-Ville'),
(3, '405 Avenue Michel Jasmin, Montréal, Qc H9P 1C2', '514-631-1436', 'aeroport@locomotion.com', 'Aéroport de Montréal'),
(4, '7675 Boulevard Viau, Montréal Québec H1S 2P4', '514-593-5559', 'saintLeonard@locomotion.com', 'Saint-Léonard');

-- --------------------------------------------------------

--
-- Structure de la table `types`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `types`;
CREATE TABLE IF NOT EXISTS `types` (
  `typeID` int(16) NOT NULL COMMENT 'Clé primaire de la table TYPES',
  `nom_type` varchar(25) NOT NULL COMMENT 'Le nom du type',
  `description` varchar(300) NOT NULL COMMENT 'Une description du type',
  `commission` float NOT NULL COMMENT 'Le prix de location de ce type de véhicule',
  `catégorie` char(1) NOT NULL COMMENT 'Catégorie du véhicule (c = camion, v = voiture)'
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `types`:
--

--
-- Contenu de la table `types`
--

INSERT INTO `types` (`typeID`, `nom_type`, `description`, `commission`, `catégorie`) VALUES
(1, 'économique', 'Essayez l’une de nos sous-compactes offrant des économies de carburant sans compromettre le style ou la performance. Elles sont parfaites pour la conduite en ville ou pour des voyages sur des courtes distances.', 0, 'v'),
(2, 'compacte', 'Plus spacieux et offrant les mêmes économies d’essence que nos véhicules économiques, nos modèles compacts sont polyvalents et idéals pour une fin de semaine entre amis.', 0, 'v'),
(3, 'Intermédiaire', 'Munis d’un habitacle plus spacieux et confortable, nos modèles intermédiaires possèdent des courbes élégantes. Sa conduite de type «tout en douceur» fera bien des jaloux sur les routes.', 0, 'v'),
(4, 'standard', 'Combinant puissance, efficacité et design innovateur, nos modèles standards sont non seulement confortables, mais offrent également un rendement éco-énergétique intéressant.', 0, 'v'),
(5, 'Vus compact', 'En plus d’avoir fière allure, nos modèles de VUS compacts possèdent une irréprochable tenue autant sur la route qu’hors route. Ce véhicule est idéal pour vos périples à travers les sentiers sinueux et les montagnes.', 0, 'v'),
(6, 'Camionnette compacte', 'Nos nombreux modèles de camionnettes disposent d’une impressionnante capacité de remorque. Robustes, ils sont idéals pour tous les types d’environnements et de terrains. L’habitacle confortable propose une panoplie de fonctionnalités.', 0, 'c'),
(7, 'Fourgonnette', 'Véhicule de transport dans sa plus simple expression, l''espace de chargement considérable de nos fourgonnettes est idéal pour des besoins de transports variés. Avec nos modèles de fourgonnettes, une expérience de conduite agréable est à portée de main.', 0, 'c'),
(8, 'Fourgon 12 pieds', 'Rendre l’utile à l’agréable! C’est ce que vous permet les modèles de camions cubes 12 pieds. Idéal pour transporter de l’équipement d’un endroit à l’autre sans trop de soucis, le camion cube 12 pieds est également très facile à conduire.', 0, 'c'),
(9, 'Fourgon 16 pieds', 'Avez-vous besoin d''un camion à grande capacité ? Notre fourgon 16 pieds peut accommoder vos meubles et objets d''un appartement ou même d''une maison comptant jusqu''à 2 chambres.', 0, 'c'),
(10, 'Vus compact', 'En plus d’avoir fière allure, nos modèles de VUS compacts possèdent une irréprochable tenue autant sur la route qu’hors route. Ce véhicule est idéal pour vos périples à travers les sentiers sinueux et les montagnes.', 0, 'v');

-- --------------------------------------------------------

--
-- Structure de la table `vehicules`
--
-- Création :  Jeu 03 Décembre 2015 à 02:50
--

DROP TABLE IF EXISTS `vehicules`;
CREATE TABLE IF NOT EXISTS `vehicules` (
  `vehiculeID` int(16) NOT NULL COMMENT 'La clé primaire de la table véhicule',
  `modeleID` int(16) NOT NULL COMMENT 'Clé étrangère de la table MODELE',
  `fabriquantID` int(16) NOT NULL COMMENT 'Clé étrangère de la table FABRIQUANTS',
  `kilometrage` int(16) DEFAULT NULL COMMENT 'La valeur actuelle de l''odomètre de la voiture',
  `plaque_num` varchar(25) NOT NULL COMMENT 'Le numéro de plaque de la voiture',
  `loc_state` varchar(5) NOT NULL DEFAULT 'LIBRE' COMMENT 'Le status de location de la voiture (Loué ou libre)',
  `succursaleID` int(4) NOT NULL COMMENT 'Clé étrangère de la table SUCCURSALES'
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

--
-- RELATIONS POUR LA TABLE `vehicules`:
--   `fabriquantID`
--       `fabriquants` -> `fabriquantID`
--   `modeleID`
--       `modeles` -> `modeleID`
--   `succursaleID`
--       `succursales` -> `succursaleID`
--

--
-- Contenu de la table `vehicules`
--

INSERT INTO `vehicules` (`vehiculeID`, `modeleID`, `fabriquantID`, `kilometrage`, `plaque_num`, `loc_state`, `succursaleID`) VALUES
(5, 1, 2, 0, 'FFB4780', 'LIBRE', 1),
(6, 1, 2, 0, 'FFB4781', 'LIBRE', 1),
(7, 2, 2, 0, 'FFB4782', 'LIBRE', 1),
(8, 2, 2, 0, 'FFB4783', 'LIBRE', 2),
(9, 3, 3, 0, 'FFB4784', 'LIBRE', 2),
(10, 4, 3, 0, 'FFB4785', 'LIBRE', 1),
(11, 7, 4, 0, 'FFB4786', 'LIBRE', 3),
(13, 10, 6, 0, 'FFB4788', 'LIBRE', 1);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `administrateurs`
--
ALTER TABLE `administrateurs`
  ADD PRIMARY KEY (`administrateurID`);

--
-- Index pour la table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`clientID`);

--
-- Index pour la table `constats_dommages`
--
ALTER TABLE `constats_dommages`
  ADD PRIMARY KEY (`constantID`),
  ADD KEY `reservationID` (`reservationID`),
  ADD KEY `employeID` (`employeID`);

--
-- Index pour la table `employes`
--
ALTER TABLE `employes`
  ADD PRIMARY KEY (`employeID`),
  ADD KEY `succursaleID` (`succursaleID`);

--
-- Index pour la table `fabriquants`
--
ALTER TABLE `fabriquants`
  ADD PRIMARY KEY (`fabriquantID`);

--
-- Index pour la table `factures`
--
ALTER TABLE `factures`
  ADD PRIMARY KEY (`factureID`),
  ADD KEY `clientID` (`clientID`);

--
-- Index pour la table `locations`
--
ALTER TABLE `locations`
  ADD PRIMARY KEY (`locationID`),
  ADD KEY `reservationID` (`reservationID`),
  ADD KEY `vehiculeID` (`vehiculeID`),
  ADD KEY `employeID` (`employeID`);

--
-- Index pour la table `modeles`
--
ALTER TABLE `modeles`
  ADD PRIMARY KEY (`modeleID`),
  ADD KEY `typeID` (`typeID`);

--
-- Index pour la table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`reservationID`),
  ADD KEY `clientID` (`clientID`),
  ADD KEY `employeID` (`employeID`),
  ADD KEY `vehiculeID` (`vehiculeID`),
  ADD KEY `factureID` (`factureID`),
  ADD KEY `succursaleID` (`succursaleID`),
  ADD KEY `locationID` (`locationID`);

--
-- Index pour la table `succursales`
--
ALTER TABLE `succursales`
  ADD PRIMARY KEY (`succursaleID`);

--
-- Index pour la table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`typeID`);

--
-- Index pour la table `vehicules`
--
ALTER TABLE `vehicules`
  ADD PRIMARY KEY (`vehiculeID`),
  ADD UNIQUE KEY `plaque_num` (`plaque_num`),
  ADD KEY `modeleID` (`modeleID`),
  ADD KEY `fabriquantID` (`fabriquantID`),
  ADD KEY `succursaleID` (`succursaleID`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `administrateurs`
--
ALTER TABLE `administrateurs`
  MODIFY `administrateurID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'La clé primaire de la table administrateur',AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `clients`
--
ALTER TABLE `clients`
  MODIFY `clientID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table CLIENTS',AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT pour la table `constats_dommages`
--
ALTER TABLE `constats_dommages`
  MODIFY `constantID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table CONSTATS_DOMMAGES';
--
-- AUTO_INCREMENT pour la table `employes`
--
ALTER TABLE `employes`
  MODIFY `employeID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table Employer. Identifiant unique de chaque employé',AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table `fabriquants`
--
ALTER TABLE `fabriquants`
  MODIFY `fabriquantID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table fabriquants',AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT pour la table `factures`
--
ALTER TABLE `factures`
  MODIFY `factureID` int(16) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `locations`
--
ALTER TABLE `locations`
  MODIFY `locationID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'La clé primaire de la table LOCATIONS';
--
-- AUTO_INCREMENT pour la table `modeles`
--
ALTER TABLE `modeles`
  MODIFY `modeleID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table MODELES',AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT pour la table `reservations`
--
ALTER TABLE `reservations`
  MODIFY `reservationID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table RESERVATION',AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT pour la table `succursales`
--
ALTER TABLE `succursales`
  MODIFY `succursaleID` int(4) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table SUCCURSALES',AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `types`
--
ALTER TABLE `types`
  MODIFY `typeID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'Clé primaire de la table TYPES',AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `vehicules`
--
ALTER TABLE `vehicules`
  MODIFY `vehiculeID` int(16) NOT NULL AUTO_INCREMENT COMMENT 'La clé primaire de la table véhicule',AUTO_INCREMENT=14;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `constats_dommages`
--
ALTER TABLE `constats_dommages`
  ADD CONSTRAINT `fk_constat_employe` FOREIGN KEY (`employeID`) REFERENCES `employes` (`employeID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_reservationID` FOREIGN KEY (`reservationID`) REFERENCES `reservations` (`reservationID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `employes`
--
ALTER TABLE `employes`
  ADD CONSTRAINT `FK_succursale_employee` FOREIGN KEY (`succursaleID`) REFERENCES `succursales` (`succursaleID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `factures`
--
ALTER TABLE `factures`
  ADD CONSTRAINT `fk_facture_client` FOREIGN KEY (`clientID`) REFERENCES `clients` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `locations`
--
ALTER TABLE `locations`
  ADD CONSTRAINT `FK_location_employe` FOREIGN KEY (`employeID`) REFERENCES `employes` (`employeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_location_reservation` FOREIGN KEY (`reservationID`) REFERENCES `reservations` (`reservationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_location_vehicule` FOREIGN KEY (`vehiculeID`) REFERENCES `vehicules` (`vehiculeID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `modeles`
--
ALTER TABLE `modeles`
  ADD CONSTRAINT `FK_model_type` FOREIGN KEY (`typeID`) REFERENCES `types` (`typeID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `reservations`
--
ALTER TABLE `reservations`
  ADD CONSTRAINT `fk_EmployeID` FOREIGN KEY (`employeID`) REFERENCES `employes` (`employeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_clientId` FOREIGN KEY (`clientID`) REFERENCES `clients` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_locationId` FOREIGN KEY (`locationID`) REFERENCES `locations` (`locationID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_reservation_facture` FOREIGN KEY (`factureID`) REFERENCES `factures` (`factureID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_succursaleId` FOREIGN KEY (`succursaleID`) REFERENCES `succursales` (`succursaleID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_vehiculeId` FOREIGN KEY (`vehiculeID`) REFERENCES `vehicules` (`vehiculeID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `vehicules`
--
ALTER TABLE `vehicules`
  ADD CONSTRAINT `FK_vehicule_fabriquant` FOREIGN KEY (`fabriquantID`) REFERENCES `fabriquants` (`fabriquantID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_vehicule_model` FOREIGN KEY (`modeleID`) REFERENCES `modeles` (`modeleID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_vehicule_succursale` FOREIGN KEY (`succursaleID`) REFERENCES `succursales` (`succursaleID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
