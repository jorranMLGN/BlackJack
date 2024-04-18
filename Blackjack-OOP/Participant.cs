namespace Blackjack_OOP;
public abstract class Participant
{
    public static int GetScore( List<Card> currentHand)
    {
        var score = 0;
        var aceCount = 0;
        foreach (var card in currentHand)
        {
            score += card.GetValue();
            if (card.GetValue() == 1)
                aceCount++;
        }

        while (score <= 11 && aceCount > 0)
        {
            score += 10;
            aceCount--;
        }

        return score;
    }
}