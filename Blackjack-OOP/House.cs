namespace Blackjack_OOP;

internal class House : Participant
{
    public House()
    {
        Hand = new List<Card>();
    }

    public void TakeTurn(Deck deck, Player player)
    {
        for (var i = 0; i < player.Hands.Count; i++)
        {
            var playerStands = false;
            while (!player.IsBusted() && GetScore() != 21 && !playerStands)
            {
                player.PlayerTurn();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Dealer action:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(
                    "Y = Hit  / N = Stand / S = Split / D = Double down");
                Console.WriteLine("What would you like to do?");
                var response = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                switch (response?.ToUpper())
                {
                    case "Y":
                        if (!player.IsBusted())
                            player.DrawCard(deck);
                        else
                            Console.WriteLine("Player is busted");

                        break;
                    case "N":
                        player.Stand();
                        playerStands = true;
                        break;
                    case "S":
                        if (!player.CanSplit())
                        {
                            Console.WriteLine("You can't split");
                            continue;
                        }

                        player.SplitHand();

                        break;
                    case "D":
                        if (!player.CanDoubleDown())
                        {
                            Console.WriteLine("You can't double down");
                            continue;
                        }

                        player.DoubleDown(deck);

                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }


                Console.ResetColor();

                if (!player.IsBusted()) continue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player is busted\n");
                Console.ResetColor();
                break;
            }

            if (GetScore() != 21) continue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name} has blackjack!");
            Console.ResetColor();
        }
    }

    public void SelfTurn(Deck deck)
    {
        while (GetScore() < 17) DrawCard(deck);
        if (GetScore() <= 21) return;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dealer is busted\n");
        Console.ResetColor();
    }

    public void RoundReset()
    {
        Hand = new List<Card>();
    }

    public void PrintHand()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Dealer's hand:");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var card in Hand) card.PrintCard();

        Console.WriteLine($"Score: {GetScore()}\n");
    }


    public void DrawCard(Deck deck)
    {
        Hand.Add(deck.Draw());
    }
}