<%@ Page Title="" Language="C#" MasterPageFile="~/TicketingSystem.Master" AutoEventWireup="true" CodeBehind="ticketTaskDetails.aspx.cs" Inherits="TicketingSystemTelekomPMF.WebForm6" %>
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
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divUpdateTaskSuccess" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Izmijenili ste informacije o zadatom Tasku.
        </div>
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divDeleteStatusForTask" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Obrisali ste Status za trenutni Task.
        </div>
        <div style="margin-top:20px;" class="alert alert-success alert-dismissible" id="divSuccess" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Uspjesno!</strong> Dodali ste status za zadati task.
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2>Detalji o Tasku</h2>
            </div>
            <div class="col-md-offset-6">
                <h2>Statusi za zadati Task</h2>
            </div>
        </div>
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
                <asp:Button ID="btnSaveStatusForTicketTask" OnClick="btnSaveStatusForTicketTask_Click" CssClass="btn btn-info" runat="server" Text="Sacuvaj" />
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
                <asp:Button CssClass="btn btn-info" ID="btnSaveTicketTaskChanges" OnClick="btnSaveTicketTaskChanges_Click"  Text="Sacuvaj" runat="server"/>
            </div>
        </div>
        <br />
        <br />
        <h1>Pregled statusa za odabrani task</h1>
        <br />
        <asp:GridView OnRowCommand="gvTakenStatus_RowCommand" ID="gvTakenStatus" AutoGenerateColumns="false" class="table table-hover" runat="server">
            <Columns>
                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-danger" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' CommandName="cmdDeleteStatusForType" text="Brisi" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="margin-top:20px;" class="alert alert-warning alert-dismissible" id="divNoRowsInGridView" runat="server" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Obavjestenje!</strong> Za zadati Task nema postavljenih Statusa.
        </div>
    </form>
   <script>
       /*$(document).ready(function () {

           var taskID = $.urlParam('id');
           $("#test").click(function () {
               alert('pocetal');
               $.ajax({
                   url: 'AllStatusForTask.asmx/allStatusForTask',
                   data: {taskId: taskID},
                   dataType: "json",
                   method: 'post',
                   success: function (data) {
                       for (var i = 0; i < data.d.length; i++) {
                           $("#gv2").append("<tr><td>" + data.d[i].Naziv + "</td><td>" + data.d[i].Opis + "</td></tr>");
                       }
                   },
                   error: function () {
                       alert("NEUSPJESNO");
                   }
               });
               /*
               $.ajax({
                   url: "AllStatusForTask.asmx/addStatusForTask",
                   contentType: "application/json; charset=utf-8",
                   data: JSON.stringify({ taskId: taskID, statusId: statusID }),
                   dataType: "json",
                   method: 'post',
                   success: function ()
                   {
                       alert("UBACIO");
                   },
                   error: function()
                   {
                       alert("nije");
                   }
               });
              
           });
       });*/
   </script>
</asp:Content>