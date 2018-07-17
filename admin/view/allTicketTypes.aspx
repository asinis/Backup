<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="allTicketTypes.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table,td,th {
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pregled Tipova Tiketa</h1>
    <a href="../add/ticketType.aspx" class="btn btn-info btn-md">
       <span class="glyphicon glyphicon-plus"></span> Dodaj Tip 
    </a>
    <br />
    <br />
    <form runat="server">
        <asp:GridView ID="gvAllTicketTypes" CssClass="table table-striped" OnRowCommand="gvAllTicketTypes_RowCommand" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                <asp:BoundField DataField="Datum unosa" HeaderText="Datum unosa" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-info" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' CommandName="cmdTicketTypeDetails" text="Detalji" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </form>
</asp:Content>
