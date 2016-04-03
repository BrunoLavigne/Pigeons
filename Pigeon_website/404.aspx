<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        <div class="row">

            <div class="col-md-6">
                <h2>404</h2>
                <h4>Oh noes!</h4>
                <asp:HyperLink runat="server" CssClass="btn btn-primary" NavigateUrl="~/Index.aspx">Retour à la page d'accueil</asp:HyperLink>
            </div>
            
            <div class="col-md-6">

                <div class="image-container">

                    <img src="Resources/img/pigception.gif" />

                </div>

            </div>

        </div>

    </div>

</asp:Content>

