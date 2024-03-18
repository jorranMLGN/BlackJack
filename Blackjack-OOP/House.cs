namespace Blackjack_OOP;

internal class House
{
    public List<Card> Hand { get; set; }
    public int Score { get; set; }


    public void TakeTurn(Deck deck, Player player)
    {
        Console.WriteLine("House's turn");
        Console.WriteLine("Y = Give card  / N = Pass / S = Split / D = Double Down");
        Console.WriteLine("What would you like to do?");
        var response = Console.ReadLine();
        switch (response)
        {
            case "Y":
                DrawCard(deck);
                break;
            case "N":
                break;
            case "S":
                player.SplitHand();
                break;
            case "D":
                DrawCard(deck);
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }


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
        foreach (var card in Hand) card.PrintCard();
    }

    public void PrintScore()
    {
        Console.WriteLine(Score);
    }
}