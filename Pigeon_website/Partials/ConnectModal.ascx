<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConnectModal.ascx.cs" Inherits="Partials_ConnectModal" %>

<style>


    .Connect-modal {
        font-family: Montserrat, sans-serif;
    }

        .Connect-modal .section-title {
            font-size: 18px;
            margin-bottom: 8px;
        }
        .Connect-modal .Icon {
            vertical-align: middle;
            margin-right: 6px;
        }

</style>

<div class="modal fade Connect-modal" role="dialog" id="connectModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>

		</div>
		<div class="modal-body">
		<div class="row">
			<div class="col-md-6">

				<div class="section-title">
                    <i class="material-icons Icon">person</i>Se connecter
				</div>
                
                <div class="form-group">
                    <asp:TextBox ID="connectUserEmail" runat="server" placeholder="Courriel" CssClass="form-control"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvConnectUserEmail" SetFocusOnError="true"  runat="server" controltovalidate="connectUserEmail" Display="Dynamic" errormessage="Veuillez entrer votre courriel" ValidationGroup="connectGroup" />
                    </div>  
                </div>
                
                <div class="form-group">
                    <asp:TextBox ID="connectUserPassword" runat="server" placeholder="Mot de passe" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvConnectUserPassword" SetFocusOnError="true"  runat="server" controltovalidate="connectUserPassword" errormessage="Veuillez entrer votre mot de passe" ValidationGroup="connectGroup" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_connectUser" OnClick="btn_connectUser_Click" Text="Connexion" ValidationGroup="connectGroup" />
                </div>

			</div>
			<div class="col-md-6">

                <div class="section-title">
                    <i class="material-icons Icon">create</i>S'inscrire
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserFirstName" runat="server" placeholder="Votre prénom" CssClass="form-control"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvCreateUserFirstName" SetFocusOnError="true"  runat="server" controltovalidate="createUserFirstName" Display="Dynamic" errormessage="Ce champ ne peut être vide" ValidationGroup="createGroup" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserLastName" runat="server" placeholder="Votre nom" CssClass="form-control"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvCreateUserLastName" SetFocusOnError="true"  runat="server" controltovalidate="createUserLastName" Display="Dynamic" errormessage="Ce champ ne peut être vide" ValidationGroup="createGroup" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserEmail" runat="server" placeholder="Votre courriel" CssClass="form-control"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvCreateUserEmail" SetFocusOnError="true"  runat="server" controltovalidate="createUserEmail" Display="Dynamic" errormessage="Ce champ ne peut être vide" ValidationGroup="createGroup" />  
                    </div>
                </div>
                
                <div class="form-group">
                    <asp:TextBox ID="createUserPass1" runat="server" placeholder="Entrez votre mot de passe" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvCreateUserPass1" SetFocusOnError="true"  runat="server" controltovalidate="createUserPass1" Display="Dynamic" errormessage="Ce champ ne peut être vide" ValidationGroup="createGroup" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="createUserPass2" runat="server" placeholder="Confirmez votre mot de passe" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <div class="validation-error-message">
                        <asp:RequiredFieldValidator ID="rfvCreateUserPass2" SetFocusOnError="true"  runat="server" controltovalidate="createUserPass2" Display="Dynamic" errormessage="Ce champ ne peut être vide" ValidationGroup="createGroup" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_createUser" OnClick="btn_createUser_Click" Text="Créer mon compte" ValidationGroup="createGroup" />
                </div>
			</div>
		</div><!-- /.row -->
		</div><!-- /.modal-body -->
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->

