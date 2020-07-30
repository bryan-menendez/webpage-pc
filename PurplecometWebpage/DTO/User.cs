using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurplecometWebpage.DTO
{
    public class User
    {
        private int id = 0;
        private string username = "";
        private string password = "";
        private string name = "";
        private string appat = "";
        private string apmat = "";
        private string email = "";
        private string type = "user";
        private Institution institution = new Institution();
        private Schedule schedule = new Schedule();

        public User() { }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Appat { get => appat; set => appat = value; }
        public string Apmat { get => apmat; set => apmat = value; }
        public Institution Institution { get => institution; set => institution = value; }
        public Schedule Schedule { get => schedule; set => schedule = value; }
    }
}