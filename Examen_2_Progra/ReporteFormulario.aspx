<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ReporteFormulario.aspx.cs" Inherits="Examen_2_Progra.ReporteFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
    <link href="CSS/EstiloGridview.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1>Reporte de Formulario Guardado</h1>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p class="text-center">
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" >
            </asp:GridView>
                <br />
                <span class="auto-style1">Para Borraro un Formulario deberas poner el Numero de Encuesta<br />
&nbsp;y seleccionar el boton de aceptar:
                <br />
                </span>&nbsp;<asp:TextBox ID="tNumEncuesta" runat="server" Height="16px" Width="41px"></asp:TextBox>
&nbsp;<br />
                <br />
                <asp:Button ID="bAceptar" runat="server" Height="40px" OnClick="bAceptar_Click" Text="Aceptar" Width="87px" />
            </div>
        </p>
    </div>



</asp:Content>
