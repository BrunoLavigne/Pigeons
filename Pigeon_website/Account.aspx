<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .Account {
            font-family: Montserrat, Arial, sans-serif;
        }

            .Account .profile-picture-container {
                padding: 24px;
                text-align: center;
            }

            .Account .profile-picture {
                width: 200px;
                height: 200px;
                border-radius: 50%;
            }
    </style>

    <div class="container Account">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AccountUpdatePanel" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>

                <img src="http://www.cuisson.co.uk/templates/cuisson/supersize/slideshow/img/progress.BAK-FOURTH.gif" id="loader-img" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="AccountUpdatePanel">
            <ContentTemplate>

                <h3>Bonjour
                    <asp:Label runat="server" ID="lblUserName"></asp:Label></h3>
                <p>Vous pouvez modifier vos informations personnelles ici</p>
                <hr />

                <div class="row">

                    <!-- Profile picture section -->
                    <div class="col-md-4">

                        <div class="profile-picture-container">
                            <asp:Image runat="server" ID="userProfilePicture" CssClass="profile-picture" />
                        </div>

                        <div class="form-group">
                            <asp:TextBox runat="server" ID="editUserProfilePicture" CssClass="form-control" placeholder="Lien vers la photo de profil..." Visible="false"></asp:TextBox>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            <asp:Button ID="Button1" runat="server" Text="Enregistrer une image" CommandArgument="22" CommandName="SaveUserPicture" OnClick="SaveUserPicture" />
                        </div>
                    </div>

                    <!-- Other profile information -->
                    <div class="col-md-8">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="editUserEmail" CssClass="form-control"></asp:TextBox>
                            <div class="validation-error-message">
                                <asp:RequiredFieldValidator ID="rfvEditUserEmail" SetFocusOnError="true" runat="server" ControlToValidate="editUserEmail" Display="Dynamic" ErrorMessage="Vous devez avoir une adresse courriel" ValidationGroup="modifyUserInfo" />
                            </div>
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
                            <asp:Button runat="server" ID="btnEditUser" CssClass="btn btn-danger" Text="Modifier" OnClick="btnEditUser_Click" ValidationGroup="modifyUserInfo" />
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEditUser" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <!-- /.container -->
</asp:Content>