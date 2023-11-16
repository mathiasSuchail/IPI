using System;
using System.Collections.Generic;

namespace TP_GestionGarages
{
    public class Garage
    {
        private string nom;
        private List<Vehicule> vehicules = new List<Vehicule>();

        public Garage(string nom)
        {
            this.nom = nom;
        }

        public void AjouterVehicule(Vehicule vehicule)
        {
                vehicules.Add(vehicule);
        }

        public void Afficher()
        {
            Console.WriteLine("Garage : "+nom);
            foreach (Vehicule vehicule in vehicules)
            {
                vehicule.Afficher();
                Console.WriteLine();
            }
        }

        public void AfficherVehiculeDeType(TypeVehicule typeVehicule)
        {
            Console.WriteLine("Garage : "+nom);
            foreach (Vehicule vehicule in vehicules)
            {
                if (typeVehicule==TypeVehicule.Camion && vehicule is Camion)
                {
                    vehicule.Afficher();
                }
                if (typeVehicule==TypeVehicule.Voiture && vehicule is Voiture)
                {
                    vehicule.Afficher();
                }
                if (typeVehicule==TypeVehicule.Moto && vehicule is Moto)
                {
                    vehicule.Afficher();
                }
            }
        }
        
    }
}