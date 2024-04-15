namespace Blackjack_OOP;

public abstract class Participant
{
    protected List<Card> Hand { get; set; }

    public int GetScore()
    {
        var score = 0;
        var aceCount = 0;
        var currentHand = this is Player player ? player.GetCurrentHand() : Hand;
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