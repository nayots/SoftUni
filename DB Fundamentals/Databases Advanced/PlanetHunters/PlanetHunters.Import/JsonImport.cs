using Newtonsoft.Json;
using PlanetHunters.Data;
using PlanetHunters.Import.DTO;
using PlanetHunters.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanetHunters.Import
{
    public static class JsonImport
    {
        public static void Astronomers()
        {
            var json = File.ReadAllText(@"..\..\..\PlanetHunters.Import\ImportFiles\astronomers.json");

            List<AstronomerDTO> astronomersDTOs = new List<AstronomerDTO>();

            astronomersDTOs = JsonConvert.DeserializeObject<List<AstronomerDTO>>(json);

            StringBuilder sb = new StringBuilder();

            List<Astronomer> astronomers = new List<Astronomer>();

            foreach (var astronomerDTO in astronomersDTOs)
            {
                if (astronomerDTO.FirstName != null && astronomerDTO.LastName != null)
                {
                    if (astronomerDTO.FirstName.Length > 50 || astronomerDTO.LastName.Length > 50)
                    {
                        sb.AppendLine("Invalid data format.");
                    }
                    else
                    {
                        Astronomer astro = new Astronomer
                        {
                            FirstName = astronomerDTO.FirstName,
                            LastName = astronomerDTO.LastName
                        };

                        astronomers.Add(astro);
                        sb.AppendLine($"Record {astro.FullName} successfully imported.");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid data format.");
                }
            }

            ImportQueries.ImportAstronomers(astronomers);

            Console.WriteLine(sb.ToString());
        }

        public static void Telescopes()
        {
            var json = File.ReadAllText(@"..\..\..\PlanetHunters.Import\ImportFiles\telescopes.json");

            List<TelescopeDTO> telescopesDTOs = new List<TelescopeDTO>();

            telescopesDTOs = JsonConvert.DeserializeObject<List<TelescopeDTO>>(json);

            StringBuilder sb = new StringBuilder();

            List<Telescope> telescopes = new List<Telescope>();

            foreach (var telescopeDTO in telescopesDTOs)
            {
                if (telescopeDTO.Name != null && telescopeDTO.Location != null)
                {
                    if (telescopeDTO.Name.Length > 255 || telescopeDTO.Location.Length > 255)
                    {
                        sb.AppendLine("Invalid data format.");
                    }
                    else
                    {
                        Telescope telescope = new Telescope
                        {
                            Name = telescopeDTO.Name,
                            Location = telescopeDTO.Location
                        };

                        if (telescopeDTO.MirrorDiameter != null)
                        {
                            if (telescopeDTO.MirrorDiameter <= 0.00)
                            {
                                sb.AppendLine("Invalid data format.");
                                continue;
                            }
                            else
                            {
                                telescope.MirrorDiameter = telescopeDTO.MirrorDiameter;
                            }
                        }

                        telescopes.Add(telescope);
                        sb.AppendLine($"Record {telescope.Name} successfully imported.");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid data format.");
                }
            }

            ImportQueries.ImportTelescopes(telescopes);

            Console.WriteLine(sb.ToString());
        }

        public static void Planets()
        {
            var json = File.ReadAllText(@"..\..\..\PlanetHunters.Import\ImportFiles\planets.json");

            List<PlanetDTO> planetsDTOs = new List<PlanetDTO>();

            planetsDTOs = JsonConvert.DeserializeObject<List<PlanetDTO>>(json);

            StringBuilder sb = new StringBuilder();

            List<Planet> planets = new List<Planet>();

            foreach (var planetDTO in planetsDTOs)
            {
                if (planetDTO.Name != null && planetDTO.Mass != null && planetDTO.StarSystem != null)
                {
                    if (planetDTO.Mass <= 0.00)
                    {
                        sb.AppendLine("Invalid data format.");
                        continue;
                    }
                    else
                    {
                        ImportQueries.ImportPlanet(planetDTO.Name, (double)planetDTO.Mass, planetDTO.StarSystem);
                        sb.AppendLine($"Record {planetDTO.Name} successfully imported.");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid data format.");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
