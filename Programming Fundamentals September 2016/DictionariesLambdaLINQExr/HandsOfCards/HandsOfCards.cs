using System;
using System.Collections.Generic;
using System.Linq;
//05. Hands of Cards
namespace HandsOfCards
{
    public class HandsOfCards
    {
        static void Main(string[] args)
        {
            bool canContinue = true;
            Dictionary<string, int> scores = new Dictionary<string, int>();
            Dictionary<string, string> rawData = new Dictionary<string, string>();

            while (canContinue)
            {

                string[] input = Console.ReadLine().Split(':').ToArray();
                string name = input[0];

                if (name == "JOKER")
                {
                    canContinue = false;
                    break;
                }

                if (rawData.ContainsKey(name))
                {
                    rawData[name] += input[1];
                }
                else
                {
                    rawData.Add(name, input[1]);
                }

            }

            foreach (KeyValuePair<string, string> item in rawData)
            {
                List<string> playerCards = new List<string>();

                playerCards = item.Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

                int sumOfHand = 0;
                foreach (string card in playerCards)
                {
                    sumOfHand += CardPoints(card);
                }

                if (scores.ContainsKey(item.Key))
                {
                    scores[item.Key] += sumOfHand;
                }
                else
                {
                    scores.Add(item.Key, sumOfHand);
                }
            }

            foreach (KeyValuePair<string, int> score in scores)
            {
                Console.WriteLine($"{score.Key}: {score.Value}");
            }
        }

        private static int CardPoints(string card)
        {
            string power = card[0].ToString();
            string type = card[card.Length - 1].ToString();
            if (power == "1")
            {
                power = "10";
            }
            int powerAsNumber = 0;
            int typeAsNumber = 0;
            bool nPower = int.TryParse(power, out powerAsNumber);

            if (nPower == false)
            {
                switch (power)//J, Q, K, A
                {
                    case "J":
                        powerAsNumber = 11;
                        break;
                    case "Q":
                        powerAsNumber = 12;
                        break;
                    case "K":
                        powerAsNumber = 13;
                        break;
                    case "A":
                        powerAsNumber = 14;
                        break;
                }
            }

            switch (type)//S -> 4, H-> 3, D -> 2, C -> 1
            {
                case "S":
                    typeAsNumber = 4;
                    break;
                case "H":
                    typeAsNumber = 3;
                    break;
                case "D":
                    typeAsNumber = 2;
                    break;
                case "C":
                    typeAsNumber = 1;
                    break;
            }

            int cardPoints = powerAsNumber * typeAsNumber;
            return cardPoints;
        }
    }
}