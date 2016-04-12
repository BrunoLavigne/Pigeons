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

    <div class="container Tasks-app">

        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <asp:UpdatePanel runat="server" ID="updatePanelTasks" UpdateMode="Conditional">
            <ContentTemplate>
                
                <!-- Add a task section -->
                <div class="Add-task-container">

                    <div class="title">Ajouter une tâche</div>

                    <!-- Description de la tâche -->
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDescription" placeholder="Description de la tâche..." CssClass="form-control"></asp:TextBox>
                        <div class="validation-error-message">
                            <asp:RequiredFieldValidator ID="rfvTaskDescription" SetFocusOnError="true"  runat="server" controltovalidate="taskDescription" errormessage="Vous devez entrer une description" ValidationGroup="taskValidation" Display="Dynamic" />  
                        </div>
                    </div>

                    <!-- Date de la tâche -->
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDueDate" placeholder="Ajouter une date limite" CssClass="form-control datepicker-holder"></asp:TextBox>
                    </div>

                    <!-- Heure de la tâche -->
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="taskDueTime" placeholder="Heure de la date limite" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- Important task? -->
                    <div class="form-group">
                        <label class="checkbox-wrapper">
                            <asp:CheckBox runat="server" ID="taskFlagged" />Marquer comme tâche importante<span class="glyphicon glyphicon-flag"></span>
                        </label>
                            
                    </div>
                    
                    <asp:Button runat="server" ID="btnAddTask" OnClick="btnAddTask_Click" Text="Ajouter" CssClass="btn btn-primary" ValidationGroup="taskValidation" />
                </div><!-- /.Add-task-container -->

                <!-- Show tasks section -->
                <div class="row">

                    <!-- TODO: flagged tasks -->
                    <div class="col-md-4">
                        <div class="title"><span class="glyphicon glyphicon-flag"></span>Flagged (<asp:Label runat="server" ID="lblFlaggedTasksCount"></asp:Label>)</div>

                        <ul class="Tasks-container flagged">

                            <asp:ListView runat="server" ID="listViewFlagged">
                                <ItemTemplate>
                                    <li class="Task-container">

			                            <label class="checkbox-wrapper">
                                            <asp:HiddenField ID="TaskIdHolder" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:CheckBox runat="server" ID="checkBoxCompleted" AutoPostBack="true" Checked='<%# Eval("is_completed") %>' OnCheckedChanged="checkBoxCompleted_CheckedChanged" /><%# Eval("description") %>
			                            </label>

			                            <div class="content">
				                            <div class="author">Michael Scott (ajouter champ?)</div> - 
				                            <div class="due-date"><%# Eval("task_datetime") %></div>
			                            </div>

                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul><!-- /.incompleted -->
                    </div>

                    <!-- Incompleted tasks -->
                    <div class="col-md-4">

                        <div class="title"><span class="glyphicon glyphicon-unchecked"></span>À faire (<asp:Label runat="server" ID="lblIncompletedTasksCount"></asp:Label>)</div>

                        <ul class="Tasks-container incompleted">

                            <asp:ListView runat="server" ID="listViewIncompleted">
                                <ItemTemplate>
                                    <li class="Task-container">

			                            <label class="checkbox-wrapper">
                                            <asp:HiddenField ID="TaskIdHolder" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:CheckBox runat="server" ID="checkBoxCompleted" AutoPostBack="true" Checked='<%# Eval("is_completed") %>' OnCheckedChanged="checkBoxCompleted_CheckedChanged" /><%# Eval("description") %>
			                            </label>

			                            <div class="content">
				                            <div class="author">Michael Scott (ajouter champ?)</div> - 
				                            <div class="due-date"><%# Eval("task_datetime") %></div>
			                            </div>

                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul><!-- /.incompleted -->
                    </div>

                    <!-- Completed tasks -->
                    <div class="col-md-4">

                        <div class="title"><span class="glyphicon glyphicon-check"></span>Completé (<asp:Label runat="server" ID="lblCompletedTasksCount"></asp:Label>)</div>

                        <ul class="Tasks-container completed">

                            <asp:ListView runat="server" ID="listViewCompleted">
                                <ItemTemplate>
                                    <li class="Task-container">

			                            <label class="checkbox-wrapper">
                                            <asp:HiddenField ID="TaskIdHolder" runat="server" Value='<%#Eval("id") %>' />
                                            <asp:CheckBox runat="server" ID="checkBoxCompleted" AutoPostBack="true" Checked='<%# Eval("is_completed") %>' OnCheckedChanged="checkBoxCompleted_CheckedChanged" /><%# Eval("description") %>
			                            </label>

			                            <div class="content">
				                            <div class="author">Michael Scott (ajouter champ?)</div> - 
				                            <div class="due-date"><%# Eval("task_datetime") %></div>
			                            </div>

                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul><!-- /.completed -->
                    </div>

                </div><!-- /.row for show tasks section -->

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

