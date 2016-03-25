<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register TagPrefix="uc" TagName="ConnectModal" Src="~/Partials/ConnectModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- place homepage animation script here -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

	    <div class="Home-logo-container">
            <img id="" src="Resources/img/pigeon.svg" alt="Pigeon logo" />
	    </div>

	    <div class="jumbotron">
		    <h2>Pigeon</h2>
            <p>[Pigeon description] Lorem ipsum dolor sit amet, consectetur adipiscing elit. In laoreet, leo eget faucibus eleifend, nisl felis sagittis nulla, vel finibus nulla turpis id turpis. Vestibulum dolor diam, scelerisque vel mollis in, molestie ut orci. Morbi pellentesque consectetur ex ac aliquam. Cras vitae leo iaculis, volutpat odio non, varius sem. Vivamus suscipit metus in ante pretium commodo. Proin tortor tortor, finibus nec purus sed, suscipit faucibus justo. Aliquam vitae justo et arcu interdum aliquet. Vivamus consectetur dignissim magna, a accumsan nisl faucibus ut. Aenean sit amet ligula et leo luctus maximus. Sed gravida diam ac magna ultrices congue. Vivamus urna dolor, lacinia ut quam id, posuere viverra nibh. Vestibulum magna orci, laoreet id lobortis non, luctus a leo. Proin rutrum erat quis rutrum congue. Donec luctus mi at finibus pellentesque.</p>
	    </div>
			
    </div>

    <!-- Connection modal -->
    <uc:ConnectModal runat="server" ID="connectModal"></uc:ConnectModal>

</asp:Content>