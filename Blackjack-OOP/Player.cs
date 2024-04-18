using System.Text;

namespace Blackjack_OOP;
enum Action { Hit, Stand, Split, DoubleDown, None }


internal class Player(string name) : Participant
{
    public string Name { get; set; } = name;
    private double _money = 100;
    public double Bet { get; set; }
    public List<List<Card>> Hands { get; set; } = [];
    public int _currentHandIndex = 0;
    private bool hasSplit = false;

    private Action PlayerAction { get; set; } = Action.None;


    public double Money
    {
        get => _money;
        set
        {
            if (value < 0)  // Money cannot be negative
                _money = 0;
            else
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
        hasSplit = false;
        PlayerAction = Action.None;
        Hands = new List<List<Card>> { new() };
        _currentHandIndex = 0;
        RandomizeBet();
    }

    public void PlayerTurn()
    {
        Console.WriteLine($"{Name}'s turn.");
        PrintCurrentHand();

        // If the player has blackjack, skip their turn


        Console.ForegroundColor = ConsoleColor.Magenta;
        var random = new Random();
        var action = random.Next(0,
                !CanDoubleDown()  ? 1 : !CanSplit() ? 2 : 3
        );

        if (GetScore(GetCurrentHand()) > 17) action = CanSplit() ? 3 : 1;

        switch (action)
        {
            case 0:
                Console.WriteLine($"{Name} wants to draw a card.");
                PlayerAction = Action.Hit;

                break;
            case 1:
                Console.WriteLine($"{Name} wants to stand.");
                PlayerAction = Action.Stand;
                break;
            case 2:
                Console.WriteLine($"{Name} wants to double down.");
                PlayerAction = Action.DoubleDown;

                break;
            case 3:
                Console.WriteLine($"{Name} wants to split.");
                PlayerAction = Action.Split;
                break;

            default:
                Console.WriteLine("Invalid input");
                break;
        }

    }

    public List<Card> GetCurrentHand()
    {

        return Hands[_currentHandIndex];
    }

    public void DrawCard(Deck deck)
    {
        Hands[_currentHandIndex].Add(deck.Draw());

    }

    public bool HasSplit()
    {
        return hasSplit;
    }


    public Action GetAction()
    {
        return PlayerAction;
    }

    public bool CanSplit()
    {
        if (hasSplit) return false;
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
        if (_currentHandIndex < Hands.Count)
        {
            return GetScore(Hands[_currentHandIndex]) > 21; // If the player's score is over 21, they are busted
        }
        return false;
    }

    public void SplitHand()
    {
        if (hasSplit)
        {
            Console.WriteLine("You can only split once per round.");
            return;
        }

        if (Hands[_currentHandIndex].Count == 2 &&
            Hands[_currentHandIndex][0].Value == Hands[_currentHandIndex][1].Value)
        {
            var newHand = new List<Card> { Hands[_currentHandIndex][1] };
            Hands[_currentHandIndex].RemoveAt(1); // Remove one card from the original hand
            Hands.Add(newHand); // Add the new hand
            hasSplit = true;
        }
        else
        {
            Console.WriteLine("You can't split because your cards don't have the same value.");
        }
    }

    public void DoubleDown(Deck deck)
    {
        if (!CanDoubleDown()) return;
            Bet *= 2;
        DrawCard(deck);
        Stand();
        }

    public void Stand()
    {
        _currentHandIndex++;
    }


    private void PrintCurrentHand()
    {
        if (_currentHandIndex >= Hands.Count) return;
        Console.WriteLine($"Hand {_currentHandIndex + 1}:");
        foreach (var card in Hands[_currentHandIndex]) card.PrintCard();
        Console.WriteLine($"Score: {GetScore(Hands[_currentHandIndex])}");
    }
}