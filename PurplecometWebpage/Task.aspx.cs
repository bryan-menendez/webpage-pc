using PurplecometWebpage.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurplecometWebpage
{
    public partial class Task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];

            if (action == "updatenewreports")
                ReportDAO.UpdateReportsWordcount(true);
            if (action == "updateallreports")
                ReportDAO.UpdateReportsWordcount(false);

            Response.Redirect("~/UserList");
        }
    }
}