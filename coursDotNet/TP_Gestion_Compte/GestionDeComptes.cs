using System;
using System.Collections.Generic;

namespace TP_Gestion_Compte
{
    public class GestionDeComptes
    {
        private List<Compte> comptes = new List<Compte>();


        public void AjouterCompte(Compte compte)
        {
            this.comptes.Add(compte);
        }

        public void AfficherComptesCourant()
        {
            foreach (Compte compte in comptes)
            {
                if (compte is CompteCourant)
                {
                    compte.Information(false);
                }
            }
        }

        public void AfficherCompteEpargne()
        {
            foreach (Compte compte in comptes)
            {
                if (compte is CompteEpargne)
                {
                    compte.Information(false);
                }
            }
        }

        public void Trier()
        {
            comptes.Sort();
        }

        public void AfficherTousLesComptes(bool displayIndex)
        {
            for (int i=0; i<comptes.Count;i++)
            {
                if(displayIndex) Console.WriteLine("Numéro de compte : "+ (i + 1));
                comptes[i].Information(false);
            }
        }

        public int nombreDeComptes()
        {
            return comptes.Count;
        }

        public Compte getCompte(int numeroCompte)
        {
            return comptes[numeroCompte-1];
        }
    }
}