using Problem5_MordorsCrueltyPlan.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_MordorsCrueltyPlan.Models
{
    public class Gandalf
    {
        private List<Food> foods;
        private Mood mood;

        public Mood Mood
        {
            get { return this.mood; }
            private set { this.mood = value; }
        }

        public Gandalf(List<Food> foodsEaten)
        {
            this.Foods = foodsEaten;
            this.Mood = MoodFacctory.GetMood(this.Foods);
        }

        public List<Food> Foods
        {
            get { return this.foods; }
            private set { this.foods = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Foods.Sum(f => f.HappinessPoints)}");
            sb.Append(this.Mood.Description);

            return sb.ToString();
        }
    }
}