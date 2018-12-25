using System;
using System.Collections.Generic;

namespace _01.Suffle_Cards
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>
            {
                new Card("2", Suit.Test1),
                new Card("3", Suit.Test2),
                new Card("4", Suit.Test3),
                //new Card("5", Suit.Test4),
            };

            if (cards.Count > 1)
            {
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    SuffleCards2(cards, i);
                }
            }

            PrintCards(cards);
        }

        private static void PrintCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }

        private static void SuffleCards2(List<Card> cards, int index)
        {
            int randomIndex = index;
            while (randomIndex == index)
            {
                randomIndex = random.Next(0, cards.Count);
            }
            Swap(index, randomIndex, cards);
        }

        private static void SuffleCards(List<Card> cards)
        {
            int index = random.Next(1, cards.Count);
            Swap(0, index, cards);
        }

        private static void Swap(int index1, int index2, List<Card> cards)
        {
            Card temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }
    }

    class Card
    {
        public string Face { get; set; }

        public Suit Suit { get; set; }

        public Card(string face, Suit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{this.Face} - {this.Suit}";
        }
    }

    enum Suit
    {
        Test1, Test2, Test3, Test4
    }
}
