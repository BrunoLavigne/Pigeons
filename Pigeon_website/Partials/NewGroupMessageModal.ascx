<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewGroupMessageModal.ascx.cs" Inherits="Partials_NewGroupMessageModal" %>

<div class="modal fade" role="dialog" id="newGroupMessageModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Composer un message</h4>
		</div>
		<div class="modal-body">
		    <div class="row">
                <div class="col-md-8">
                    <h2>Nouveau message</h2>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMessageContent"></asp:TextBox>
                    <asp:Button ID="btnNewMessage" runat="server" Text="Envoyer" CssClass="btn btn-primary" OnClick="btnNewMessage_Click" />
                </div>
		    </div>
		</div>
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->

