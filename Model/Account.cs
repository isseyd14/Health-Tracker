using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Account
    {
        // Properties
        public string FullName { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Goal { get; set; }

        // Constructor
        public Account() { }
        public Account(string fullName, string username, string password, string age)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Age = age;
        }
        public Account(string fullName, string weight, string height, string username, string password, string goal)
        {
            FullName = fullName;
            Weight = weight;
            Height = height;
            Username = username;
            Password = password;
            Goal = goal;
        }

        // Additional methods or behaviors can be added as needed
        public double CalculateBMI()
        {
            double weight = double.Parse(Weight);
            double height = double.Parse(Height);
            // Example method to calculate BMI (Body Mass Index)
            return weight / Math.Pow(height, 2);
        }
    }
}