using System;
using System.Collections.Generic;

namespace TP_Pendu
{
    internal class Program
    {

        private int test = 0;
        
        
        
        public static void Main(string[] args)
        {
            string rejouer = "o";
            string motCache = "";
            string motDecouvert = "";
            char guess;
            int coup = 10;
            
            //déclare une liste pour stocker les mots
            //string[] mots = new string[20]
            List<String> mots = new List<string>() {"bleu", "blanc", "rouge"};
            
            
            //aficher du texte
            Console.WriteLine("Bienvenu dans le jeu du pendu");

            while (rejouer.ToLower() == "o")
            {
                //récupère la valeur retournée par
                //ChoisirMot
                motCache = choisirMot(mots);
                motDecouvert = initEtoile(motCache);
                
                while (coup>0)
                {
                    Console.WriteLine("Lettre : ");
                    guess = Console.ReadLine().ToCharArray()[0];
                    if (isInWord(motCache, guess))
                    {
                        motDecouvert = replaceEtoile(motCache, motDecouvert, guess);
                        displayPendu(coup, motDecouvert, true);
                    }
                    else {
                        coup--;
                        displayPendu(coup, motDecouvert, false);
                    };
                }
                
                Console.WriteLine("Voulez vous rejouer? (o / n)");
                rejouer = Console.ReadLine();
            }
        }

        /// <summary>
        /// Génère un nombre aléatoire
        /// </summary>
        /// <param name="min">int mini</param>
        /// <param name="max">int maxi</param>
        /// <returns>nombre aléatoire compris entre min et max</returns>
        static int GetNombreAleatoire(int min, int max)
        {
            int nombre = 0;
            Random rdm = new Random();
            nombre = rdm.Next(min, max);
            return nombre;
        }

        static string choisirMot(List<String> listeDeMots)
        {
            string mot = "";
            int nbAleatoire = GetNombreAleatoire(0, listeDeMots.Count-1);
            return listeDeMots[nbAleatoire];
        }

        static string initEtoile(string mot)
        {
            string motCache = "";
            for (int i = 0; i < mot.Length; i++)
            {
                motCache += "*";
            }
            return motCache;
        }

        static bool isInWord(string motCache, char letter)
        {
            if (motCache.Contains(letter.ToString())) return true;
            return false;
        }
        
        static string replaceEtoile(string motCache, string motDecouvert, char lettre)
        {
            char[] motDecouvertSplit = motDecouvert.ToCharArray();
            for (int i=0; i < motCache.Length; i++)
            {
                if (lettre == motCache.ToCharArray()[i])
                {
                    motDecouvertSplit[i] = lettre;
                }
                else
                {
                    motDecouvertSplit[i] = '*';
                }
            }
            return motDecouvertSplit.ToString();
        }

        static void displayPendu(int coup, string motDecouvert, bool isInWord)
        {
            System.Console.Clear();
            Console.WriteLine(isInWord?"Bravo!":"Mauvais choix");
            Console.WriteLine("Coup restants = "+coup);
            Console.WriteLine("Mot découvert = "+motDecouvert);
            String[] pendues = new string[]
            {
                "      \n      \n      \n      \n      \n      \n",
                "      \n      \n      \n      \n      \n_|_   \n",
                "      \n |    \n |    \n |    \n |    \n_|_   \n",
                " ---- \n |    \n |    \n |    \n |    \n_|_   \n",
                " ---- \n |  | \n |    \n |    \n |    \n_|_   \n",
                " ---- \n |  | \n |  O \n |    \n |    \n_|_   \n",
                " ---- \n |  | \n |  O \n |  | \n |    \n_|_   \n",
                " ---- \n |  | \n |  O \n | /| \n |    \n_|_   \n",
                " ---- \n |  | \n |  O \n | /|\\\n |    \n_|_   \n",
                " ---- \n |  | \n |  O \n | /|\\\n |   \\\n_|_   \n",
                " ---- \n |  | \n |  O \n | /|\\\n | / \\\n_|_   \n",
            };
            Console.WriteLine(pendues[pendues.Length - coup]);
        }
    }
}