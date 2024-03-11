using Blackjack_OOP;
namespace Blackjack_OOP
{
    public class CreditSystemBase
    {
       
        public CreditSystemBase() { }
        public int Credit { get; set; }
        public int Bet { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }
        public int TotalGames { get; set; }
        public int WinPercentage { get; set; }
        public int LossPercentage { get; set; }
        public int DrawPercentage { get; set; }
        public int TotalGamesPercentage { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalGamesWon { get; set; }
        public int TotalGamesLost { get; set; }
            
        public void Start()
        {
            Credit = 100;
            Bet = 0;
            Win = 0;
            Loss = 0;
            Draw = 0;
            TotalGames = 0;
            WinPercentage = 0;
            LossPercentage = 0;
            DrawPercentage = 0;
            TotalGamesPercentage = 0;
            TotalGamesPlayed = 0;
            TotalGamesWon = 0;
            TotalGamesLost = 0;
        }public void End()
        {
            TotalGames = Win + Loss + Draw;
            WinPercentage = (Win / TotalGames) * 100;
            LossPercentage = (Loss / TotalGames) * 100;
            DrawPercentage = (Draw / TotalGames) * 100;
            TotalGamesPercentage = (TotalGames / TotalGames) * 100;
            TotalGamesPlayed = TotalGames;
            TotalGamesWon = Win;
            TotalGamesLost = Loss;
        }
        public void BetCredit(int bet)
        {
            Bet = bet;
            Credit -= Bet;
        }
        public void WinCredit()
        {
            Credit += Bet * 2;
            Win++;
        }
        public void DrawCredit()
        {
            Credit += Bet;
            Draw++;
        }
        public void LossCredit()
        {
            Loss++;
        }
        
    }  
}