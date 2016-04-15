using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Taskinator : System.Web.UI.Page
{

    public GroupFacade groupFacade { get; set; }

    public int? groupId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        if(groupId == null)
        {
            groupId = int.Parse(Request.Params["GroupID"]); // still dirty
        }

        if(!Page.IsPostBack)
        {
            refreshGroupTasks();
        }
    }

    /// <summary>
    /// Update a task
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void checkBoxCompleted_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox checkbox = (CheckBox)sender;
        HiddenField lblIdField = (HiddenField) checkbox.Parent.FindControl("TaskIdHolder");

        int taskId = int.Parse(lblIdField.Value);

        groupFacade.UpdateTaskCompleted(taskId, checkbox.Checked);

        refreshGroupTasks();
    }

    /// <summary>
    /// Add a task
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddTask_Click(object sender, EventArgs e)
    {

        person currentUser = (person) Session["user"];
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
            if(taskDueTime.Text.Length > 0)
            {
                string timeStr = taskDueTime.Text;

                dueDate = DateTime.ParseExact(dateStr + " " + timeStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            } else {

                dueDate = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            
            theTask.Task_DateTime = dueDate;

        }

        groupFacade.CreateNewTask(theTask, groupId, currentUserID);

        refreshGroupTasks();    // dirty

        clearFields();          // also dirty...js?

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
            if( ! t.Is_important ?? true )
            {
                taskListIncompleted.Add(t);
            }
        }

        // Get all flagged tasks that are not completed
        foreach (task t in groupFacade.GetGroupTasks(groupId, false))
        {

            // ( "??" : If t.Is_Important is null, then assume it is not important)
            if ( t.Is_important ?? false )
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

    protected void clearFields()
    {
        taskDescription.Text = "";
        taskDueDate.Text = "";
        taskDueTime.Text = "";
        taskFlagged.Checked = false;
    }


    protected void btnDeleteTask_Click(object sender, EventArgs e)
    {
        Button btn = (Button) sender;
        HiddenField hiddenIdField = (HiddenField) btn.Parent.FindControl("TaskIdHolder");

        groupFacade.DeleteTask(int.Parse(hiddenIdField.Value));

        refreshGroupTasks();

    }
}
