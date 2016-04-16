<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadTest.aspx.cs" Inherits="FileUploadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" /></br>
        <asp:Button ID="Button1" runat="server" Text="Save User Picture" CommandArgument="22" CommandName="SaveUserPicture" OnClick="SaveUserPicture" /><br />
        <asp:Button ID="Button2" runat="server" Text="Save Group Picture" CommandArgument="<GROUP ID>" CommandName="SaveGroupPicture" OnClick="SaveGroupPicture" /><br />
        <asp:Button ID="Button3" runat="server" Text="Save File to Group" CommandArgument="<GROUP ID>" CommandName="SaveGroupFile" OnClick="SaveGroupFile" />
        <!-- NOTE POUR LAURENT: Quand tu générera les contrôles permettant de télécharger ou de uploader des fichiers, tu devra
            manuellement assigner une valeur à l'argument CommandArgument du contrôle (pour le upload, soit le user ID soit le group ID;
            pour le téléchargement ce sera le filePath du fichier à télécharger. Voir mon exemple-test avec le panel ci-dessous et
            la méthode AfficherGroupFiles(int groupID) du code behind -->
        </br>
        Get files:
        </br>
        <asp:DropDownList ID="ListGroupSelectDownload" runat="server" OnSelectedIndexChanged="ListGroupSelectDownload_SelectedIndexChanged"></asp:DropDownList>
        </br>
        <asp:Panel ID="PanelGroupFiles" runat="server" ScrollBars="Vertical" Height="70%" Width="80%"></asp:Panel>
    </div>
    </form>
</body>
</html>
