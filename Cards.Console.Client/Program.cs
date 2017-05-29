using System;
using System.Linq;
using Cards.Console.Client.Models;

namespace Cards.Console.Client
{
    public class Program
    {
        private static void Main(string[] args)
        {
            printHeader();
            var selectedOption = 0;
            do
            {
                selectedOption = getInput();
                processInput(selectedOption);
            } while (selectedOption != 0);
            System.Console.ReadLine();
        }

        #region Processing Methods

        /// <summary>
        ///     ProcessStandardDeckOfCards
        ///     Orders cards of deck based on numbers/ ranking order
        ///     1-13 (heart) 1-13 (diamond) like that
        /// </summary>
        private static void ProcessStandardDeckOfCards()
        {
            var deck = LoadDeckOfCards();
            beautify();
            foreach (var card in deck.Cards)
            {
                System.Console.WriteLine($"     |{card._order,7}|{card._suit,7}|");
                if (card._order == Order.King) System.Console.WriteLine("---------------------------------------");
            }
        }

        /// <summary>
        ///     ProcessRandomShuffledDeckOfCards
        ///     randomizes the cards of deck, requires complete deck
        ///     processes radomly shuffled cards
        /// </summary>
        private static void ProcessRandomShuffledDeckOfCards()
        {
            var deck = LoadDeckOfCards();
            var randomizedDeck = Randomize(deck);
            System.Console.WriteLine($"     |{"Order ",7}|{"Suit",7}|");
            System.Console.WriteLine("-----------------------------------");
            foreach (var card in randomizedDeck.Cards)
            {
                System.Console.WriteLine($"     |{card._order,7}|{card._suit,7}|");
            }
        }

        /// <summary>
        ///     ProcessOrderedShuffledDeckOfCards
        ///     shuffles the cards of deck by suit, thats defined on suit class
        ///     spade (1-13) , heart (1-13) like this
        /// </summary>
        private static void ProcessOrderedShuffledDeckOfCards()
        {
            var deck = LoadDeckOfCards();
            var orderedDeck = deck.Cards.OrderBy(p => p._order).ToList();
            beautify();
            foreach (var card in orderedDeck)
            {
                System.Console.WriteLine($"     |{card._order,7}|{card._suit,7}|");
                if (card._suit == Suit.Club) System.Console.WriteLine("--------------------------------");
            }
        }

        #endregion

        #region Private Methods

        private static int getInput()
        {
            var selectedOption = 0;
            System.Console.WriteLine("1 : Get Standard Deck of Cards. Ordered by the Numbers ");
            System.Console.WriteLine("2 : Get Randomly Shuffled Deck of Cards");
            System.Console.WriteLine("3 : Get Ordered Shuffled Deck of Cards. Ordered by the Suits ");
            System.Console.WriteLine("0 : Exit  ");
            System.Console.Write("Enter a value : ");
            var inputStr = System.Console.ReadLine();
            int.TryParse(inputStr, out selectedOption);
            System.Console.WriteLine(" You've entered = {0}", selectedOption);
            return selectedOption;
        }

        private static void printHeader()
        {
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("                        Deck Of Cards               ");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("==============================================================");
        }

        private static void processInput(int value)
        {
            var guid = Guid.NewGuid();
            switch (value)
            {
                case 1:
                    ProcessStandardDeckOfCards();
                    break;
                case 2:
                    ProcessRandomShuffledDeckOfCards();
                    break;
                case 3:
                    ProcessOrderedShuffledDeckOfCards();
                    break;
                default:
                    System.Console.WriteLine("Press ENTER to exit the program");
                    break;
            }
        }

        private static void beautify()
        {
            System.Console.WriteLine($"     |{"Order ",7}|{"Suit",7}|");
            System.Console.WriteLine("-----------------------------------");
        }

        public static Deck LoadDeckOfCards()
        {
            var deck = new Deck();
            var suitList = Enum.GetNames(typeof(Suit)).Length;
            var orderList = Enum.GetNames(typeof(Order)).Length;
            for (var suitIndex = 1; suitIndex <= suitList; suitIndex++)
            {
                for (var orderIndex = 1; orderIndex <= orderList; orderIndex++)
                {
                    deck.Cards.Add(new Card((Suit) suitIndex, (Order) orderIndex));
                }
            }
            return deck;
        }

        public static Deck Randomize(Deck deck)
        {
            var rmd = new Random();
            var cards = deck.Cards;
            for (var i = cards.Count - 1; i > 0; i--)
            {
                var tempIndex = rmd.Next(i + 1);
                if (tempIndex != i)
                {
                    var tmp = cards[tempIndex];
                    cards[tempIndex] = cards[i];
                    cards[i] = tmp;
                }
            }
            deck.Cards = cards;
            return deck;
        }

        #endregion
    }
}