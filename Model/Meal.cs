using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Meal
    {
        public string Name { get; set; }
        public string Calories { get; set; }

        public Meal(string name, string calories)
        {
            Name = name;
            string[] parts = calories.Split('.');
            Calories = parts[0];
        }
    }
}
