using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DAO;
using PurplecometWebpage.DTO;

namespace PurplecometWebpage
{
    public partial class MessageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User sUser = (User)Session["user"];

            if (sUser == null || !sUser.Type.Equals("admin"))
            {
                Response.Redirect("~/Login");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}