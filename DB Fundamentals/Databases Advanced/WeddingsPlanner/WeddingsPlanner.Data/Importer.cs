using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeddingsPlanner.Data.DTOs;
using WeddingsPlanner.Models;
using WeddingsPlanner.Models.enums;

namespace WeddingsPlanner.Data
{
    public static class Importer
    {
        private static Random rnd = new Random();
        private static readonly object syncLock = new object();
        public static void ImportAgencies()
        {
            List<Agency> agencies = new List<Agency>();

            string json = File.ReadAllText(@"..\..\..\WeddingsPlanner.Data\Imports\agencies.json");

            agencies = JsonConvert.DeserializeObject<List<Agency>>(json);

            using (var context = new WeddingsPlannerContext())
            {
                context.Agencies.AddRange(agencies);
                context.SaveChanges();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var agency in agencies)
            {
                sb.AppendLine($"Successfully imported {agency.Name}");
            }
            Console.WriteLine(sb.ToString());
        }

        public static void ImportPresents()
        {
            //presentType, invitationId => required
            //if Cash amount must be specified
            //if gift name is required
            XDocument presentsXml = XDocument.Load(@"..\..\..\WeddingsPlanner.Data\Imports\presents.xml");

            List<Present> presents = new List<Present>();
            StringBuilder sb = new StringBuilder();

            using (var context = new WeddingsPlannerContext())
            {
                foreach (var p in presentsXml.Root.Elements())
                {
                    var typeAtr = p.Attribute("type");
                    var invIdAtr = p.Attribute("invitation-id");
                    if (typeAtr == null || invIdAtr == null)
                    {
                        sb.AppendLine($"Error. Invalid data provided");
                    }
                    else
                    {
                        string type = typeAtr.Value;
                        int invId = int.Parse(invIdAtr.Value);
                        if (type == "cash")
                        {
                            var amountAtr = p.Attribute("amount");
                            if (amountAtr != null)
                            {
                                decimal amount = decimal.Parse(amountAtr.Value);

                                Invitation inv = GetInvitation(context, invId);

                                if (inv == null)
                                {
                                    sb.AppendLine($"Error. Invalid data provided");
                                    continue;
                                }

                                Present present = new Cash
                                {
                                    Invitation = inv,
                                    CashAmount = amount
                                };

                                presents.Add(present);
                                sb.AppendLine($"Succesfully imported {type} from {inv.Guest.FullName}");
                            }
                            else
                            {
                                sb.AppendLine($"Error. Invalid data provided");
                            }
                        }
                        else if (type == "gift")
                        {
                            var nameAtr = p.Attribute("present-name");
                            if (nameAtr != null)
                            {
                                string name = nameAtr.Value;
                                Invitation inv = GetInvitation(context, invId);

                                if (inv == null)
                                {
                                    sb.AppendLine($"Error. Invalid data provided");
                                    continue;
                                }

                                GiftSize size = GiftSize.NotSpecified;
                                var sizeAtr = p.Attribute("size");
                                if (sizeAtr != null)
                                {
                                    if (!Enum.TryParse(sizeAtr.Value, out size))
                                    {
                                        sb.AppendLine($"Error. Invalid data provided");
                                        continue;
                                    }
                                }

                                Present present = new Gift
                                {
                                    Name = name,
                                    Invitation = inv,
                                    Size = size
                                };

                                presents.Add(present);
                                sb.AppendLine($"Succesfully imported {type} from {inv.Guest.FullName}");
                            }
                            else
                            {
                                sb.AppendLine($"Error. Invalid data provided");
                            }
                        }
                        else
                        {
                            sb.AppendLine($"Error. Invalid data provided");
                        }
                    }
                }

                context.Presents.AddRange(presents);
                context.SaveChanges();
                Console.WriteLine(sb.ToString());
            }
        }

        private static Invitation GetInvitation(WeddingsPlannerContext context, int invId)
        {
            if (context.Invitations.Any(i => i.Id == invId))
            {
                return context.Invitations.FirstOrDefault(i => i.Id == invId);
            }
            else
            {
                return null;
            }
        }

        public static void ImportVenues()
        {
            XDocument venuesXml = XDocument.Load(@"..\..\..\WeddingsPlanner.Data\Imports\venues.xml");

            List<Venue> venues = new List<Venue>();
            StringBuilder sb = new StringBuilder();

            foreach (var ven in venuesXml.Root.Elements())
            {
                string venueName = null;
                int capacity = 0;
                string town = null;

                var nameAtr = ven.Attribute("name");
                if (nameAtr != null)
                {

                    venueName = ven.Attribute("name").Value;

                }

                var capEle = ven.Element("capacity");
                if (capEle != null)
                {
                    capacity = int.Parse(ven.Element("capacity").Value);
                }

                var townEle = ven.Element("town");
                if (townEle != null)
                {

                    town = ven.Element("town").Value;

                }

                Venue newVenue = new Venue
                {
                    Name = venueName,
                    Capacity = capacity,
                    Town = town
                };

                venues.Add(newVenue);

                sb.AppendLine($"Successfully imported {venueName}");
            }

            using (var context = new WeddingsPlannerContext())
            {
                var weddings = context.Weddings.ToList();


                context.Venues.AddRange(venues);
                context.SaveChanges();
                venues = context.Venues.ToList();
                foreach (var w in weddings)
                {

                    Venue venueOne = venues[GenerateRandomNumber(0, venues.Count - 1)];

                    Venue venueTwo = venues[GenerateRandomNumber(0, venues.Count - 1)];
                    while (venueOne.Equals(venueTwo))
                    {
                        venueTwo = venues[GenerateRandomNumber(0, venues.Count - 1)];
                    }

                    w.Venues.Add(venueOne);
                    w.Venues.Add(venueTwo);
                }

                
                context.SaveChanges();
            }

            Console.WriteLine(sb.ToString());
        }

        private static int GenerateRandomNumber(int v1, int v2)
        {
            lock (syncLock)
            {
                return rnd.Next(v1, v2);
            }
        }

        public static void ImportWeddingsAndInvitations()
        {
            //Bride, bridegroom, agency, date => required
            using (var context = new WeddingsPlannerContext())
            {
                List<WeddingDTO> weddings = new List<WeddingDTO>();

                string json = File.ReadAllText(@"..\..\..\WeddingsPlanner.Data\Imports\weddings.json");

                weddings = JsonConvert.DeserializeObject<List<WeddingDTO>>(json);

                StringBuilder sb = new StringBuilder();

                List<Wedding> newWeddings = new List<Wedding>();

                foreach (var w in weddings)
                {
                    if (w.Bride == null || w.Bridegroom == null || w.Agency == null || w.Date == null)
                    {
                        sb.AppendLine($"Error. Invalid data provided");
                    }
                    else
                    {
                        if (!PersonExists(context, w.Bride) || !PersonExists(context, w.Bridegroom))
                        {
                            sb.AppendLine($"Error. Invalid data provided");
                            continue;
                        }
                        Wedding newWedding = new Wedding
                        {
                            Agency = GetAgency(context, w.Agency),
                            Bride = GetPerson(context, w.Bride),
                            Bridegroom = GetPerson(context, w.Bridegroom),
                            Date = DateTime.Parse(w.Date.Value.ToString())
                        };

                        foreach (var guest in w.Guests)
                        {
                            if (guest.Name != null)
                            {
                                if (PersonExists(context, guest.Name))
                                {
                                    Invitation inv = new Invitation
                                    {
                                        Guest = GetPerson(context, guest.Name),
                                        IsAttending = guest.RSVP,
                                        Family = guest.Family,
                                        Wedding = newWedding
                                    };

                                    newWedding.Invitations.Add(inv);
                                }
                            }

                        }

                        newWeddings.Add(newWedding);

                        string brideName = w.Bride.Split().FirstOrDefault();
                        string groomName = w.Bridegroom.Split().FirstOrDefault();

                        sb.AppendLine($"Successfully imported wedding of {brideName} and {groomName}");
                    }
                }
                context.Weddings.AddRange(newWeddings);
                context.SaveChanges();
                Console.WriteLine(sb.ToString());
            }
        }

        private static Person GetPerson(WeddingsPlannerContext context, string fullname)
        {
            return context.People.FirstOrDefault(p => p.FirstName + " " + p.MiddleInitial + " " + p.LastName == fullname);
        }

        private static Agency GetAgency(WeddingsPlannerContext context, string agency)
        {
            if (context.Agencies.Any(a => a.Name == agency))
            {
                return context.Agencies.FirstOrDefault(a => a.Name == agency);
            }
            else
            {
                return null;
            }
        }

        private static bool PersonExists(WeddingsPlannerContext context, string fullName)
        {
            return context.People.Any(p => p.FirstName + " " + p.MiddleInitial + " " + p.LastName == fullName);
        }

        public static void ImportPeople()
        {
            //firstname MiddleInit lastname -> required
            //gender to be validated => if null SEt to Not Specified
            List<PersonDTO> people = new List<PersonDTO>();

            string json = File.ReadAllText(@"..\..\..\WeddingsPlanner.Data\Imports\people.json");

            people = JsonConvert.DeserializeObject<List<PersonDTO>>(json);

            StringBuilder sb = new StringBuilder();

            List<Person> newPeople = new List<Person>();



            foreach (var personDTO in people)
            {
                if (personDTO.FirstName == null
                    || personDTO.LastName == null
                    || personDTO.MiddleInitial == null
                    || personDTO.MiddleInitial.Length != 1
                    || personDTO.FirstName.Length < 1
                    || personDTO.FirstName.Length > 60
                    || personDTO.LastName.Length < 2)
                {
                    sb.AppendLine($"Error. Invalid data provided");
                }
                else
                {
                    if (personDTO.Email != null)
                    {
                        if (!Regex.IsMatch(personDTO.Email, @"^[a-zA-Z0-9]+\@[a-z]+\.[a-z]+$"))
                        {
                            sb.AppendLine($"Error. Invalid data provided");
                            continue;
                        }
                    }

                    Gender gender = Gender.NotSpecified;

                    if (personDTO.Gender != null)
                    {
                        Enum.TryParse(personDTO.Gender, out gender);
                    }



                    var newPerson = new Person
                    {
                        FirstName = personDTO.FirstName,
                        LastName = personDTO.LastName,
                        MiddleInitial = personDTO.MiddleInitial,
                        Gender = gender,
                        Birthdate = personDTO.Birthday,
                        Phone = personDTO.Phone,
                        Email = personDTO.Email
                    };

                    newPeople.Add(newPerson);

                    sb.AppendLine($"Successfully imported {newPerson.FirstName} {newPerson.MiddleInitial} {newPerson.LastName}");
                }
            }


            using (var context = new WeddingsPlannerContext())
            {
                context.People.AddRange(newPeople);
                context.SaveChanges();
            }


            Console.WriteLine(sb.ToString());
        }
    }
}
