﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" %>
<%@ Register TagPrefix="uc" TagName="NewGroupMessageModal" Src="~/Partials/NewGroupMessageModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Group-page.css" />

    <!-- Page header - main group info -->
    <div class="Group-presentation">

        <div class="picture-container">
            <img src="http://placehold.it/400/400" />
        </div>

        <div class="text">
            <div class="title">
                <asp:Label runat="server" ID="lblGroupName"></asp:Label>
            </div>

            <p>
                <asp:Label runat="server" ID="lblGroupDescription"></asp:Label>
            </p>

            <div class="h4">
                    Créé le <asp:Label runat="server" ID="lblGroupDateCreated"></asp:Label> 
                    à <asp:Label runat="server" ID="lblGroupTimeCreated"></asp:Label> 
                    par <asp:Label runat="server" ID="lblGroupAuthor"></asp:Label>      
            </div>
    
        </div>
        

    
    </div>

    <!-- temporary -->
    <div class="container">

        <!-- Only show if user is also admin -->
        <asp:Panel runat="server" ID="panelAdminButtons">

            <div class="row">
                <div class="col-sm-12">
                    <div class="Group-action-btn AddUser">

                        <div class="icon-container">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </div>
                
                        <div class="text-container">Personne</div>
                    </div>
                
                    <div class="Group-action-btn RemoveUser">

                        <div class="icon-container">
                            <i class="glyphicon glyphicon-minus-sign"></i>
                        </div>
                
                        <div class="text-container">Personne</div>
                    </div>
                    
                    <div class="Group-action-btn deleteGroup">

                        <div class="icon-container">
                            <i class="glyphicon glyphicon-remove-sign"></i>
                        </div>
                
                        <div class="text-container">Groupe</div>
                    </div>
                </div>
            </div>

        </asp:Panel>


        <div class="row">

            <!-- Messages section -->
            <div class="col-lg-4">
                
                <div class="Toggler messages">
                    <div class="text">Messages</div>

                    <div class="action">
                        <a href="#newGroupMessageModal" data-toggle="modal" data-target="#newGroupMessageModal">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </a>
                    </div>

                    <div class="action">
                        <a id="Group-messages-toggler">
                            <i class="glyphicon glyphicon-collapse-down"></i>
                        </a>
                    </div>

                    <div class="action"><i class="glyphicon glyphicon-search"></i></div>
                </div>

                <div class="Group-messages-container">
                    <asp:ListView ID="messagesListView" runat="server">
                        <ItemTemplate>
                            <div class="Group-message">
                                <div class="media">
                                    <div class="media-left media-middle">

                                        <!-- toggle profile picture, some info (email) -->
                                        <a href="#">
                                            <img class="media-object" src="http://lorempixel.com/300/300" alt="...">
                                        </a>
                                    &nbsp;</div>
                                    <div class="media-body">
                                        <h4 class="media-heading">Media heading</h4>
                                        <p><asp:Label runat="server" Text='<%#Eval("content") %>'></asp:Label></p>
                                    </div>
                                </div>
                            </div>
                    
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>

            <!-- Files section -->
            <div class="col-lg-4">
                <div class="Toggler files">
                    <div class="text">Files</div>

                    <div class="action">
                        <a href="#newGroupMessageModal" data-toggle="modal" data-target="#newGroupMessageModal">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </a>
                    </div>

                    <div class="action">
                        <a id="Group-files-toggler">
                            <i class="glyphicon glyphicon-collapse-down"></i>
                        </a>
                    </div>

                    <div class="action"><i class="glyphicon glyphicon-search"></i></div>
                </div>
            </div>

            <!-- Tasks section -->
            <div class="col-lg-4">

                <div class="Toggler tasks">
                    <div class="text">Todos</div>

                    <div class="action">
                        <a href="#newGroupMessageModal" data-toggle="modal" data-target="#newGroupMessageModal">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </a>
                    </div>

                    <div class="action">
                        <a id="Group-tasks-toggler">
                            <i class="glyphicon glyphicon-collapse-down"></i>
                        </a>
                    </div>

                    <div class="action"><i class="glyphicon glyphicon-search"></i></div>
                </div>

                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <div class="Group-todo">
                            <div class="h4"><asp:Label runat="server" Text='<%#Eval("description") %>'></asp:Label></div>
                            <p>Completé?: <asp:Label runat="server" Text='<%#Eval("is_completed") %>'></asp:Label></p>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>

        </div>


    </div><!-- ./container -->


    <!-- Connection modal -->
    <uc:NewGroupMessageModal runat="server" ID="newGroupMessageModal"></uc:NewGroupMessageModal>

</asp:Content>

