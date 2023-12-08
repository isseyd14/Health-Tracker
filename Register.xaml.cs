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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database database = new Database();

            String username = Username.Text;
            String password = Password.Text;
            String Confirm = Confirm_Password.Text;
            String fullname = name.Text;
            String Age = age.Text;
            Debug.WriteLine("c"+username);
            if (username == "" || password == "" || Confirm == "" || fullname == "" || Age == "")
            {
                errormessage.Content = "Please fill out all the boxes";
            }
            else if (password != Confirm)
            {
                errormessage.Content = "Passwords dont match";
            }
            else if (database.usernameValid(username))
            {
                errormessage.Content = "Username is already taken";
            }
            else
            {
                Account userAccount = new Account(fullname, username, password, Age);
                Attributes attributes = new Attributes(userAccount);
                this.Close();
                attributes.Show();
            }

        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
