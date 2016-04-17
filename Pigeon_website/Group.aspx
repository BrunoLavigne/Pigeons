<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" ValidateRequest="false" %>
<%@ Register TagPrefix="uc" TagName="RemoveUserModal" Src="~/Partials/RemoveUserFromGroupModal.ascx" %>
<%@ Register TagPrefix="uc" TagName="DeleteGroupModal" Src="~/Partials/DeleteGroupModal.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Resources/Vendor/summernote/summernote.css" />
    <link rel="stylesheet" href="Resources/css/Tasks.css" />
    <link rel="stylesheet" href="Resources/css/Events-Page.css" />
    <link rel="stylesheet" href="Resources/css/Vendor-overrides.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="stylesheet" href="Resources/css/Group-page.css" />

    <!-- The sidebar to navigate to the different sections -->
    <div class="Sidebar">
        <ul>
            <li>
                <a href="#messages-section">
                    <span class="glyphicon glyphicon-envelope"></span>
                </a>
            </li>
            <li>
                <a href="#events-section">
                    <span class="glyphicon glyphicon-calendar"></span>
                </a>
            </li>
            <li>
                <a href="#tasks-section">
                    <span class="glyphicon glyphicon-check"></span>
                </a>
            </li>
            <li>
                <a href="#files-section">
                    <span class="glyphicon glyphicon-paperclip"></span>
                </a>
            </li>
        </ul>
    </div>


    <!-- Page header - main group info -->
    <div class="Group-presentation">

        <div class="picture-container">
            <asp:Image runat="server" ID="presentationPicture" />
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

        <!-- Only show if user is also admin -->
        <asp:Panel runat="server" ID="panelAdminButtons" CssClass="Admin-buttons">

            <div class="row">
                <div class="col-sm-12">
                    <div class="Group-action-btn AddUser">

                        <div class="icon-container">
                            <i class="glyphicon glyphicon-plus-sign"></i>
                        </div>
                
                        <div class="text-container">Personne</div>
                    </div>
                
                    <a href="#removeUserModal" data-toggle="modal" data-target="#removeUserModal">
                        <div class="Group-action-btn RemoveUser">

                            <div class="icon-container">
                                <i class="glyphicon glyphicon-minus-sign"></i>
                            </div>
                
                            <div class="text-container">Personne</div>
                        </div>
                    </a>

                    <a href="#deleteGroupModal" data-toggle="modal" data-target="#deleteGroupModal">
                        <div class="Group-action-btn deleteGroup">

                            <div class="icon-container">
                                <i class="glyphicon glyphicon-remove-sign"></i>
                            </div>
                
                            <div class="text-container">Groupe</div>
                        </div>
                    </a>

                </div>
            </div>

        </asp:Panel>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-------------->
        <!-- MESSAGES -->
        <!-------------->
        <div class="Group-messages-container" id="messages-section">

            
            <asp:UpdatePanel runat="server" ID="updatePanelMessages" UpdateMode="Conditional">

                <ContentTemplate>

                    <div class="form-group"">
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtNewMessage" CssClass="form-control summernote" placeholder="Composer un message..."></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ID="btnNewMessage" CssClass="btn btn-success" OnClick="btnNewMessage_Click" Text="Envoyer" />
                    </div>

                    <asp:ListView ID="messagesListView" runat="server">
                        <ItemTemplate>

                            <div class="Group-message row">

                                <div class="user-info col-sm-1">

                                    <!-- User profile picture here -->
                                    <div class="profile-picture-container">
                                        <img class="" src='<%# Eval("profile_picture_link") %>' alt="UserName profile picture">
                                    </div>

                                </div><!-- /.user-info -->

                                <div class="content col-sm-11">
                                    <div class="post-info">
                                        <%# Eval("author") %> - <%# Eval("date_created") %>
                                    </div>

                                    <asp:Label runat="server" Text='<%#Server.HtmlDecode(Eval("content").ToString()) %>'></asp:Label>

                                </div><!-- /.content -->

                            </div><!-- /.Group-message -->
                    
                        </ItemTemplate>
                    </asp:ListView>

                </ContentTemplate>

            </asp:UpdatePanel>

        </div>
        <!---------------->
        <!-- /.MESSAGES -->
        <!---------------->







        <!------------>
        <!-- EVENTS -->
        <!------------>
        <div class="Group-events-container" id="events-section">

            <div class="container Events-app">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnNewEvent" />
                        <asp:AsyncPostBackTrigger ControlID="btnCreateEvent" />
                        <asp:AsyncPostBackTrigger ControlID="Calendar1" />
                    </Triggers>

                    <ContentTemplate>

                        <fieldset>
                            <div class="container">
                                <div class="row">

                                    <div class="col-lg-3">
                                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" CssClass="eventCalendar" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" SelectionMode="None" NextMonthText="&#8674&nbsp;" PrevMonthText="&nbsp;&#8672&nbsp;"></asp:Calendar>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:Table ID="Table1" runat="server" CssClass="table table-hover">
                                        </asp:Table>
                                    </div>

                                    <div class="container">

                                        <div class="col-lg-2">

                                            <div class="row">
                                                <asp:Button ID="btnNewEvent" runat="server" CssClass="btn btn-default btn-block" Text="+" OnClick="btnNewEvent_Click" />
                                            </div>

                                            <div id="newEvent" visible="false" runat="server">
                                                <div class="row">
                                                    <asp:TextBox ID="txtEventDescription" runat="server" CssClass="form-control" placeHolde="Description"></asp:TextBox>
                                                </div>
                                                <div class="row" style="padding-top: 10px;">
                                                    <asp:TextBox ID="txtEventStart" runat="server" CssClass="form-control input-sm datepicker-holder"></asp:TextBox>
                                                    <%--<asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-default btn-sm" OnClick="Button1_Click" />--%>
                                                </div>
                                                <div class="row" style="padding-top: 10px;">
                                                    <asp:TextBox ID="txtEventEnd" runat="server" CssClass="form-control input-sm datepicker-holder"></asp:TextBox>
                                                    <%--<asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-default btn-sm" OnClick="Button2_Click" />   --%>
                                                </div>
                                                <div class="row" style="padding-top: 10px;">
                                                    <asp:Button ID="btnCreateEvent" runat="server" Text="Créer l'évènement" CssClass="btn btn-primary btn-sm" OnClick="btnCreateEvent_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>

        </div>
        <!-------------->
        <!-- ./EVENTS -->
        <!-------------->









        <!----------->
        <!-- TASKS -->
        <!----------->
        <div class="Group-tasks-container" id="tasks-section">
                
            <div class="container Tasks-app">

                


                <asp:UpdatePanel runat="server" ID="updatePanelTasks" UpdateMode="Conditional">
                    <ContentTemplate>
                
                        <div class="title">Ajouter une tâche</div>

                        <!-- Add a task section -->
                        <div class="Add-task-container">

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

                                                <!-- we shouldn't have two hiddenfields... -->
			                                    <%--<asp:HiddenField ID="TaskIdHolder2" runat="server" Value='<%#Eval("id") %>' />--%>
                                                <asp:Button CssClass="btn-delete-task" runat="server" ID="btnDeleteTask" AutoPostBack="true" Text="X" OnClick="btnDeleteTask_Click" />


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

            </div><!-- ./Tasks-app -->
        </div>
        <!------------->
        <!-- ./TASKS -->
        <!------------->



        <!----------->
        <!-- FILES -->
        <!----------->
        <div class="Group-files-container" id="files-section">
            <h2>Files!</h2>
        </div>
        <!------------->
        <!-- ./FILES -->
        <!------------->

    </div><!-- ./container -->

    <!-- Remove user from group modal -->
    <uc:RemoveUserModal runat="server" ID="RemoveUserModal"></uc:RemoveUserModal>

    <!-- Delete group modal -->
    <uc:DeleteGroupModal runat="server" ID="DeleteGroupModal" />


    <!-- To avoid conflict with summernote js (bug with tooltip not positioned correctly on summernote buttons) -->
    <script type="text/javascript" src="Scripts/jquery-ui-1.11.4.min.js"></script>

</asp:Content>

<asp:Content ID="contentScripts" ContentPlaceHolderID="ContentPlaceHolderScripts" Runat="Server">

    <script type="text/javascript" src="Resources/js/animations/Group.js"></script>
    <script type="text/javascript" src="Resources/Vendor/summernote/summernote.min.js"></script>
    <script type="text/javascript" src="Resources/js/Group.js"></script>

</asp:Content>
