<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RemoveUserFromGroupModal.ascx.cs" Inherits="Partials_RemoveUserFromGroupModal" %>


<style>

    .Remove-user-modal {
        font-family: Montserrat, sans-serif;
    }
        .Remove-user-modal .Person-container {
            padding: 20px;
        }

        .Remove-user-modal .Person-container > div {
            display: inline-block;
            vertical-align: middle;
        }
        .Remove-user-modal .Person-container .name {
            font-size: 20px;
            font-weight: bold;
        }
        .Remove-user-modal .Person-container .profile-picture {
            width: 100px;
            height: 100px;
            border-radius: 50%;
        }

</style>

<div class="modal fade Remove-user-modal" role="dialog" id="removeUserModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Enlever des utilisateurs du groupe</h4>
		</div>
		<div class="modal-body">
		<div class="row">

            <asp:Label runat="server" ID="testLabel">

            </asp:Label>

            <h2>Utilisateurs du groupe</h2>
			<div class="">

                <asp:ListView ID="followingListView" runat="server" OnItemCommand="btnRemoveFollowing_Command">
                    <ItemTemplate>
                        <div class="Person-container">

                            <div class="profile-picture" style='background: url(<%# Eval("profile_picture_link") %>);'></div>

                            <div class="info">
                                <div class="name"><%#Eval("name") %></div>
                                <div class="email"><%#Eval("email") %></div>
                                <div class="organization"><%#Eval("organization") %></div>
                            </div>

                            <div class="button-wrapper">
                                 <asp:Button CssClass="btn btn-danger" ID="btnRemoveFollowing" runat="server" Text="Supprimer" CommandName="RemoveFollowing" CommandArgument='<%#Eval("id") %>'></asp:Button>
                            </div>
                            
                        </div>
                    </ItemTemplate>
                </asp:ListView>

                <asp:Panel runat="server" ID="panelFollowersInfo">
                    <div class="panel panel-primary">
                        Vous n'avez pas d'utilisateur associé à ce groupe!
                    </div>
                </asp:Panel>
			</div>

		</div>
		</div>
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->
