namespace Blackjack_OOP;

public class GameStandards
{
    public static readonly int MaxPlayers = 6;
    public static readonly int MinPlayers = 1;
    public static readonly int StartingMoney = 100;
    public static readonly int StartingDeckCount = 6;
    public static readonly int BlackjackValue = 21;
    public static readonly int DealerStandValue = 17;
    public static readonly int MaxHandValue = 21;
    private static readonly int MinHandValue = 17;

    public bool IsBust(int score)
    {
        return score > MaxHandValue;
    }

    public bool IsBlackjack(int score)
    {
        return score == BlackjackValue;
    }

    public bool IsDealerStand(int score)
    {
        return score >= DealerStandValue;
    }

    public bool IsPlayerStand(int score)
    {
        return score >= MinHandValue;
    }

    public bool IsPlayerBust(int score)
    {
        return score > MaxHandValue;
    }

    public bool IsPlayerBlackjack(int score)
    {
        return score == BlackjackValue;
    }

    public bool IsPlayerSplit(int score)
    {
        return score == BlackjackValue;
    }

    public bool IsPlayerDoubleDown(int score)
    {
        return score == BlackjackValue;
    }

    public bool IsPlayerDraw(int score)
    {
        return score < MinHandValue;
    }
}