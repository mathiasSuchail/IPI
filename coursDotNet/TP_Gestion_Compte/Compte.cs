using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Gestion_Compte
{
    public abstract class Compte: IComparable
    {
        protected List<Operation> operations=new List<Operation>();
        public string Proprietaire { get; set; }
        protected decimal Solde
        {
            get
            {
                decimal solde = 0;
                foreach(Operation operation in operations)
                {
                    if (operation.Types == Mouvement.Credit) solde += operation.Montant;
                    if (operation.Types == Mouvement.Debit) solde -= operation.Montant;
                }
                return solde;                
            }
        }
        protected Compte(string proprietaire, decimal solde)
        {
            Proprietaire = proprietaire;
            if (solde > 0) operations.Add(new Operation(solde, Mouvement.Credit));
        }

        public void Crediter(decimal montant)
        {
            Operation operation = new Operation(montant, Mouvement.Credit);
            operations.Add(operation);
        }

        public void Debiter(decimal montant)
        {
            Operation operation = new Operation(montant, Mouvement.Debit);
            operations.Add(operation);
        }
        
        public void Crediter(decimal montant, Compte compteADebiter)
        {
            Crediter(montant);
            compteADebiter.Debiter(montant);
        }

        public void Debiter(decimal montant, Compte compteACrediter)
        {
            Debiter(montant);
            compteACrediter.Crediter(montant);
        }

        public abstract decimal CalculBenefice();

        public decimal SoldeFinal()
        {
            return Solde + CalculBenefice();
        }

        public virtual void Information(bool displayOperations)
        {
            string typeDeCompte="";
            if (this is CompteCourant) typeDeCompte = "CCP";
            else if (this is CompteEpargne) typeDeCompte = "epargne";
            
            Console.WriteLine("Compte "+typeDeCompte+" appartenant à : "+Proprietaire+" ayant un solde de "+SoldeFinal()+"€.");
            if (operations.Count > 0 & displayOperations)
            {
                Console.WriteLine(operations.Count +" opération(s) : ");
                operations.ForEach(operation =>
                {
                    Console.WriteLine(operation.Types +" : "+ operation.Montant.ToString());
                });
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Compte otherCompte = obj as Compte;
            if (otherCompte != null)
            {
                return this.Solde.CompareTo(otherCompte.Solde);
            }
            throw new ArgumentException("Object is not a Compte");
        }
    }
}