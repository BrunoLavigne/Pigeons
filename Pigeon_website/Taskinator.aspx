<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Taskinator.aspx.cs" Inherits="Taskinator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Tasks.css" />
    <style>
        /*
            Add file for vendor overrides?
        */
        .ui-datepicker {
            background: #eee;
            padding: 10px;
        }
        .ui-datepicker .ui-datepicker-header {
            padding: 0 10px;
        }
        .ui-datepicker th, .ui-datepicker td {
            padding: 10px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <asp:UpdatePanel runat="server" ID="updatePanelTasks" UpdateMode="Conditional">
            <ContentTemplate><asp:Label runat="server" ID="testLabel"></asp:Label>
                
                <div class="Add-task-container">

                    <!-- Description de la tâche -->
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDescription" placeholder="Description de la tâche..." CssClass="form-control"></asp:TextBox>
                        <div class="validation-error-message">
                            <asp:RequiredFieldValidator ID="rfvTaskDescription" SetFocusOnError="true"  runat="server" controltovalidate="taskDescription" errormessage="Vous devez entrer une description" ValidationGroup="taskValidation" />  
                        </div>
                    </div>

                    <!-- Date de la tâche -->
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDueDate" placeholder="Ajouter une date limite" CssClass="form-control datepicker-holder"></asp:TextBox>
                    </div>
                    
                    <asp:Button runat="server" ID="btnAddTask" OnClick="btnAddTask_Click" Text="Ajouter" CssClass="btn btn-primary" ValidationGroup="taskValidation" />
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

    <!-- Import jQuery Ui for datepicker -->
    <!-- Todo: import only datepicker widget -->
    <script type="text/javascript" src="Scripts/jquery-ui-1.11.4.min.js"></script>
    <script>
        $(function () {
            $(".datepicker-holder").datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
    </script>

</asp:Content>

