using MassDefect.Data.DTO;
using MassDefect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MassDefect.Data
{
    public static class Importer
    {
        public static void ImportSolarSystems()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\solar-systems.json");

                List<SolarSystem> solarSystems = new List<SolarSystem>();

                solarSystems = JsonConvert.DeserializeObject<List<SolarSystem>>(json);

                StringBuilder sb = new StringBuilder();

                solarSystems = solarSystems.Where(s => s.Name != null).ToList();

                foreach (var ss in solarSystems)
                {
                    sb.AppendLine($"Successfully imported Solar System {ss.Name}");
                }

                context.SolarSystems.AddRange(solarSystems);
                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ImportPlanets()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\planets.json");

                List<PlanetDTO> planetsDTO = new List<PlanetDTO>();

                planetsDTO = JsonConvert.DeserializeObject<List<PlanetDTO>>(json);

                List<Planet> planets = new List<Planet>();

                StringBuilder sb = new StringBuilder();

                foreach (var p in planetsDTO)
                {
                    if (p.Name != null && p.SolarSystem != null && p.Sun != null)
                    {
                        if (SolarSystemExists(p.SolarSystem) && StarExists(p.Sun))
                        {
                            Planet planet = new Planet
                            {
                                Name = p.Name,
                                SolarSystem = GetSolarSystemByName(p.SolarSystem, context),
                                Sun = GetStarByName(p.Sun, context)
                            };

                            planets.Add(planet);
                            sb.AppendLine($"Successfully imported Planet {p.Name}");
                        }
                        else
                        {
                            sb.AppendLine("Error: Invalid data.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }

                context.Planets.AddRange(planets);
                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ImportPeople()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\persons.json");

                List<PersonDTO> peopleDTO = new List<PersonDTO>();

                peopleDTO = JsonConvert.DeserializeObject<List<PersonDTO>>(json);

                List<Person> people = new List<Person>();

                StringBuilder sb = new StringBuilder();

                foreach (var p in peopleDTO)
                {
                    if (p.Name != null && p.HomePlanet != null)
                    {
                        if (PlanetExists(p.HomePlanet))
                        {
                            Person person = new Person
                            {
                                Name = p.Name,
                                HomePlanet = GetPlanetByName(p.HomePlanet, context)
                            };

                            people.Add(person);
                            sb.AppendLine($"Successfully imported Person {p.Name}");
                        }
                        else
                        {
                            sb.AppendLine("Error: Invalid data.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }

                context.People.AddRange(people);
                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ImportAnomalies()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\anomalies.json");

                List<AnomalyDTO> anomaliesDTO = new List<AnomalyDTO>();

                anomaliesDTO = JsonConvert.DeserializeObject<List<AnomalyDTO>>(json);

                List<Anomaly> anomalies = new List<Anomaly>();

                StringBuilder sb = new StringBuilder();

                foreach (var a in anomaliesDTO)
                {
                    if (a.OriginPlanet != null && a.TeleportPlanet != null)
                    {
                        if (PlanetExists(a.OriginPlanet) && PlanetExists(a.TeleportPlanet))
                        {
                            Anomaly anomaly = new Anomaly
                            {
                                OriginPlanet = GetPlanetByName(a.OriginPlanet, context),
                                TeleportPlanet = GetPlanetByName(a.TeleportPlanet, context)
                            };

                            anomalies.Add(anomaly);
                            sb.AppendLine($"Successfully imported Anomaly from {anomaly.OriginPlanet.Name} to {anomaly.TeleportPlanet.Name}");
                        }
                        else
                        {
                            sb.AppendLine("Error: Invalid data.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }

                context.Anomalies.AddRange(anomalies);
                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ImportAnomalyVictims()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\anomaly-victims.json");

                List<AnomalyVictimDTO> avDTOs = new List<AnomalyVictimDTO>();

                avDTOs = JsonConvert.DeserializeObject<List<AnomalyVictimDTO>>(json);

                StringBuilder sb = new StringBuilder();

                foreach (var av in avDTOs)
                {
                    Anomaly anomaly = GetAnomalyById(av.Id, context);
                    Person person = GetPersonByName(av.Person, context);


                    if (anomaly != null && person != null)
                    {
                        anomaly.Victims.Add(person);

                        sb.AppendLine($"Successfully imported Victim {person.Name} to anomaly: {anomaly.Id}");
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }

                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ImportNewAnomalies()
        {
            XDocument anomaliesXML = XDocument.Load(@"..\..\..\MassDefect.Data\Import\new-anomalies.xml");

            StringBuilder sb = new StringBuilder();

            List<Anomaly> anomalies = new List<Anomaly>();

            using (var context = new MassDefectContext())
            {
                foreach (var a in anomaliesXML.Root.Elements())
                {
                    var originPlanetAtr = a.Attribute("origin-planet");
                    var teleportPlanetAtr = a.Attribute("teleport-planet");
                    if (originPlanetAtr != null && teleportPlanetAtr != null)
                    {
                        if (PlanetExists(originPlanetAtr.Value) && PlanetExists(teleportPlanetAtr.Value))
                        {
                            Anomaly anomaly = new Anomaly
                            {
                                OriginPlanet = GetPlanetByName(originPlanetAtr.Value, context),
                                TeleportPlanet = GetPlanetByName(teleportPlanetAtr.Value, context)
                            };

                            foreach (var victim in a.XPathSelectElements("victims/victim"))
                            {
                                var victrimNameAtr = victim.Attribute("name");
                                if (victrimNameAtr == null)
                                {
                                    continue;
                                }
                                string victimName = victim.Attribute("name").Value;

                                Person vic = GetPersonByName(victimName, context);

                                if (vic != null)
                                {
                                    anomaly.Victims.Add(vic);
                                }
                            }

                            anomalies.Add(anomaly);
                            sb.AppendLine($"Successfully imported Anomaly from {anomaly.OriginPlanet.Name} to {anomaly.TeleportPlanet.Name} with {anomaly.Victims.Count} victims!");
                        }
                        else
                        {
                            sb.AppendLine("Error: Invalid data.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }
                context.Anomalies.AddRange(anomalies);
                context.SaveChanges();
                Console.WriteLine(sb.ToString());
            }
        }

        private static Person GetPersonByName(string personName, MassDefectContext context)
        {
            return context.People.FirstOrDefault(p => p.Name == personName);
        }

        private static Anomaly GetAnomalyById(int id, MassDefectContext context)
        {
            return context.Anomalies.FirstOrDefault(a => a.Id == id);
        }

        private static Planet GetPlanetByName(string planetName, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == planetName);
        }

        private static bool PlanetExists(string planetName)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.Any(p => p.Name == planetName);
            }
        }

        private static Star GetStarByName(string starName, MassDefectContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == starName);
        }

        private static bool StarExists(string starName)
        {
            using (var context = new MassDefectContext())
            {
                return context.Stars.Any(s => s.Name == starName);
            }
        }

        public static void ImportStars()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText(@"..\..\..\MassDefect.Data\Import\stars.json");

                List<StarDTO> starsDTO = new List<StarDTO>();

                starsDTO = JsonConvert.DeserializeObject<List<StarDTO>>(json);

                List<Star> stars = new List<Star>();

                StringBuilder sb = new StringBuilder();

                foreach (var s in starsDTO)
                {
                    if (s.Name != null && s.SolarSystem != null)
                    {
                        if (SolarSystemExists(s.SolarSystem))
                        {
                            Star star = new Star
                            {
                                Name = s.Name,
                                SolarSystem = GetSolarSystemByName(s.SolarSystem, context)
                            };

                            stars.Add(star);
                            sb.AppendLine($"Successfully imported Star {s.Name}");
                        }
                        else
                        {
                            sb.AppendLine("Error: Invalid data.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }

                context.Stars.AddRange(stars);
                context.SaveChanges();

                Console.WriteLine(sb.ToString());
            }
        }

        private static SolarSystem GetSolarSystemByName(string solarSystem, MassDefectContext context)
        {
            return context.SolarSystems.FirstOrDefault(ss => ss.Name == solarSystem);
        }

        private static bool SolarSystemExists(string solarSystem)
        {
            using (var context = new MassDefectContext())
            {
                return context.SolarSystems.Any(ss => ss.Name == solarSystem);
            }
        }
    }
}
