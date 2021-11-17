using System;

namespace ProjectB2_Hector
{
    class PokerHand : HandOfCards
    {
        #region Clear
        public override void Clear()
        {
            cards.Clear();
        }
        #endregion

        #region Remove and Add related
        public override void Add(PlayingCard card) => cards.Add(card);
        #endregion

        #region Poker Rank related
        //https://www.poker.org/poker-hands-ranking-chart/
        /// <summary>
        /// Got through a 5 card hand and determine the Rank according to
        /// https://www.poker.org/poker-hands-ranking-chart/
        /// After determination properties Rank and RankHiCard can be read.
        /// In case Rank is PokerRank.TwoPair, RankHiCardPair1 and RankHiCardPair2 
        /// are set and RankHiCard is set to higest of RankHiCardPair1 and RankHiCardPair2
        /// </summary>
        /// <returns>The pokerhand rank. PokerRank.Undefined in case Hand is not 5 cards</returns>
        //Hint: using backing fields
        private PokerRankEnum _rank = PokerRankEnum.Unknown;
        private PlayingCard _rankHigh = null; 
        private PlayingCard _rankHighPair1 = null;
        private PlayingCard _rankHighPair2 = null;

        public PokerRankEnum Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;
        public PlayingCard RankHiCardPair1 => _rankHighPair1;
        public PlayingCard RankHiCardPair2 => _rankHighPair2;

        //Hint: Worker Methods to examine a sorted hand
        private int NrSameValue(int firstValueIdx, out int lastValueIdx, out PlayingCard HighCard) 
        {
            lastValueIdx = 0;
            HighCard = null;
            return 0; 
        }
        private bool IsSameColor(out PlayingCard HighCard)
        {
            HighCard = null;
            return false;
        }
        private bool IsConsecutive(out PlayingCard HighCard)
        {
            HighCard = null;
            return false;
        }

        //Hint: Worker Properties to examine each rank
        private bool IsRoyalFlush => false;
        private bool IsStraightFlush => false;
        private bool IsFourOfAKind => false;
        private bool IsFullHouse => false;
        private bool IsFlush => false;
        private bool IsStraight => false;
        private bool IsThreeOfAKind => false;

        private bool IsTwoPair
        {
            get
            {
                return false;
            }
        }
        private bool IsPair => false;

        public PokerRankEnum DetermineRank(PokerHand playerHand)
        {
            for (int i = 0; i < playerHand.Count; i++)
            {
                // When hand has one pair.
                if(playerHand.cards[i].Value == playerHand.cards[i + 1].Value)
                {
                    
                }
            }
            return PokerRankEnum.Unknown;
        }

        //Hint: Clear rank
        private void ClearRank()
        {
            _rankHigh = null;
            _rankHighPair1 = null;
            _rankHighPair2 = null;
            _rank = PokerRankEnum.Unknown;
        }
        #endregion
    }
}
