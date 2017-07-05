using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem5_MordorsCrueltyPlan.Models.FoodModels;

namespace Problem5_MordorsCrueltyPlan.Models
{
    public class MoodFacctory
    {
        internal static Mood GetMood(List<Food> foods)
        {
            int happyPoints = foods.Sum(f => f.HappinessPoints);

            if (happyPoints < -5)
            {
                return new Mood("Angry");
            }
            if (happyPoints >= -5 && happyPoints <= 0)
            {
                return new Mood("Sad");
            }
            if (happyPoints >= 1 && happyPoints <= 15)
            {
                return new Mood("Happy");
            }

            return new Mood("JavaScript");
        }
    }
}