using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurplecometWebpage.DTO
{
    public class Schedule
    {
        private int id;
        private int fk_institution;
        private string name = "unk";
        private string description = "blank";
        private string lunesin = "";
        private string lunesout = "";
        private string martesin = "";
        private string martesout = "";
        private string miercolesin = "";
        private string miercolesout = "";
        private string juevesin = "";
        private string juevesout = "";
        private string viernesin = "";
        private string viernesout = "";
        private string sabadoin = "";
        private string sabadoout = "";
        private string domingoin = "";
        private string domingoout = "";

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Lunesin { get => lunesin; set => lunesin = value; }
        public string Lunesout { get => lunesout; set => lunesout = value; }
        public string Martesin { get => martesin; set => martesin = value; }
        public string Martesout { get => martesout; set => martesout = value; }
        public string Miercolesin { get => miercolesin; set => miercolesin = value; }
        public string Miercolesout { get => miercolesout; set => miercolesout = value; }
        public string Juevesin { get => juevesin; set => juevesin = value; }
        public string Juevesout { get => juevesout; set => juevesout = value; }
        public string Viernesin { get => viernesin; set => viernesin = value; }
        public string Viernesout { get => viernesout; set => viernesout = value; }
        public string Sabadoin { get => sabadoin; set => sabadoin = value; }
        public string Sabadoout { get => sabadoout; set => sabadoout = value; }
        public string Domingoin { get => domingoin; set => domingoin = value; }
        public string Domingoout { get => domingoout; set => domingoout = value; }
        public int Fk_institution { get => fk_institution; set => fk_institution = value; }
    }
}