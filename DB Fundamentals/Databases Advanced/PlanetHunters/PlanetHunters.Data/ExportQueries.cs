using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanetHunters.Data
{
    public class ExportQueries
    {
        public static string Planets(string telescopeName)
        {
            using (var context = new PlanetHuntersContext())
            {
                var planetsByTelescope = context.Discoveries
                    .Where(d => d.TelescopeUsed.Name == telescopeName)
                    .Select(d => d.Planets
                        .Select(s => new
                        {
                            Name = s.Name,
                            Mass = s.Mass,
                            Orbiting = s.HostStarSystem.Name
                        })
                    ).ToList();



                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(planetsByTelescope, settings);

                return json;
            }
        }

        public static XElement Stars()
        {
            using (var context = new PlanetHuntersContext())
            {
                var stars = context.Stars.Where(s => s.Discovery != null).ToList();

                XElement starsNode = new XElement("Stars");

                foreach (var star in stars)
                {
                    XElement starNode = new XElement("Star");

                    starNode.Add(new XElement("Name", star.Name));
                    starNode.Add(new XElement("Temperature", star.Temperature));
                    starNode.Add(new XElement("StarSystem", star.HostStarSystem.Name));
                    var discoveryNode = new XElement("DiscoveryInfo");
                    //discoveryNode.Add(new XAttribute("DiscoveryDate", star.Discovery.Date.ToString("yyyy'/'MM'/'dd")));
                    discoveryNode.Add(new XAttribute("TelescopeName", star.Discovery.TelescopeUsed.Name));
                    
                    //we dont export the date since the bonus taks changed thing a bit

                    List<Astronomer> astronomersPioneers = star.Discovery.Pioneers.ToList();
                    List<Astronomer> astronomersObservers = star.Discovery.Observers.ToList();

                    List<Astronomer> allAstronomers = new List<Astronomer>();

                    allAstronomers.AddRange(astronomersObservers);
                    allAstronomers.AddRange(astronomersPioneers);

                    allAstronomers = allAstronomers.OrderBy(a => a.FullName).ToList();

                    foreach (var a in allAstronomers)
                    {
                        XElement astro = new XElement("Astronomer");

                        if (astronomersPioneers.Contains(a))
                        {
                            astro.Add(new XAttribute("Pioneer", true));
                            astro.Value = a.FullName;
                        }
                        else
                        {
                            astro.Add(new XAttribute("Pioneer", false));
                            astro.Value = a.FullName;
                        }
                        discoveryNode.Add(astro);
                    }
                    starNode.Add(discoveryNode);
                    starsNode.Add(starNode);
                }

                return starsNode;
            }
        }

        public static string Astronomers(string starSystemName)
        {
            using (var context = new PlanetHuntersContext())
            {
                var systems = context.StarSystems
                    .Where(ss => ss.Name == starSystemName)
                    .Select(s => new { Stars = s.Stars, Planets = s.Planets })
                    .ToList();

                List<AstronomerDTO> astronomers = new List<AstronomerDTO>();

                foreach (var s in systems)
                {
                    foreach (var planet in s.Planets)
                    {
                        if (planet.Discovery != null)
                        {
                            foreach (var a in planet.Discovery.Pioneers)
                            {
                                var ast = new AstronomerDTO
                                {
                                    Name = a.FirstName + " " + a.LastName,
                                    Role = "pioneer"
                                };

                                astronomers.Add(ast);
                            }

                            foreach (var a in planet.Discovery.Observers)
                            {
                                var ast = new AstronomerDTO
                                {
                                    Name = a.FirstName + " " + a.LastName,
                                    Role = "observer"
                                };

                                astronomers.Add(ast);
                            }
                        }

                    }

                    foreach (var star in s.Stars)
                    {
                        if (star.Discovery != null)
                        {
                            foreach (var a in star.Discovery.Pioneers)
                            {
                                var ast = new AstronomerDTO
                                {
                                    Name = a.FirstName + " " + a.LastName,
                                    Role = "pioneer"
                                };

                                astronomers.Add(ast);
                            }

                            foreach (var a in star.Discovery.Observers)
                            {
                                var ast = new AstronomerDTO
                                {
                                    Name = a.FirstName + " " + a.LastName,
                                    Role = "observer"
                                };

                                astronomers.Add(ast);
                            }
                        }

                    }
                }

                astronomers = astronomers.Distinct().ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(astronomers, settings);

                return json;
            }
        }
    }
}
