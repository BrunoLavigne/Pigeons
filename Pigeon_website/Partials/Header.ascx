﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Partials_Header" %>

<div class="header">
	<nav class="navbar navbar-default">
		<div class="container-fluid">
			<!-- Brand and toggle get grouped for better mobile display -->
			<div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				<a class="navbar-brand" href="#">Pigeon</a>
			</div>

			<!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <%--<asp:Button ID="btn_connexion" runat="server" OnClick="btn_connexion_Click" Text="ConnexionTest" />--%>

                <asp:Panel runat="server" ID="header_panel_connected">
                    <ul class="nav navbar-nav navbar-right">
				        <li><a href="#"><span class="menu-icon glyphicon glyphicon-home"></span>Home</a></li>
                        <li><a href="#"><span class="menu-icon glyphicon glyphicon glyphicon-cog"></span>Profile</a></li>
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
                            <a href="#myModal" data-toggle="modal" data-target="#myModal">
                                <span class="menu-icon glyphicon glyphicon-user"></span>Connexion
                            </a>
                        </li>
                    </ul>
                </asp:Panel>

			</div><!-- /.navbar-collapse -->
		</div><!-- /.container-fluid -->
	</nav>
</div><!-- /header -->
