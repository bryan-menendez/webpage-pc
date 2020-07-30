using PurplecometWebpage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurplecometWebpage
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User sUser = (User)Session["user"];

            if (sUser == null)
            {
                Response.Redirect("~/Login");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}