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
        <asp:GridView CssClass="table table-striped" OnRowCommand="GridViewAllTicketTasks_RowCommand" AutoGenerateColumns="false" id="GridViewAllTicketTasks" runat="server">
            <Columns>
                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                <asp:BoundField DataField="Datum unosa" HeaderText="Datum unosa" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-info" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' CommandName="cmdTicketTaskDetails" text="Detalji" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </form>
    
</asp:Content>
