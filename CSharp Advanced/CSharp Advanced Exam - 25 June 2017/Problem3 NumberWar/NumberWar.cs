using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_NumberWar
{
    class NumberWar
    {
        public static readonly string alphabet = "#abcdefghijklmnopqrstuvwxyz";

        private static void Main(string[] args)
        {
            var turns = 0;
            bool draw = false;

            Queue<Card> playerOneCards = new Queue<Card>();
            Queue<Card> playerTwoCards = new Queue<Card>();

            var input1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var input2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ca in input1)
            {
                int digit = int.Parse(ca.Substring(0, ca.Length - 1));
                string letter = ca.Substring(ca.Length - 1);
                playerOneCards.Enqueue(new Card(digit, letter));
            }

            foreach (var ca in input2)
            {
                int digit = int.Parse(ca.Substring(0, ca.Length - 1));
                string letter = ca.Substring(ca.Length - 1);
                playerTwoCards.Enqueue(new Card(digit, letter));
            }
            bool outOfcards = false;
            while (turns < 1000000 && playerOneCards.Count > 0 && playerTwoCards.Count > 0)
            {
                if (turns > 10000)//Delete this
                {
                    turns = 1000000;
                    break;
                }

                List<Card> playedCards = new List<Card>();

                var playerOneCard = playerOneCards.Dequeue();
                var playerTwoCard = playerTwoCards.Dequeue();

                playedCards.Add(playerOneCard);
                playedCards.Add(playerTwoCard);

                if (playerOneCard.Digit > playerTwoCard.Digit)//Player 1 wins
                {
                    foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                    {
                        playerOneCards.Enqueue(card);
                    }
                }
                else if (playerOneCard.Digit < playerTwoCard.Digit)//Player 2 wins
                {
                    foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                    {
                        playerTwoCards.Enqueue(card);
                    }
                }
                else//War
                {
                    outOfcards = false;
                    var haveWinner = false;

                    if (playerOneCards.Count - 3 < 0 || playerTwoCards.Count - 3 < 0)
                    {
                        haveWinner = true;
                        outOfcards = true;
                        if (playerOneCards.Count == playerTwoCards.Count)
                        {
                            draw = true;
                        }
                    }

                    while (haveWinner == false)
                    {
                        if (playerOneCards.Count - 3 < 0 || playerTwoCards.Count - 3 < 0)
                        {
                            haveWinner = true;
                            outOfcards = true;
                            if (playerOneCards.Count == playerTwoCards.Count)
                            {
                                draw = true;
                            }
                            break;
                        }

                        List<Card> p1DrawCards = new List<Card>();
                        List<Card> p2DrawCards = new List<Card>();

                        for (int k = 0; k < 3; k++)
                        {
                            p1DrawCards.Add(playerOneCards.Dequeue());
                            p2DrawCards.Add(playerTwoCards.Dequeue());
                        }

                        int drawResult = int.MinValue;

                        drawResult = GetDrawWinner(p1DrawCards, p2DrawCards);

                        playedCards.AddRange(p1DrawCards);
                        playedCards.AddRange(p2DrawCards);

                        if (drawResult == 1)
                        {
                            haveWinner = true;
                            foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                            {
                                playerOneCards.Enqueue(card);
                            }
                        }
                        else if (drawResult == 2)
                        {
                            haveWinner = true;
                            foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                            {
                                playerTwoCards.Enqueue(card);
                            }
                        }
                    }
                }

                turns++;
                if (outOfcards || draw)
                {
                    break;
                }
            }

            if (draw)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else
            {
                if (playerOneCards.Count > playerTwoCards.Count)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
            }
        }

        private static int GetDrawWinner(List<Card> p1DrawCards, List<Card> p2DrawCards)
        {
            string p1Chars = string.Join(string.Empty, p1DrawCards.Select(x => x.Name)).ToLower();
            string p2Chars = string.Join(string.Empty, p2DrawCards.Select(x => x.Name)).ToLower();

            var p1Sum = 0;
            var p2Sum = 0;

            for (int i = 0; i < p1Chars.Length; i++)
            {
                var num = alphabet.IndexOf(p1Chars[i]);
                p1Sum += num;
            }

            for (int i = 0; i < p1Chars.Length; i++)
            {
                var num = alphabet.IndexOf(p2Chars[i]);
                p2Sum += num;
            }

            if (p1Sum > p2Sum)
            {
                return 1;
            }
            else if (p1Sum < p2Sum)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }

    class Card
    {
        public Card(int digit, string name)
        {
            this.Digit = digit;
            this.Name = name;
        }

        public int Digit { get; set; }
        public string Name { get; set; }
    }
}