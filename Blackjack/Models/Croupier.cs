using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    
    public class Croupier
    {
        public List<Carte> Main { get; private set; }

        public Croupier()
        {
            Main = new List<Carte>();
        }

        public void Jouer(PaquetDeCartes paquet)
        {
            while (CalculerScore() < 17)
            {
                Main.Add(paquet.TirerCarte());
            }
        }

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
