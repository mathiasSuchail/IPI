using System;

namespace TP_Gestion_Ecole
{
    public class Personne
    {
        protected string nom;
        protected string prenom;
        protected int age;

        public Personne(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Nom : " + nom + "\n" +
                              "Prenom : " + prenom + "\n" +
                              "Age : " + age + "\n");
        }

        public void viellir()
        {
            age++;
        }
    }
}