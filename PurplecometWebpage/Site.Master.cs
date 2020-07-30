using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DTO;

namespace PurplecometWebpage
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Preinit(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SetupNavbar();
        }

        private void SetupNavbar()
        {
            User user = (User) Session["user"];

            if (user == null)
                user = new User();

            string usertype = user.Type;

            navbarDefault.Visible = false;
            navbarAdmin.Visible = false;
            navbarManager.Visible = false;

            if (usertype == "admin")
                navbarAdmin.Visible = true;
            else if (usertype == "manager")
                navbarManager.Visible = true;
            else
                navbarDefault.Visible = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = new User();
            Response.Redirect("~/");
        }

        protected void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora sistema: " + DateTime.Now.ToLongTimeString();
        }
    }
}