using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckApp
{
    class Deck
    {
        private static List<Card> cards = new List<Card>();
        private static Random rng = new Random();
        static void Main(string[] args)
        {
            bool option = true;          

            CreateDeck();           
            while (option)
            {                
                Console.WriteLine("1. Take first card");
                Console.WriteLine("2. Check how many left");
                Console.WriteLine("3. Shuffle deck");
                Console.WriteLine("4. New deck");
                Console.WriteLine("5. Exit");
                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(TakeFirst());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(CheckDeck());
                        break;
                    case 3:
                        ShuffleDeck(cards);
                        Console.Clear();
                        Console.WriteLine("Shuffled");
                        break;
                    case 4:
                        cards.Clear();
                        CreateDeck();
                        Console.Clear();
                        Console.WriteLine("New deck created");
                        break;
                    case 5:
                        option = false;                        
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        public static void ShuffleDeck<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void CreateDeck()
        {
           cards.AddRange(
           new[] { "Club", "Diamond", "Heart", "Spade" }
               .SelectMany(
                   type => Enum.GetValues(typeof(Card.CardNumberEnum)).Cast<Card.CardNumberEnum>(),
                   (type, number) => new Card { CardNumber = number.ToString(), CardType = type })
               .ToArray());
        }

        public static string TakeFirst()
        {
            if (!cards.Any())
                return "No more cards in the deck";
            else
            {
                var cardReturn = cards.First();
                cards.Remove(cardReturn);
                return cardReturn.ToString();
            }
        }

        public static string CheckDeck()
        {
            return cards.Count().ToString();
        }
    }
}
