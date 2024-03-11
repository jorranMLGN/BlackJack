namespace Blackjack_OOP
{
    internal class GameLogic
    {
        private readonly Deck _deck;
        private readonly List<Player> _player;
        private readonly House _house;

        public GameLogic()
        {
            _player = new List<Player>();

            Console.WriteLine("Welcome to:");
            Console.WriteLine("█▄▄ █░░ ▄▀█ █▀▀ █▄▀ ░░█ ▄▀█ █▀▀ █▄▀\n█▄█ █▄▄ █▀█ █▄▄ █░█ █▄█ █▀█ █▄▄ █░█");
            Console.WriteLine();
            Console.WriteLine("Enter amount of players: (Enter 1 Player)");

            int playerAmount;
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid number of players");
                }
                else
                {
                    try
                    {
                        playerAmount = Convert.ToInt32(input);
                        if (playerAmount < 1)
                        {
                            Console.WriteLine("Please enter a valid number of players");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number of players");
                    }
                }
            }


            for (int i = 0; i < playerAmount; i++)
            {

                Console.WriteLine("Enter name for Player " + (i+1) );
                Player player = new Player(Console.ReadLine());
                _player.Add(player);
                Console.WriteLine("Player Added, Press Enter to continue.");
                Console.ReadLine();


            }


            _deck = new Deck();
            _deck.Shuffle();
            _house = new House();
        }


        public void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var player in _player)
                {
                    player.DrawCard(_deck);
                }
                _house.DrawCard(_deck);
            }
            Console.WriteLine("Player's turn:");
            PlayerTurn();
        }

        

        public void PlayerTurn()
        {
            _player.ForEach(player =>
            
            {
                Console.WriteLine(player.Name + "'s turn:");
                Console.WriteLine();
                Console.WriteLine("Your hand:");

                while (player.Score < 21)
                {
                    player.PrintAllHand();
                    player.PrintScore();
                    Console.WriteLine();

                    Console.WriteLine("House hand:");
                    _house.PrintHand();
                    _house.PrintScore();
                    Console.WriteLine();

                    Console.WriteLine("Do you want to draw another card? (y/n)");
                    var response = Console.ReadLine();
                    if (response == "y")
                    {
                        player.DrawCard(_deck);
                    }else if(response == "s")
                    {
                          player.SplitHand();
                        player.PrintScore();
                        
                        Console.WriteLine();
                        Console.WriteLine("Your hand:");
                        player.PrintAllHand();
                        player.PrintScore();
                        Console.WriteLine();

                    }
                    else if (player.Hands.Count() > 1)
                    {
                        Console.WriteLine("Do you want to draw another card? (y/n)");
                        var response2 = Console.ReadLine();
                        if (response2 == "y")
                        {
                            player.DrawCard(_deck);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (response == "n")
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            });
            
        }

        public void HouseTurn()
        {
            while (_house.Score < 17)
            {
                _house.DrawCard(_deck);
            }
        }

        public void End()
        {

            _player.ForEach(player =>
            {
                Console.WriteLine( player + " hand:" );
                player.PrintAllHand();
                player.PrintScore();
            _house.PrintHand();
            _house.PrintScore();

            if (player.Score > 21)
            {
                Console.WriteLine("Player busts! House wins!");
            }
            else if (_house.Score > 21)
            {
                Console.WriteLine("House busts! Player wins!");
            }
            else if (player.Score > _house.Score)
            {
                Console.WriteLine("Player wins!");
            }
            else if (_house.Score > player.Score)
            {
                Console.WriteLine("House wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
            });

        }
    }
}
