using System;

namespace TP_GestionGarages
{
    public class Moteur
    {
        private static int increment = 0;
        private int id;
        private string nom;
        private int puissance;
        private TypeMoteur typeMoteur;


        public Moteur(string nom, int puissance, TypeMoteur typeMoteur)
        {
            increment++;
            id = increment;
            this.nom = nom;
            this.puissance = puissance;
            this.typeMoteur = typeMoteur;
        }

        public void Afficher()
        {
            Console.WriteLine("Moteur n°"+id+" : "+nom+" "+typeMoteur+"("+puissance+"chevaux)");
        }
    }
}