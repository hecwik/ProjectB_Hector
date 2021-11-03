using System;
namespace ProjectB2_Hector
{
    class Program
    {
        // create deckofcards annd handofcards outside main method as fields of class program
        public static DeckOfCards myDeck = new DeckOfCards();
        public static HandOfCards player1 = new HandOfCards();
        public static HandOfCards player2 = new HandOfCards();
        
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            PokerHand Player = new PokerHand();
            Console.WriteLine("Cards added to hand: ");
            while (myDeck.Count > 5)
            {
                Player.Add(myDeck.RemoveTopCard());

                //Your code to Give 5 cards to the player and determine the rank
                //Continue for as long as the deck has at least 5 cards 
            }
            Console.WriteLine(Player);
        }
    }
}

