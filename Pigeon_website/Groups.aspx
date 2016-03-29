<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="Resources/js/ajax/groups.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%@ Register TagPrefix="uc" TagName="NewGroupModal" Src="~/Partials/NewGroupModal.ascx" %>

    <asp:Label ID="TestLabel" runat="server" Text="Label"></asp:Label>

    <div class="container">

        <asp:Panel runat="server" ID="groupsView">
            <asp:GridView ID="gridViewUserGroups" runat="server"></asp:GridView>
        </asp:Panel>

        <div class="row">
            <asp:ListView ID="groupsListView" runat="server">
                <ItemTemplate>
                    <div class="col-sm-6 col-md-4">
                        <div class="Group-item">
                            <div class="group-title">
                                <asp:Label ID="lblGroupName" runat="server" Text='<%#Eval("name") %>' />
                            </div>
                            <div class="group-since">
                                Créé le <asp:Label ID="lblGroupSince" runat="server" Text='<%#Eval("creation_date") %>' />
                            </div>
                            <div class="group-description">
                                <asp:Label ID="lblGroupDescription" runat="Server" Text='<%#Eval("description") %>' />
                            </div>
                        </div>
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

    <div class="New-group-bar">
        <div class="container">
            <a href="#newGroupModal" data-toggle="modal" data-target="#newGroupModal" class="btn btn-success Btn-new-group">
                <span class="menu-icon glyphicon glyphicon-plus"></span>Nouveau groupe
            </a>

            <input type="text" id="searchBarValue" />
            <button id="myButton" class="btn btn-primary">Get Person List</button> 
        </div>
    </div>

    <!-- New group modal -->
    <uc:NewGroupModal runat="server" ID="newGroupModal"></uc:NewGroupModal>

</asp:Content>

