using System.Runtime.CompilerServices;

namespace TP_Gestion_Ecole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Eleve eleve1 = new Eleve("Suchail", "Mathias", 24);
            Professeur professeur1 = new Professeur("Dupont", "Pierre", 45, 1300);
            
            
            
            
            eleve1.ajouterMoyenne(12.7);
            eleve1.ajouterMoyenne(15.2);
            eleve1.Afficher();

            professeur1.Afficher();

            Ecole ecole1 = new Ecole("ecole1", "3 chemin de la pomme", 123876.54);
            
            ecole1.AjouterEleve(eleve1);
            ecole1.AjouterProfesseur(professeur1);
            ecole1.Afficher();
            
            
        }

        void creerEleve(string nom, string prenom, int age, Ecole ecole)
        {
            Eleve eleve = new Eleve(nom, prenom, age);
            ecole.AjouterEleve(eleve);
        }

        void creerProfesseur(string nom, string prenom, int age, int salaire, Ecole ecole)
        {
            Professeur professeur = new Professeur(nom, prenom, age, salaire);
            ecole.AjouterProfesseur(professeur);
        }
    }
}