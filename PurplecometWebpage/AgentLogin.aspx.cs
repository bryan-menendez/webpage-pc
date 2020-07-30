using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DTO;
using PurplecometWebpage.DAO;
using PurplecometWebpage.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PurplecometWebpage
{
    /**
     * Este es el portal al cual accede la aplicacion de escritorio utilizando sus credenciales.
     * En caso de que estas sean validas, devolvera un json con los datos del usuario y de su horario.
     */
    public partial class AgentLogin : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                string username = Request.Params["username"];
                string password = Request.Params["password"];

                User usr = UserDAO.Login(username, password);

                var json = new JObject();
                json.Add("id", usr.Id);
                json.Add("nombre", usr.Name + " " + usr.Appat + " " + usr.Apmat);
                json.Add("institution", usr.Institution.Name);
                json.Add("lunesin", usr.Schedule.Lunesin);
                json.Add("lunesout", usr.Schedule.Lunesout);
                json.Add("martesin", usr.Schedule.Martesin);
                json.Add("martesout", usr.Schedule.Martesout);
                json.Add("miercolesin", usr.Schedule.Miercolesin);
                json.Add("miercolesout", usr.Schedule.Miercolesout);
                json.Add("juevesin", usr.Schedule.Juevesin);
                json.Add("juevesout", usr.Schedule.Juevesout);
                json.Add("viernesin", usr.Schedule.Viernesin);
                json.Add("viernesout", usr.Schedule.Viernesout);
                json.Add("sabadoin", usr.Schedule.Sabadoin);
                json.Add("sabadoout", usr.Schedule.Sabadoout);
                json.Add("domingoin", usr.Schedule.Domingoin);
                json.Add("domingoout", usr.Schedule.Domingoout);

                Response.AddHeader("Content-Type", "application/json");
                Response.Write(json.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("THERE WAS A CRASH");
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}