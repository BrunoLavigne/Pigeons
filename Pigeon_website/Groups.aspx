<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">

        $(document).ready(function() {

                var $searchValue = $("#searchBarValue");


                // Optimize this in future
                // link if input empty or if we didn't find any results and search value keeps getting longer
                
                // Use JSON.NET in backend before using this, otherwise we get a "circular reference exception"
                // http://stackoverflow.com/questions/16949520/circular-reference-detected-exception-while-serializing-object-to-json
                

                $searchValue.on('change input', function() {

                        console.log("i just want to log" + $(this).val());

                        var params = JSON.stringify({ searchValue: $(this).val() });

                        $.ajax({

                            type: "POST",
                            url: "Groups.aspx/GetMatchingUsers",
                            data: params,
                            contentType: "application/json; charset=UTF-8",
                            dataType: "json",
                            success: OnSuccess,
                            error: function (response) {
                                alert(response.e);
                            }
                        });

                         function OnSuccess(response) {
                            console.log("success i guess" + response.d);
                        }
                });

    }); 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%@ Register TagPrefix="uc" TagName="NewGroupModal" Src="~/Partials/NewGroupModal.ascx" %>

    <asp:Label ID="TestLabel" runat="server" Text="Label"></asp:Label>

    <div class="container">
        <asp:Panel runat="server">
            <asp:GridView ID="gridViewUserGroups" runat="server"></asp:GridView>
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

