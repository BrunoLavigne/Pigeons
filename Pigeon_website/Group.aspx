<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" %>

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

        <div class="row test">

            <asp:Label runat="server" ID="lblTest"></asp:Label>
            <asp:Button ID="BtnTest" runat="server" Text="Button" OnClick="BtnTest_Click" />
        </div>


        <!-- Messages section -->
        <div class="row">
            <asp:ListView ID="messagesListView" runat="server">
                <ItemTemplate>
                    <div class="Group-message">
                        <div class="media">
                            <div class="media-left media-middle">
                                <a href="#">
                                    <img class="media-object" src="http://lorempixel.com/300/300" alt="...">
                                </a>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">Media heading</h4>
                                <p><asp:Label runat="server" Text='<%#Eval("content") %>'></asp:Label></p>
                            </div>
                        </div>
                    </div>
                    
                </ItemTemplate>
            </asp:ListView>
        </div>

        <!-- the todos -->
        <div class="row">

        </div>


    </div><!-- ./container -->


    


</asp:Content>

