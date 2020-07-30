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
    public partial class MessageDetails : System.Web.UI.Page
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
                        Context.ApplicationInstance.CompleteRequest();
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
                        Message msg = MessageDAO.GetMessage(int.Parse(idstr));

                        if (msg != null)
                        {
                            boxID.Enabled = false;
                            boxID.Text = idstr;
                            boxNombre.Text = msg.Name;
                            boxEmail.Text = msg.Email;
                            boxAsunto.Text = msg.Subject;
                            boxContenido.InnerText = msg.Content;
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
                    Message msg = new Message();
                    msg.Name = boxNombre.Text;
                    msg.Email = boxEmail.Text;
                    msg.Subject = boxAsunto.Text;
                    msg.Content = boxContenido.InnerText;

                    MessageDAO.AddMessage(msg);
                }
                else //update
                {
                    Message msg = new Message();
                    msg.Id = int.Parse(idstr);
                    msg.Name = boxNombre.Text;
                    msg.Email = boxEmail.Text;
                    msg.Subject = boxAsunto.Text;
                    msg.Content = boxContenido.InnerText;

                    MessageDAO.ModMessage(msg);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            Response.Redirect("~/MessageList");
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            MessageDAO.RemoveMessage(int.Parse(boxID.Text));
            Response.Redirect("~/MessageList");
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MessageList");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}