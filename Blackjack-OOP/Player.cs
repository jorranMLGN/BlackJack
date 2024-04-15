using System.Text;

namespace Blackjack_OOP;

internal class Player : Participant
{
    public string Name { get; set; }
    private double _money = 100;
    public double Bet { get; set; }
    public List<List<Card>> Hands { get; set; } = new() { new List<Card>() };
    private int _currentHandIndex;

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
        Hands = new List<List<Card>> { Hand };
        _currentHandIndex = 0;
    }

    public double Money
    {
        get => _money;
        set
        {
            if (value < 0) throw new InvalidOperationException("Not enough money");
            _money = value;
        }
    }

    // Randomize bet amount between 1 and the player's money amount
    private void RandomizeBet()
    {
        // Minimum bet amount is 1
        const double minBet = 1;
        var random = new Random();
        var betRandom = random.NextDouble() * (Money - minBet) + minBet;
        Bet = Math.Round(betRandom, 2);
    }


    // Reset the player's hand and bet amount
    public void RoundReset()
    {
        Hands = new List<List<Card>> { new() };
        _currentHandIndex = 0;
        RandomizeBet();
    }

    public void PlayerTurn()
    {
        Console.WriteLine($"{Name}'s turn.");
        PrintCurrentHand(_currentHandIndex);

        // If the player has blackjack, skip their turn


        Console.ForegroundColor = ConsoleColor.Magenta;
        var random = new Random();
        var action = random.Next(0,
            !CanSplit() ? 1 : !CanDoubleDown() ? 2 : 3
        );

        if (GetScore() > 17) action = 1; // If the player has a score of 17 or higher, they will stand

        switch (action)
        {
            case 0:
                Console.WriteLine($"{Name} wants to draw a card.");
                break;
            case 1:
                Console.WriteLine($"{Name} wants to stand.");
                break;
            case 2:
                Console.WriteLine($"{Name} wants to split.");
                break;
            case 3:
                Console.WriteLine($"{Name} wants to double down.");
                break;
        }
    }

    public List<Card> GetCurrentHand()
    {
        if (_currentHandIndex >= Hands.Count) return new List<Card>();
        return Hands[_currentHandIndex];
    }

    public void DrawCard(Deck deck)
    {
        Hands[_currentHandIndex].Add(deck.Draw());
    }


    public bool CanSplit()
    {
        return Hands[_currentHandIndex].Count == 2 &&
               Hands[_currentHandIndex][0].Value == Hands[_currentHandIndex][1].Value;
    }

    public bool CanDoubleDown()
    {
        if (Money < Bet) return false; // Only allow doubling down if the player has enough money
        if (_currentHandIndex > 0) return false; // Only allow doubling down on the first hand (not the split hand
        return Hands[_currentHandIndex].Count == 2; // Only allow doubling down if the player has two cards
    }

    public bool IsBusted()
    {
        return GetScore() > 21; // If the player's score is over 21, they are busted
    }


    public void SplitHand()
    {
        var newHand = new List<Card> { Hands[_currentHandIndex][1] };
        Hands[_currentHandIndex].RemoveAt(1); // Remove one card from the original hand
        Hands.Add(newHand); // Add the new hand
    }

    public void DoubleDown(Deck deck)
    {
        DrawCard(deck);
        Stand();
    }

    public void Stand()
    {
        _currentHandIndex++;
    }


    public void PrintCurrentHand(int handIndex)
    {
        Console.WriteLine($"Hand {handIndex + 1}:");
        foreach (var card in Hands[handIndex]) card.PrintCard();
        Console.WriteLine($"Score: {GetScore()}");
    }
}