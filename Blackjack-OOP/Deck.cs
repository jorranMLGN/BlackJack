
namespace Blackjack_OOP
{
    internal class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
               
            foreach (var suit in Enum.GetValues(typeof(Card.EnumSuit)))
            {
                foreach (var face in Enum.GetValues(typeof(Card.EnumFace)))
                {
                    var card = new Card
                    {
                        Suit = suit.ToString(),
                        Face = face.ToString(),
                        Value = (int)face
                    };
                    _cards.Add(card);
                }
            }
            Shuffle();
        }

        public void Print()
        {
            foreach (var card in _cards)
            {
                card.Print();
            }
        }

        public void Shuffle()
        {
            var rnd = new Random();
            _cards = _cards.OrderBy(x => rnd.Next()).ToList();
        }

        public Card Draw()
        {
            var card = _cards.First();
            _cards.Remove(card);
            return card;
        }
    }
}
