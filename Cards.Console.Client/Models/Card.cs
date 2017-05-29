namespace Cards.Console.Client.Models
{
    /// <summary>
    ///    class Cards, card has  suit property  and rank property. card ( suits and   ranks) 
    /// when someone calls card, it'll provide the suit and order, hence intialized under constructor 
    /// </summary>
    public class Card
    {
        #region Card is defined to have Suit and Order Property (based on google) 
        public Suit _suit { get; set; }
        public Order _order { get; set; }
        #endregion
        public Card(Suit suit, Order order)
        {
            _suit = suit;
            _order = order;
        }

    }
}
