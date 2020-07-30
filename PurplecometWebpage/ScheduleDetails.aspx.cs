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
    public partial class ScheduleDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User sUser = (User)Session["user"];

                if (sUser == null)
                {
                    Response.Redirect("~/Login");
                }

                string idstr = Request["Id"];

                if (String.IsNullOrEmpty(idstr)) //new schedule
                {
                    btnBorrar.Visible = false;
                    lblId.Visible = false;
                    boxID.Visible = false;
                }
                else //load schedule
                {
                    try
                    {
                        boxID.Enabled = false;
                        Schedule schedule = ScheduleDAO.GetSchedule(int.Parse(idstr));

                        boxID.Text = schedule.Id.ToString();
                        boxNombre.Text = schedule.Name;
                        boxDescripcion.Text = schedule.Description;
                        boxLunesin.Text = schedule.Lunesin;
                        boxLunesout.Text = schedule.Lunesout;
                        boxMartesin.Text = schedule.Martesin;
                        boxMartesout.Text = schedule.Martesout;
                        boxMiercolesin.Text = schedule.Miercolesin;
                        boxMiercolesout.Text = schedule.Miercolesout;
                        boxJuevesin.Text = schedule.Juevesin;
                        boxJuevesout.Text = schedule.Juevesout;
                        boxViernesin.Text = schedule.Viernesin;
                        boxViernesout.Text = schedule.Viernesout;
                        boxSabadoin.Text = schedule.Sabadoin;
                        boxSabadoout.Text = schedule.Sabadoout;
                        boxDomingoin.Text = schedule.Domingoin;
                        boxDomingoout.Text = schedule.Domingoout;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                        Debug.WriteLine(ex.Message);
                    }
                }

                List<Institution> institutions = InstitutionDAO.GetInstitutions();
                int ins_fk = 1;

                if (!String.IsNullOrEmpty(Request["Id"]))
                {
                    ins_fk = ScheduleDAO.GetSchedule(int.Parse(boxID.Text)).Fk_institution;
                }

                if (sUser.Type == "admin")
                {
                    foreach (Institution ins in institutions)
                    {
                        if (!String.IsNullOrEmpty(Request["Id"]) && ins.Id == ins_fk) //not postback, requesting id info,
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
                Schedule schedule = new Schedule();

                schedule.Name = boxNombre.Text;
                schedule.Description = boxDescripcion.Text;
                schedule.Fk_institution = int.Parse(selInstitution.SelectedValue);
                schedule.Lunesin = boxLunesin.Text;
                schedule.Lunesout = boxLunesout.Text;
                schedule.Martesin = boxMartesin.Text;
                schedule.Martesout = boxMartesout.Text;
                schedule.Miercolesin = boxMiercolesin.Text;
                schedule.Miercolesout = boxMiercolesout.Text;
                schedule.Juevesin = boxJuevesin.Text;
                schedule.Juevesout = boxJuevesout.Text;
                schedule.Viernesin = boxViernesin.Text;
                schedule.Viernesout = boxViernesout.Text;
                schedule.Sabadoin = boxSabadoin.Text;
                schedule.Sabadoout = boxSabadoout.Text;
                schedule.Domingoin = boxDomingoin.Text;
                schedule.Domingoout = boxDomingoout.Text;

                if (String.IsNullOrEmpty(idstr)) //new
                    ScheduleDAO.AddSchedule(schedule);               
                else //update
                {
                    schedule.Id = int.Parse(boxID.Text);
                    ScheduleDAO.ModSchedule(schedule);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            Response.Redirect("~/ScheduleList");
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ScheduleDAO.RemoveSchedule(int.Parse(boxID.Text));
            Response.Redirect("~/ScheduleList");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}