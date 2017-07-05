using Problem5_MordorsCrueltyPlan.Models;
using Problem5_MordorsCrueltyPlan.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_MordorsCrueltyPlan
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var foodNames = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Food> foods = new List<Food>();

            var ff = new FoodFactory();

            foreach (var name in foodNames)
            {
                foods.Add(ff.CreateFood(name));
            }

            Gandalf gandalf = new Gandalf(foods);

            Console.WriteLine(gandalf.ToString());
        }
    }
}