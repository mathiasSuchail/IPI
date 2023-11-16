using System;
using System.Reflection.Emit;

namespace TP_Gestion_Compte
{
    public class Operation
    {
        public decimal Montant
        {
            get;
            set;
        }

        public Mouvement Types
        {
            get;
            set;
        }

        public Operation(decimal montant, Mouvement types)
        {
            Montant = montant;
            Types = types;
        }
    }
}