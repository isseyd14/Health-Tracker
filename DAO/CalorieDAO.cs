using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using MySql.Data.MySqlClient;
using WpfApp1.Model;


namespace WpfApp1.DAO
{
    class CalorieDAO
    {
        private MySqlConnection _connection;

        public CalorieDAO()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=HealthTracker;User Id=root;Password=root;";
            _connection = new MySqlConnection(connectionString);
        }

        public List<Meal> Calories(String Username) {
            List<Meal> list = new List<Meal>();
            using (var command = new MySqlCommand("SELECT * FROM healthtracker.meal WHERE username = @Username AND date = @Date", _connection))
            {
                DateTime currentDate = DateTime.Now.Date;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Date",formattedDate );

                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string calories = reader.GetString("Calories");
                            string name = reader.GetString("MealName");
                            list.Add(new Meal(name, calories));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return list;
                }
                finally
                {
                    _connection.Close();
                }
                return list;
            }
        } 


        public Characteristic charcteristics(string username)
        {
            Characteristic charcteristics = new Characteristic();
            charcteristics.Username = username;
            using (var command = new MySqlCommand("SELECT * FROM healthtracker.charcteristics WHERE username = @Username", _connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                try
                {
                    _connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            charcteristics.Work = reader.GetString("work");
                            charcteristics.Exercise = reader.GetString("workout");
                        }
                    }
                    return charcteristics;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine($"MySQL Exception: {ex.Message}");
                    return charcteristics;
                }
                finally
                {
                    _connection.Close();
                }
            }

        }

        public void AddMeal(Meal meal, String username)
        {
            using (var command = new MySqlCommand("INSERT INTO healthtracker.meal (Username, Date, MealName, Calories) VALUES (@Username, @date, @meal, @calories)", _connection))
            {
                DateTime currentDate = DateTime.Now.Date;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@date", formattedDate );
                command.Parameters.AddWithValue("@meal", meal.Name);
                command.Parameters.AddWithValue("@calories", meal.Calories);
                try
                {
                    _connection.Open();
                    Debug.WriteLine("somethings gone wrong");
                    command.ExecuteNonQuery();
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
        public void DeleteMeal(Meal meal, String username)
        {
            using (var command = new MySqlCommand("DELETE FROM healthtracker.meal WHERE Username = @Username AND Date = @Date AND MealName = @MealName AND Calories = @Calories", _connection))
            {
                DateTime currentDate = DateTime.Now.Date;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Date", formattedDate);
                command.Parameters.AddWithValue("@MealName", meal.Name);
                command.Parameters.AddWithValue("@Calories", meal.Calories);
                Debug.WriteLine(meal.Name , meal.Calories, username);
                try
                {
                    _connection.Open();
                    Debug.WriteLine("somethings gone wrong");
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine("Exception Message: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        Debug.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }
                }
                finally
                {
                    _connection.Close();
                }

            }

        }
    }
}
