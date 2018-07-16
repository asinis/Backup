<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="AddTicketTask.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divSuccessTaskAdded" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Uspjesno!</strong> Dodali ste status.
    </div>
    <h1>Unos Taska</h1>
    <br />
    <form runat="server">
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskName" runat="server" Text="Naziv : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTaskName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskDescription" runat="server" Text="Opis :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox id="txtTicketTasksDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-offset-1 col-md-3">
                <asp:Button ID="btnAddTicketTask" runat="server" CssClass="btn btn-info" Text="Sacuvaj" OnClick="btnAddTicketTask_Click"/>
            </div>
        </div>
   </form>
</asp:Content>
