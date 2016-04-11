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

        // Création du task
        task theTask = new task();

        theTask.Description = taskDescription.Text;
        theTask.Group_ID = groupId ?? default(int);
        theTask.Is_completed = false;

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
            
            theTask.Task_End = dueDate;

        }

        groupFacade.CreateNewTask(theTask, groupId, currentUserID);

        refreshGroupTasks(); // dirty

    }

    /// <summary>
    /// Distribute tasks on the page
    /// </summary>
    /// <param name="groupId"></param>
    protected void refreshGroupTasks()
    {

        List<task> taskListIncompleted = groupFacade.GetGroupTasks(groupId, false); // get incomplete tasks
        List<task> taskListCompleted = groupFacade.GetGroupTasks(groupId, true);    // get completed tasks

        // bind to templates
        listViewIncompleted.DataSource = taskListIncompleted;
        listViewIncompleted.DataBind();

        listViewCompleted.DataSource = taskListCompleted;
        listViewCompleted.DataBind();

    }
}
