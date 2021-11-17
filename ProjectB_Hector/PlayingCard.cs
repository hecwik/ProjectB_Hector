using System;

namespace ProjectB_Hector
{
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        public PlayingCardColor Color { get; init; }
        public PlayingCardValue Value { get; init; }

        #region IComparable Implementation
        //Need only to compare value in the project
        // is in itself compareto method. Use as normal
        public int CompareTo(PlayingCard card1)
        {
            return Value.CompareTo(card1.Value);
        }
        #endregion

        #region ToString() related
        private string ShortDescription
        {
            //Use switch statment or switch expression
            //https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
            get
            {
                string unicodePic = "";

                switch (Color)
                {
                    case PlayingCardColor.Clubs:
                        unicodePic = "\u2663";
                        break;

                    case PlayingCardColor.Diamonds:
                        unicodePic = "\u2666";
                        break;

                    case PlayingCardColor.Hearts:
                        unicodePic = "\u2665";
                        break;

                    case PlayingCardColor.Spades:
                        unicodePic = "\u2660";
                        break;

                }
                /*
				ALTERNATIVELY: Switch expression
				

				string unicodePic = Color switch
				{
					PlayingCardColor.Clubs    => "\u2663",
					PlayingCardColor.Diamonds => "\u2666",
					PlayingCardColor.Hearts   => "\u2665",
					PlayingCardColor.Spades   => "\u2660",

					_                         => default
				};
				*/

                return $"{unicodePic} {Value,-7}";
            }
        }
        public override string ToString() => ShortDescription;
        #endregion
    }
}
