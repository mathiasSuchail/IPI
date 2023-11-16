using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TP_Gestion_Ecole
{
    public class Eleve : Personne
    {
        private List<double> moyenne = new List<double>();

        public Eleve(string nom, string prenom, int age) : base(nom, prenom, age)
        {
        }

        public Eleve(string nom, string prenom, int age, List<double> moyenne) : base(nom, prenom, age)
        {
            this.moyenne = moyenne;
        }


        public override void Afficher()
        {
            base.Afficher();
            string moyenneToString = String.Join(", ", moyenne.ConvertAll(d=>d.ToString(CultureInfo.InvariantCulture)).ToArray());
            Console.WriteLine("Moyennes : "+ moyenneToString +"\n"+
                              "Moyenne generale : "+MoyenneGen()+"\n");
        }

        public double MoyenneGen()
        {
            double moyenneGen = 0;
            foreach (var d in moyenne)
            {
                moyenneGen += d;
            }
            moyenneGen = moyenneGen / moyenne.Count;
            return moyenneGen;
        }

        public void ajouterMoyenne(double moyenne)
        {
            this.moyenne.Add(moyenne);
        }
    }
}