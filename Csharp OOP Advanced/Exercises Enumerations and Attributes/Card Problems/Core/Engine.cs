using Card_Problems.Models;
using Card_Problems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_Problems.Core
{
    public class Engine
    {
        private string playerOneName;
        private string playerTwoName;
        private IList<Card> playerOneCards;
        private IList<Card> playerTwoCards;
        private IList<string> cardRankNames;
        private IList<string> cardSuitNames;

        public Engine()
        {
            this.playerOneCards = new List<Card>();
            this.playerTwoCards = new List<Card>();
            this.cardRankNames = new List<string>(Enum.GetNames(typeof(CardRank)));
            this.cardSuitNames = new List<string>(Enum.GetNames(typeof(CardSuit)));
        }

        public void Run()
        {
            this.playerOneName = Console.ReadLine();
            this.playerTwoName = Console.ReadLine();

            while (this.playerOneCards.Count < 5 || this.playerTwoCards.Count < 5)
            {
                ProcessCard(Console.ReadLine().Split(new string[] { " of " }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            string winnerInfo = GetWinner();

            Console.WriteLine(winnerInfo);
        }

        private string GetWinner()
        {
            Card bestCardPlayerOne = playerOneCards.OrderByDescending(c => c.CardPower).First();

            Card bestCardPlayerTwo = playerTwoCards.OrderByDescending(c => c.CardPower).First();

            if (bestCardPlayerOne.CardPower >= bestCardPlayerTwo.CardPower)
            {
                return $"{this.playerOneName} wins with {bestCardPlayerOne.CardRank} of {bestCardPlayerOne.CardSuit}.";
            }
            else
            {
                return $"{this.playerTwoName} wins with {bestCardPlayerTwo.CardRank} of {bestCardPlayerTwo.CardSuit}.";
            }
        }

        private void ProcessCard(List<string> cardInfo)
        {
            string cardRank = cardInfo[0];
            string cardSuit = cardInfo[1];

            if (CardIsValid(cardRank, cardSuit))
            {
                if (CardIsAvailable(cardRank, cardSuit))
                {
                    if (this.playerOneCards.Count < 5)
                    {
                        this.playerOneCards.Add(new Card(cardRank, cardSuit));
                    }
                    else
                    {
                        this.playerTwoCards.Add(new Card(cardRank, cardSuit));
                    }
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            else
            {
                Console.WriteLine("No such card exists.");
            }
        }

        private bool CardIsAvailable(string cardRank, string cardSuit)
        {
            List<string> playerOneCardsInHand = new List<string>();
            List<string> playerTwoCardsInHand = new List<string>();

            foreach (var card in this.playerOneCards)
            {
                playerOneCardsInHand.Add($"{card.CardRank} of {card.CardSuit}");
            }

            foreach (var card in this.playerTwoCards)
            {
                playerTwoCardsInHand.Add($"{card.CardRank} of {card.CardSuit}");
            }

            string cardToCheck = $"{cardRank} of {cardSuit}";

            if (playerOneCardsInHand.Any(c => c == cardToCheck) || playerTwoCardsInHand.Any(c => c == cardToCheck))
            {
                return false;
            }

            return true;
        }

        private bool CardIsValid(string cardRank, string cardSuit)
        {
            if (!this.cardRankNames.Contains(cardRank))
            {
                return false;
            }

            if (!this.cardSuitNames.Contains(cardSuit))
            {
                return false;
            }

            return true;
        }
    }
}