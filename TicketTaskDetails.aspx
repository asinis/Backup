<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="TicketTaskDetails.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskDetailsName" runat="server" Text="Naziv :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTaskDetailsName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-offset-6">
                <div class="col-md-2">
                    <asp:Label ID="lblTicketTaskStatus" for="ddlStatusForTicketTask" runat="server" Text="Status :"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlStatusForTicketTask" CssClass="form-control" runat="server">
                        <asp:ListItem>Sinisa</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskDetailsDescription" runat="server" Text="Opis :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox id="txtTicketTaskDetailsDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
            </div>
            <div class="col-md-offset-3 col-md-3">
                <asp:Button ID="btnSaveStatusForTicketTask" CssClass="btn btn-info" runat="server" Text="Sacuvaj" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTaskDetailsInsertDate" runat="server" Text="Datum unosa :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTaskDetailsinsertDate" CssClass="form-control" runat="server" disabled="true"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-offset-1 col-md-3">
                <asp:Button ID="btnUpdateTicketTask" CssClass="btn btn-info" runat="server" Text="Sacuvaj" />
            </div>
        </div>
        <br />

    </form>
</asp:Content>
