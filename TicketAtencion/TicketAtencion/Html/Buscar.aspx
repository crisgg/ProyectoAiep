<%@ Page Title="" Language="C#" MasterPageFile="~/Data/TICKET.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="TicketAtencion.Html.Buscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel-heading clearfix"><span style="font-weight:bolder;">Buscar</span></div>
        <div class="panel-body">
            <div class="form-group">
                 <label class=" control-label">Obtener los Registros con los Estados :</label>
                        <select class="form-control" id="cmbMostrar">
                        </select>
            </div>
            <hr />
            <div class="table-responsive">
                <table id="grilla" class="table   table-striped order-column table-bordered table-hover dt-responsive nowrap "
                       style="font-size: 12px; width:100%;">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Usuario</th>
                        <th>Cliente</th>
                        <th>Estado</th>
                        <th>Fecha Ingreso</th>
                        <th>Fecha Modificación</th>
                        <th>Anexo</th>
                        <th>Boton1</th>
                        <th>Boton2</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
            </div>
        </div>
    </div>

</asp:Content>
