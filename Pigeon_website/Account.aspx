<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        <div class="jumbotron">

            <h3>The account page</h3>
            <p>View/edit profile info here...</p>

            <div class="form-group">
                <asp:TextBox runat="server" ID="editUserEmail" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox TextMode="MultiLine" runat="server" ID="editUserDescription" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button runat="server" ID="btnEditUser" CssClass="btn btn-danger" Text="Modifier" OnClick="btnEditUser_Click" />
            </div>
        </div>
    </div>
</asp:Content>

