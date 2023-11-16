using System;

namespace TP_GestionGarages
{
    public class Option
    {
        private static int increment=0;
        private int id;
        private string nom;
        private decimal prix;

        public Option(string nom, decimal prix)
        {
            increment++;
            id = increment;
            this.nom = nom;
            this.prix = prix;
        }

        public void Afficher()
        {
            Console.WriteLine("Option n°"+id+" : "+nom+"("+prix+"€)");
        }
    }
}