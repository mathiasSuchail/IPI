using System;
using System.Collections.Generic;

namespace TP_GestionGarages
{
    public class Voiture : Vehicule
    {
        private int chevauxFiscaux;
        private int nbPorte;
        private int nbSiege;
        private int tailleCoffre;

        public Voiture(string nom, decimal prixHt, Marque marque, Moteur moteur, List<Option> options, int chevauxFiscaux, int nbPorte, int nbSiege, int tailleCoffre) : base(nom, prixHt, marque, moteur, options)
        {
            this.chevauxFiscaux = chevauxFiscaux;
            this.nbPorte = nbPorte;
            this.nbSiege = nbSiege;
            this.tailleCoffre = tailleCoffre;
        }

        public override decimal CallculerTaxe()
        {
            return chevauxFiscaux * 10;
        }

        public override void Afficher()
        {
            Console.WriteLine("Information générales sur le véhicule : ");
            base.Afficher();
            Console.WriteLine("Information spécifiques sur la moto : \n" +
                              "Nombre d'essieux : "+chevauxFiscaux+"\n" +
                              "Poids : "+nbPorte+"\n" +
                              "Nombre de sièges : "+nbSiege+"\n" +
                              "Taille du coffre : "+tailleCoffre);
        }
    }
}