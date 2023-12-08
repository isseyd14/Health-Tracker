using System;
using System.Collections.Generic;
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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Attributes.xaml
    /// </summary>
    public partial class Attributes : Window
    {
        private Account _user;

        public Attributes(Account user)
        {
            InitializeComponent();
            _user = user;

        }

        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Height1.Text == "" || Weight1.Text == "" || GoalWeight.Text == "")
            { }
            else
            {
                String height = Height1.Text;
                String weight = Weight1.Text;
                String goal = GoalWeight.Text;
                _user.Goal = goal;
                _user.Weight = weight;
                _user.Height = height;
                Excersise excersise = new Excersise(_user);
                this.Close();
                excersise.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Height1_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = !IsNumeric(Height1.Text);
        }

        private void Weight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = !IsNumeric(Weight1.Text);

        }
        private void GoalWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = !IsNumeric(GoalWeight.Text);

        }
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
