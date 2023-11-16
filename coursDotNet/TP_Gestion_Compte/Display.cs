using System;
using System.Collections.Generic;

namespace TP_Gestion_Compte
{
    
    public class Display
    {
        private GestionDeComptes gestionDeComptes;
        
        private void DisplayMenu(){
            Console.WriteLine(
                "Que souhaitez vous faire?\n"+
                " 1 : Créer un compte courant.\n"+
                " 2 : Créer un compte épargne.\n"+
                " 3 : Créditer un compte.\n"+
                " 4 : Débiter un compte.\n"+
                " 5 : Effectuer un virement.\n"+
                " 6 : Afficher la liste des comptes.\n" +
                " 7 : Trier les comptes.\n" +
                " 8 : Quitter.");
        }

        public void LaunchApp(GestionDeComptes gestionDeComptes)
        {
            this.gestionDeComptes = gestionDeComptes;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayMenu();
                Console.WriteLine("Tapez le numéro correspondant à votre choix : ");
                int choice=0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    choice = 0;
                }
                
                
                Console.Clear();
                switch (choice)
                {
                    case 1:
                    {
                        CreerCompte(TypeDeComptes.Courant);
                        break;
                    }
                    case 2:
                    {
                        CreerCompte(TypeDeComptes.Epargne);
                        break;
                    }
                    case 3:
                    {
                        DebiterOuCrediter(Mouvement.Credit);
                        break;
                    }
                    case 4:
                    {
                        DebiterOuCrediter(Mouvement.Debit);
                        break;
                    }
                    case 5:
                    {
                        Virement();
                        break;
                    }
                    case 6:
                    {
                        AfficherComptes();
                        break;
                    }
                    case 7:
                    {
                        TrierComptes();
                        break;
                    }
                    case 8:
                    {
                        Console.WriteLine("Bonne journée à vous!");
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.Clear();
                        Error("La saisie ne correspond à aucun choix valide");
                        break;
                    }
                }
            }

        }

        private void TrierComptes()
        {
            gestionDeComptes.Trier();
            OperationReussie("Les comptes ont été triés par soldes croissants");
        }

        private void AfficherComptes()
        {
            Console.Clear();
            bool exit;
            do
            {
                exit = true;
                Console.WriteLine("Quelle type de comptes souhaitez vous afficher?\n" +
                                  " 1 : Comptes courants.\n" +
                                  " 2 : Comptes epargnes.\n" +
                                  " 3 : Tout\n" +
                                  "Choix : ");
                int choix = 0;
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    choix = 0;
                }
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        gestionDeComptes.AfficherComptesCourant();
                        break;
                    case 2:
                        gestionDeComptes.AfficherCompteEpargne();
                        break;
                    case 3:
                        gestionDeComptes.AfficherTousLesComptes(false);
                        break;
                    default:
                        Error("Choix non valide.");
                        exit = false;
                        break;
                }
            } while (!exit);
            OperationReussie("Appuyer sur entrer pour revenir à l'accueil");
        }

        private void Virement()
        {
            decimal montant = DebiterOuCrediter(Mouvement.Debit,0, 0, false);
            Console.Clear();
            DebiterOuCrediter(Mouvement.Credit, montant, 0, false);
            Console.Clear();
            OperationReussie("Virement effectué avec succès.");
        }

        private decimal DebiterOuCrediter(Mouvement mouvement, decimal montant = 0, int numeroCompte = 0, bool display=true)
        {
            bool exit;
            if(numeroCompte==0) do
            {
                exit = true;
                gestionDeComptes.AfficherTousLesComptes(true);
                Console.WriteLine("Numéro de compte à " + ((mouvement == Mouvement.Credit) ? "créditer :" : "débiter :"));
                try
                {
                    numeroCompte = Convert.ToInt32(Console.ReadLine());
                    if (numeroCompte > gestionDeComptes.nombreDeComptes()) throw new Exception("");
                }
                catch (Exception e)
                {
                    Error("Mauvais choix");
                    exit = false;
                }
            } while (!exit);
            Compte compte = gestionDeComptes.getCompte(numeroCompte);
            
            if(montant==0)do
            {
                exit = true;
                Console.Clear();
                Console.WriteLine("Compte n°"+numeroCompte+" selectioné.");
                Console.WriteLine("Montant : ");
                try
                {
                    montant = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Error("Montant non valide, veuillez reessayer");
                    exit = false;
                }
                
            } while (!exit);

            
            if(mouvement==Mouvement.Credit)
            {
                compte.Crediter(montant);
                if(display) OperationReussie("Le compte à bien été crédité");
            }
            else if (mouvement == Mouvement.Debit)
            {
                compte.Debiter(montant);
                if(display) OperationReussie("Le compte à bien été débité");
            }

            return montant;
        }

        private void CreerCompte(TypeDeComptes typeDeComptes)
        {
            Console.WriteLine("Nom du propriétaire : ");
            string proprietaire = Console.ReadLine();
            Console.WriteLine("Solde initial : ");
            decimal solde = Convert.ToDecimal(Console.ReadLine());
            
            if (typeDeComptes == TypeDeComptes.Courant)
            {
                Console.WriteLine("Découvert autorisé : ");
                decimal decouvert = Convert.ToDecimal(Console.ReadLine());
                gestionDeComptes.AjouterCompte(new CompteCourant(decouvert, proprietaire, solde));
            }
            else if (typeDeComptes == TypeDeComptes.Epargne)
            {
                Console.WriteLine("Abondement : ");
                decimal abondement = Convert.ToDecimal(Console.ReadLine());
                gestionDeComptes.AjouterCompte(new CompteEpargne(abondement, proprietaire, solde));
            }
            OperationReussie("Création du compte effectuée avec succès. Appuyer sur entrer pour revenir à l'accueil");
        }

        private void OperationReussie(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }
        private void Error(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }
    }

}