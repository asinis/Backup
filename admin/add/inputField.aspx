<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="inputField.aspx.cs" Inherits="TicketingSystemTelekomPMF.admin.add.inputField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Novi input field-a za task</h1>

    <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divSuccess" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Uspesno ste dodali input polje!</strong>
    </div>

    <div style="margin-top:20px;" class="alert alert-error alert-dismissible" id="divError" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Doslo je do greske: </strong><span id="errorText" runat="server"></span>
    </div>
    
    <br />
    
    <form runat="server">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Text="Ticket Task:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlTicketTask" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" Text="Input Field:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlInputField" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>

        <br />
        
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label6" runat="server" Text="ID: "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />
        
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbl3" runat="server" Text="Label: "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtLabel" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />
        
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label5" runat="server" Text="CSS classes: "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtCSS" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />
        
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbl4" runat="server" Text="Pattern: "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtPattern" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbl5" runat="server" Text="Validation Message:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtValidationMessage" CssClass="form-control" TextMode="multiline" Columns="10" Rows="4" runat="server" />
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label4" runat="server" Text="Data Query:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtDataQuery" CssClass="form-control" TextMode="multiline" Columns="10" Rows="4" runat="server" />
            </div>
        </div>
        
        <br />
        
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label3" runat="server" Text="Required" AssociatedControlId="chkbxReq"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:CheckBox ID="chkbxReq" CssClass="flat" runat="server"></asp:CheckBox>
            </div>
        </div>


        <br />

        <div class="row">
            <div class="col-md-offset-2 col-md-3">
                <asp:Button ID="btnSend" runat="server" CssClass="btn btn-info btn-block" Text="Save" OnClick="btnSend_Click" />
            </div>
        </div>
    </form>
</asp:Content>
