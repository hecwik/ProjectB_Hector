﻿using System;

namespace ProjectB_Hector
{
    class Program
    {
        // create deckofcards annd handofcards outside main method as fields of class program
        public static DeckOfCards myDeck = new DeckOfCards();
        public static HandOfCards player1 = new HandOfCards();
        public static HandOfCards player2 = new HandOfCards();
        public static int winCount1;
        public static int winCount2;
        static void Main(string[] args)
        {
            PlaySomeCards(player1, player2);
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;

            Console.WriteLine();
            Console.Write("\n\tHow many cards should be dealt to each player? (1-5 or Q to quit): ");
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int resOutput))
            {
                NrOfCards = resOutput;
                // return true since cards were read
                return true;
            }
            else if (userInput == "q" || userInput == "Q")
            {
                Console.Clear();
                Console.WriteLine("\n\tThank you for playing!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input was invalid! Must be a number (1-5).\n");
            }
            return false;
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            Console.WriteLine();
            Console.WriteLine($"\n\tHow many rounds should we play? (1-5 or Q to quit): ");
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int resOutput))
            {
                NrOfRounds = resOutput;
                return true;
            }
            else if (userInput == "q" || userInput == "Q")
            {
                Console.WriteLine("Thank you for playing");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input was invalid! Must be a number (1-5).");
                Console.ReadKey();
            }

            return false;
        }

        public static void PlaySomeCards(HandOfCards player1, HandOfCards player2)
        {
            string cardSymbols = "\u2663 \u2666 \u2665 \u2660";
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"\n\t{cardSymbols} Welcome to the Card Game! {cardSymbols}");
                Console.WriteLine($"\n\t1. Play Cards");
                Console.WriteLine($"\n\t2. Sort and show the deck");
                Console.WriteLine($"\n\t3. Shuffle and show the deck");
                Console.WriteLine($"\n\t4. Quit");

                if (Int32.TryParse(Console.ReadLine(), out int resOutput))
                {
                    switch (resOutput)
                    {
                        case 1:
                            CardGame();
                            break;

                        case 2:
                            myDeck.Sort();
                            Console.WriteLine(myDeck);

                            Console.ReadKey();
                            break;

                        case 3:
                            myDeck.Shuffle();
                            Console.WriteLine(myDeck);
                            Console.WriteLine("Press anywhere to continue...\n");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("Thank you for playing!\n");
                            isRunning = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input! Must be a number between 1-4.");
                    Console.WriteLine("Press anywhere to try again.");
                    Console.ReadKey();
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
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            // clear both hands before adding new cards
            player1.Clear();
            player2.Clear();
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                // adds the removed top card to player hand
                player1.Add(myDeck.RemoveTopCard());
            }
            string nrCardsLeft1 = $"The deck now contains {myDeck.Count} cards.\n";

            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                player2.Add(myDeck.RemoveTopCard());
            }
            string nrCardsLeft2 = $"The deck now contains {myDeck.Count} cards.\n";

            // displays the hands
            ShowHand(player1, nrCardsToPlayer, nrCardsLeft1);
            ShowHand(player2, nrCardsToPlayer, nrCardsLeft2);
        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {

            if (player1.Highest.Value.CompareTo(player2.Highest.Value) > 0)
            {
                winCount1++;
                Console.WriteLine($"{nameof(player1)} won the round! Win nr: {winCount1}");
            }
            else if (player1.Highest.Value.CompareTo(player2.Highest.Value) < 0)
            {
                winCount2++;
                Console.WriteLine($"{nameof(player2)} won the round! Win nr: {winCount2}");
            }
            else if (player1.Highest.Value.CompareTo(player2.Highest.Value) == 0)
            {
                Console.WriteLine($"Round tie!");
            }
        }
        public static void DetermineGameWinner()
        {
            if (winCount1 > winCount2)
            {
                Console.WriteLine($"\n\tPlayer 1 wins the game {winCount1} to {winCount2}!");
                winCount1 = 0;
                winCount2 = 0;
            }
            else if (winCount1 < winCount2)
            {
                Console.WriteLine($"\n\tPlayer 2 wins the game {winCount2} to {winCount1}!");
                winCount1 = 0;
                winCount2 = 0;
            }
            else
            {
                Console.WriteLine($"\n\tThe game was tied! P1: {winCount1} to P2: {winCount2}");
                winCount1 = 0;
                winCount2 = 0;
            }
        }
        private static void ShowHand(HandOfCards player, int nrOfCards, string nrCardsLeft)
        {
            string nameOfPlayer = "";
            if (player == player1)
                nameOfPlayer = "Player 1";
            else if (player == player2)
                nameOfPlayer = "Player 2";

            player.Sort();
            if (player.Count > 1)
            {
                Console.WriteLine($"{nrOfCards} cards given to {nameOfPlayer}.\n");
                Console.WriteLine($"{nameOfPlayer}'s hand:\n{player}\n");
                Console.WriteLine($"Lowest card: {player.Lowest} & Highest card: {player.Highest}\n");
            }
            else
            {
                Console.WriteLine($"{nrOfCards} cards given to {nameOfPlayer}.\n");
                Console.WriteLine($"{nameOfPlayer}'s card:\n{player}\n");
            }

            Console.WriteLine(nrCardsLeft);

        }
        public static void CardGame()

        {
            Console.Clear();
            Console.WriteLine("\n\tLet's play a game of Highest Card with two players.");
            TryReadNrOfCards(out int NrOfCards);
            TryReadNrOfRounds(out int NrOfRounds);
            myDeck.CreateFreshDeck();
            myDeck.Shuffle();
            Console.WriteLine(myDeck.ToString());

            for (int i = 1; i <= NrOfRounds; i++)
            {
                Console.Clear();
                Console.WriteLine($"\tPlaying round nr {i}\n");
                Deal(myDeck, NrOfCards, player1, player2);
                DetermineWinner(player1, player2);
                Console.WriteLine();
                if (i == NrOfRounds)
                    break;

                Console.WriteLine("\n\tPress anywhere to play next round...\n");
                Console.ReadKey();
            }
            DetermineGameWinner();
            Console.ReadKey();
        }
    }
}
