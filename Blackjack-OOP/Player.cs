
using System.Runtime.InteropServices;

namespace Blackjack_OOP
{
    internal class Player(string name)
    {
        public string Name { get; set; } = name;
        public List<Card> Hand { get; private set; } = [];
        public List<List<Card>> Hands { get; set; } = new List<List<Card>>();
        public int Score { get; set; } = 0;

        private int _currentHandIndex = 0;



        public void DrawCard(Deck deck)
        {
            var card = deck.Draw();
                Hands[_currentHandIndex].Add(card);
                Score += card.Value;
        }
        public void SplitHand()
        {
            if (Hands[_currentHandIndex].Count == 2 && Hands[_currentHandIndex][0].Value == Hands[_currentHandIndex][1].Value)
            {
                List<Card> newHand = new List<Card> { Hands[_currentHandIndex][1] };
                Hands[_currentHandIndex].RemoveAt(1); // Remove one card from the original hand
                Hands.Add(newHand); // Add the new hand


            }
            else
            {
                throw new InvalidOperationException("Cannot split hand.");
            }
        }

        public void Stand()
        {
            _currentHandIndex++;
        }


        public void PrintAllHand()
        {
            foreach (var hand in Hands)
            {
                foreach (var card in hand)
                {
                    card.Print();
                }
                Console.WriteLine();
            }
        }

        public void PrintScore()
        {
            Console.WriteLine(Score);
        }




        public void PrintHand(int handIndex)
        {
            foreach (var card in Hands[handIndex])
            {
                card.Print();
            }
        }

        public void PrintScore(int handIndex)
        {
            Console.WriteLine(Hands[handIndex].Sum(x => x.Value));
        }

        public void PrintScoreAll()
        {
            foreach (var hand in Hands)
            {
                Console.WriteLine(hand.Sum(x => x.Value));
            }
        }

        public void PrintHandAll()
        {
            foreach (var hand in Hands)
            {
                foreach (var card in hand)
                {
                    card.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
