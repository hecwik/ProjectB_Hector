using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB2_Hector
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related

        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public int Count => cards.Count;
        #endregion
        public PlayingCard this[int idx] => cards[idx];

        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < Count; i++)
            {
                if (i % 13 == 0)
                    sRet += $"\n";

                sRet += cards[i];
            }
            return $"{sRet}";
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = 0; i < Count - 1; i++)
            {
                int j = rng.Next(i, Count);
                PlayingCard tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }
            Console.WriteLine($"Deck shuffled, it now has {Count} cards.\n");
        }


        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    // if value of the current card is bigger than the next, swap places
                    if (cards[j].Value > cards[j + 1].Value)
                    {
                        PlayingCard tmp = cards[j + 1];
                        cards[j + 1] = cards[j];
                        cards[j] = tmp;
                    }
                }
            }
            if (Count == MaxNrOfCards)
                Console.WriteLine($"Deck sorted, it now has {Count} cards.");
        }
        #endregion

        #region Creating a fresh Deck
        public virtual void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            cards.Clear();
            // nested for loop that stores PlayingCard objects in the PlayingCard[] cards array
            // using the enum values of the colors and values of the cards

            // while color is clubs, create cards one, two three.. etc of current color up to ace
            // then repeat with the next color up until spades
            // lowest card (first created one) is two of clubs, and the highest card is ace of spades (last created one)
            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)
            {
                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)
                {
                    // set members values to the enum objects' current value
                    cards.Add(new PlayingCard { Color = color, Value = value });

                }
            }
        }
        #endregion



        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard cardDrawn = cards[0];
            cards.RemoveAt(0);

            // Below code shifts the deck to put cards[1] in the place of cards[0]
            // and move along the other cards in the deck by one index position towards the top

            // nested for-loop for shifting array and avoiding duplicate cards by nullifying placeholders
            for (int i = 0; i < Count; i++)
            {
                // check if cards[i] is null (if the card is drawn from the deck)
                // if null, shift the next elements to that spot length-1 times to fill the empty index left by drawn card
                if (cards[i] == null)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        PlayingCard tmp = cards[Count - 1];
                        cards[Count - 1] = cards[j];
                        cards[j] = tmp;
                        j--;
                    }
                }
            }
            // returns the card drawn from the top
            return cardDrawn;
        }
        #endregion
        // whenever a new deck is created, create a fresh deck
        public DeckOfCards()
        {
            CreateFreshDeck();
        }
    }
}
