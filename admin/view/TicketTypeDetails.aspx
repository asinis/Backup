﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="ticketTypeDetails.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table,th,td {
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div style="margin-top:20px;" class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Greska!</strong> Doslo je do greske, obratite se administratoru.
        </div>
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divDeleteTaskForType" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Obrisali ste Task za odabrani Tip Tiketa.
        </div>
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divSuccessUpdateType" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Izmijenili ste odabrani tip tiketa.
        </div>
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divAddTaskForType" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Dodali ste Task za odabrani Tip Tiketa.
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2>Detalji o Tipu Tiketa</h2>
            </div>
            <div class="col-md-offset-6">
                <h2>Task-ovi za zadati Tip</h2>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTypeDetailsName" runat="server" Text="Naziv :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTypeDetailsName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-offset-6">
                <div class="col-md-1">
                    <asp:Label ID="lblTaskForTicketType" runat="server" Text="Naziv: "></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlTasksForType" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTypeDetailsDescription" runat="server" Text="Opis :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox id="txtTicketTypeDetailsDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
            </div>
            <div class="col-md-offset-3 col-md-3">
                <asp:Button ID="btnSaveTaskForType" CssClass="btn btn-info" Text="Dodaj" OnClick="btnSaveTaskForType_Click" runat="server"/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblTicketTypeDetailsInsertDate" runat="server" Text="Datum unosa :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTicketTypeDetailsinsertDate" CssClass="form-control" runat="server" disabled="true"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblActive" runat="server" Text="Aktivan:"></asp:Label>
            </div>
            <div class="col-md-1">
                <asp:CheckBox ID="chbActive" runat="server" value=""/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-offset-1 col-md-3">
                <asp:Button CssClass="btn btn-info" ID="btnSaveTicketTypeChanges" onclick="btnSaveTicketTypeChanges_Click" Text="Sacuvaj" runat="server"/>
            </div>
        </div>
        <br />
        <br />
        <h1>Pregled Task-ova za odabrani Tip Tiketa</h1>
        <br />
        <asp:GridView ID="gvTakenTasks" OnRowCommand="gvTakenTasks_RowCommand" AutoGenerateColumns="false" class="table table-hover" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Naziv" />
                <asp:BoundField DataField="Description" HeaderText="Opis" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-danger" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' CommandName="cmdDeleteTaskForType" text="Brisi" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="margin-top:20px;" class="alert alert-warning alert-dismissible" id="divNoRowsInGridView" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Obavjestenje!</strong> Za zadati Tip Tiketa nema postavljenih Taskova.
        </div>
    </form>
</asp:Content>
