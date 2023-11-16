using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP_GestionGarages
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            test();
        }

        public static void test()
        {
            Garage garage = new Garage("Mon super garage");


            //Creation d'un jeu de moteurs
            Moteur moteurElec = new Moteur("ACDCPower", 312, TypeMoteur.electrique);
            Moteur moteurHybrid = new Moteur("Hybrid", 240, TypeMoteur.hybride);
            Moteur moteurAtmos = new Moteur("Atmos", 65, TypeMoteur.diesel);
            Moteur moteurV6E = new Moteur("V6E", 120, TypeMoteur.essence);
            Moteur moteurV8E = new Moteur("V8E", 240, TypeMoteur.essence);
            Moteur moteurV12D = new Moteur("V12D", 360, TypeMoteur.diesel);


            //Création d'un jeu d'options : 
            Option optionClim = new Option("Climatisation", 300);
            Option optionToitPanoramix = new Option("toitPanoramix", 750);
            Option optionPharesXenons = new Option("pharesXenon", 2300);
            Option optionAileronTunning = new Option("Aileron de Tunning", 10000);
            Option optionCaissonBassReflex = new Option("Caisson de basse", 650);
            Option optionKlaxonQuiFaitPouetPouet = new Option("Klaxon qui fait pouet-pouet", 10000);
            
            //Création

            //Création d'un jeu de véhicule
            Voiture ECC = new Voiture("Electric Concept Car (ECC)",
                120000,
                Marque.renault,
                moteurElec,
                new List<Option>
                {
                    optionClim,
                    optionToitPanoramix,
                    optionAileronTunning
                },
                10,
                2,
                4,
                2);

            Camion camionPouetPouet = new Camion("Le camion qui fait pouet-pouet",
                36000,
                Marque.renault,
                moteurV12D,
                new List<Option>
                {
                    optionKlaxonQuiFaitPouetPouet
                },
                10,
                2,
                4);
            
            Moto motoVroumVroum = new Moto("La moto qui fait vroum-vroum",
                12000,
                Marque.audi,
                moteurV6E,
                new List<Option>
                {
                    optionClim
                },
                300);
            
            
            foreach (Vehicule vehicule in new List<Vehicule>{ECC, camionPouetPouet, motoVroumVroum})
            {
                garage.AjouterVehicule(vehicule);
            }
            
            garage.Afficher();
        }
    }
}