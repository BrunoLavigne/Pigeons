<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Taskinator.aspx.cs" Inherits="Taskinator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Tasks.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <asp:UpdatePanel runat="server" ID="updatePanelTasks" UpdateMode="Conditional">
            <ContentTemplate><asp:Label runat="server" ID="testLabel"></asp:Label>
                
                <div class="Add-task-container">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDescription" placeholder="Description de la tâche..." CssClass="form-control"></asp:TextBox>
                    </div>
                    
                    <asp:Button runat="server" ID="btnAddTask" OnClick="btnAddTask_Click" Text="Ajouter" CssClass="btn btn-primary" />
                </div>

                <ul class="Tasks-container">

                    <asp:ListView runat="server" ID="listViewTasks">
                        <ItemTemplate>
                            <li class="Task-container">

			                    <label class="checkbox-wrapper">
                                    <asp:HiddenField ID="TaskIdHolder" runat="server" Value='<%#Eval("id") %>' />
                                    <asp:CheckBox runat="server" ID="checkBoxCompleted" AutoPostBack="true" Checked='<%# Eval("is_completed") %>' OnCheckedChanged="checkBoxCompleted_CheckedChanged" /><%# Eval("description") %>
			                    </label>

			                    <div class="content">
				                    <div class="author">Michael Scott (ajouter champ?)</div> - 
				                    <div class="due-date"><%# Eval("task_end") %></div>
			                    </div>

                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </ul>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" Runat="Server">
</asp:Content>

