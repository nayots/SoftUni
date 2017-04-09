using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Models;

namespace PlanetHunters.Data
{
    public static class ImportQueries
    {
        public static void ImportAstronomers(List<Astronomer> astronomers)
        {
            using (var context = new PlanetHuntersContext())
            {
                context.Astronomers.AddRange(astronomers);
                context.SaveChanges();
            }
        }

        public static void ImportTelescopes(List<Telescope> telescopes)
        {
            using (var context = new PlanetHuntersContext())
            {
                context.Telescopes.AddRange(telescopes);
                context.SaveChanges();
            }
        }

        public static void ImportPlanet(string name, double mass, string starSystem)
        {
            using (var context = new PlanetHuntersContext())
            {
                Planet planet = new Planet
                {
                    Name = name,
                    Mass = mass
                };

                if (StarSystemExists(starSystem))
                {
                    planet.HostStarSystem = GetStarSystemByName(starSystem, context);
                }
                else
                {
                    planet.HostStarSystem = new StarSystem
                    {
                        Name = starSystem
                    };
                }

                context.Planets.Add(planet);
                context.SaveChanges();
            }
        }

        private static StarSystem GetStarSystemByName(string starSystemName, PlanetHuntersContext context)
        {
            return context.StarSystems.FirstOrDefault(ss => ss.Name == starSystemName);
        }

        private static bool StarSystemExists(string starSystemName)
        {
            using (var context = new PlanetHuntersContext())
            {
                return context.StarSystems.Any(ss => ss.Name == starSystemName);
            }
        }

        public static void ImportStar(string name, int temperature, string starSystem)
        {
            using (var context = new PlanetHuntersContext())
            {
                Star star = new Star
                {
                    Name = name,
                    Temperature = temperature
                };

                if (StarSystemExists(starSystem))
                {
                    star.HostStarSystem = GetStarSystemByName(starSystem, context);
                }
                else
                {
                    star.HostStarSystem = new StarSystem
                    {
                        Name = starSystem
                    };
                }

                context.Stars.Add(star);
                context.SaveChanges();
            }
        }

        public static bool ValidateStarsByName(List<string> starNames)
        {
            using (var context = new PlanetHuntersContext())
            {
                bool valid = true;

                foreach (var name in starNames)
                {
                    if (!context.Stars.Any(s => s.Name == name))
                    {
                        valid = false;
                        return valid;
                    }
                }

                return valid;
            }
        }

        public static bool ValidatePlanetsByName(List<string> planetNames)
        {
            using (var context = new PlanetHuntersContext())
            {
                bool valid = true;

                foreach (var name in planetNames)
                {
                    if (!context.Planets.Any(p => p.Name == name))
                    {
                        valid = false;
                        return valid;
                    }
                }

                return valid;
            }
        }

        public static bool ValidateAstronomersByName(List<string> astronomersNames)
        {
            using (var context = new PlanetHuntersContext())
            {
                bool valid = true;

                foreach (var name in astronomersNames)
                {
                    if (!context.Astronomers.Any(a => a.FirstName + " " + a.LastName == name))
                    {
                        valid = false;
                        return valid;
                    }
                }

                return valid;
            }
        }

        public static void ImportDiscovery(DateTime date, string telescopeName, List<string> starNames, List<string> planetNames, List<string> pioneersNames, List<string> observersNames)
        {
            using (var context = new PlanetHuntersContext())
            {
                Discovery discovery = new Discovery
                {
                    TelescopeUsed = GetTelescopeByName(telescopeName, context),
                    Stars = GetStarsByName(starNames, context),
                    Planets = GetPlanetsByName(planetNames, context),
                    Pioneers = GetAstronomersByName(pioneersNames, context),
                    Observers = GetAstronomersByName(observersNames, context)
                };

                Publication publication = new Publication
                {
                    Discovery = discovery,
                    ReleaseDate = date
                };

                context.Discoveries.Add(discovery);
                context.Publications.Add(publication);
                context.SaveChanges();
            }
        }

        private static ICollection<Astronomer> GetAstronomersByName(List<string> astronomerNames, PlanetHuntersContext context)
        {
            List<Astronomer> astronomers = new List<Astronomer>();

            foreach (var an in astronomerNames)
            {
                var astronomer = context.Astronomers.FirstOrDefault(a => a.FirstName + " " + a.LastName == an);
                astronomers.Add(astronomer);
            }

            return astronomers;
        }

        private static ICollection<Planet> GetPlanetsByName(List<string> planetNames, PlanetHuntersContext context)
        {
            List<Planet> planets = new List<Planet>();

            foreach (var pn in planetNames)
            {
                var planet = context.Planets.FirstOrDefault(p => p.Name == pn);
                planets.Add(planet);
            }

            return planets;
        }

        private static ICollection<Star> GetStarsByName(List<string> starNames, PlanetHuntersContext context)
        {
            List<Star> stars = new List<Star>();

            foreach (var sn in starNames)
            {
                var star = context.Stars.FirstOrDefault(s => s.Name == sn);
                stars.Add(star);
            }

            return stars;
        }

        private static Telescope GetTelescopeByName(string telescopeName, PlanetHuntersContext context)
        {
            return context.Telescopes.FirstOrDefault(t => t.Name == telescopeName);
        }
    }
}
