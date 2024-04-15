namespace Blackjack_OOP;

internal class GameLogic
{
    private readonly Deck _deck;
    private readonly List<Player> _player;
    private readonly House _house;

    public GameLogic()
    {
        _player = new List<Player>();
        _deck = new Deck();
        _house = new House();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("█▄▄ █░░ ▄▀█ █▀▀ █▄▀ ░░█ ▄▀█ █▀▀ █▄▀\n█▄█ █▄▄ █▀█ █▄▄ █░█ █▄█ █▀█ █▄▄ █░█\n");
        Console.ResetColor();
        SetupPlayer();
    }


    private void SetupPlayer()
    {
        int playerAmount;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Enter the amount of players and their names to start the game.\n");
        Console.ResetColor();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var input = Console.ReadLine()!;
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Please enter a valid number of players");
            else
                try
                {
                    playerAmount = Convert.ToInt32(input);
                    if (playerAmount < 1)
                        Console.WriteLine("Please enter a valid number of players");
                    else
                        Console.ResetColor();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number of players");
                }
        }


        for (var i = 0; i < playerAmount; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Enter name for Player {i + 1} \n");
            Console.ForegroundColor = ConsoleColor.Gray;
            var player = new Player(Console.ReadLine()!);
            _player.Add(player);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("All players have been added. Press any key to start the game.\n");
    }

    public void Start()
    {
        foreach (var player in _player)
        {
            if (player.Money < 1)
            {
                _player.Remove(player);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{player.Name} has no money left and has been removed from the game.\n");
                return;
            }


            player.RoundReset();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{player.Name} has {Math.Round(player.Money, 2)
            } left. Bet: {Math.Round(player.Bet, 2)}\n");
        }

        _house.RoundReset();

        for (var i = 0; i < 2; i++)
        {
            foreach (var player in _player) player.DrawCard(_deck);
            _house.DrawCard(_deck);
        }

        _house.PrintHand();

        foreach (var player in _player) _house.TakeTurn(_deck, player);

        _house.SelfTurn(_deck);
    }


    private void ReturnMoney()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        _player.ForEach(player =>
        {
            foreach (var hand in player.Hands)
            {
                if (player.GetScore() == 21)
                {
                    player.Money += player.Bet * 1.5;
                    Console.WriteLine($"{player.Name} has Blackjack and has won");
                }
                else if (player.GetScore() > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    player.Money -= player.Bet;
                    Console.WriteLine($"{player.Name} has Lost");
                }

                else if (_house.GetScore() > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    player.Money += player.Bet;
                    Console.WriteLine($"{player.Name} has Won");
                }
                else if (player.GetScore() > _house.GetScore())
                {
                    player.Money += player.Bet;
                    Console.WriteLine($"{player.Name} has Won");
                }
                else if (_house.GetScore() > player.GetScore())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    player.Money -= player.Bet;
                    Console.WriteLine($"{player.Name} has Lost");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;


                Console.WriteLine($"{player.Name} now has {Math.Round(player.Money, 2)}");
            }
        });
    }

    public void End()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("Game over! Here are the results:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("House had:");
        _house.PrintHand();
        ReturnMoney();
    }
}