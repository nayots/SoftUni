using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.Application.Models
{
    public static class CakeList
    {
        private const string dbFilePath = @".\Application\Resources\Data\database.csv";

        private static List<Cake> cakes = new List<Cake>();

        private static bool isLoadedUpToDate = false;

        public static void Add(Cake cake)
        {
            cakes.Add(cake);
            SaveCakeToDb(cake);
        }

        private static void SaveCakeToDb(Cake cake)
        {
            if (!File.Exists(dbFilePath))
            {
                File.Create(dbFilePath);
            }

            File.AppendAllText(dbFilePath, $"{cake.Name}, {cake.Price}{Environment.NewLine}");
        }

        public static string GetCakesAsHtmlString()
        {
            if (!isLoadedUpToDate)
            {
                LoadData();
                isLoadedUpToDate = true;
            }

            var sb = new StringBuilder();

            foreach (var cake in cakes)
            {
                sb.AppendLine(cake.ToString());
            }

            return sb.ToString();
        }

        public static string GetCakesAsHtmlString(string keyword)
        {
            if (!isLoadedUpToDate)
            {
                LoadData();
                isLoadedUpToDate = true;
            }

            var sb = new StringBuilder();

            var filteredCakes = cakes.Where(c => c.Name.ToLower().Contains(keyword.ToLower()));

            foreach (var cake in filteredCakes)
            {
                sb.AppendLine(cake.ToString());
            }

            return sb.ToString();
        }

        private static void LoadData()
        {
            if (!File.Exists(dbFilePath))
            {
                File.Create(dbFilePath);
            }

            string[] rawData = File.ReadAllLines(dbFilePath);

            for (int i = 0; i < rawData.Length; i++)
            {
                string[] lineTokens = rawData[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string name = lineTokens[0];
                double price = double.Parse(lineTokens[1]);

                cakes.Add(new Cake(name, price));
            }
        }
    }
}