using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurplecometWebpage.DTO
{
    public class Institution
    {
        private int id = 1;
        private string name = "";
        private string description = "";
        private string notes = "";

        public Institution()
        {
            //blank
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}