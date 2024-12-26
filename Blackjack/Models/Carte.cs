using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    
    public class Carte
    {
        public int Valeur { get; set; }
        public string Symbole { get; set; }

        public override string ToString() => $"{Symbole} ({Valeur})";
    }
}
