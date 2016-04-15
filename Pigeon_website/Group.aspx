<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" ValidateRequest="false" %>
<%@ Register TagPrefix="uc" TagName="RemoveUserModal" Src="~/Partials/RemoveUserFromGroupModal.ascx" %>
<%@ Register TagPrefix="uc" TagName="DeleteGroupModal" Src="~/Partials/DeleteGroupModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Resources/Vendor/summernote/summernote.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Group-page.css" />

    <!-- Page header - main group info -->
    <div class="Group-presentation">

        <asp:HyperLink runat="server" ID="testTodosLink" Text="Voir la tasklist du group"></asp:HyperLink>

        <div class="picture-container">
            <asp:Image runat="server" ID="presentationPicture" />
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
        <asp:Panel runat="server" ID="panelAdminButtons" CssClass="Admin-buttons">

            <div class="row">
                <div class="col-sm-12">
                    <div class="Group-action-btn AddUser">

                        <div class="icon-container">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </div>
                
                        <div class="text-container">Personne</div>
                    </div>
                
                    <a href="#removeUserModal" data-toggle="modal" data-target="#removeUserModal">
                        <div class="Group-action-btn RemoveUser">

                            <div class="icon-container">
                                <i class="glyphicon glyphicon-minus-sign"></i>
                            </div>
                
                            <div class="text-container">Personne</div>
                        </div>
                    </a>

                    <a href="#deleteGroupModal" data-toggle="modal" data-target="#deleteGroupModal">
                        <div class="Group-action-btn deleteGroup">

                            <div class="icon-container">
                                <i class="glyphicon glyphicon-remove-sign"></i>
                            </div>
                
                            <div class="text-container">Groupe</div>
                        </div>
                    </a>

                </div>
            </div>

        </asp:Panel>


        <!-------------->
        <!-- MESSAGES -->
        <!-------------->
        <div class="Group-messages-container">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="updatePanelMessages" UpdateMode="Conditional">

                <ContentTemplate>

                    <div class="form-group"">
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtNewMessage" CssClass="form-control summernote" placeholder="Composer un message..."></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ID="btnNewMessage" CssClass="btn btn-success" OnClick="btnNewMessage_Click" Text="Envoyer" />
                    </div>

                    <asp:ListView ID="messagesListView" runat="server">
                        <ItemTemplate>

                            <div class="Group-message row">

                                <div class="user-info col-sm-1">

                                    <!-- User profile picture here -->
                                    <div class="profile-picture-container">
                                        <img class="" src='<%# Eval("profile_picture_link") %>' alt="UserName profile picture">
                                    </div>

                                </div><!-- /.user-info -->

                                <div class="content col-sm-11">
                                    <div class="post-info">
                                        <%# Eval("author") %> - <%# Eval("date_created") %>
                                    </div>

                                    <asp:Label runat="server" Text='<%#Server.HtmlDecode(Eval("content").ToString()) %>'></asp:Label>

                                </div><!-- /.content -->

                            </div><!-- /.Group-message -->
                    
                        </ItemTemplate>
                    </asp:ListView>

                </ContentTemplate>

            </asp:UpdatePanel>

        </div>
        <!---------------->
        <!-- /.MESSAGES -->
        <!---------------->


        <!------------>
        <!-- EVENTS -->
        <!------------>
        <div class="Group-events-container">
            <h2>The events!</h2>
        </div>
        <!-------------->
        <!-- ./EVENTS -->
        <!-------------->


        <!----------->
        <!-- TASKS -->
        <!----------->
        <div class="Group-tasks-container">
            <h2>Tasks!</h2>
        </div>
        <!------------->
        <!-- ./TASKS -->
        <!------------->



        <!----------->
        <!-- FILES -->
        <!----------->
        <div class="Group-files-container">
            <h2>Files!</h2>
        </div>
        <!------------->
        <!-- ./FILES -->
        <!------------->

    </div><!-- ./container -->

    <!-- Remove user from group modal -->
    <uc:RemoveUserModal runat="server" ID="RemoveUserModal"></uc:RemoveUserModal>

    <!-- Delete group modal -->
    <uc:DeleteGroupModal runat="server" ID="DeleteGroupModal" />

</asp:Content>

<asp:Content ID="contentScripts" ContentPlaceHolderID="ContentPlaceHolderScripts" Runat="Server">
    <script type="text/javascript" src="Resources/js/animations/Group.js"></script>
    <script src="Resources/Vendor/summernote/summernote.min.js"></script>
    <script>

        // Start summernote plugin on textbox
        function pageLoad () {
            $(".summernote").summernote();
        }

    </script>
</asp:Content>