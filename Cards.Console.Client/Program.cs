using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Console.Client.Models;
namespace Cards.Console.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            printHeader();
            int selectedOption = 0;
            do
            {
                selectedOption = getInput();
                processInput(selectedOption);
            }
            while (selectedOption != 0);
            System.Console.ReadLine();
        }

        #region Processing Methods
        /// <summary>
        /// ProcessStandardDeckOfCards
        /// Orders cards of deck based on numbers/ ranking order
        /// 1-13 (heart) 1-13 (diamond) like that 
        /// </summary>
        static void ProcessStandardDeckOfCards()
        {
            var deck = LoadDeckOfCards();
            beautify();
            foreach (Card card in deck.Cards)
            {
                System.Console.WriteLine($"     |{card._order,7}|{card._suit,7}|");
                if (card._order == Order.King) System.Console.WriteLine("---------------------------------------");

            }
        }

        /// <summary>
        /// ProcessRandomShuffledDeckOfCards
        /// randomizes the cards of deck, requires complete deck
        /// processes radomly shuffled cards
        /// </summary>
        static void ProcessRandomShuffledDeckOfCards()
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
        /// ProcessOrderedShuffledDeckOfCards
        /// shuffles the cards of deck by suit, thats defined on suit class 
        /// spade (1-13) , heart (1-13) like this
        /// </summary>
        static void ProcessOrderedShuffledDeckOfCards()
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


        static int getInput()
        {
            int selectedOption = 0;
            System.Console.WriteLine("1 : Get Standard Deck of Cards. Ordered by the Numbers ");
            System.Console.WriteLine("2 : Get Randomly Shuffled Deck of Cards");
            System.Console.WriteLine("3 : Get Ordered Shuffled Deck of Cards. Ordered by the Suits ");
            System.Console.WriteLine("0 : Exit  ");
            System.Console.Write("Enter a value : ");
            string inputStr = System.Console.ReadLine();
            Int32.TryParse(inputStr, out selectedOption);
            System.Console.WriteLine(" You've entered = {0}", selectedOption);
            return selectedOption;
        }

        static void printHeader()
        {
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("                        Deck Of Cards               ");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("==============================================================");
        }

        static void processInput(int value)
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

        static void beautify()
        {
            System.Console.WriteLine($"     |{"Order ",7}|{"Suit",7}|");
            System.Console.WriteLine("-----------------------------------");
        }

        public static Deck LoadDeckOfCards()
        {
            Deck deck = new Deck();
            var suitList = Enum.GetNames(typeof(Suit)).Length;
            var orderList = Enum.GetNames(typeof(Order)).Length;
            for (int suitIndex = 1; suitIndex <= suitList; suitIndex++)
            {
                for (int orderIndex = 1; orderIndex <= orderList; orderIndex++)
                {
                    deck.Cards.Add(new Card((Suit)suitIndex, (Order)orderIndex));
                }
            }
            return deck;
        }

        public static Deck Randomize(Deck deck)
        {
            Random rmd = new Random();
            List<Card> cards = deck.Cards;
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int tempIndex = rmd.Next(i + 1);
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
