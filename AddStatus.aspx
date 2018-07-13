﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="AddStatus.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Unos statusa</h1>
    <br />
    <form runat="server">
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblStatusName" runat="server" Text="Naziv: "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtStatusName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblStatusDescription" runat="server" Text="Opis :"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox id="txtStatusDescription" CssClass="form-control" TextMode="multiline" Columns="10" Rows="5" runat="server" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-offset-1 col-md-3">
                <asp:Button ID="btnAddStatus" runat="server" CssClass="btn btn-info" Text="Sacuvaj" OnClick="btnAddStatus_Click"/>
            </div>
        </div>
    </form>
</asp:Content>