using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;

public partial class Partials_GroupTodosModal : System.Web.UI.UserControl
{

    protected GroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(groupFacade == null) {
            groupFacade = new GroupFacade();
        }

        int groupId = int.Parse(Request.Params["groupID"]);

        List<task> taskList = new List<task>();
        taskList = groupFacade.GetGroupTasks(groupId, false);
        todosGridView.DataSource = taskList;
        todosGridView.DataBind();
    }
}