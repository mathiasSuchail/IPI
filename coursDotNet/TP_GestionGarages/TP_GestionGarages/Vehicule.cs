using System;
using System.Collections.Generic;

namespace TP_GestionGarages
{
    public abstract class Vehicule: IComparable
    {
        private static int increment;
        private int id;
        private string nom;
        private decimal prixHT;
        private Marque marque;
        private Moteur moteur;
        private List<Option> options;


        protected Vehicule(string nom, decimal prixHt, Marque marque, Moteur moteur, List<Option> options)
        {
            this.nom = nom;
            prixHT = prixHt;
            this.marque = marque;
            this.moteur = moteur;
            this.options = options;
        }

        public void AfficherOptions()
        {
            foreach (Option option in options)
            {
                option.Afficher();
            }
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Vehicule n°" + id + " : " + marque + " " + nom + "(" + prixHT + "€)");
            Console.WriteLine("Moteur : ");
            moteur.Afficher();
            Console.WriteLine("Options : ");
            AfficherOptions();
        }

        public void AjouterOption(Option option)
        {
            options.Add(option);
        }

        public abstract decimal CallculerTaxe();

        public decimal prixTotal()
        {
            return CallculerTaxe() + prixHT;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Vehicule vehicule = obj as Vehicule;
            if(vehicule!=null) return prixTotal().CompareTo(vehicule.prixTotal());
            throw new ArgumentException("L'objet comparé n'est pas un véhicule");
        }
    }
}