using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;

namespace WpfApp1.Health_Algorithms
{
    class Calories
    {
        public Calories() { 

        }

        public String CalorieSum(List<Meal> Calories)
        {
            int sum = 0;
            for (int i = 0; i < Calories.Count; i++)
            {
                String calories = Calories[i].Calories.Substring(0, Math.Min(Calories[i].Calories.Length, 4));
                sum += Convert.ToInt32(calories);
            }
            return sum.ToString();
        }

        public String CalorieGoal(Account account, Characteristic charcteristcs)
        {
            double Goal = Convert.ToDouble(account.Goal);
            double weight = Convert.ToDouble(account.Weight);
            double age = Convert.ToDouble(account.Age);
            double height = Convert.ToDouble(account.Height);
            String excersise = charcteristcs.Exercise;
            String Work = charcteristcs.Work;
            double bmrForMen = 88.362 + (13.397 * Goal) + (4.799 * height) - (5.677 * age);
            Double muliplier = Multiplier(excersise, Work);
            return (bmrForMen * muliplier).ToString();
        }

        public String CurrentMaintanence(Account account, Characteristic charcteristcs)
        {
            double weight = Convert.ToDouble(account.Weight);
            double age = Convert.ToDouble(account.Age);
            double height = Convert.ToDouble(account.Height);
            String excersise = charcteristcs.Exercise;
            String Work = charcteristcs.Work;
            double bmrForMen = 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
            Double muliplier = Multiplier(excersise, Work);
            return (bmrForMen * muliplier).ToString();
        }

        private double Multiplier( String Exercise, String Work)
        {
            double activityMultiplier;

            switch (Work.ToLower())
            {
                case "light":
                    switch (Exercise.ToLower())
                    {
                        case "1-2":
                            activityMultiplier = 1.2;
                            break;
                        case "2-3":
                            activityMultiplier = 1.35;
                            break;
                        case "4-5":
                            activityMultiplier = 1.55;
                            break;
                        case "6":
                            activityMultiplier = 1.7;
                            break;
                        case "7":
                            activityMultiplier = 1.8;
                            break;
                        default:
                            // Handle unknown exercise values
                            activityMultiplier = 1.55;
                            break;
                    }
                    break;
                case "medium":
                    switch (Exercise.ToLower())
                    {
                        case "1-2":
                            activityMultiplier = 1.375;
                            break;
                        case "2-3":
                            activityMultiplier = 1.5;
                            break;
                        case "4-5":
                            activityMultiplier = 1.65;
                            break;
                        case "6":
                            activityMultiplier = 1.8;
                            break;
                        case "7":
                            activityMultiplier = 1.9;
                            break;
                        default:
                            // Handle unknown exercise values
                            activityMultiplier = 1.55;
                            break;
                    }
                    break;
                case "heavy":
                    switch (Exercise.ToLower())
                    {
                        case "1-2":
                            activityMultiplier = 1.4;
                            break;
                        case "2-3":
                            activityMultiplier = 1.6;
                            break;
                        case "4-5":
                            activityMultiplier = 1.75;
                            break;
                        case "6":
                            activityMultiplier = 1.9;
                            break;
                        case "7":
                            activityMultiplier = 2.0;
                            break;
                        default:
                            // Handle unknown exercise values
                            activityMultiplier = 1.9;
                            break;
                    }
                    break;
                default:
                    // Handle unknown work values
                    activityMultiplier = 1.2;
                    break;
            }

            return activityMultiplier;
        }

        public double AskForGramsEaten(FoodItem selectedFoodItem)
        {
            if (selectedFoodItem != null)
            {
                string name = selectedFoodItem.Name;
                string calories = selectedFoodItem.Description;

                string gramsInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter the grams of {name} eaten:", "Grams Eaten", "100");

                if (string.IsNullOrEmpty(gramsInput))
                {
                    MessageBox.Show("Operation canceled.");
                }

                if (double.TryParse(gramsInput, out double grams))
                {

                    double caloriesConsumed = CalculateCaloriesConsumed(calories, grams);
                    MessageBox.Show($"You consumed {caloriesConsumed} calories by eating {grams} grams of {name}.");
                    return caloriesConsumed;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a numeric value for grams.");
                }
            }
            return 0.0;

        }

        public double CalculateCaloriesConsumed(string caloriesPer100g, double grams)
        {
            caloriesPer100g = caloriesPer100g.Substring(0,5);
            Debug.WriteLine(caloriesPer100g);
            Debug.WriteLine(grams);
            if (double.TryParse(caloriesPer100g.Trim('~',' ', 'c', 'a', 'l', 'o', 'r', 'i', 'e', 's', ' ', 'p', 'e', 'r', ' '), out double calories))
            {
                Debug.WriteLine(calories);
                Debug.WriteLine(grams);
                return (calories / 100) * grams;
            }
            return 0;
        }
    }
}
