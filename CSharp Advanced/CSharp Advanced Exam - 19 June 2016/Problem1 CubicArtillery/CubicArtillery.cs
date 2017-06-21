using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_CubicArtillery
{
    class CubicArtillery
    {
        private static int maxCapacity;

        private static void Main(string[] args)
        {
            maxCapacity = int.Parse(Console.ReadLine());

            List<Bunker> bunkers = new List<Bunker>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = input.Split(' ');//Here we get the tokens

                foreach (var tok in tokens)
                {
                    int weapon = 0;// We initialize an Empty weapon;

                    bool isDigit = int.TryParse(tok, out weapon); //If the tryParse returns true , it means that the token is a Digit

                    if (!isDigit)
                    {
                        bunkers.Add(new Bunker(tok, maxCapacity)); // If the current token is not a digit we just add a new bunker with its name and the maxCapacity
                    }
                    else
                    {
                        // Here we traverse our bunkers to see if we can fit the weapon and if not either fit it / print it / remove the bunker
                        for (int i = 0; i < bunkers.Count; i++)
                        {
                            if (bunkers[i].Load + weapon <= bunkers[i].Capacity)
                            {
                                // If we can fit the weapon in the current bunker we add it to the weapons Queue and increase the bunker load
                                bunkers[i].Weapons.Enqueue(weapon);
                                bunkers[i].Load += weapon;
                                break;
                            }
                            else
                            {
                                //OVERFLOW happens when the weapon is beyond the capacity of our bunker
                                if (bunkers.Count == 1)
                                {
                                    //FIT + PRINT, here we are in the case where we have only ONE BUNKER so we check if we can fit the weapon or if we ignore it
                                    if (bunkers[i].Capacity < weapon)
                                    {
                                        //IGNORE the weapon if IT'S TOO BIG
                                        break;
                                    }
                                    else
                                    {
                                        //FIT
                                        while (bunkers[i].Capacity - bunkers[i].Load < weapon)
                                        {
                                            //We know now that the weapon can fit but we must free the needed space by removing other weapons,
                                            //we do that here until we have the needed space
                                            var wep = bunkers[i].Weapons.Dequeue();
                                            bunkers[i].Load -= wep;
                                        }
                                        //Now with enough space for the weapon we just add it and change the bunker load
                                        bunkers[i].Weapons.Enqueue(weapon);
                                        bunkers[i].Load += weapon;
                                        break;
                                    }
                                }
                                else
                                {
                                    //Here we are dealing with an overflow situation where we have more than one bunker

                                    //PRINT + REMOVE

                                    //If the bunker that overflowed has weapons inside it we print them, otherwise we just print that its EMPTY
                                    if (bunkers[i].Weapons.Count > 0)
                                    {
                                        Console.WriteLine($"{bunkers[i].Name} -> {string.Join(", ", bunkers[i].Weapons)}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bunkers[i].Name} -> Empty");
                                    }
                                    //We remove the bunker after printing and decrease i because if we don't we will miss the next bunker.
                                    bunkers.Remove(bunkers[i]);
                                    i--;
                                    //We continue searching for a bunker to store the weapon..
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    class Bunker
    {
        public Bunker(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Load = 0;
            this.Weapons = new Queue<int>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Load { get; set; }
        public Queue<int> Weapons { get; set; }
    }
}