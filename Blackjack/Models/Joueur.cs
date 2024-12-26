using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
   
    public class Joueur
    {
        public string Nom { get; set; }
        public List<Carte> Main { get; private set; }
        public double Mise { get; set; }

        public Joueur(string nom)
        {
            Nom = nom;
            Main = new List<Carte>();
        }

        public void AjouterCarte(Carte c) => Main.Add(c);

        public int CalculerScore()
        {
            int score = 0;
            int asCount = 0;

            foreach (var carte in Main)
            {
                score += carte.Valeur;
                if (carte.Valeur == 1) asCount++;
            }

            while (asCount > 0 && score <= 11)
            {
                score += 10;
                asCount--;
            }

            return score;
        }
    }
}
