using System;
using System.Collections.Generic;

namespace TP_GestionGarages
{
    public class Moto : Vehicule
    {
        private int cylindre;

        public Moto(string nom, decimal prixHt, Marque marque, Moteur moteur, List<Option> options, int cylindre) : base(nom, prixHt, marque, moteur, options)
        {
            this.cylindre = cylindre;
        }

        public override decimal CallculerTaxe()
        {
            return (int)(0.3 * cylindre);
        }

        public override void Afficher()
        {
            Console.WriteLine("Information générales sur le véhicule : ");
            base.Afficher();
            Console.WriteLine("Information spécifiques sur la moto : \n" +
                              "Cylindré : "+cylindre);
        }
    }
}