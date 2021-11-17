using System;
namespace ProjectB2_Hector
{
    class Program
    {
        // create deckofcards annd handofcards outside main method as fields of class program
        public static DeckOfCards myDeck = new DeckOfCards();
        public static PokerHand player = new PokerHand();

        public static int MaxNrOfCards = 5;
        public static int NrOfCardsLeft = myDeck.Count;
        static void Main(string[] args)
        {
            // Deck is created from parameter-less constructor of DeckOfCards.
            Console.WriteLine($"A freshly created deck with {myDeck.Count} cards.\n");
            Console.WriteLine(myDeck);

            Console.WriteLine($"A sorted deck with {myDeck.Count} cards.\n");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"A shuffled deck with {myDeck.Count} cards.\n");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            while (myDeck.Count > 5)
            {
                for (int i = 0; i < MaxNrOfCards; i++)
                {
                    Deal(myDeck, player);
                    ShowHand();
                    
                }
            }
        }

        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, HandOfCards player1)
        {
            // clear both hands before adding new cards
            player.Clear();
            for (int i = 0; i < MaxNrOfCards; i++)
            {
                // adds the removed top card to player hand
                player.Add(myDeck.RemoveTopCard());
            }
            string nrCardsLeft = $"The deck now contains {myDeck.Count} cards.\n";
        }



        private static void ShowHand()
        {
            player.Sort();

            Console.WriteLine($"Player's hand: \n{player}\n");
            Console.WriteLine($"Lowest card: {player.Lowest} & Highest card: {player.Highest}\n");

            Console.WriteLine($"Deck now has {myDeck.Count} cards.");

        }
    }
}

