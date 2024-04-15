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


        _player.ForEach(player => { player.PlayerTurn(_deck); });
    }


    private void CheckGameStandards()
    {
        if (_player.Count < GameStandards.MinPlayers || _player.Count > GameStandards.MaxPlayers)
            throw new InvalidOperationException("Invalid amount of players");
    }

    private void ReturnMoney()
    {
        _player.ForEach(player =>
        {
            if (player.GetScore() > 21)
                player.Money -= 10;
            else if (_house.Score > 21)
                player.Money += 10;
            else if (player.GetScore() > _house.Score)
                player.Money += 10;
            else if (_house.Score > player.GetScore())
                player.Money -= 10;
        });
    }

    public void End()
    {
        Console.WriteLine("Game over");
        ReturnMoney();
        _player.ForEach(player => Console.WriteLine($"{player.Name} has {player.Money}"));
    }
}