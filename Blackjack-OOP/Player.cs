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
    public List<List<Card>> Hands { get; set; } = new() { new List<Card>() };
    private int _currentHandIndex = 0;


    public void PlayerTurn(Deck deck)
    {
        Console.WriteLine("Player's turn");
        DisplayHands();

        RandomAlgorithm(Hands[_currentHandIndex]);
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
    
    
    public void SplitHand()
    {
        if (Hands[_currentHandIndex].Count == 2 &&
            Hands[_currentHandIndex][0].Value == Hands[_currentHandIndex][1].Value)
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

    public void Stand()
    {
        _currentHandIndex++;
    }


    public void PrintCurrentHand(int handIndex)
    {
        Console.WriteLine($"Hand {handIndex + 1}:");
        foreach (var card in Hands[handIndex]) card.PrintCard();
    }

    public int GetScore()
    {
        return Hands[_currentHandIndex].Sum(x => x.Value);
    }

    public void PrintScore(int handIndex)
    {
        Console.WriteLine(Hands[handIndex].Sum(x => x.Value));
    }


    public string DisplayHands()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Hands.Count; i++)
        {
            sb.Append($"Hand {i + 1}: ");
            foreach (var card in Hands[i]) sb.Append($"{card} ");
            sb.Append("\n");
        }

        return sb.ToString();
    }

    public void RandomAction(List<Card> hands)
    {
        var random = new Random();
        var action = random.Next(0, 3);
        switch (action)
        {
            case 0:
                DrawCard(hands);
                break;
            case 1:
                Stand();
                break;
            case 2:
                SplitHand();
                break;
            case 3:
                DrawCard(hands);
                break;
        }
    }
}