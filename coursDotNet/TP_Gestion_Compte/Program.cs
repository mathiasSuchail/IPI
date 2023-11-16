using System;
using System.Collections.Generic;

namespace TP_Gestion_Compte
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Display display = new Display();
            display.LaunchApp(InitData());
        }

        public static GestionDeComptes InitData()
        {
            GestionDeComptes gestionDeComptes = new GestionDeComptes();
            gestionDeComptes.AjouterCompte(new CompteCourant(50, "Mathias", 100));
            gestionDeComptes.AjouterCompte(new CompteCourant(100, "Paul"));
            return gestionDeComptes;
        }

        private static void Test()
        {
            List<Compte> Nicolas = new List<Compte>();
            List<Compte> Jeremie = new List<Compte>();
            Nicolas.Add(new CompteCourant(2000, "Nicolas"));
            Jeremie.Add(new CompteCourant(500, "Jérémie"));
            Nicolas.Add(new CompteEpargne(2.5M, "Nicolas"));

            GestionDeComptes gestionDeComptes = new GestionDeComptes();
            
            foreach (Compte compte in Nicolas)
            {
                gestionDeComptes.AjouterCompte(compte);
            }
            foreach (Compte compte in Jeremie)
            {
                gestionDeComptes.AjouterCompte(compte);
            }

            Nicolas[0].Crediter(1000);
            Nicolas[1].Crediter(200);
            Nicolas[0].Debiter(50);
            Nicolas[0].Crediter(100);
            Nicolas[1].Crediter(100);
            Jeremie[0].Debiter(500);
            Jeremie[0].Debiter(200, Nicolas[0]);
            gestionDeComptes.Trier();
            gestionDeComptes.AfficherComptesCourant();
            gestionDeComptes.AfficherCompteEpargne();
        }
        
        private static void initData(){}
    }
}