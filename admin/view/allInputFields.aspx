<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="allInputFields.aspx.cs" Inherits="TicketingSystemTelekomPMF.admin.view.allInputFields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table,td,th {
            border:none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pregled svih input polja</h1>
    <br />
    <div id="divError" runat="server"></div>
    <form runat="server">
        <asp:GridView CssClass="table table-striped" AutoGenerateColumns="false" id="GridViewAllInputFields" runat="server">
            <Columns>
                <asp:BoundField DataField="Task" HeaderText="Task" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="LabelText" HeaderText="Label" />
                <asp:BoundField DataField="HtmlID" HeaderText="HTML ID" />
                <asp:BoundField DataField="isRequired" HeaderText="Required" />
                <asp:BoundField DataField="Pattern" HeaderText="Pattern" />
                <%--<asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-info" CausesValidation="false" text="Detalji"  CommandArgument='<%# Eval("Id") %>' CommandName="cmdTicketTaskDetails" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            
        </asp:GridView>
    </form>
</asp:Content>
