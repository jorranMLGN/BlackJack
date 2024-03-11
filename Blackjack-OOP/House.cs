namespace Blackjack_OOP
{
    internal class House
    {
        public List<Card> Hand { get; set; }
        public int Score { get; set; }

        public House()
        {
            Hand = new List<Card>();
            Score = 0;
        }

        public void DrawCard(Deck deck)
        {
            var card = deck.Draw();
            Hand.Add(card);
            Score += card.Value;
        }

        public void PrintHand()
        {
            Console.WriteLine("House's hand:");
            foreach (var card in Hand)
            {
                card.Print();
            }
        }

        public void PrintScore()
        {
            Console.WriteLine(Score);
        }
    }
}
