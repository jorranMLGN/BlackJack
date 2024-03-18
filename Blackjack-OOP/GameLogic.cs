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

        Console.WriteLine("Welcome to:");
        Console.WriteLine("█▄▄ █░░ ▄▀█ █▀▀ █▄▀ ░░█ ▄▀█ █▀▀ █▄▀\n█▄█ █▄▄ █▀█ █▄▄ █░█ █▄█ █▀█ █▄▄ █░█\n");
        SetupPlayer();
    }


    private void SetupPlayer()
    {
        int playerAmount;
        string input;

        Console.WriteLine("Enter the amount of players and their names to start the game.\n");

        while (true)
        {
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Please enter a valid number of players");
            else
                try
                {
                    playerAmount = Convert.ToInt32(input);
                    if (playerAmount < 1)
                        Console.WriteLine("Please enter a valid number of players");
                    else
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number of players");
                }
        }


        for (var i = 0; i < playerAmount; i++)
        {
            Console.WriteLine($"Enter name for Player {i + 1} \n");
            var player = new Player(Console.ReadLine());
            _player.Add(player);
            Console.WriteLine($"Added {player.Name}.\n");
        }
    }

    public void Start()
    {
        for (var i = 0; i < 2; i++)
        {
            foreach (var player in _player) player.DrawCard(_deck);
            _house.DrawCard(_deck);
        }

        Console.WriteLine("Player's turn:");
        PlayerTurn();
    }


    private void PlayerTurn()
    {
        _player.ForEach(player => { });
    }


    private void CheckGameStandards()
    {
        if (_player.Count < GameStandards.MinPlayers || _player.Count > GameStandards.MaxPlayers)
            throw new InvalidOperationException("Invalid amount of players");
    }


    public void End()
    {
        _player.ForEach(player =>
        {
            Console.WriteLine(player + " hand:");
            player.DisplayHands();
            player.GetScore();
            _house.PrintHand();
            _house.PrintScore();

            if (player.GetScore() > 21)
                Console.WriteLine("Player busts! House wins!");
            else if (_house.Score > 21)
                Console.WriteLine("House busts! Player wins!");
            else if (player.GetScore() > _house.Score)
                Console.WriteLine("Player wins!");
            else if (_house.Score > player.GetScore())
                Console.WriteLine("House wins!");
            else
                Console.WriteLine("It's a tie!");
        });
    }
}