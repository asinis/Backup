<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="inputField.aspx.cs" Inherits="TicketingSystemTelekomPMF.admin.add.inputField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Novi tip input field-a</h1>
    <br />
    <form runat="server">
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="Label1" runat="server" Text="Ticket Task:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlTicketTask" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskDescription" runat="server" Text="Opis :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTasksDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-offset-1 col-md-3">
                <%--<asp:Button ID="btnAddTicketTask" runat="server" CssClass="btn btn-info" Text="Sacuvaj" OnClick="btnAddTicketTask_Click" />--%>
            </div>
        </div>
    </form>
</asp:Content>
