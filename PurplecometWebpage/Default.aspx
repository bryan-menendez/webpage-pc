<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PurplecometWebpage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Purplecomet</h1> 
        <p class="lead">Purplecomet es una empresa orientada a la gestion de datos empresariales por medio de software especializado.</p>
        <p><a href="~/About" runat="server" class="btn btn-primary btn-lg">Aprender mas &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Mayor control</h2>
            <p>
                Aumentar el control de la informacion de su empresa es nuestra prioridad. Nuestro software le entrega informacion de rendimiento y actividades de sus trabajadores remotos.
            </p>
            <p>
                <a runat="server" class="btn btn-default" href="~/About">Aprender mas &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Contacto</h2>
            <p>
                Si desea contratar los servicios de Purplecomet, o tiene alguna consulta, sugerencia o comentario respecto a ellos, sientase libre de contactarnos.
            </p>
            <p>
                <a runat="server" class="btn btn-default" href="~/Contact">Contacto &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>¿Ya es miembro?</h2>
            <p>
                Ingrese a la plataforma y utilice las herramientas a su disposicion.
            </p>
            <p>
                <a runat="server" class="btn btn-default" href="~/Login">Ingresar &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
