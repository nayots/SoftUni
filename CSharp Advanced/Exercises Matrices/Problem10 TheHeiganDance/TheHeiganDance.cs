using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Problem10_TheHeiganDance
{
    class TheHeiganDance
    {
        private static int cloudDOTleft;
        private static decimal playerHP = 18500M;
        private static decimal bossHP = 3000000M;
        private static decimal playerDPT;
        private static int playerRow = 7;
        private static int playerCol = 7;
        private static bool cloudKill = false;

        private static void Main(string[] args)
        {
            playerDPT = decimal.Parse(Console.ReadLine());
            int[][] chamber = new int[15][];

            InitializeChamber(chamber);
            ManageBattle(chamber);
        }

        private static void ManageBattle(int[][] chamber)
        {
            while (true)
            {
                string[] spellArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string spellType = spellArgs[0];
                int spellRow = int.Parse(spellArgs[1]);
                int spellCol = int.Parse(spellArgs[2]);

                var killSource = string.Empty;
                cloudKill = false;
                ApplyCloudDOT();
                HitBoss();
                if (playerHP <= 0 && bossHP < 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    if (cloudKill)
                    {
                        killSource = "Plague Cloud";
                    }
                    else
                    {
                        if (spellType == "Cloud")
                        {
                            killSource = "Plague Cloud";
                        }
                        else if (spellType == "Eruption")
                        {
                            killSource = "Eruption";
                        }
                    }
                    Console.WriteLine($"Player: Killed by {killSource}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
                if (bossHP <= 0)//CheckBossState
                {
                    Console.WriteLine("Heigan: Defeated!");
                    Console.WriteLine($"Player: {playerHP}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
                CastSpell(chamber, spellType, spellRow, spellCol);
                if (playerHP <= 0)
                {
                    Console.WriteLine($"Heigan: {bossHP:F2}");

                    if (spellType == "Cloud" || cloudKill)
                    {
                        killSource = "Plague Cloud";
                    }
                    else
                    {
                        killSource = "Eruption";
                    }
                    Console.WriteLine($"Player: Killed by {killSource}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }
            }
        }

        private static void CastSpell(int[][] chamber, string spellType, int spellRow, int spellCol)
        {
            List<int[]> affectedCells = new List<int[]>();
            for (int r = Math.Max(spellRow - 1, 0); r <= Math.Min(spellRow + 1, chamber.Length - 1); r++)
            {
                for (int c = Math.Max(spellCol - 1, 0); c <= Math.Min(spellCol + 1, chamber[0].Length - 1); c++)
                {
                    affectedCells.Add(new int[] { r, c });
                    chamber[r][c] = -1;
                }
            }
            //PrintChamber(chamber);
            CheckPlayer(spellType, chamber);
            CleanBattleField(chamber, affectedCells);
        }

        private static void PrintChamber(int[][] chamber)//FOR TESTING
        {
            for (int r = 0; r < chamber.Length; r++)
            {
                Console.WriteLine(string.Join(" ", chamber[r]));
            }
        }

        private static void CleanBattleField(int[][] chamber, List<int[]> affectedCells)
        {
            foreach (var cell in affectedCells)
            {
                chamber[cell[0]][cell[1]] = 0;
            }
            chamber[playerRow][playerCol] = 69;
        }

        private static void CheckPlayer(string spellType, int[][] chamber)
        {
            if (chamber[playerRow][playerCol] == -1)
            {
                if (playerRow > 0)//UP
                {
                    if (chamber[playerRow - 1][playerCol] != -1)
                    {
                        playerRow--;
                        return;
                    }
                }
                if (playerCol < chamber[0].Length - 1)//RIGHT
                {
                    if (chamber[playerRow][playerCol + 1] != -1)
                    {
                        playerCol++;
                        return;
                    }
                }
                if (playerRow < chamber.Length - 1)//DOWN
                {
                    if (chamber[playerRow + 1][playerCol] != -1)
                    {
                        playerRow++;
                        return;
                    }
                }
                if (playerCol > 0)//LEFT
                {
                    if (chamber[playerRow][playerCol - 1] != -1)
                    {
                        playerCol--;
                        return;
                    }
                }

                //If we get here it means that we got hit and have nowhere to run.
                if (spellType == "Cloud")
                {
                    playerHP -= 3500;
                    cloudDOTleft++;
                }
                else
                {
                    playerHP -= 6000;
                }
            }
        }

        private static void HitBoss()
        {
            bossHP -= playerDPT;
        }

        private static void ApplyCloudDOT()
        {
            if (cloudDOTleft > 0)
            {
                for (int i = 0; i < cloudDOTleft; i++)
                {
                    playerHP -= 3500;
                }
                cloudDOTleft = 0;
                if (playerHP <= 0)
                {
                    cloudKill = true;
                }
            }
        }

        private static void InitializeChamber(int[][] chamber)
        {
            for (int r = 0; r < chamber.Length; r++)
            {
                chamber[r] = new int[15];
            }

            chamber[7][7] = 69;//This is the player's starting position in the center
        }
    }
}