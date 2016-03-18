<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">

	    <div class="Home-logo-container">
            <img id="" src="Resources/img/pigeon.svg" alt="Alternate Text" />
		    <div class="bubbles-container">
			    <div class="bubble"></div>
			    <div class="bubble"></div>
			    <div class="bubble"></div>
		    </div>

	    </div>

	    <div class="jumbotron">
		    <h2>Pigeon</h2>
		    <h5>Log in for some crumbs...</h5>
		    <button class="btn btn-primary" data-toggle="modal" data-target="#myModal">Connexion</button>
	    </div>
			
    </div>

    <!-- modal here -->
    <!-- #include file ="Partials/ConnectModal.aspx" -->

</asp:Content>