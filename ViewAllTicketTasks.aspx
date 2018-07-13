<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="ViewAllTicketTasks.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table,td,th {
            border:none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pregled Ticket Task-ova</h1>
    <br />
    <form runat="server">
        <asp:GridView CssClass="table table-striped" id="GridViewAllTicketTasks" runat="server"></asp:GridView>
    </form>
    
</asp:Content>
