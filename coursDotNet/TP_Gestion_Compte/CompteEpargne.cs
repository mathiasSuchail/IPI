using System;

namespace TP_Gestion_Compte
{
    public class CompteEpargne: Compte
    {
        private decimal abondement;

        public CompteEpargne(decimal abondement, string proprietaire, decimal solde=0) : base(proprietaire, solde)
        {
            this.abondement = abondement;
        }
        public override decimal CalculBenefice()
        {
            return Solde * (decimal)abondement/100;
        }

        public override void Information(bool displayOperations)
        {
            base.Information(displayOperations);
            Console.WriteLine("Taux : " + abondement);
            Console.WriteLine("\n");
        }
    }
}