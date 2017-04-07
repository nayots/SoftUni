using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeddingsPlanner.Models;

namespace WeddingsPlanner.Data
{
    public static class Exporter
    {
        public static void OrderedAgencies()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var agencies = context.Agencies
                    .Select(a => new
                    {
                        Name = a.Name,
                        Count = a.EmployeesCount,
                        Town = a.Town
                    })
                    .OrderByDescending(o => o.Count)
                    .ThenBy(o => o.Name)
                    .ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(agencies, settings);

                File.WriteAllText(@"..\..\..\WeddingsPlanner.Data\Exports\agencies-ordered.json", json);
            }
        }

        public static void GuestList()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var guests = context.Weddings
                    .Select(w => new
                    {
                        Bride = w.Bride.FirstName + " " + w.Bride.MiddleInitial + " " + w.Bride.LastName,
                        Bridegroom = w.Bridegroom.FirstName + " " + w.Bridegroom.MiddleInitial + " " + w.Bridegroom.LastName,
                        Agency = new { Name = w.Agency.Name, Town = w.Agency.Town },
                        InvitedGuests = w.Invitations.Count,
                        BrideGuests = w.Invitations.Where(i => i.Family == Models.enums.Family.Bride).Count(),
                        BridegroomGuests = w.Invitations.Where(i => i.Family == Models.enums.Family.Bridegroom).Count(),
                        AttendingGuests = w.Invitations.Where(i => i.IsAttending == true).Count(),
                        Guests = w.Invitations.Where(i => i.IsAttending == true).Select(g => g.Guest.FirstName + " " + g.Guest.MiddleInitial + " " + g.Guest.LastName)
                    })
                    .OrderByDescending(o => o.InvitedGuests)
                    .ThenBy(o => o.AttendingGuests)
                    .ToList();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(guests, settings);

                File.WriteAllText(@"..\..\..\WeddingsPlanner.Data\Exports\guests.json", json);
            }
        }

        public static void VenuesSofia()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var venues = context.Venues
                    .Where(v => v.Town == "Sofia" && v.Weddings.Count >= 3)
                    .OrderBy(o => o.Capacity)
                    .ToList();

                var xml = new XElement("venues");
                xml.Add(new XAttribute("town", "Sofia"));
                foreach (var v in venues)
                {
                    var venueEle = new XElement("venue");
                    venueEle.Add(new XAttribute("name", v.Name));
                    venueEle.Add(new XAttribute("capacity", v.Capacity));
                    venueEle.Add(new XElement("weddings-count", v.Weddings.Count));
                    xml.Add(venueEle);
                }

                xml.Save(@"..\..\..\WeddingsPlanner.Data\Exports\sofia-venues.xml");
            }
        }

        public static void AgenciesByTown()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var agenciesByTown = context.Agencies
                    .GroupBy(a => a.Town, at => at, (town, agencies) => new
                    {
                        Town = town,
                        Agencies = agencies.Where(a => a.OrganizedWeddings.Count >= 2)
                    })
                    .Where(a => a.Town.Length >= 6)
                    .ToList();

                var xml = new XElement("towns");

                foreach (var at in agenciesByTown)
                {
                    var townEle = new XElement("town");
                    townEle.Add(new XAttribute("name", at.Town));
                    var agenciesEle = new XElement("agencies");
                    foreach (var a in at.Agencies)
                    {
                        decimal profit = a.OrganizedWeddings
                            .Sum(w => w.Invitations.Where(i => (i.Present as Cash) != null).Sum(i => (i.Present as Cash).CashAmount) * 0.2M);

                        var agencyEle = new XElement("agency");
                        agencyEle.Add(new XAttribute("name", a.Name));
                        agencyEle.Add(new XAttribute("profit", profit));
                        foreach (var w in a.OrganizedWeddings)
                        {
                            var wedEle = new XElement("wedding");
                            wedEle.Add(new XAttribute("cash", w.Invitations.Where(i => i.Present as Cash != null).Sum(i => (i.Present as Cash).CashAmount)));
                            wedEle.Add(new XAttribute("presents", w.Invitations.Where(i => i.Present as Gift != null).Select(g => g.Present as Gift).Where(g => g.Size != Models.enums.GiftSize.NotSpecified).Count()));
                            wedEle.Add(new XElement("bride", w.Bride.FullName));
                            wedEle.Add(new XElement("bridegroom", w.Bridegroom.FullName));
                            var guestsEle = new XElement("guests");
                            foreach (var g in w.Invitations)
                            {
                                var guestEle = new XElement("guest");
                                guestEle.Add(new XAttribute("family", g.Family));
                                guestEle.Value = g.Guest.FirstName;
                                guestsEle.Add(guestEle);
                            }
                            wedEle.Add(guestsEle);
                            agencyEle.Add(wedEle);
                        }
                        agenciesEle.Add(agencyEle);
                    }
                    townEle.Add(agenciesEle);
                    xml.Add(townEle);
                }

                xml.Save(@"..\..\..\WeddingsPlanner.Data\Exports\agencies-by-town.xml");
            }
        }
    }
}
