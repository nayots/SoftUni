using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8_WTFBunnies
{
    class WTFBunnies
    {
        private static int playerRow = 0;
        private static int playerCol = 0;
        private static bool hasEscaped = false;
        private static bool isDead = false;

        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = inputArgs[0];
            int m = inputArgs[1];

            char[][] lair = new char[n][];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                lair[i] = input.ToCharArray();
                if (input.Contains('P'))
                {
                    var indxCol = input.IndexOf('P');
                    playerRow = i;
                    playerCol = indxCol;
                }
            }
            HandleMoves(lair);
            PrintLair(lair);
            if (isDead || !hasEscaped)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        private static void PrintLair(char[][] lair)
        {
            for (int i = 0; i < lair.Length; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }
        }

        private static void HandleMoves(char[][] lair)
        {
            string moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                if (isDead || (hasEscaped && !isDead))
                {
                    break;
                }

                switch (moves[i])
                {
                    case 'U':
                        MoveUP(lair);
                        break;

                    case 'D':
                        MoveDown(lair);
                        break;

                    case 'L':
                        MoveLeft(lair);
                        break;

                    case 'R':
                        MoveRight(lair);
                        break;
                }
                MultiplyBunnies(lair);
            }
        }

        private static void MultiplyBunnies(char[][] lair)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int r = 0; r < lair.Length; r++)
            {
                for (int c = 0; c < lair[0].Length; c++)
                {
                    if (lair[r][c] == 'B')
                    {
                        bunnies.Add(new int[] { r, c });
                    }
                }
            }

            foreach (var bunny in bunnies)
            {
                SpreadBunny(lair, bunny[0], bunny[1]);
            }
        }

        private static void SpreadBunny(char[][] lair, int r, int c)
        {
            if (r > 0)//UpperBunny
            {
                if (lair[r - 1][c] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[r - 1][c] = 'B';
            }

            if (r < lair.Length - 1)//BottomBunny
            {
                if (lair[r + 1][c] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[r + 1][c] = 'B';
            }

            if (c > 0)//LeftBunny
            {
                if (lair[r][c - 1] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[r][c - 1] = 'B';
            }

            if (c < lair[0].Length - 1)//RightBunny
            {
                if (lair[r][c + 1] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[r][c + 1] = 'B';
            }
        }

        private static void MoveRight(char[][] lair)
        {
            if (playerCol == lair[0].Length - 1)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow][playerCol + 1] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerCol += 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow][playerCol + 1] = 'P';
                playerCol += 1;
            }
        }

        private static void MoveLeft(char[][] lair)
        {
            if (playerCol == 0)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow][playerCol - 1] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerCol -= 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow][playerCol - 1] = 'P';
                playerCol -= 1;
            }
        }

        private static void MoveDown(char[][] lair)
        {
            if (playerRow == lair.Length - 1)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow + 1][playerCol] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerRow += 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow + 1][playerCol] = 'P';
                playerRow += 1;
            }
        }

        private static void MoveUP(char[][] lair)
        {
            if (playerRow == 0)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow - 1][playerCol] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerRow -= 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow - 1][playerCol] = 'P';
                playerRow -= 1;
            }
        }
    }
}