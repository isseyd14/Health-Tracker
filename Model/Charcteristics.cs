using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Characteristic
    {
        public string Username { get; set; }
        public string Work { get; set; }
        public string Exercise { get; set; }

        public Characteristic(string username, string work, string exercise)
        {
            Username = username;
            Work = work;
            Exercise = exercise;
        }
        public Characteristic()
        {
        }
    }
}
