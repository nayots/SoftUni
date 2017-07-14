using PawInc.Models.Animals;
using PawInc.Models.Centers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models
{
    public class CenterManager
    {
        private List<AdoptionCenter> adoptionCenters;
        private List<CleansingCenter> cleansingCenters;
        private List<CastrationCenter> castrationCenters;
        private List<string> cleansedAnimalNames;
        private List<string> adoptedAnimalNames;
        private List<string> castratedAnimalNames;

        public CenterManager()
        {
            this.adoptionCenters = new List<AdoptionCenter>();
            this.cleansingCenters = new List<CleansingCenter>();
            this.castrationCenters = new List<CastrationCenter>();
            this.cleansedAnimalNames = new List<string>();
            this.adoptedAnimalNames = new List<string>();
            this.castratedAnimalNames = new List<string>();
        }

        public void RegisterCleansingCenter(string name)
        {
            this.cleansingCenters.Add(new CleansingCenter(name));
        }

        public void RegisterAdoptionCenter(string name)
        {
            this.adoptionCenters.Add(new AdoptionCenter(name));
        }

        public void RegisterCastrationCenter(string name)
        {
            this.castrationCenters.Add(new CastrationCenter(name));
        }

        public void RegisterDog(string name, int age, int commands, string adoptionCenterName)
        {
            var center = this.adoptionCenters.First(c => c.Name == adoptionCenterName);

            center.Animals.Add(new Dog(name, age, commands, adoptionCenterName));
        }

        public void RegisterCat(string name, int age, int intelligence, string adoptionCenterName)
        {
            var center = this.adoptionCenters.First(c => c.Name == adoptionCenterName);

            center.Animals.Add(new Cat(name, age, intelligence, adoptionCenterName));
        }

        public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            var cleansingCenter = this.cleansingCenters.First(c => c.Name == cleansingCenterName);

            var animalsToCleanse = adoptionCenter.Animals.Where(a => a.CleansingStatus == false).ToList();

            adoptionCenter.Animals.RemoveAll(a => a.CleansingStatus == false);

            cleansingCenter.Animals.AddRange(animalsToCleanse);
        }

        public void SendForCastration(string adoptionCenterName, string castrationCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            var castrationCenter = this.castrationCenters.First(c => c.Name == castrationCenterName);

            var animalsToCastrate = adoptionCenter.Animals.Where(a => a.CastrationStatus == false).ToList();

            adoptionCenter.Animals.RemoveAll(a => a.CastrationStatus == false);

            castrationCenter.Animals.AddRange(animalsToCastrate);
        }

        public void Cleanse(string cleansingCenterName)
        {
            var cleansingCenter = this.cleansingCenters.First(c => c.Name == cleansingCenterName);

            var animals = cleansingCenter.Cleanse();

            this.cleansedAnimalNames.AddRange(animals.Select(a => a.Name).ToList());

            var adoptionCentersNames = animals.Select(a => a.AdoptionCenterName).Distinct().ToList();

            foreach (var acn in adoptionCentersNames)
            {
                var adoptionCenter = this.adoptionCenters.First(c => c.Name == acn);

                var centerAnimals = animals.Where(a => a.AdoptionCenterName == acn).ToList();

                adoptionCenter.Animals.AddRange(centerAnimals);
            }
        }

        public void Castrate(string castrationCenterName)
        {
            var castrationCenter = this.castrationCenters.First(c => c.Name == castrationCenterName);

            var animals = castrationCenter.Castrate();

            this.castratedAnimalNames.AddRange(animals.Select(a => a.Name).ToList());

            var adoptionCentersNames = animals.Select(a => a.AdoptionCenterName).Distinct().ToList();

            foreach (var acn in adoptionCentersNames)
            {
                var adoptionCenter = this.adoptionCenters.First(c => c.Name == acn);

                var centerAnimals = animals.Where(a => a.AdoptionCenterName == acn).ToList();

                adoptionCenter.Animals.AddRange(centerAnimals);
            }
        }

        public void Adopt(string adoptionCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);

            this.adoptedAnimalNames.AddRange(adoptionCenter.Animals.Where(a => a.CleansingStatus == true).Select(a => a.Name).ToList());

            adoptionCenter.Adopt();
        }

        public void CastrationStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Paw Inc. Regular Castration Statistics");
            sb.AppendLine($"Castration Centers: {this.castrationCenters.Count}");
            var castratedAnimals = this.castratedAnimalNames.Count > 0 ? string.Join(", ", this.castratedAnimalNames.OrderBy(n => n)) : "None";
            sb.Append($"Castrated Animals: {castratedAnimals}");

            Console.WriteLine(sb.ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Paw Incorporative Regular Statistics");
            sb.AppendLine($"Adoption Centers: {this.adoptionCenters.Count}");
            sb.AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}");
            var adoptedAnimals = this.adoptedAnimalNames.Count > 0 ? string.Join(", ", this.adoptedAnimalNames.OrderBy(n => n)) : "None";
            sb.AppendLine($"Adopted Animals: {adoptedAnimals}");
            var cleansedAnimals = this.cleansedAnimalNames.Count > 0 ? string.Join(", ", this.cleansedAnimalNames.OrderBy(n => n)) : "None";
            sb.AppendLine($"Cleansed Animals: {cleansedAnimals}");

            sb.AppendLine($"Animals Awaiting Adoption: {this.adoptionCenters.Sum(c => c.Animals.Where(a => a.CleansingStatus == true).ToList().Count)}");
            sb.AppendLine($"Animals Awaiting Cleansing: {this.cleansingCenters.Sum(c => c.Animals.Where(a => a.CleansingStatus == false).ToList().Count)}");

            return sb.ToString();
        }
    }
}