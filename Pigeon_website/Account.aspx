<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>
        .profile-picture {
            width: 100%;
            max-width: 400px;
        }
    </style>

    <div class="container">

        <div class="jumbotron">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AccountUpdatePanel" dynamiclayout="true" DisplayAfter="1">
                <progresstemplate>
                    
                    <img src="http://www.cuisson.co.uk/templates/cuisson/supersize/slideshow/img/progress.BAK-FOURTH.gif" id="loader-img" />

                </progresstemplate>
            </asp:UpdateProgress>


            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="AccountUpdatePanel">
                <ContentTemplate>

                    <h3>The account page</h3>
                    <p>View/edit profile info here...</p>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="editUserEmail" CssClass="form-control"></asp:TextBox>
                    </div>
            
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="editUserPhoneNumber" CssClass="form-control" placeholder="Numéro de téléphone"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="editUserDescription" CssClass="form-control" placeholder="Description"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="editUserOrganization" CssClass="form-control" placeholder="Organisation"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="editUserPosition" CssClass="form-control" placeholder="Postion/poste"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="editUserProfilePicture" CssClass="form-control" placeholder="Lien vers la photo de profil..."></asp:TextBox>
                    </div>

                    <div class="form-group">

                        <asp:Image runat="server" ID="userProfilePicture" CssClass="profile-picture" />

                        <asp:Button runat="server" ID="btnEditUser" CssClass="btn btn-danger" Text="Modifier" OnClick="btnEditUser_Click" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnEditUser" EventName="Click" />     
                </Triggers>
            </asp:UpdatePanel>




        </div><!-- /.jumbotron -->
    </div>
</asp:Content>

