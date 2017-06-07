<%@ Page Language="C#" MasterPageFile="~/Data/TICKET.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TicketAtencion.Html.Main" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button type="button" id="Boton" onclick="ObtenerDato()">Press</button>
    <span>El Datox</span>
    <input type ="text" id="Dato" disabled ="disabled" style="width:400px"/>
</asp:Content>