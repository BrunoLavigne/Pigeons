<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" %>
<%@ Register TagPrefix="uc" TagName="NewGroupMessageModal" Src="~/Partials/NewGroupMessageModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Page header - main group info -->
    <div class="Group-presentation">

        <div class="picture-container">
            <img src="http://lorempixel.com/400/400" />
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

                <a href="#newGroupMessageModal" data-toggle="modal" data-target="#newGroupMessageModal">
                    Nouveau message
                </a>

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

            <!-- Tasks section -->
            <div class="col-lg-4">

                <a id="Tasks-toggler" class="Toggler tasks">
                    <div class="Toggler-container">Tasks <i class="glyphicon glyphicon-collapse-down"></i></div>
                </a>
                
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


        <!-- the todos -->
        <div class="row">

            <asp:ListView ID="todosListView" runat="server">
                <ItemTemplate>
                    <div class="Group-todo">
                        <div class="h4"><asp:Label runat="server" Text='<%#Eval("description") %>'></asp:Label></div>
                        <p>Completé?: <asp:Label runat="server" Text='<%#Eval("is_completed") %>'></asp:Label></p>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>


    </div><!-- ./container -->


    <!-- Connection modal -->
    <uc:NewGroupMessageModal runat="server" ID="newGroupMessageModal"></uc:NewGroupMessageModal>

</asp:Content>

