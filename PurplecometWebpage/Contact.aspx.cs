using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DTO;
using PurplecometWebpage.DAO;
using System.Diagnostics;

namespace PurplecometWebpage
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                Message msg = new Message();

                msg.Name = (string)txtNombre.Text;
                msg.Email = (string)txtEmail.Text;
                msg.Subject = (string)txtAsunto.Text;
                msg.Content = (string)txtContenido.InnerText;

                MessageDAO.AddMessage(msg);

                ltMsg.Text = "<br/>";
                ltMsg.Text += "Mensaje enviado";
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}