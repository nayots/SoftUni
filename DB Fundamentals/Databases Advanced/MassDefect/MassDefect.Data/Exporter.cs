using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassDefect.Data
{
    public static class Exporter
    {
        public static void ExportPlanets()
        {
            using (var context = new MassDefectContext())
            {
                var planets = context.Planets
                    .Where(p => !p.OriginatingAnomalies.Any())
                    .Select(p => new
                    {
                        Name = p.Name
                    }).ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(planets, settings);

                File.WriteAllText(@"..\..\..\MassDefect.Data\Export\planets.json", json);
            }
        }

        public static void ExportPeople()
        {
            using (var context = new MassDefectContext())
            {
                var people = context.People
                    .Where(p => !p.Anomalies.Any())
                    .Select(p => new
                    {
                        Name = p.Name,
                        HomePlanet = new { Name = p.HomePlanet.Name }
                    }).ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(people, settings);

                File.WriteAllText(@"..\..\..\MassDefect.Data\Export\people.json", json);
            }
        }

        public static void ExportAnomaly()
        {
            using (var context = new MassDefectContext())
            {
                var anomaly = context.Anomalies
                    .OrderByDescending(a => a.Victims.Count)
                    .Take(1)
                    .Select(a => new
                    {
                        Id = a.Id,
                        OriginPlanet = new { Name = a.OriginPlanet.Name},
                        TeleportPlanet = new { Name = a.TeleportPlanet.Name},
                        VictimsCount = a.Victims.Count
                    });

                
                    

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(anomaly, settings);

                File.WriteAllText(@"..\..\..\MassDefect.Data\Export\anomaly.json", json);
            }
        }

        public static void ExportAnomalies()
        {
            using (var context = new MassDefectContext())
            {
                var anomalies = context.Anomalies
                    .Select(a => new
                    {
                        Id = a.Id,
                        OriginPlanet = a.OriginPlanet.Name,
                        TeleportPlanet = a.TeleportPlanet.Name,
                        Victims = a.Victims.Select(v => v.Name)
                    })
                    .OrderBy(o => o.Id)
                    .ToList();

                var xml = new XElement("anomalies");

                foreach (var a in anomalies)
                {
                    var anomalyNode = new XElement("anomaly");
                    anomalyNode.Add(new XAttribute("id", a.Id));
                    anomalyNode.Add(new XAttribute("origin-planet", a.OriginPlanet));
                    anomalyNode.Add(new XAttribute("teleport-planet", a.TeleportPlanet));
                    var victimsNode = new XElement("victims");
                    foreach (var name in a.Victims)
                    {
                        var victimEle = new XElement("victim");
                        victimEle.Add(new XAttribute("name", name));

                        victimsNode.Add(victimEle);
                    }
                    anomalyNode.Add(victimsNode);

                    xml.Add(anomalyNode);
                }


                xml.Save(@"..\..\..\MassDefect.Data\Export\anomalies.xml");
            }
        }
    }
}
