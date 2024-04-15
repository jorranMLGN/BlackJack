using System.Text;

namespace Blackjack_OOP;

internal class Player(string name)
{
    public string Name { get; set; } = name;
    private double _money = 100;

    public double Money
    {
        get => _money;
        set
        {
            if (value < 0) throw new InvalidOperationException("Not enough money");
            _money = value;
        }
    }

    public List<Card> Hand { get; private set; } = [];
    private List<List<Card>> Hands { get; set; } = new() { new List<Card>() };
    private int _currentHandIndex = 0;


    public void PlayerTurn(Deck deck)
    {
        Console.WriteLine("Player's turn");
        while (_currentHandIndex < Hands.Count)
        {
            PrintCurrentHand(_currentHandIndex);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Stand");
            if (CanSplit()) Console.WriteLine("3. Split");
            if (CanDoubleDown()) Console.WriteLine("4. Double Down");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    DrawCard(deck);
                    break;
                case "2":
                    Stand();
                    break;
                case "3":
                    SplitHand();
                    break;
                case "4":
                    DoubleDown(deck);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        DisplayHands();

        // RandomAlgorithm(Hands[_currentHandIndex]);
    }

    public void DrawCard(Deck deck)
    {
        var card = deck.Draw();
        Hands[_currentHandIndex].Add(card);
    }


    private bool CanSplit()
    {
        return Hands[_currentHandIndex].Count == 2 &&
               Hands[_currentHandIndex][0].Value == Hands[_currentHandIndex][1].Value;
    }

    private bool CanDoubleDown()
    {
        return Hands[_currentHandIndex].Count == 2;
    }

    public bool IsBusted()
    {
        return GetScore() > 21;
    }


    public void SplitHand()
    {
        if (CanSplit())
        {
            var newHand = new List<Card> { Hands[_currentHandIndex][1] };
            Hands[_currentHandIndex].RemoveAt(1); // Remove one card from the original hand
            Hands.Add(newHand); // Add the new hand
        }
        else
        {
            throw new InvalidOperationException("Cannot split hand.");
        }
    }

    public void DoubleDown(Deck deck)
    {
        if (CanDoubleDown())
        {
            DrawCard(deck);
            Stand();
        }
        else
        {
            throw new InvalidOperationException("Cannot double down.");
        }
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


    public int GetScore()
    {
        var score = 0;
        var aceCount = 0;
        foreach (var card in Hands[_currentHandIndex])
        {
            if (card.Value == 1) aceCount++;
            score += card.Value;
        }

        while (score < 17 && aceCount > 0)
        {
            score += 10;
            aceCount--;
        }

        return score;
    }


    public string DisplayHands()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Hands.Count; i++)
        {
            sb.Append($"Hand {i + 1}: ");
            foreach (var card in Hands[i]) sb.Append($"{card.PrintCard()} ");
            sb.AppendLine();
        }

        return new StringBuilder().AppendJoin(" ", Hands.Select(x => x.Sum(y => y.Value))).ToString();
    }

    public void RandomAction(List<Card> hands)
    {
        var random = new Random();
        var action = random.Next(0, 3);
        switch (action)
        {
            case 0:
                // DrawCard( );
                break;
            case 1:
                Stand();
                break;
            case 2:
                SplitHand();
                break;
            case 3:
                // DrawCard(hands);
                break;
        }
    }
}