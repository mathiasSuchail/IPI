using System;

namespace TP_Gestion_Compte
{
    public class CompteCourant: Compte
    {
        private decimal decouvert;

        public CompteCourant(decimal decouvert, string proprietaire, decimal solde=0):base(proprietaire, solde)
        {
            this.decouvert = decouvert;
        }

        public override decimal CalculBenefice()
        {
            return 0;
        }

        public override void Information(bool displayOperations)
        {
            base.Information(displayOperations);
            Console.WriteLine("Découvert autorisé : "+decouvert);
            Console.WriteLine("\n");
            
        }
    }
}