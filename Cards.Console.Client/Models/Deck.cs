using System.Collections.Generic;
namespace Cards.Console.Client.Models
{
    /// <summary>
    /// class deck, deck has cards (list of cards)  1 deck =52 cards 
    /// </summary>
    public class Deck
    {
        #region Number of cards in a deck predefined (52)
        public List<Card> Cards;
        public Deck()
        {
            Cards = new List<Card>();
        }
        #endregion
    }
}
