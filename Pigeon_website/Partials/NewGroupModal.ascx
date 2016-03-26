<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewGroupModal.ascx.cs" Inherits="Partials_NewGroupModal" %>

<div class="modal fade" role="dialog" id="newGroupModal">
	<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<h4 class="modal-title">Création d'un groupe</h4>
		</div>
		<div class="modal-body">
		<div class="row">
			<div class="col-md-6">

                <div class="form-group">
                    <asp:TextBox runat="server" ID="newGroupName" placeholder="Nom" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <textarea id="newGroupDescription" placeholder="Description" class="form-control" runat="server"></textarea>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtPersonSearch" placeholder="Chercher quelqu'un..." CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="personFilterList" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
				

			</div>

		</div>
		</div>
		<div class="modal-footer">
		<button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
		</div>
	</div><!-- /.modal-content -->
	</div><!-- /.modal-dialog -->
</div><!-- /.modal -->

