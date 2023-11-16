using System;
using System.Collections.Generic;
using System.Reflection;

namespace TP_Gestion_Ecole
{
    public class Ecole
    {
        private string nom;
        private string adresse;
        private double budget;
        private List<Professeur> professeurs=new List<Professeur>();
        private List<Eleve> eleves=new List<Eleve>();

        public Ecole()
        {
            
        }

        public Ecole(string nom, string adresse, double budget)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.budget = budget;
        }

        public void AjouterProfesseur(Professeur professeur)
        {
            professeurs.Add(professeur);
        }

        public void AjouterEleve(Eleve eleve)
        {
            eleves.Add(eleve);
        }
        

        public void Afficher()
        {
            Console.WriteLine("Nom : "+nom+"\n+" +
                              "Adresse : "+adresse+"\n"+
                              "Budget : "+budget+"\n");
            
            Console.WriteLine("Nombre de professeurs : "+professeurs.Count);
            if(professeurs.Count>0)
            {
                Console.WriteLine("Professeurs : ");
                foreach (Professeur professeur in professeurs)
                {
                    professeur.Afficher();
                }
            }
            
            Console.WriteLine("Nombre d'élèves : "+eleves.Count);
            if(eleves.Count>0)
            {
                Console.WriteLine("Eleves : ");
                foreach (Eleve eleve in eleves)
                {
                    eleve.Afficher();
                }
            }
            
            
        }
    }
}