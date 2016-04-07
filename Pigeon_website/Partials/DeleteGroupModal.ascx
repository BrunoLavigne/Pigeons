<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteGroupModal.ascx.cs" Inherits="Partials_DeleteGroupModal" %>

<div class="modal fade" role="dialog" id="deleteGroupModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Création d'un groupe</h4>
		</div>
		<div class="modal-body">
		<div class="row">
			<div class="col-md-6">

                <h2>Supprimer le groupe</h2>
                
                Êtes-vous sûr de vouloir supprimer le groupe <asp:Label runat="server"></asp:Label>? Vous ne pourrez pas défaire cette action.
                <asp:Button runat="server" ID="confirmDeleteGroup" OnClick="confirmDeleteGroup_Click" />

			</div>

		</div>
		</div>
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->