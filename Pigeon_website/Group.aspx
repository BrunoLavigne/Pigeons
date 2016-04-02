<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        <div class="row">

            <asp:Label runat="server" ID="lblTest"></asp:Label>
            <asp:Button ID="BtnTest" runat="server" Text="Button" OnClick="BtnTest_Click" />
        </div>

    </div>


</asp:Content>

