using System;
using System.Collections.Generic;
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
    /// Interaction logic for AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Window
    {
        private Characteristic character;
        private Account account;
        public AccountsPage(Account account_, Characteristic character_)
        {
            InitializeComponent();
            character = character_;
            account = account_;
            username.Text = account.Username;
            fullname.Text = account.FullName;
            Height.Text = account.Height;
            Weight.Text = account.Weight;
            GoalWeight.Text = account.Goal;
            Debug.WriteLine(account.Weight);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String user = account.Username;
            Database database = new Database();
            if (string.IsNullOrEmpty(username.Text) ||
                string.IsNullOrEmpty(fullname.Text) ||
                string.IsNullOrEmpty(Height.Text) ||
                string.IsNullOrEmpty(Weight.Text) ||
                string.IsNullOrEmpty(GoalWeight.Text))
            {
                errormessage.Content = "Make sure to input in all boxes";
            }
            else if ( !int.TryParse(Height.Text, out _) ||
                      !int.TryParse(Weight.Text, out _) ||
                      !int.TryParse(GoalWeight.Text, out _))
            {
                errormessage.Content = "Only enter digits for Height, Weight and Goal Weight";
            }
            else if (database.usernameValid(username.Text) && user != account.Username)
            {
                errormessage.Content = "Username is already taken";
            }
            else
            {
                account.Username = username.Text;
                account.FullName = fullname.Text;
                account.Height = Height.Text;
                account.Weight = Weight.Text;
                account.Goal = GoalWeight.Text;
                database.AccountUpdate(account, character, user);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Home home = new Home(account.Username);
            home.Show();
            this.Close();
        }

        private void Work_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            character.Work = Work.Text;

        }

        private void Workout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            character.Exercise = Workout.Text;
        }

    }
}
