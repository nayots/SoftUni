using Problem8_MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem8_MilitaryElite.Core
{
    public class Engine
    {
        public void Run()
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var type = tokens[0];
                tokens.Remove(tokens.First());

                string id = tokens[0];
                string firstName = tokens[1];
                string lastName = tokens[2];

                if (type != "Spy")
                {
                    double salary = double.Parse(tokens[3]);

                    if (type == "Private")
                    {
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                    }
                    else if (type == "LeutenantGeneral")
                    {
                        tokens = tokens.Skip(4).ToList();

                        LeutenantGeneral general = new LeutenantGeneral(id, firstName, lastName, salary);
                        foreach (var soldId in tokens)
                        {
                            var currentPrivate = soldiers.First(p => p.Id == soldId);

                            general.Privates.Add(currentPrivate as IPrivate);
                        }
                        soldiers.Add(general);
                    }
                    else if (type == "Engineer" || type == "Commando")
                    {
                        Corps corps = Corps.Marines;

                        if (Enum.TryParse(tokens[4], out corps))
                        {
                            if (type == "Engineer")
                            {
                                Engineer engi = new Engineer(id, firstName, lastName, salary, corps);
                                tokens = tokens.Skip(5).ToList();

                                for (int i = 0; i < tokens.Count; i += 2)
                                {
                                    string partName = tokens[i];
                                    int hoursWorked = int.Parse(tokens[i + 1]);
                                    IRepair repair = new Repair(partName, hoursWorked);
                                    engi.Repairs.Add(repair);
                                }

                                soldiers.Add(engi);
                            }
                            else if (type == "Commando")
                            {
                                Commando comm = new Commando(id, firstName, lastName, salary, corps);
                                tokens = tokens.Skip(5).ToList();

                                for (int i = 0; i < tokens.Count; i += 2)
                                {
                                    string missionCodeName = tokens[i];
                                    MissionState missionState = MissionState.inProgress;
                                    if (Enum.TryParse(tokens[i + 1], out missionState))
                                    {
                                        IMission mission = new Mission(missionCodeName, missionState);
                                        comm.Missions.Add(mission);
                                    }
                                }

                                soldiers.Add(comm);
                            }
                        }
                    }
                }
                else if (type == "Spy")
                {
                    string codeNumber = tokens[3];

                    Spy spy = new Spy(id, firstName, lastName, int.Parse(codeNumber));
                    soldiers.Add(spy);
                }
            }

            foreach (var sold in soldiers)
            {
                Console.WriteLine(sold.ToString());
            }
        }
    }
}