using PurplecometWebpage.DAO;
using PurplecometWebpage.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurplecometWebpage
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User sUser = (User)Session["user"];

                if (sUser == null)
                {
                    Response.Redirect("~/Login");
                    Context.ApplicationInstance.CompleteRequest();
                }

                //if (sUser.Type == "manager")
                //{
                //    //lblInst.Visible = false;
                //    //selInstitution.Visible = false;
                //}
                    

                string idstr = Request["Id"];

                if (String.IsNullOrEmpty(idstr)) //new Message
                {
                    btnBorrar.Visible = false;
                    lblId.Visible = false;
                    boxID.Visible = false;
                }
                else
                {
                    User usr = UserDAO.GetUser(int.Parse(idstr));

                    boxID.Text = idstr; boxID.Enabled = false;
                    boxNombre.Text = usr.Name;
                    boxApPat.Text = usr.Appat;
                    boxApMat.Text = usr.Apmat;
                    boxEmail.Text = usr.Email;
                    boxUsername.Text = usr.Username; boxUsername.Enabled = false;
                }


                //load institutions selector
                List<Institution> institutions = InstitutionDAO.GetInstitutions();
                int ins_fk = 1;

                if (!String.IsNullOrEmpty(Request["Id"]))
                {
                    ins_fk = UserDAO.GetUser(int.Parse(idstr)).Institution.Id;
                }

                if (sUser.Type == "admin")
                {
                    foreach (Institution ins in institutions)
                    {
                        if (!String.IsNullOrEmpty(Request["Id"]) && ins.Id == ins_fk) //not postback, requesting id info
                        {
                            selInstitution.Items.Add(new ListItem(ins.Id + " - " + ins.Name, ins.Id.ToString()));
                            selInstitution.SelectedValue = ins.Id.ToString();
                            //selInstitution.InnerText += ("<option value=\"" + ins.Id + "\" selected>" + ins.Id + "-" + ins.Name + "</option>");
                        }
                        else
                        {
                            //selInstitution.InnerText += ("<option value=\"" + ins.Id + "\">" + ins.Id + "-" + ins.Name + "</option>");
                            selInstitution.Items.Add(new ListItem(ins.Id + " - " + ins.Name, ins.Id.ToString()));                          
                        }

                    }
                }
                else if (sUser.Type == "manager")
                {
                    selInstitution.Items.Add(new ListItem(sUser.Institution.Id + " - " + sUser.Institution.Name, sUser.Institution.Id.ToString()));
                    //selInstitution.InnerText += ("<option value=\"" + sUser.Institution.Id + "\" selected>" + sUser.Institution.Name + "</option>");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string idstr = boxID.Text;

            try
            {
                User usr = new User();

                if (!String.IsNullOrEmpty(idstr))
                    usr.Id = int.Parse(idstr);
                usr.Name = boxNombre.Text;
                usr.Appat = boxApPat.Text;
                usr.Apmat = boxApMat.Text;
                usr.Email = boxEmail.Text;
                usr.Institution = InstitutionDAO.GetInstitution(int.Parse(selInstitution.SelectedValue));
                usr.Schedule = ScheduleDAO.GetSchedule(int.Parse(Request.Form["selSchedule"]));
                usr.Username = boxUsername.Text;
                usr.Password = boxPassword.Text;
                
                User sUser = (User)Session["user"];
                if (sUser.Type == "manager")
                    usr.Type = "agent";
                else
                    usr.Type = Request.Form["selType"];

                if (String.IsNullOrEmpty(idstr)) //new
                {
                    UserDAO.AddUser(usr);
                }
                else //update
                {
                    UserDAO.ModUser(usr);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            Response.Redirect("~/UserList");
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            UserDAO.RemoveUser(int.Parse(boxID.Text));
            Response.Redirect("~/UserList");
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserList");
        }
    }
}