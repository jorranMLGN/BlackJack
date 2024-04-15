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

    public bool CanDealerStand(int score)
    {
        return score >= DealerStandValue;
    }

    public bool CanSplit(List<Card> hand)
    {
        return hand.Count == 2 && hand[0].Value == hand[1].Value;
    }

    public bool CanDoubleDown(List<Card> hand)
    {
        return hand.Count == 2;
    }
}