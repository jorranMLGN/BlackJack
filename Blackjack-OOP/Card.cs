namespace Blackjack_OOP;

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum Face
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public class Card
{
    private Suit Suit { get; set; }
    private Face Face { get; set; }
    public int Value { get; private set; }
    private char Symbol { get; set; }
    private ConsoleColor CardColor { get; set; }

    public Card(Suit suit, Face face)
    {
        Suit = suit;
        Face = face;
        SetCardValueAndColor();
    }

    private void SetCardValueAndColor()
    {
        CardColor = Suit is Suit.Hearts or Suit.Diamonds ? ConsoleColor.Red : ConsoleColor.Black;

        switch (Face)
        {
            case Face.Two:
                Value = 2;
                Symbol = '2';
                break;
            case Face.Three:
                Value = 3;
                Symbol = '3';
                break;
            case Face.Four:
                Value = 4;
                Symbol = '4';
                break;

            case Face.Five:
                Value = 5;
                Symbol = '5';
                break;
            case Face.Six:
                Value = 6;
                Symbol = '6';
                break;
            case Face.Seven:
                Value = 7;
                Symbol = '7';
                break;
            case Face.Eight:
                Value = 8;
                Symbol = '8';
                break;
            case Face.Nine:
                Value = 9;
                Symbol = '9';
                break;
            case Face.Ten:
                Value = 10;
                Symbol = 'T';
                break;
            case Face.Jack:
                Value = 10;
                Symbol = 'J';
                break;
            case Face.Queen:
                Value = 10;
                Symbol = 'Q';
                break;
            case Face.King:
                Value = 10;
                Symbol = 'K';
                break;
            case Face.Ace:
                Value = 1;
                Symbol = 'A';
                break;

            default:
                Value = 10; // Jack, Queen, King
                Symbol = char.Parse(Face.ToString()[..1]);
                break;
        }
    }

    public int GetValue()
    {
        return Value;
    }


    private string SuitIcon()
    {
        return Suit switch
        {
            Suit.Hearts => "♥",
            Suit.Diamonds => "♦",
            Suit.Clubs => "♣",
            Suit.Spades => "♠",
            _ => "Invalid suit"
        };
    }

    public Card PrintCard()
    {
        Console.ForegroundColor = CardColor;
        Console.WriteLine($"{Symbol}{SuitIcon()}");
        Console.ResetColor();
        return this;
    }
}