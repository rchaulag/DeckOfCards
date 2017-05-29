using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Console.Client;
using Cards.Console.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Cards.Tests
{

    /// <summary>
    /// Unit Test is being implemented to test several units of the application, although preferred is NUnit :P
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CountCardsOnDeck_Pass()
        {
            //ACT
            //since its static method/ console app, we dont need to instantiate class

            //ARRANGE
            var loadedDeck = Program.LoadDeckOfCards();

            //ASSERT
            //since the initial requirement specifies the deck consists of 52 cards, i've hand coded 52 in here :D
            var NoOfCardsOnDeck = 52;
            Assert.AreEqual(NoOfCardsOnDeck, loadedDeck.Cards.Count);

        }

        [TestMethod]
        public void CountCardsOnDeckSuit_Pass()
        {
            //ACT
            //since its static method/ console app, we dont need to instantiate class

            //ARRANGE
            var loadedDeck = Program.LoadDeckOfCards();

            //ASSERT
            var suitList = Enum.GetNames(typeof(Suit)).Length;
            var tempSuitList = new List<Suit>();
            foreach (var item in loadedDeck.Cards)
            {
                tempSuitList.Add(item._suit);
            }
            var sth = tempSuitList.Distinct().Count();
            Assert.AreEqual(suitList, tempSuitList.Distinct().Count());
        }

        [TestMethod]
        public void CountCardsOnDeckOrder_Pass()
        {
            //ACT
            //since its static method/ console app, we dont need to instantiate class

            //ARRANGE
            var loadedDeck = Program.LoadDeckOfCards();
            //ASSERT
            var orderList = Enum.GetNames(typeof(Order)).Length;
            var tempOrderList = new List<Order>();
            foreach (var item in loadedDeck.Cards)
            {
                tempOrderList.Add(item._order);
            }
            Assert.AreEqual(orderList, tempOrderList.Distinct().Count());

        }

        [TestMethod]
        public void RandomizedCardsHasDinstinctCards_Pass()
        {
            //ACT
            //since its static method/ console app, we dont need to instantiate class

            //ARRANGE
            var loadedDeck = Program.LoadDeckOfCards();
            var randomizedDeck = Program.Randomize(loadedDeck);

            //ASSERT
            var distinctCards = new HashSet<Card>();//create new cards list, 
            foreach (var card in randomizedDeck.Cards)
            {
                distinctCards.Add(card);//add content to distinctCardList and check it, so that we know if its distinct or not
            }
            var NoOfCardsOnDeck = 52;
            Assert.AreEqual(NoOfCardsOnDeck, distinctCards.Count);
        }

    }
}
