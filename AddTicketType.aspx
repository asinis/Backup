<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="AddTicketType.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    <div class="row">
        <div class="col-md-1">
            <asp:Label ID="lblTicketTypeName" runat="server" Text="Naziv :"></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="txtTicketTypeName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-1">
            <asp:Label ID="lblTicketTypeDescription"  runat="server" Text="Opis :"></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox id="txtTicketTypeDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-offset-1 col-md-3">
            <asp:Button ID="btnAddTicketType" runat="server" CssClass="btn btn-info" Text="Sacuvaj" OnClick="btnAddTicketType_Click" />
        </div>
    </div>       
</form>

</asp:Content>
