using HospitalDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB
{
    class Hospital
    {
        static void Main(string[] args)
        {
            //DB Initialization
            //var context = new HospitalDBContext();
            //context.Database.Initialize(true);


            //This project hold exercise number 9 and 10
            //For 10 i have migrated the database after changing the Visitations and adding Doctor class
            //You can take a look at the hospital digram picture in the files.


            //Use the following method to seed your DB with some sample data.
            //AddSampleData();


        }

        private static void AddSampleData()
        {
            Doctor doctorOne = new Doctor() { Name = "Gosho", Speciality = "GP" };
            Doctor doctorTwo = new Doctor() { Name = "Pesho", Speciality = "GP" };
            Doctor doctorThree = new Doctor() { Name = "Ivan", Speciality = "GP" };

            Visitation visitationOne = new Visitation() { Date = DateTime.Now, Comments = "Blabla1" };
            Visitation visitationTwo = new Visitation() { Date = DateTime.Now, Comments = "Blabla2" };
            Visitation visitationThree = new Visitation() { Date = DateTime.Now, Comments = "Blabla3" };

            Diagnose diagnoseOne = new Diagnose() {Name = "SomeDiagnose1", Comments = "You're a wizard harry!" };
            Diagnose diagnoseTwo = new Diagnose() { Name = "SomeDiagnose2", Comments = "You're not a wizard Ivan!" };

            Medicament medOne = new Medicament() { Name = "Vitamin C" };
            Medicament medTwo = new Medicament() { Name = "Vitamin B" };

            Patient patiantOne = new Patient()
            {
                FirstName = "Vankata",
                LastName = "Vankov",
                Address = "Kichuka",
                Email = "ivan123@ivan.com",
                DateOfBirth = new DateTime(2000, 10, 25),
                IsInsured = true
            };

            Patient patiantTwo = new Patient()
            {
                FirstName = "Bankata",
                LastName = "Bankov",
                Address = "Bichuka",
                Email = "bivan123@bivan.com",
                DateOfBirth = new DateTime(2001, 11, 26),
                IsInsured = true
            };

            visitationOne.Doctor = doctorOne;
            visitationTwo.Doctor = doctorTwo;
            visitationThree.Doctor = doctorOne;

            patiantOne.Visitations.Add(visitationOne);
            patiantTwo.Visitations.Add(visitationTwo);
            patiantTwo.Visitations.Add(visitationThree);

            patiantOne.Diagnoses.Add(diagnoseOne);
            patiantTwo.Diagnoses.Add(diagnoseTwo);

            patiantOne.Medicaments.Add(medOne);
            patiantTwo.Medicaments.Add(medTwo);

            var context = new HospitalDBContext();

            context.Visitations.Add(visitationOne);
            context.Visitations.Add(visitationTwo);
            context.Visitations.Add(visitationThree);

            context.Patients.Add(patiantOne);
            context.Patients.Add(patiantTwo);

            context.Diagnoses.Add(diagnoseOne);
            context.Diagnoses.Add(diagnoseTwo);

            context.Medicaments.Add(medOne);
            context.Medicaments.Add(medTwo);

            context.SaveChanges();
        }
    }
}
