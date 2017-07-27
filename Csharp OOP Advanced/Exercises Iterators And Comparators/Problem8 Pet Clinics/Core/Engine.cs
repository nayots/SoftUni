using Problem8_Pet_Clinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem8_Pet_Clinics.Core
{
    public class Engine
    {
        private IList<Pet> allPets;
        private IList<Clinic> clinics;

        public Engine()
        {
            this.allPets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }

        public void Run()
        {
            string input = string.Empty;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                try
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string command = tokens[0];
                    tokens.RemoveAt(0);

                    switch (command)
                    {
                        case "Create":
                            if (tokens[0] == "Pet")
                            {
                                allPets.Add(new Pet(tokens[1], int.Parse(tokens[2]), tokens[3]));
                            }
                            else if (tokens[0] == "Clinic")
                            {
                                clinics.Add(new Clinic(tokens[1], int.Parse(tokens[2])));
                            }
                            break;

                        case "Add":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[1]).Add(allPets.First(p => p.Name == tokens[0])));
                            break;

                        case "Release":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[0]).Release());
                            break;

                        case "HasEmptyRooms":
                            Console.WriteLine(clinics.First(c => c.Name == tokens[0]).HasEmptyRooms());
                            break;

                        case "Print":
                            if (tokens.Count == 1)
                            {
                                clinics.First(c => c.Name == tokens[0]).Print();
                            }
                            else if (tokens.Count > 1)
                            {
                                clinics.First(c => c.Name == tokens[0]).Print(int.Parse(tokens[1]));
                            }
                            break;

                        default:
                            throw new InvalidOperationException("Invalid Operation!");
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}