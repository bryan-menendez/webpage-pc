using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DTO;
using PurplecometWebpage.DAO;

namespace PurplecometWebpage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = UserDAO.Login(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                ltMsg.Text = "Error al comprobar los datos";
            }
            else
            {
                Session["user"] = user;
                Session["usertype"] = user.Type;

                if (user.Type == "admin")
                    Response.Redirect("~/MessageList");

                else if (user.Type == "manager")
                    Response.Redirect("~/UserList");

                else
                    Response.Redirect("~/");
            }
        }
    }
}