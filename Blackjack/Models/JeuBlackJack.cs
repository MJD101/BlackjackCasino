using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    

    public class JeuBlackJack
    {
        private List<Joueur> joueurs;
        private Croupier croupier;
        private PaquetDeCartes paquet;

        public JeuBlackJack()
        {
            joueurs = new List<Joueur>();
            croupier = new Croupier();
            paquet = new PaquetDeCartes();
        }

        public void InitialiserJeu()
        {
            paquet.Melanger();

            Console.Write("Entrez le nombre de joueurs: ");
            int nbJoueurs = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.Write($"Entrez le nom du joueur {i + 1}: ");
                string nom = Console.ReadLine();
                joueurs.Add(new Joueur(nom));
            }
        }

        public void DistribuerCartes()
        {
            foreach (var joueur in joueurs)
            {
                joueur.AjouterCarte(paquet.TirerCarte());
                joueur.AjouterCarte(paquet.TirerCarte());
            }

            croupier.Main.Add(paquet.TirerCarte());
        }

        public void DeterminerGagnant()
        {
            Console.WriteLine("-- Résultats --");

            int scoreCroupier = croupier.CalculerScore();
            Console.WriteLine($"Score du Croupier: {scoreCroupier}");

            foreach (var joueur in joueurs)
            {
                int scoreJoueur = joueur.CalculerScore();
                Console.WriteLine($"{joueur.Nom}: {scoreJoueur}");

                if (scoreJoueur > 21)
                {
                    Console.WriteLine("Dépassé 21. Vous perdez!");
                }
                else if (scoreJoueur > scoreCroupier || scoreCroupier > 21)
                {
                    Console.WriteLine("Vous gagnez!");
                }
                else
                {
                    Console.WriteLine("Vous perdez!");
                }
            }
        }

        public void Jouer()
        {
            InitialiserJeu();
            DistribuerCartes();

            foreach (var joueur in joueurs)
            {
                Console.WriteLine($"-- Tour de {joueur.Nom} --");
                while (true)
                {
                    Console.WriteLine($"Main: {string.Join(", ", joueur.Main)}");
                    Console.Write("Action (carte/servi): ");
                    string action = Console.ReadLine().ToLower();

                    if (action == "carte")
                    {
                        joueur.AjouterCarte(paquet.TirerCarte());
                        if (joueur.CalculerScore() > 21)
                        {
                            Console.WriteLine("Dépassé 21!");
                            break;
                        }
                    }
                    else if (action == "servi")
                    {
                        break;
                    }
                }
            }

            croupier.Jouer(paquet);
            DeterminerGagnant();
        }
    }
}
