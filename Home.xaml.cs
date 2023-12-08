using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DAO;
using WpfApp1.Health_Algorithms;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private String? Username;
        private Account Account;
        private Characteristic Character;

        public Home(String username)
        {
            Database database = new Database();
            CalorieDAO calorieDAO = new CalorieDAO();
            Username = username;
            Character = calorieDAO.charcteristics(Username);
            Account = database.Account(Username);
            InitializeComponent();
            LabelSetters();
            DataContext = new Model.Search();
            PopulateCurrentMeals();

        }

        public void LabelSetters()
        {
            CalorieDAO calorieDAO = new CalorieDAO();
            Calories calories = new Calories();
            List<Meal> currentcalories = calorieDAO.Calories(Username);
            Current_calories.Content = calories.CalorieSum(currentcalories);
            //goal calolries
            //Debug.WriteLine(Character.Exercise + " d " + Character.Work);
            String GoalCalories = calories.CalorieGoal(Account, Character);
            string[] parts = GoalCalories.Split('.');
            String goalCaloriesValue = parts[0];
            Goal_Intake.Content = goalCaloriesValue.ToString();

        }
        public void PopulateCurrentMeals()
        {
            CalorieDAO calorieDAO = new CalorieDAO();
            List<Meal> meal = calorieDAO.Calories(Username);
            if (meal.Count > 0)
            {
                CurrentMeals.ItemsSource = meal;
            } else
            {
                CurrentMeals.ItemsSource = "No meals have been ate";

            }

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Calories calories = new Calories();
                CalorieDAO calorieDAO = new CalorieDAO();
                var selectedFoodItem = (FoodItem)e.AddedItems[0];
                string name = selectedFoodItem.Name;
                double Calories = calories.AskForGramsEaten(selectedFoodItem);
                if (Calories > 0)
                {
                    calorieDAO.AddMeal(new Meal(name, Calories.ToString()), Username);
                    CurrentMeals.Visibility = Visibility.Visible;
                    Home home = new Home(Username);
                    Debug.WriteLine(selectedFoodItem.Description);
                    home.Show();
                    this.Close();

                }
                else
                {
                    CurrentMeals.Visibility = Visibility.Collapsed;
                }

            }
        }

        private void CurrentMeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentMeals.SelectedItem != null)
            {
                // Access the selected item
                var selectedMeal = (Meal)CurrentMeals.SelectedItem;

                // Prompt the user for confirmation
                MessageBoxResult result = MessageBox.Show($"Do you want to delete {selectedMeal.Name}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    CalorieDAO calorieDAO = new CalorieDAO();
                    calorieDAO.DeleteMeal(selectedMeal, Username);
                    Home home = new Home(Username);
                    home.Show();
                    this.Close();

                }
                else
                {
                    // User canceled the deletion
                    // You can handle this case if needed
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountsPage accountsPage = new AccountsPage(Account, Character); 
            accountsPage.Show();
            this.Close();
        }
    }
}
