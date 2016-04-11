using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Taskinator : System.Web.UI.Page
{

    public GroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {


        /*
         * This page is for testing tasks given to a certain group 
         */
        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        if(!Page.IsPostBack)
        {

            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if (goodGroupId)
            {
                refreshGroupTasks(groupId);
            }
        }
    }

    protected void checkBoxCompleted_CheckedChanged(object sender, EventArgs e)
    {
        // Connect with groupfacade, update task
        CheckBox checkbox = (CheckBox)sender;
        HiddenField lblIdField = (HiddenField) checkbox.Parent.FindControl("TaskIdHolder");
        int lblId = int.Parse(lblIdField.Value);
        if (checkbox.Checked)
        {
            testLabel.Text = "Checkbox is indeed checked!" + lblId;
        } else
        {
            testLabel.Text = "Checkbox is not checked" + lblId;
        }
    }

    protected void btnAddTask_Click(object sender, EventArgs e)
    {

        int groupID = int.Parse(Request.Params["groupID"]);

        person currentUser = (person) Session["user"];
        int currentUserID = currentUser.Id;

        // Création du task
        task theTask = new task();

        theTask.Description = taskDescription.Text;
        theTask.Group_ID = groupID;
        theTask.Is_completed = false;

        // See if we add a due date to the task
        if (taskDueDate.Text.Length > 0)
        {
            DateTime dueDate = new DateTime();
            dueDate = DateTime.ParseExact(taskDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            theTask.Task_End = dueDate;
        }

        groupFacade.CreateNewTask(theTask, groupID, currentUserID);

        refreshGroupTasks(groupID); // dirty
    }

    protected void refreshGroupTasks(int groupId)
    {
        List<task> taskList = groupFacade.GetGroupTasks(groupId);
        listViewTasks.DataSource = taskList;
        listViewTasks.DataBind();
    }
}
