using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DAO;
using PurplecometWebpage.DTO;

namespace PurplecometWebpage
{
    public partial class InstitutionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    User sUser = (User)Session["user"];

                    if (sUser == null)
                    {
                        Response.Redirect("~/Login");
                    }

                    string idstr = Request["Id"];

                    if (String.IsNullOrEmpty(idstr)) //new Message
                    {
                        btnBorrar.Visible = false;
                        lblId.Visible = false;
                        boxID.Visible = false;
                    }
                    else
                    {
                        Institution inst = InstitutionDAO.GetInstitution(int.Parse(idstr));

                        if (inst != null)
                        {
                            boxID.Enabled = false;
                            boxID.Text = idstr;
                            boxNombre.Text = inst.Name;
                            boxDescripcion.Text = inst.Description;
                            boxNotas.Text = inst.Notes;
                        }
                    }

                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string idstr = boxID.Text;
            Debug.WriteLine("ID AL wardar: " + idstr);

            try
            {
                if (String.IsNullOrEmpty(idstr)) //new
                {
                    Institution inst = new Institution();
                    inst.Name = boxNombre.Text;
                    inst.Description = boxDescripcion.Text;
                    inst.Notes = boxNotas.Text;

                    InstitutionDAO.AddInstitution(inst);
                }
                else //update
                {
                    Institution inst = new Institution();
                    inst.Id = int.Parse(idstr);
                    inst.Name = boxNombre.Text;
                    inst.Description = boxDescripcion.Text;
                    inst.Notes = boxNotas.Text;

                    InstitutionDAO.ModInstitution(inst);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            Response.Redirect("~/InstitutionList");
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            InstitutionDAO.RemoveInstitution(int.Parse(boxID.Text));
            Response.Redirect("~/InstitutionList");
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitutionList");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}