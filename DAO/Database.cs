
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using WpfApp1.Model;
using System.Windows.Documents;


namespace WpfApp1
{

    class Database
    {
        private MySqlConnection _connection;

        public Database()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=HealthTracker;User Id=root;Password=root;";
            _connection = new MySqlConnection(connectionString);
        }

        public bool IsLoginValid(string username, SecureString password)
        {
            Debug.WriteLine(username + ConvertSecureStringToString(password));

            using (var command = new MySqlCommand("SELECT COUNT(*) FROM healthtracker.account WHERE username = @Username AND password = @Password", _connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", ConvertSecureStringToString(password));


                try
                {
                    _connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return false;
                }
                finally {
                    _connection.Close();
                }
            }
        }

        public bool Register(string username, SecureString password)
        {
            Debug.WriteLine(username + ConvertSecureStringToString(password));

            using (var command = new MySqlCommand("SELECT COUNT(*) FROM healthtracker.account WHERE username = @Username AND password = @Password", _connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", ConvertSecureStringToString(password));


                try
                {
                    _connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return false;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public bool usernameValid(string username)
        {
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM healthtracker.account WHERE Username = @Username", _connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    _connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return false;
                }
                finally
                {
                    _connection.Close();
                }
            }

        }

        public void AccountRegister(Account account, Characteristic charcter)
        {
            using (var command = new MySqlCommand("INSERT INTO healthtracker.account (Username, Password, full_name, Weight, Height, Goal_Weight, Age) VALUES (@Username, @Password, @FullName, @Weight, @Height, @goal, @Age)", _connection))
            {
                var command2 = new MySqlCommand("INSERT INTO healthtracker.charcteristics (username, workout, work) VALUES (@Username, @Workout, @Work)", _connection);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@FullName", account.FullName);
                command.Parameters.AddWithValue("@Weight", account.Weight);
                command.Parameters.AddWithValue("@Height", account.Height);
                command.Parameters.AddWithValue("@goal", account.Goal);
                command.Parameters.AddWithValue("@Age", account.Age);
                command2.Parameters.AddWithValue("@Username", account.Username);
                command2.Parameters.AddWithValue("@Workout", charcter.Exercise);
                command2.Parameters.AddWithValue("@Work", charcter.Work);
                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public Account Account(String username)
        {
            Account account = new Account();
            using (var command = new MySqlCommand("SELECT * FROM healthtracker.account WHERE Username = @Username", _connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fullname = reader.GetString("full_name");
                            string password = reader.GetString("Password");
                            string height = reader.GetString("Height");
                            string Weight = reader.GetString("Weight");
                            string calories = reader.GetString("Goal_Weight");
                            account.FullName = fullname;
                            account.Password = password;
                            account.Height = height;    
                            account.Username = username;
                            account.Weight = Weight;
                            account.Goal = calories;
                        }
                    }
                    return account;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return account;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }


        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            try
            {
                return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
        }

        public void AccountUpdate(Account account, Characteristic charcter, String username)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    var updateMealCommand = new MySqlCommand("UPDATE healthtracker.meal SET Username = @NewUsername WHERE Username = @OldUsername", _connection);
                    updateMealCommand.Parameters.AddWithValue("@OldUsername", username);
                    updateMealCommand.Parameters.AddWithValue("@NewUsername", account.Username);

                    var updateAccountCommand = new MySqlCommand("UPDATE healthtracker.account SET Username = @User, full_name = @FullName, Weight = @Weight, Height = @Height, Goal_Weight = @Goal WHERE Username = @OldUsername", _connection);
                    updateAccountCommand.Parameters.AddWithValue("@User", account.Username);
                    updateAccountCommand.Parameters.AddWithValue("@OldUsername", username);
                    updateAccountCommand.Parameters.AddWithValue("@FullName", account.FullName);
                    updateAccountCommand.Parameters.AddWithValue("@Weight", account.Weight);
                    updateAccountCommand.Parameters.AddWithValue("@Height", account.Height);
                    updateAccountCommand.Parameters.AddWithValue("@Goal", account.Goal);

                    var updateCharacteristicsCommand = new MySqlCommand("UPDATE healthtracker.charcteristics SET workout = @Workout, work = @Work WHERE username = @OldUsername", _connection);
                    updateCharacteristicsCommand.Parameters.AddWithValue("@Workout", charcter.Exercise);
                    updateCharacteristicsCommand.Parameters.AddWithValue("@Work", charcter.Work);
                    updateCharacteristicsCommand.Parameters.AddWithValue("@OldUsername", username);
                    updateAccountCommand.ExecuteNonQuery();
                    updateMealCommand.ExecuteNonQuery();
                    updateCharacteristicsCommand.ExecuteNonQuery();
                    Debug.WriteLine("idk2");

                    transaction.Commit();
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    transaction.Rollback();
                }
                finally
                {
                    _connection.Close();
                }
            }
        }



    }
}

