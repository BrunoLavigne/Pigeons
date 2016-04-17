<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="Resources/js/ajax/groups.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Groups-page.css" />

    <%@ Register TagPrefix="uc" TagName="NewGroupModal" Src="~/Partials/NewGroupModal.ascx" %>

    <div class="container">

        <div class="row t-center">
            <a href="#newGroupModal" data-toggle="modal" data-target="#newGroupModal" class="btn btn-success Btn-new-group">
                <span class="glyphicon glyphicon-plus"></span>
            </a>
        </div>

        <div class="New-group-container">

            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNewGroupName" placeholder="Nom du groupe" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNewGroupFollowers" placeholder="Inviter des gens au groupe..." CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNewGroupDescription" placeholder="Description" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNewGroupPicture" placeholder="Url de la photo pour le groupe..." CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button runat="server" ID="btnNewGroup" Text="Créer le groupe" CssClass="btn btn-success" />
            </div>
            
            
        </div>



        <div class="row">
            <asp:ListView ID="groupsListView" runat="server">
                <ItemTemplate>
                    <div class="col-sm-6 col-md-4">

                        <div class="Group-item">
                            <div class="group-title">
                                <asp:HyperLink runat="server" NavigateUrl='<%# "Group.aspx?groupID=" + Eval("id") %>'>
                                    <div class="group-picture-wrapper">
                                        <div class="group-picture" style='background-image:url(<%# Eval("group_picture_link") %>);'></div>
                                    </div>
                                    <div class="group-name-wrapper">
                                        <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("name") %>' />
                                    </div>
                                    
                                </asp:HyperLink>
                            </div>
                            <div class="group-info">
                                <div class="group-since">
                                    Créé le <asp:Label ID="lblGroupSince" runat="server" Text='<%# Eval("creation_date") %>' />
                                </div>
                                <div class="group-description">
                                    <asp:Label ID="lblGroupDescription" runat="Server" Text='<%# Eval("description") %>' />
                                </div>
                                <div class="groupFollowers">
                                    <asp:Label ID="lblGroupFollowrers" runat="server" Text='<%# "Nb followers : " + Eval("followers") %>' />
                                </div>
                             </div>
                        </div><!-- /.Group-item -->

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        
        <asp:Panel runat="server" ID="noGroupsView">
            <div class="panel panel-primary">
                <div class="panel-heading">Information</div>
                <div class="panel-body">
                    <asp:Label ID="groupsViewMessage" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>

    </div>

    <!-- New group modal -->
    <uc:NewGroupModal runat="server" ID="newGroupModal"></uc:NewGroupModal>

</asp:Content>

