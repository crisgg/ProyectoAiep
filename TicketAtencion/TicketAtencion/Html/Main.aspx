<%@ Page Language="C#" MasterPageFile="~/Data/TICKET.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TicketAtencion.Html.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body1" runat="server"> 


    <button type="button" id="Boton" >Press</button>
    <span>El Datox</span>
    <input type ="text" id="Dato" disabled ="disabled" style="width:400px"/>

    <script src="../Js/Ticket.js"></script>

</asp:Content>