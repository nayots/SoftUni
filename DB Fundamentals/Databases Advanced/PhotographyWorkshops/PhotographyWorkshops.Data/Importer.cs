using Newtonsoft.Json;
using PhotographyWorkshops.Data.DTOs;
using PhotographyWorkshops.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhotographyWorkshops.Data
{
    public class Importer
    {
        private static readonly Random rnd = new Random();
        public void ImportLenses()
        {
            List<Lens> lenses = new List<Lens>();

            string json = File.ReadAllText(@"..\..\..\PhotographyWorkshops.Data\Imports\lenses.json");

            lenses = JsonConvert.DeserializeObject<List<Lens>>(json);

            using (var context = new PhotographyWorkshopsContext())
            {
                context.Lenses.AddRange(lenses);
                context.SaveChanges();
            }

            StringBuilder sb = new StringBuilder();
            if (lenses.Count > 0)
            {
                var last = lenses.Last();
                foreach (var lens in lenses)
                {
                    if (lens != last)
                    {
                        sb.AppendLine($"Successfully imported {lens.Make} {lens.FocalLength}mm f{lens.MaxAperture:F1}");
                    }
                    else
                    {
                        sb.Append($"Successfully imported {lens.Make} {lens.FocalLength}mm f{lens.MaxAperture:F1}");
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public void ImportWorkshops()
        {
            //workshopName, location, price, trainer -> required
            XDocument workshopsXml = XDocument.Load(@"..\..\..\PhotographyWorkshops.Data\Imports\workshops.xml");
            StringBuilder sb = new StringBuilder();
            List<Workshop> workshops = new List<Workshop>();
            
            using (var context = new PhotographyWorkshopsContext())
            {
                foreach (var ws in workshopsXml.Root.Elements())
                {
                    string wsName = null;
                    string location = null;
                    decimal price = 0;
                    Photographer trainer = null;
                    DateTime? startDate = new DateTime();
                    DateTime? endDate = new DateTime();

                    var wsNameAtr = ws.Attribute("name");
                    var wsLocationAtr = ws.Attribute("location");
                    var wsPriceAtr = ws.Attribute("price");
                    var wsTrainer = ws.Element("trainer");
                    var wsStartDateAtr = ws.Attribute("start-date");
                    var wsEndDateAtr = ws.Attribute("end-date");

                    var wsParticipantsEle = ws.Element("participants");

                    if (wsNameAtr != null && wsLocationAtr != null && wsPriceAtr != null && wsTrainer != null)
                    {
                        wsName = wsNameAtr.Value;
                        location = wsLocationAtr.Value;
                        price = decimal.Parse(wsPriceAtr.Value);
                        trainer = GetTrainerByFullName(context, wsTrainer.Value);

                        Workshop newWorkshop = new Workshop
                        {
                            Name = wsName,
                            Location = location,
                            PricePerParticipant = price,
                            Trainer = trainer
                        };

                        if (wsStartDateAtr != null)
                        {
                            startDate = DateTime.Parse(wsStartDateAtr.Value);
                            newWorkshop.StartDate = startDate;
                        }

                        if (wsEndDateAtr != null)
                        {
                            endDate = DateTime.Parse(wsEndDateAtr.Value);
                            newWorkshop.EndDate = endDate;
                        }

                        if (wsParticipantsEle != null)
                        {
                            foreach (var participant in wsParticipantsEle.Elements())
                            {
                                string firstName = participant.Attribute("first-name").Value;
                                string lastName = participant.Attribute("last-name").Value;

                                newWorkshop.Participants.Add(GetParticipant(context, firstName, lastName));

                            }
                        }

                        workshops.Add(newWorkshop);
                        sb.AppendLine($"Successfully imported {newWorkshop.Name}");
                    }
                    else
                    {
                        sb.AppendLine($"Error. Invalid data provided");
                    }
                }
                context.Workshops.AddRange(workshops);
                context.SaveChanges();
            }
            Console.WriteLine(sb.ToString());
        }

        private Photographer GetParticipant(PhotographyWorkshopsContext context, string firstName, string lastName)
        {
            return context.Photographers.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
        }

        private Photographer GetTrainerByFullName(PhotographyWorkshopsContext context, string trainerFullname)
        {
            return context.Photographers.FirstOrDefault(p => (p.FirstName + " " + p.LastName) == trainerFullname);
        }

        public void ImportAccessories()
        {
            XDocument accessoriesXml = XDocument.Load(@"..\..\..\PhotographyWorkshops.Data\Imports\accessories.xml");

            List<Accessory> accessories = new List<Accessory>();
            StringBuilder sb = new StringBuilder();

            foreach (var acc in accessoriesXml.Root.Elements())
            {
                var nameEle = acc.Attribute("name");
                if (nameEle != null)
                {
                    Accessory newAcc = new Accessory
                    {
                        Name = acc.Attribute("name").Value,
                        OwnerId = GetRandomOwnerId()
                    };
                    accessories.Add(newAcc);
                    sb.AppendLine($"Successfully imported {newAcc.Name}");
                }
            }

            using (var context = new PhotographyWorkshopsContext())
            {
                context.Accessories.AddRange(accessories);
                context.SaveChanges();
            }

            Console.WriteLine(sb.ToString());
        }

        private int GetRandomOwnerId()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                var photographersIds = context.Photographers.Select(p => p.Id).ToList();

                return photographersIds[rnd.Next(0, photographersIds.Count - 1)];
            }
        }

        public void ImportPhotographers()
        {
            //firstname & lastname -> required
            //phone to be validated
            List<PhotographerDTO> photographers = new List<PhotographerDTO>();

            string json = File.ReadAllText(@"..\..\..\PhotographyWorkshops.Data\Imports\photographers.json");

            photographers = JsonConvert.DeserializeObject<List<PhotographerDTO>>(json);

            StringBuilder sb = new StringBuilder();

            List<Photographer> photograpersWithLenses = new List<Photographer>();

            var context = new PhotographyWorkshopsContext();

            foreach (var ph in photographers)
            {
                if (ph.FirstName == null || ph.LastName == null)
                {
                    sb.AppendLine($"Error. Invalid data provided");
                }
                else
                {
                    if (ph.Phone != null)
                    {
                        if (!Regex.IsMatch(ph.Phone, @"^\+[\d]{1,3}\/[\d]{8,10}$"))
                        {
                            sb.AppendLine($"Error. Invalid data provided");
                            continue;
                        }
                    }

                    var photographer = new Photographer
                    {
                        FirstName = ph.FirstName,
                        LastName = ph.LastName,
                        Phone = ph.Phone,
                        PrimaryCamera = GetRandomCamera(context),
                        SecondaryCamera = GetRandomCamera(context)
                    };


                    photographer.Lenses = GetLensesFromIdArray(context, ph.Lenses, photographer.PrimaryCamera.Make, photographer.SecondaryCamera.Make);


                    photograpersWithLenses.Add(photographer);

                    sb.AppendLine($"Successfully imported {photographer.FirstName} {photographer.LastName} | Lenses: {photographer.Lenses.Count}");
                }
            }


            context.Photographers.AddRange(photograpersWithLenses);

            context.SaveChanges();


            Console.WriteLine(sb.ToString());
        }

        private Camera GetRandomCamera(PhotographyWorkshopsContext context)
        {

            var dslrcameras = context.DSLRCameras.ToList();
            var mirrorlesscameras = context.MirrorlessCameras.ToList();



            int randomCameraType = rnd.Next(0, 1);

            if (randomCameraType == 0)
            {
                int rndDslr = rnd.Next(0, dslrcameras.Count - 1);
                return dslrcameras[rndDslr];
            }
            else
            {
                int rndMrrls = rnd.Next(0, mirrorlesscameras.Count - 1);
                return mirrorlesscameras[rndMrrls];
            }

        }

        private ICollection<Lens> GetLensesFromIdArray(PhotographyWorkshopsContext context, int[] lenses, string makePrimary, string makeSecondary)
        {

            List<Lens> lensesToadd = new List<Lens>();

            foreach (var id in lenses)
            {
                if (context.Lenses.Any(l => l.Id == id))
                {
                    var lens = context.Lenses.FirstOrDefault(l => l.Id == id);

                    if (lens.CompatibleWith == makePrimary || lens.CompatibleWith == makeSecondary)
                    {
                        lensesToadd.Add(lens);
                    }
                }
            }

            return lensesToadd;
        }

        public void ImportCameras()
        {
            List<CameraDTO> cameras = new List<CameraDTO>();

            string json = File.ReadAllText(@"..\..\..\PhotographyWorkshops.Data\Imports\cameras.json");

            cameras = JsonConvert.DeserializeObject<List<CameraDTO>>(json);

            //Type, make, model, minIso -> required

            List<DSLRCamera> dslrCameras = new List<DSLRCamera>();
            List<MirrorlessCamera> mirrorlessCameras = new List<MirrorlessCamera>();
            StringBuilder sb = new StringBuilder();

            foreach (var cam in cameras)
            {
                if (cam.Type != "DSLR" && cam.Type != "Mirrorless" || (cam.Make == null || cam.Model == null || cam.MinISO < 100))
                {
                    sb.AppendLine($"Error. Invalid data provided");
                }
                else
                {
                    if (cam.Type == "DSLR")
                    {
                        CameraType type = new CameraType();
                        Enum.Parse(type.GetType(), cam.Type);
                        dslrCameras.Add(new DSLRCamera
                        {
                            IsFullFrame = cam.IsFullFrame,
                            Make = cam.Make,
                            MaxIso = cam.MaxISO,
                            MaxShutterSpeed = cam.MaxShutterSpeed,
                            MinIso = cam.MinISO,
                            Model = cam.Model,
                            Type = type
                        });
                    }
                    else
                    {
                        CameraType type = new CameraType();
                        Enum.Parse(type.GetType(), cam.Type);
                        mirrorlessCameras.Add(new MirrorlessCamera
                        {
                            IsFullFrame = cam.IsFullFrame,
                            Make = cam.Make,
                            MaxIso = cam.MaxISO,
                            MinIso = cam.MinISO,
                            MaxFrameRate = cam.MaxFrameRate,
                            MaxVideoResolution = cam.MaxVideoResolution,
                            Model = cam.Model,
                            Type = type
                        });
                    }

                    sb.AppendLine($"Successfully imported {cam.Type} {cam.Make} {cam.Model}");
                }
            }

            using (var context = new PhotographyWorkshopsContext())
            {
                context.DSLRCameras.AddRange(dslrCameras);
                context.MirrorlessCameras.AddRange(mirrorlessCameras);
                context.SaveChanges();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
