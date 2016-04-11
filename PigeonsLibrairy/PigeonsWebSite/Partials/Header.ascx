<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="PigeonsWebSite.Partials.Header" %>
<div class="header">
	<nav class="navbar navbar-default">
		<div class="container">
			<!-- Brand and toggle get grouped for better mobile display -->
			<div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
                <asp:HyperLink CssClass="navbar-brand" runat="server" NavigateUrl="~/Index.aspx">

                    <!-- font in the logo is railway -->
                    <asp:Image ImageUrl="~/Resources/img/logo_no_txt.png" runat="server" />
                </asp:HyperLink>
			</div>

			<!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">

                <asp:Panel runat="server" ID="header_panel_connected">
                    <ul class="nav navbar-nav navbar-right">

				        <li>
                            <asp:HyperLink runat="server" NavigateUrl="~/Groups.aspx">
                                <span class="menu-icon glyphicon glyphicon-tent"></span>Groups
                            </asp:HyperLink>
				        </li>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl="~/Account.aspx">
                                <span class="menu-icon glyphicon glyphicon glyphicon-cog"></span>Account
                            </asp:HyperLink>                           
                        <li>
                            <asp:LinkButton runat="server" ID="btn_deconnexion" OnClick="btn_deconnexion_Click">
                                    <span class="menu-icon glyphicon glyphicon-off"></span>Déconnexion
                            </asp:LinkButton>
                        </li>
                    </ul>
                </asp:Panel>

                <asp:Panel runat="server" ID="header_panel_disconnected">
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <a href="#connectModal" data-toggle="modal" data-target="#connectModal">
                                <span class="menu-icon glyphicon glyphicon-user"></span>Connexion
                            </a>
                        </li>
                    </ul>
                </asp:Panel>

			</div><!-- /.navbar-collapse -->
		</div><!-- /.container -->
	</nav>
</div><!-- /header -->