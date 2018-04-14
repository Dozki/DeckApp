using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckApp
{
    class Card
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }

        public enum CardNumberEnum
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public override string ToString()
        {
            return $"{CardType} {CardNumber}";
        }
    }
}
