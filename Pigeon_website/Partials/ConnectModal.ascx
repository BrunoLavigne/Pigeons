<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConnectModal.ascx.cs" Inherits="Partials_ConnectModal" %>

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
                    <asp:TextBox ID="connectUserEmail" runat="server" placeholder="Courriel" CssClass="form-control"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <asp:TextBox ID="connectUserPassword" runat="server" placeholder="Mot de passe" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_connectUser" OnClick="btn_connectUser_Click" Text="Connexion" />
                </div>

			</div>
			<div class="col-md-6">

                <h4>S'inscrire</h4>

                <div class="form-group">
                    <asp:TextBox ID="createUserFirstName" runat="server" placeholder="Votre prénom" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserLastName" runat="server" placeholder="Votre nom" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserEmail" runat="server" placeholder="Votre courriel" CssClass="form-control"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <asp:TextBox ID="createUserPass1" runat="server" placeholder="Entrez votre mot de passe" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserPass2" runat="server" placeholder="Entrez votre mot de passe" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_createUser" OnClick="btn_createUser_Click" Text="Créer mon compte" />
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

