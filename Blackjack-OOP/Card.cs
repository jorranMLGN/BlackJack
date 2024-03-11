
namespace Blackjack_OOP
{
    public class Card
    {
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value { get; set; }

        public enum EnumSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum EnumFace
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

        public  enum EnumFaceEmoij
        {
        }

        public enum EnumFaceValue
        {
            Ace = 1 | 11,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 10,
            Queen = 10,
            King = 10
        }

        public override string ToString()
        {
            return $"{Face} of {Suit}";
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void PrintValue()
        {
            Console.WriteLine(Value);
        }

        public void PrintSuit()
        {
            Console.WriteLine(Suit);
        }

        public void PrintFace()
        {
            Console.WriteLine(Face);
        }

        public void PrintCard()
        {
            Console.WriteLine($"{Face} of {Suit}");
        }
    }
}