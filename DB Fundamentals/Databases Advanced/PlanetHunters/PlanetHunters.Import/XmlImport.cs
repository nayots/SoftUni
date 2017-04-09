using PlanetHunters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanetHunters.Import
{
    public static class XmlImport
    {
        public static void Stars()
        {
            XDocument starsXML = XDocument.Load(@"..\..\..\PlanetHunters.Import\ImportFiles\stars.xml");

            StringBuilder sb = new StringBuilder();

            foreach (var starEle in starsXML.Root.Elements())
            {
                var nameEle = starEle.Element("Name");
                var temperatureELe = starEle.Element("Temperature");
                var starSEle = starEle.Element("StarSystem");

                if (nameEle != null && temperatureELe != null && starEle != null)
                {
                    int temperature = int.Parse(temperatureELe.Value);

                    if (temperature < 2400)
                    {
                        sb.AppendLine("Invalid data format.");
                        continue;
                    }
                    else
                    {
                        ImportQueries.ImportStar(nameEle.Value, temperature, starSEle.Value);
                        sb.AppendLine($"Record {nameEle.Value} successfully imported.");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid data format.");
                }
            }

            Console.WriteLine(sb.ToString());

        }

        public static void Discoveries()
        {
            XDocument discoveriesXML = XDocument.Load(@"..\..\..\PlanetHunters.Import\ImportFiles\discoveries.xml");

            StringBuilder sb = new StringBuilder();
            //Must have valid existing : astronomer, planets, stars => continue
            //telescope always exists
            foreach (var discEle in discoveriesXML.Root.Elements())
            {
                var discDateAtr = discEle.Attribute("DateMade");
                var discTelescopeAtr = discEle.Attribute("Telescope");
                var starsEle = discEle.Element("Stars");
                var planetsEle = discEle.Element("Planets");
                var pioneersEle = discEle.Element("Pioneers");
                var observersEle = discEle.Element("Observers");

                List<string> starNames = new List<string>();
                List<string> planetNames = new List<string>();
                List<string> pioneersNames = new List<string>();
                List<string> observersNames = new List<string>();

                DateTime date = DateTime.Parse(discDateAtr.Value);

                if (starsEle != null)
                {
                    foreach (var starName in starsEle.Elements())
                    {
                        if (starName != null)
                        {
                            starNames.Add(starName.Value);
                        }
                    }

                    if (starNames.Count > 0)
                    {
                        if (!ImportQueries.ValidateStarsByName(starNames))
                        {
                            continue;
                        }
                        
                    }
                }

                if (planetsEle != null)
                {
                    foreach (var planetName in planetsEle.Elements())
                    {
                        if (planetName != null)
                        {
                            planetNames.Add(planetName.Value);
                        }
                    }

                    if (planetNames.Count > 0)
                    {
                        if (!ImportQueries.ValidatePlanetsByName(planetNames))
                        {
                            continue;
                        }

                    }
                }

                if (pioneersEle != null)
                {
                    foreach (var pioneerName in pioneersEle.Elements())
                    {
                        if (pioneerName != null)
                        {
                            string[] nameArg = pioneerName.Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string fullName = $"{nameArg[1]} {nameArg[0]}";
                            pioneersNames.Add(fullName);
                        }
                    }

                    if (pioneersNames.Count > 0)
                    {
                        if (!ImportQueries.ValidateAstronomersByName(pioneersNames))
                        {
                            continue;
                        }

                    }
                }

                if (observersEle != null)
                {
                    foreach (var observerName in observersEle.Elements())
                    {
                        if (observerName != null)
                        {
                            string[] nameArg = observerName.Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string fullName = $"{nameArg[1]} {nameArg[0]}";
                            observersNames.Add(fullName);
                        }
                    }

                    if (observersNames.Count > 0)
                    {
                        if (!ImportQueries.ValidateAstronomersByName(observersNames))
                        {
                            continue;
                        }
                    }
                }

                ImportQueries.ImportDiscovery(date, discTelescopeAtr.Value, starNames, planetNames, pioneersNames, observersNames);
                sb.AppendLine($"Discovery ({date.ToString("yyyy'/'MM'/'dd")} - {discTelescopeAtr.Value}) with {starNames.Count} stars, {planetNames.Count} planets, {pioneersNames.Count} pioneers and {observersNames.Count} observers successfully imported.");

            }

            Console.WriteLine(sb.ToString());
            //TODO CHANGE PLURAL FORM for discovered objects and astronomers
        }
    }
}
