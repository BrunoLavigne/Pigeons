using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Group : System.Web.UI.Page
{
    protected GroupFacade groupFacade { get; set; }

    protected HomeFacade homeFacade { get; set; }

    public int? groupId { get; set; }

    private List<@event> eventsList { get; set; }

    private DateTime dateValidation = DateTime.Parse("0001-01-01 12:00:00 AM");

    private enum ActionType { NONE, SAVE_PERSON_PICTURE, SAVE_GROUP_PICTURE, SAVE_GROUP_FILE };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }

        // Also check if the group actually exists and if the user is following it
        if (!IsValidated())
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
            person currentUser = (person)Session["user"];

            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int maybeGroupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out maybeGroupId);

            if (goodGroupId)
            {
                groupId = maybeGroupId;     // definitely

                if (!Page.IsPostBack)
                {
                    renderGroupToPage();

                    eventsList = groupFacade.GetGroupEvent(groupId);

                    Session["events"] = eventsList;
                    Session["facade"] = groupFacade;

                    // Events table avec les Events du mois
                    createEventTable(DateTime.Now);
                }
                else
                {
                    eventsList = (List<@event>)Session["events"];
                    groupFacade = (GroupFacade)Session["facade"];

                    // Events table selon le mois visible en ce moment sur la page (au first load la visible date est égale à la date de validation et nous ne voulons pas afficher pour celle-ci)
                    createEventTable((Calendar1.VisibleDate == dateValidation) ? DateTime.Now : Calendar1.VisibleDate);
                }

                if (!groupFacade.PersonIsGroupAdmin(currentUser.Id, groupId))
                {
                    panelAdminButtons.Visible = false;
                }

                AfficherGroupFiles((int)groupId);
            }
        }
    }

    protected bool IsValidated()
    {
        // Also, if group exists, if user is in group, etc.
        bool isFine = Session["user"] != null ||
                        Request.Params["groupID"] != null;

        return isFine;
    }

    // On devrait plus passer un groupe
    protected void renderGroupToPage()
    {
        group theGroup;

        // TODO: Faire une méthode bool groupExists(int groupId)
        try
        {
            theGroup = groupFacade.GetGroupByID(groupId);

            lblGroupName.Text = theGroup.Name;
            lblGroupDescription.Text = theGroup.Description;

            presentationPicture.ImageUrl = theGroup.Group_picture_link;

            CultureInfo frCA = new CultureInfo("fr-CA");

            lblGroupDateCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.LongDatePattern, frCA);
            lblGroupTimeCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.ShortTimePattern, frCA);
            renderMessagesToPage();
            refreshGroupTasks();
        }
        catch (Exception e)
        {
            Console.WriteLine("Group not found: " + e.Message);
        }
    }

    # region MESSAGES

    /// <summary>
    /// Display the group messages on the page
    /// </summary>
    protected void renderMessagesToPage()
    {
        DataTable table = new DataTable();
        table.Columns.Add("date_created");
        table.Columns.Add("content");
        table.Columns.Add("author");
        table.Columns.Add("profile_picture_link");

        foreach (message m in groupFacade.GetGroupMessages(int.Parse(Request.Params["groupID"])))
        {
            DataRow dr = table.NewRow();
            dr["date_created"] = m.Date_created;
            dr["content"] = m.Content;
            dr["author"] = homeFacade.GetPersonByID(m.Author_Id).Name;
            dr["profile_picture_link"] = homeFacade.GetPersonByID(m.Author_Id).Profile_picture_link;

            table.Rows.Add(dr);
        }

        messagesListView.DataSource = table;
        messagesListView.DataBind();
    }

    /// <summary>
    /// Create a new message
    /// Encode it first to support html tags
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNewMessage_Click(object sender, EventArgs e)
    {
        person user = (person)Session["user"];

        // Create the message
        message newMessage = new message();
        newMessage.Date_created = DateTime.Now;
        newMessage.Content = Server.HtmlEncode(txtNewMessage.Text);
        newMessage.Author_Id = user.Id;
        newMessage.Group_Id = int.Parse(Request.Params["groupID"]);

        // Save it
        groupFacade.CreateNewMessage(newMessage);

        // Refresh
        renderMessagesToPage();

        // Clear textbox for eventual new messages
        txtNewMessage.Text = "";
    }

    #endregion MESSAGES

    # region TASKS

    /// <summary>
    /// Clear the fields on the create a new task form
    /// </summary>
    protected void clearFields()
    {
        taskDescription.Text = "";
        taskDueDate.Text = "";
        taskDueTime.Text = "";
        taskFlagged.Checked = false;
    }

    /// <summary>
    /// Distribute tasks on the page
    /// 3 groups of tasks:
    /// - A group of tasks is incompleted (not completed AND not flagged)
    /// - A group of tasks is flagged (not completed AND flagged)
    /// - A group of tasks is completed (doesn't matter if flagged or not)
    /// </summary>
    /// <param name="groupId"></param>
    protected void refreshGroupTasks()
    {
        List<task> taskListIncompleted = new List<task>();
        List<task> taskListCompleted = groupFacade.GetGroupTasks(groupId, true);    // get completed tasks
        List<task> taskListFlagged = new List<task>();

        // Get all incompleted UNFLAGGED tasks from group
        foreach (task t in groupFacade.GetGroupTasks(groupId, false))
        {
            // Get all unimportant/null ones
            if (!t.Is_important ?? true)
            {
                taskListIncompleted.Add(t);
            }
        }

        // Get all flagged tasks that are not completed
        foreach (task t in groupFacade.GetGroupTasks(groupId, false))
        {
            // ( "??" : If t.Is_Important is null, then assume it is not important)
            if (t.Is_important ?? false)
            {
                taskListFlagged.Add(t);
            }
        }

        // bind to templates
        listViewIncompleted.DataSource = taskListIncompleted;
        listViewIncompleted.DataBind();

        listViewCompleted.DataSource = taskListCompleted;
        listViewCompleted.DataBind();

        listViewFlagged.DataSource = taskListFlagged;
        listViewFlagged.DataBind();

        // bind count labels
        lblIncompletedTasksCount.Text = taskListIncompleted.Count.ToString();
        lblCompletedTasksCount.Text = taskListCompleted.Count.ToString();
        lblFlaggedTasksCount.Text = taskListFlagged.Count.ToString();
    }

    /// <summary>
    /// Add a task
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddTask_Click(object sender, EventArgs e)
    {
        person currentUser = (person)Session["user"];
        int currentUserID = currentUser.Id;

        // Create task
        task theTask = new task();

        // Task properties
        theTask.Description = taskDescription.Text;
        theTask.Group_ID = groupId ?? default(int);
        theTask.Is_completed = false;
        theTask.Is_important = taskFlagged.Checked;

        // See if we add a due date to the task
        // TODO: Validate if right format
        if (taskDueDate.Text.Length > 0)
        {
            string dateStr = taskDueDate.Text;

            DateTime dueDate = new DateTime();

            // See if we also add the time on the due date
            // TODO: Validate if right format
            if (taskDueTime.Text.Length > 0)
            {
                string timeStr = taskDueTime.Text;

                dueDate = DateTime.ParseExact(dateStr + " " + timeStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            else
            {
                dueDate = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            theTask.Task_DateTime = dueDate;
        }

        groupFacade.CreateNewTask(theTask, groupId, currentUserID);

        refreshGroupTasks();    // dirty

        clearFields();          // also dirty...js?
    }

    /// <summary>
    /// Delete a task
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteTask_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hiddenIdField = (HiddenField)btn.Parent.FindControl("TaskIdHolder");

        groupFacade.DeleteTask(int.Parse(hiddenIdField.Value));

        refreshGroupTasks();
    }

    /// <summary>
    /// Toggle task completion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void checkBoxCompleted_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        HiddenField lblIdField = (HiddenField)checkbox.Parent.FindControl("TaskIdHolder");

        int taskId = int.Parse(lblIdField.Value);

        groupFacade.UpdateTaskCompleted(taskId, checkbox.Checked);

        refreshGroupTasks();
    }

    # endregion TASKS

    # region EVENTS

    /// <summary>
    /// Affichage des événements
    /// </summary>
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Style eventDayStyle = new Style();
        eventDayStyle.BackColor = System.Drawing.Color.LightSlateGray;
        eventDayStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

        Style lateEventDayStyle = new Style();
        lateEventDayStyle.BackColor = System.Drawing.Color.Red;
        lateEventDayStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

        // Loops sur les évènement à chaque jour pour voir s'il-y-a quelquechose
        foreach (@event ev in eventsList)
        {
            // Évènement de plus d'une journée
            if (ev.Event_End != null)
            {
                if (e.Day.Date >= ev.Event_Start.Date && e.Day.Date <= ev.Event_End.Value.Date)
                {
                    string actualID = e.Cell.Attributes["data-id"];
                    e.Cell.Attributes.Add("data-id", actualID + ev.ID.ToString() + ",");

                    // Si la date précède la date d'aujourd'hui, la cellule est en rouge. Sinon regular style
                    e.Cell.ApplyStyle((e.Day.Date < DateTime.Now) ? lateEventDayStyle : eventDayStyle);
                }
            }
            // Évènement d'une journée
            else
            {
                if (e.Day.Date == ev.Event_Start.Date)
                {
                    string actualID = e.Cell.Attributes["data-id"];
                    e.Cell.Attributes.Add("data-id", actualID + ev.ID.ToString() + ",");

                    // Si la date précède la date d'aujourd'hui, la cellule est en rouge. Sinon regular style
                    e.Cell.ApplyStyle((e.Day.Date < DateTime.Now) ? lateEventDayStyle : eventDayStyle);
                }
            }
        }

        e.Cell.Attributes.Add("onmouseover", "this.className='Highlight';");
        e.Cell.Attributes.Add("onmouseout", "this.className='day';");
    }

    /// <summary>
    /// Affichage des évènements dans le tableau
    /// </summary>
    /// <param name="eventsList"></param>
    private void createEventTable(DateTime selectedDate)
    {
        eventsList = groupFacade.GetGroupEvent(groupId, selectedDate);

        listViewEvents.DataSource = eventsList;
        listViewEvents.DataBind();
    }

    /// <summary>
    /// Création de l'évènement
    /// </summary>
    protected void btnCreateEvent_Click(object sender, EventArgs e)
    {
        string eventDesc = txtEventDescription.Text;
        string sStart = txtEventStart.Text;
        string sEnd = txtEventEnd.Text;
        string format = "dd/MM/yyyy";

        @event newEvent = new @event();

        newEvent.Event_Start = string.IsNullOrWhiteSpace(sStart) ? new DateTime() : DateTime.ParseExact(sStart, format, CultureInfo.InvariantCulture);
        newEvent.Event_End = string.IsNullOrWhiteSpace(sEnd) ? new DateTime() : DateTime.ParseExact(sEnd, format, CultureInfo.InvariantCulture); ;
        newEvent.Description = eventDesc;
        newEvent.Group_ID = (int)groupId;

        groupFacade.CreateNewEvent(newEvent);
        createEventTable(Calendar1.VisibleDate);

        txtEventDescription.Text = "";
        txtEventStart.Text = "";
        txtEventEnd.Text = "";
    }

    /// <summary>
    /// Marque en évènement comme complété
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteEvent_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hiddenIdField = (HiddenField)btn.Parent.FindControl("eventIDHolder");
        int eventID = int.Parse(hiddenIdField.Value);

        groupFacade.ChangeEventStatus(eventID, true);

        createEventTable(Calendar1.VisibleDate);
    }

    /// <summary>
    /// Réaffichage du table d'évènements selon le mois visible sur le calendrier
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        createEventTable(e.NewDate);
    }

    /// <summary>
    /// Affichage du formulaire de création d'un Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNewEvent_Click(object sender, EventArgs e)
    {
        bool visible = newEvent.Visible;
        newEvent.Visible = (visible) ? false : true;
    }

    #endregion EVENTS

    #region FILES

    /// <summary>
    /// Affichage des fichiers disponible pour le groupe
    /// </summary>
    /// <param name="groupID">Le id du groupe actuel</param>
    protected void AfficherGroupFiles(int groupID)
    {
        try
        {
            List<file> listeFichiersGroupe = homeFacade.fileControl.GetAllGroupFiles(groupID);

            foreach (file fichier in listeFichiersGroupe)
            {
                if (!(fichier == null))
                {
                    if (!Page.IsPostBack)
                    {
                        test.DataSource = listeFichiersGroupe;
                        test.DataBind();
                    }
                }
            }
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
            return;
        }
    }

    private void fileUploader(int optionnalID = -1, ActionType optionnalActionType = ActionType.NONE)
    {
        System.Diagnostics.Debug.WriteLine("FileUploadTest fileUploader method called.");
        System.Diagnostics.Debug.WriteLine("Parameter optionnalID: " + optionnalID);
        System.Diagnostics.Debug.WriteLine("Parameter optionnalActionType: " + optionnalActionType);
        if (FileUpload1.HasFile)
        {
            try
            {
                Byte[] fileBytes = FileUpload1.FileBytes;
                System.Diagnostics.Debug.WriteLine("File Byte Array: " + fileBytes.ToString());
                string[] parts = FileUpload1.FileName.Split('.');
                string extension = "." + parts[parts.Length - 1];
                System.Diagnostics.Debug.WriteLine("File extension: " + extension);
                string filename = null;
                for (int i = 0; i < (parts.Length); i++)
                {
                    if (i == 0)
                    {
                        filename += parts[i];
                    }
                    else
                    {
                        filename += "." + parts[i];
                    }
                }
                System.Diagnostics.Debug.WriteLine("File Name: " + filename);

                homeFacade.fileControl.AddAssociatedFileToGroup(fileBytes, optionnalID, filename);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
                return;
            }
        }
    }

    protected void DownloadButtonClick(object sender, EventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        homeFacade.fileControl.DownloadAFile(imageButton.CommandArgument);
    }

    protected void SaveGroupFile(object sender, EventArgs e)
    {
        // something to get the group ID (request parameter, ex &groupID=######## ?)

        fileUploader((int)groupId, ActionType.SAVE_GROUP_FILE);
        AfficherGroupFiles((int)groupId);
    }

    #endregion FILES

    /// <summary>
    /// Recherche d'une personne afin de l'ajouter au groupe
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string name = personNameSearch.Text;

        if (!string.IsNullOrWhiteSpace(name))
        {
            List<person> thosePerson = homeFacade.GetAllPersons(name);
            listView1.DataSource = thosePerson;
            listView1.DataBind();
        }
        else
        {
            // afficher message ?
        }
    }

    /// <summary>
    /// Création du following the la person vers le groupe
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddPerson_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hiddenIdField = (HiddenField)btn.Parent.FindControl("personIdHolder");
        int personToAddId = (hiddenIdField != null) ? int.Parse(hiddenIdField.Value) : 0;

        if ((person)Session["user"] != null)
        {
            groupFacade.AddPersonToGroup(((person)Session["user"]).Id, personToAddId, groupId);
        }
    }
}