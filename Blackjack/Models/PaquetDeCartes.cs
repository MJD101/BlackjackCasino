using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack.Models
{

    public class PaquetDeCartes
    {
        private List<Carte> cartes;

        public PaquetDeCartes()
        {
            cartes = new List<Carte>();
            string[] symboles = { "Coeur", "Carreau", "Trèfle", "Pique" };

            foreach (var symbole in symboles)
            {
                for (int i = 1; i <= 13; i++)
                {
                    int valeur = i > 10 ? 10 : i;
                    cartes.Add(new Carte { Valeur = valeur, Symbole = symbole });
                }
            }
        }



        public void Melanger()
        {
            var rand = new Random();
            for (int i = Carte.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = cartes[i];
                cartes[i] = cartes[j];
                cartes[j] = temp;
            }
        }

        public Carte TirerCarte()
        {
            if (cartes.Count == 0) throw new InvalidOperationException("Le paquet est vide!");
            var carte = cartes[0];
            cartes.RemoveAt(0);
            return carte;
        }

    }
}
