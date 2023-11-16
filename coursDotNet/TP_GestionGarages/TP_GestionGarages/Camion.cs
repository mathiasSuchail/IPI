using System;
using System.Collections.Generic;

namespace TP_GestionGarages
{
    public class Camion : Vehicule
    {
        private int nbEssieu;
        private int poids;
        private int volume;

        public Camion(string nom, decimal prixHt, Marque marque, Moteur moteur, List<Option> options, int nbEssieu, int poids, int volume) : base(nom, prixHt, marque, moteur, options)
        {
            this.nbEssieu = nbEssieu;
            this.poids = poids;
            this.volume = volume;
        }

        public override decimal CallculerTaxe()
        {
            return nbEssieu * 50;
        }


        public override void Afficher()
        {
            Console.WriteLine("Information générales sur le véhicule : ");
            base.Afficher();
            Console.WriteLine("Information spécifiques sur la moto : \n" +
                              "Nombre d'essieux : "+nbEssieu+"\n" +
                              "Poids : "+poids+"\n" +
                              "Volume : "+volume);
        }
    }
}