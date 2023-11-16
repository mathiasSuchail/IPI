using System;
using System.Runtime.CompilerServices;

namespace TP_Gestion_Ecole
{
    public class Professeur : Personne
    {
        private int salaire;
        
        public Professeur(string nom, string prenom, int age, int salaire) : base(nom, prenom, age)
        {
            this.salaire = salaire;
        }


        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Salaire : "+salaire+"\n"+
                              "Cout : "+CalculCout()+"\n");
        }

        public double CalculCout()
        {
            return salaire * 12;
        }
    }

}