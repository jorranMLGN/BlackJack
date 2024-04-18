namespace Blackjack_OOP;

internal class Deck
{
    private List<Card> _cards;

    public Deck(List<Card> cards)
    {
        _cards = cards;
        CreateDeck();
    }


    public Card Draw()
    {
        if (_cards.Count == 0) CreateDeck();

        var card = _cards.First();
        _cards.Remove(card);
        return card;
    }

    private void Shuffle()
    {
        var rnd = new Random();
        _cards = _cards.OrderBy(x => rnd.Next()).ToList();
    }

    private void CreateDeck()
    {
        _cards = [];
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        foreach (Face face in Enum.GetValues(typeof(Face)))
        {
            var card = new Card(suit, face);
            _cards.Add(card);
        }

        Shuffle();
    }
}