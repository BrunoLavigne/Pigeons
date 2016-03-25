<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="TestLabel" runat="server" Text="Label"></asp:Label>

    <div class="container">
        <asp:Panel runat="server">
            <asp:GridView ID="gridViewUserGroups" runat="server"></asp:GridView>
        </asp:Panel>
    </div>

    <div class="New-group-bar">
        <div class="container">
            <a href="#myModal" data-toggle="modal" data-target="#myModal" class="btn btn-success Btn-new-group">
                <span class="menu-icon glyphicon glyphicon-plus"></span>Nouveau groupe
            </a>
        </div>

    </div>
</asp:Content>

