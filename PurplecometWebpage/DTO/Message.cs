using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurplecometWebpage.DTO
{
    public class Message
    {
        private int id;
        private string name = "";
        private string subject = "";
        private string email = "";
        private string content = "";

        public Message() {}

        public Message(int id, string name, string subject, string email, string content)
        {
            this.id = id;
            this.name = name;
            this.subject = subject;
            this.email = email;
            this.content = content;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Email { get => email; set => email = value; }
        public string Content { get => content; set => content = value; }
    }
}