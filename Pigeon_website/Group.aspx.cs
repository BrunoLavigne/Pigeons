using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class Group : System.Web.UI.Page
{

    protected GroupFacade groupFacade { get; set; }

    protected HomeFacade homeFacade { get; set; }

    public int? groupId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        if(homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }


        // Also check if the group actually exists and if the user is following it
        if(!IsValidated())
        {

            Response.Redirect("Index.aspx");

        } else {

            person currentUser = (person) Session["user"];


            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int maybeGroupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out maybeGroupId);

            if(goodGroupId)
            {

                groupId = maybeGroupId;     // definitely

                // For todos testing
                testTodosLink.NavigateUrl = "Taskinator.aspx?groupID=" + groupId;

                if(!Page.IsPostBack)
                {
                    renderGroupToPage();
                }
                

                if(!groupFacade.PersonIsGroupAdmin(currentUser.Id, groupId))
                {
                    panelAdminButtons.Visible = false;
                }
            }
        }
    }


    protected bool IsValidated()
    {
        
        // Also, if group exists, if user is in group, etc.
        bool isFine =   Session["user"] != null ||
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
            lblGroupTimeCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.ShortDatePattern, frCA);
            messagesListView.DataSource = groupFacade.GetGroupMessages(int.Parse(Request.Params["groupID"]));
            renderMessagesToPage();
            refreshGroupTasks();

        } catch(Exception e)
        {
            Console.WriteLine("Group not found: " + e.Message);
        }
        
    }

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
























    protected void clearFields()
    {
        taskDescription.Text = "";
        taskDueDate.Text = "";
        taskDueTime.Text = "";
        taskFlagged.Checked = false;
    }

    /// <summary>
    /// Distribute tasks on the page
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
            else {

                dueDate = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }

            theTask.Task_DateTime = dueDate;

        }

        groupFacade.CreateNewTask(theTask, groupId, currentUserID);

        refreshGroupTasks();    // dirty

        clearFields();          // also dirty...js?

    }




    protected void btnDeleteTask_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hiddenIdField = (HiddenField)btn.Parent.FindControl("TaskIdHolder");

        groupFacade.DeleteTask(int.Parse(hiddenIdField.Value));

        refreshGroupTasks();

    }

    /// <summary>
    /// Update a task
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
}