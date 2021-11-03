using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_Hector
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public void Add(PlayingCard card) => cards.Add(card);
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                //return cards.Max();
                Sort();
                return this[Count - 1];
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                //return cards.Min();
                Sort();
                return this[0];
            }
        }

        #endregion
    }
}
