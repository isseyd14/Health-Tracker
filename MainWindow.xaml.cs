using Org.BouncyCastle.Tls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Security;

using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

        }

        private void LoginSubmit_Click(object sender, RoutedEventArgs e)
        {

            string username = Username.Text;
            SecureString password = Password.SecurePassword;
            Database database = new Database();
            bool isValidLogin = database.IsLoginValid(username, password);
            if (isValidLogin)
            {
                Home home = new Home(username);
                home.Show();
                this.Close();
                Debug.WriteLine("worked");
                
            }
            else { error.Content = "Login invalid"; }

        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}