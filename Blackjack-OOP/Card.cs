namespace Blackjack_OOP
{
    public enum Suit : int
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Face : int
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
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor CardColor { get; set; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
            SetCardValueAndColor();
        }

        private void SetCardValueAndColor()
        {
            if (Suit == Suit.Hearts || Suit == Suit.Diamonds)
            {
                CardColor = ConsoleColor.Red;
            }
            else
            {
                CardColor = ConsoleColor.Black;
            }

            switch (Face)
            {
                case Face.Ace:
                    Value = 11; // Of 1, afhankelijk van de spellogica
                    Symbol = 'A';
                    break;
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

                default:
                    Value = 10; // Voor Jack, Queen, King
                    Symbol = char.Parse(Face.ToString().Substring(0, 1));
                    break;
            }
        }

        public int PrintValue()
        {
            return Value;
        }


        public void PrintCard()
        {
            Console.ForegroundColor = CardColor;
            Console.WriteLine($"{Symbol} of {Suit}");
            Console.ResetColor();
        }
        
        
           
    }
}
