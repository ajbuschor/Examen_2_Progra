<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Examen_2_Progra.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1>Formulario</h1>
    </div>

    <div class="text-center">
        <h2>&nbsp;</h2>
        <h2>Número de Encuesta : <asp:Label ID="lblNumeroEncuesta" runat="server"></asp:Label>
        </h2>
        <p>&nbsp;</p>
        <p class="auto-style2">Nombre:</p>
        <p class="auto-style1">
            <asp:TextBox ID="tNombre" runat="server" Width="201px"></asp:TextBox>
        </p>
        <p class="auto-style2">Apellido:</p>
        <p class="auto-style1">
            <asp:TextBox ID="tApellido" runat="server" Width="203px"></asp:TextBox>
        </p>
        <p class="auto-style2">Fecha de Nacimiento:</p>
        <p class="auto-style1">
            <asp:TextBox ID="tFechaNac" runat="server" Width="209px"></asp:TextBox>
        </p>
        <p class="auto-style2">Edad:</p>
        <p class="auto-style1">
            <asp:TextBox ID="tEdad" runat="server" Width="112px"></asp:TextBox>
        </p>
        <p class="auto-style2">Correo Electronico:</p>
        <p class="auto-style1">
            <asp:TextBox ID="tCorreo" runat="server" Width="211px"></asp:TextBox>
        </p>
        <p class="auto-style2">Tiene Carro Propio ?</p>
        <p class="auto-style1">
            <asp:DropDownList ID="dCarro" runat="server" Width="57px">
                <asp:ListItem>Si</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p class="auto-style1">&nbsp;</p>
        <p class="auto-style1">&nbsp;</p>
        <p class="auto-style1">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar Encuesta" />
        </p>
        <p class="auto-style1">&nbsp;</p>
        <p class="auto-style1">&nbsp;</p>
    </div>





</asp:Content>
