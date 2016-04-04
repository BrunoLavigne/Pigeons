<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewGroupMessageModal.ascx.cs" Inherits="Partials_NewGroupMessageModal" %>

<div class="modal fade" role="dialog" id="newGroupMessageModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Connexion</h4>
		</div>
		<div class="modal-body">
		<div class="row">
            <div class="col-md-8">
                <h2>Nouveau message</h2>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMessageContent"></asp:TextBox>
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

