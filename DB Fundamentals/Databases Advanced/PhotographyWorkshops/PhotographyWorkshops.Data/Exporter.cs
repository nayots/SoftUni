using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhotographyWorkshops.Data
{
    public class Exporter
    {
        public void ExportOrderedPhotographers()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                var photographers = context.Photographers
                    .Select(p => new
                    {
                        p.FirstName,
                        p.LastName,
                        p.Phone
                    })
                    .OrderBy(o => o.FirstName)
                    .ThenByDescending(o => o.LastName)
                    .ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(photographers, settings);

                File.WriteAllText(@"..\..\..\PhotographyWorkshops.Data\Exports\photographers-ordered.json", json);
            }
        }

        public void ExportWorkshopsByLocation()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                var workshopsBylocation = context.Workshops
                    .GroupBy(g => g.Location, ws => ws, (location, workshops) => new
                    {
                        Location = location,
                        Workshops = workshops.Where(ws => ws.Participants.Count >= 5)
                    })
                    .Where(ws => ws.Workshops.Count() > 0)
                    .Select(wsBylocation => new
                    {
                        Location = wsBylocation.Location,
                        WorkShops = wsBylocation.Workshops
                    })
                    .ToList();

                var xml = new XElement("locations");

                foreach (var location in workshopsBylocation)
                {
                    var locNode = new XElement("location");
                    locNode.Add(new XAttribute("name", $"{location.Location}"));
                    foreach (var w in location.WorkShops)
                    {
                        var wsNode = new XElement("workshop");
                        wsNode.Add(new XAttribute("name", $"{w.Name}"));
                        wsNode.Add(new XAttribute("total-profit", ((w.Participants.Count * w.PricePerParticipant) * 0.80M)));
                        var participantsNode = new XElement("participants");
                        participantsNode.Add(new XAttribute("count", w.Participants.Count));
                        foreach (var p in w.Participants)
                        {
                            var participantNode = new XElement("participant");
                            participantNode.Value = $"{p.FirstName} {p.LastName}";
                            participantsNode.Add(participantNode);
                        }
                        wsNode.Add(participantsNode);
                        locNode.Add(wsNode);
                    }
                    xml.Add(locNode);
                }
                
                xml.Save(@"..\..\..\PhotographyWorkshops.Data\Exports\workshops-by-location.xml");
            }
        }

        public void ExportSameCamerasPhotographers()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                var photographers = context.Photographers
                    .Where(p => p.PrimaryCamera.Make == p.SecondaryCamera.Make)
                    .ToList();

                var xml = new XElement("photographers");

                foreach (var ph in photographers)
                {
                    var phNode = new XElement("photographer");
                    phNode.Add(new XAttribute("name", $"{ph.FirstName} {ph.LastName}"));
                    phNode.Add(new XAttribute("primary-camera", $"{ph.PrimaryCamera.Make} {ph.PrimaryCamera.Model}"));

                    if (ph.Lenses.Count > 0)
                    {
                        var lensesNode = new XElement("lenses");
                        foreach (var lens in ph.Lenses)
                        {
                            var lensNode = new XElement("lens");
                            lensNode.Value = $"{lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}";
                            lensesNode.Add(lensNode);
                        }
                        phNode.Add(lensesNode);
                    }
                    xml.Add(phNode);
                }
                xml.Save(@"..\..\..\PhotographyWorkshops.Data\Exports\same-cameras-photographers.xml");
            }
        }

        public void ExportLandscapePhotographers()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                var photographers = context.Photographers
                    .Where(p => p.PrimaryCamera.Type == Models.CameraType.DSLR && p.Lenses.All(l => l.FocalLength <= 30))
                    .Select(p => new
                    {
                        p.FirstName,
                        p.LastName,
                        CameraMake = p.PrimaryCamera.Make,
                        LensesCount = p.Lenses.Count
                    })
                    .OrderBy(o => o.FirstName)
                    .ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(photographers, settings);

                File.WriteAllText(@"..\..\..\PhotographyWorkshops.Data\Exports\landscape-photogaphers.json", json);
            }
        }
    }
}
