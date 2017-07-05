using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_MordorsCrueltyPlan.Models.FoodModels
{
    public abstract class Food
    {
        private int happinessPoints;

        public Food(int points)
        {
            this.HappinessPoints = points;
        }

        public int HappinessPoints
        {
            get { return this.happinessPoints; }
            private set { this.happinessPoints = value; }
        }
    }
}