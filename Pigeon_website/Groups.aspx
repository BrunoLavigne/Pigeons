<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="Resources/js/ajax/groups.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Groups-page.css" />

    <div class="container">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updatePanelGroups" UpdateMode="Conditional">

            <ContentTemplate>

                <div class="New-group-form">

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNewGroupName" placeholder="Nom du groupe" CssClass="form-control"></asp:TextBox>
                        <div class="validation-error-message">
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ID="rfvTxtNewGroupName" ControlToValidate="txtNewGroupName" ValidationGroup="createNewGroupValidation" Text="Vous devez entrer un nom de groupe"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNewGroupFollowers" placeholder="Inviter des gens au groupe..." CssClass="form-control searchBarValue"></asp:TextBox>
                        <div class="new-group-followers-container" id="new-group-followers">

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNewGroupDescription" placeholder="Description" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <div class="validation-error-message">
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ID="rfvTxtNewGroupDescription" ControlToValidate="txtNewGroupDescription" ValidationGroup="createNewGroupValidation" Text="Vous devez entrer une description"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNewGroupPicture" placeholder="Url de la photo pour le groupe..." CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ID="btnNewGroup" Text="Créer le groupe" CssClass="btn btn-success" OnClick="btnNewGroup_Click" ValidationGroup="createNewGroupValidation" />
                    </div>
            
                </div><!-- /.New-group-container -->

                <div class="title">
                    Vos groupes
                    <div class="toggle-new-group-form">
                        <a href="#" id="toggleNewGroupForm" class="btn btn-info btn-sm">
                            <span class="glyphicon glyphicon-plus"></span>Créer un groupe
                        </a>
                    </div>
                </div>
                <hr />

                <!-- The user's group(s) -->
                <div class="row">
                    <asp:ListView ID="groupsListView" runat="server">
                        <ItemTemplate>

                            <div class="col-sm-6 col-md-4">

                                <div class="Group-item equal">

                                    <div class="inner-wrapper">
                                        <div class="group-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "Group.aspx?groupID=" + Eval("id") %>'>
                                                <div class="group-picture-wrapper">
                                                    <div class="group-picture" style='background-image:url(<%# Eval("group_picture_link") %>);'></div>
                                                </div>
                                                <div class="group-name-wrapper">
                                                    <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("name") %>' />
                                                </div>
                                                <div class="group-followers-count">
                                                    <asp:Label ID="lblGroupFollowrers" runat="server" Text='<%# "Nb followers : " + Eval("followers") %>' />
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
                                         </div>
                                    </div><!-- /.inner-wrapper -->

                                </div><!-- /.Group-item -->

                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div><!-- /.row list groups -->

            </ContentTemplate>

        </asp:UpdatePanel>

        
        <asp:Panel runat="server" ID="noGroupsView">
            <div class="panel panel-primary">
                <div class="panel-heading">Information</div>
                <div class="panel-body">
                    <asp:Label ID="groupsViewMessage" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>

    </div>

</asp:Content>

