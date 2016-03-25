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
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. In laoreet, leo eget faucibus eleifend, nisl felis sagittis nulla, vel finibus nulla turpis id turpis. Vestibulum dolor diam, scelerisque vel mollis in, molestie ut orci. Morbi pellentesque consectetur ex ac aliquam. Cras vitae leo iaculis, volutpat odio non, varius sem. Vivamus suscipit metus in ante pretium commodo. Proin tortor tortor, finibus nec purus sed, suscipit faucibus justo. Aliquam vitae justo et arcu interdum aliquet. Vivamus consectetur dignissim magna, a accumsan nisl faucibus ut. Aenean sit amet ligula et leo luctus maximus. Sed gravida diam ac magna ultrices congue. Vivamus urna dolor, lacinia ut quam id, posuere viverra nibh. Vestibulum magna orci, laoreet id lobortis non, luctus a leo. Proin rutrum erat quis rutrum congue. Donec luctus mi at finibus pellentesque.

Donec ipsum diam, interdum in pellentesque non, pellentesque a enim. Sed vel lorem nisi. Quisque in lectus vel arcu ullamcorper accumsan. Donec sed mollis urna. Sed eros sapien, tincidunt nec venenatis eget, suscipit eu ipsum. Maecenas et purus diam. Nullam at accumsan magna. Aliquam erat volutpat. Proin luctus sodales fermentum. Pellentesque vitae sapien ut augue eleifend hendrerit in vitae diam. Mauris ultrices justo nec nunc iaculis lobortis in eget magna. Aenean ut rutrum orci. Suspendisse ac molestie odio, vitae euismod quam.</p>
<%--		    <h5>Log in for some crumbs...</h5>
		    <button class="btn btn-primary" data-toggle="modal" data-target="#myModal">Connexion</button>--%>
	    </div>
			
    </div>

    <!-- modal here -->
    <!-- dont include file ="Partials/ConnectModalzzzzz.aspx" -->

        <div class="modal fade" role="dialog" id="myModal">
	    <div class="modal-dialog">
	    <div class="modal-content">
		    <div class="modal-header">
		    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		    <h4 class="modal-title">Connexion</h4>
		    </div>
		    <div class="modal-body">
		    <div class="row">
			    <div class="col-md-6">

				    <h4>Se connecter</h4>
                
                    <div class="form-group">
                        <asp:TextBox runat="Server" ID="userEmail" class="form-control"></asp:TextBox>
                    </div>
                
                    <div class="form-group">
                       <%-- <input type="password" class="form-control" id="userPassword" placeholder="Mot de passe">--%>
                        <asp:TextBox runat="server" type="password" ID="userPassword" class="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ID="connectButton" Text="Connexion" OnClick="connectButton_Click" />
                        <%--<button type="button" class="btn btn-default">Connexion</button>--%>
                    </div>

			    </div>
			    <div class="col-md-6">

                    <h4>S'inscrire</h4>

                    <div class="form-group">

                        <input type="text" class="form-control" id="createUserFirstName" placeholder="Votre prénom">
                    </div>

                    <div class="form-group">
                        <input type="text" class="form-control" id="createUserLastName" placeholder="Votre Nom">
                    </div>

                    <div class="form-group">
                        <input type="email" class="form-control" id="createUserEmail" placeholder="Votre courriel">
                    </div>
                
                    <div class="form-group">
                        <input type="password" class="form-control" id="createUserPass1" placeholder="Entrez votre mot de passe">
                    </div>

                    <div class="form-group">
                        <input type="password" class="form-control" id="createUserPass2" placeholder="Confirmer votre mot de passe">
                    </div>

                    <div class="form-group">
                        <button type="button" class="btn btn-default">S'inscire</button>
                    </div>
			    </div>
		    </div>
		    </div>
		    <div class="modal-footer">
		    <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
		    <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
		    </div>
	    </div><!-- /.modal-content -->
	    </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

</asp:Content>