using Blackjack_OOP;

var game = new GameLogic();

while (true)
{
    game.Start();
    game.End();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Would you like to play again? Y/N");
    Console.ForegroundColor = ConsoleColor.Gray;
    var response = Console.ReadLine();
    if (response?.ToUpper() != "Y")
        break;
    Console.Clear();
}