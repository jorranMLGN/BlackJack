namespace Blackjack_OOP;

internal class House : Participant
{
    public List<Card> Hand { get; set; }

    public House()
    {
        Hand = new List<Card>();
    }

    public void TakeTurn(Deck deck, Player player)
    {
        var wrongInput = false;
        do
        {
            var playerStands = false;
            if ( !wrongInput)             player.PlayerTurn();
            wrongInput = false;

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
                        if (player.GetAction() != Action.Hit)
                        {
                            Console.WriteLine("This action is not allowed!");
                            wrongInput = true;
                            return;
                        }
                        player.DrawCard(deck);

                        break;
                    case "N":
                        if (player.GetAction() != Action.Stand)
                        {
                            Console.WriteLine("This action is not allowed!");
                            wrongInput = true;

                            return;
                        }

                        player.Stand();
                        playerStands = true;
                        break;
                    case "S":

                        if (player.GetAction() != Action.Split)
                        {
                            Console.WriteLine("This action is not allowed!");
                            wrongInput = true;

                            return;
                        }

                        if (!player.CanSplit())
                        {
                            Console.WriteLine("You can't split");
                            wrongInput = true;

                            return;
                        }

                        player.SplitHand();

                        break;
                    case "D":
                        if (player.GetAction() != Action.DoubleDown)
                        {
                            Console.WriteLine("This action is not allowed!");
                            return;
                        }
                        if (!player.CanDoubleDown())
                        {
                            Console.WriteLine("You can't double down");
                            return;
                        }

                        player.DoubleDown(deck);

                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        return;
                }


                Console.ResetColor();


                if (player.IsBusted() )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player is busted\n");
                    Console.ResetColor();
                    break;
                }

                if (player.GetAction() == Action.Stand) break;



                if (player.GetCurrentHand().Count == 2 && GetScore(player.GetCurrentHand()) == 21)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{player.Name} has blackjack!");
                    Console.ResetColor();
                    break;
                }

        } while (player.GetAction() != Action.Stand || !player.IsBusted() && !player.HasSplit());
        if (player.HasSplit() && player._currentHandIndex < player.Hands.Count )
        {
            Console.WriteLine($"{player.Name}'s turn for second hand.");
            TakeTurn(deck, player);
        }
    }

    public void SelfTurn(Deck deck)
    {
        while (GetScore(Hand) < 17) DrawCard(deck);
        if (GetScore(Hand) <= 21) return;
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

        Console.WriteLine($"Score: {GetScore(Hand)}\n");
    }


    public void DrawCard(Deck deck)
    {
        Hand.Add(deck.Draw());
    }
}