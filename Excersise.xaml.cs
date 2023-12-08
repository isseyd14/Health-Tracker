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
    /// Interaction logic for Excersise.xaml
    /// </summary>
    public partial class Excersise : Window
    {
        private Account _user;

        public Excersise(Account account)
        {
            InitializeComponent();
            _user = account;
        }

        private void Workout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {
            String workout = Workout.Text ;
            String work = Work.Text;
            String username = _user.Username;
            Characteristic characteristic = new Characteristic(username,work, workout);
            Database DAO = new Database();
            DAO.AccountRegister(_user,characteristic);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Attributes att = new Attributes(_user);

        }
    }
}
