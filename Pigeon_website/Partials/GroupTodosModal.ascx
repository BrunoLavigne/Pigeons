<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupTodosModal.ascx.cs" Inherits="Partials_GroupTodosModal" %>

<div class="modal fade" role="dialog" id="todosModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Création d'un groupe</h4>
		</div>
		<div class="modal-body">
		<div class="row">
			<div class="col-md-6">

                <h2>À faire</h2>

                <asp:DataGrid runat="server" ID="todosGridView"></asp:DataGrid>

			</div>

		</div>
		</div>
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->