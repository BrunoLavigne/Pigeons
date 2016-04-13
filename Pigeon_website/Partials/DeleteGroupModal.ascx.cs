using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_DeleteGroupModal : System.Web.UI.UserControl
{

    protected static GroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }
    }

    protected void confirmDeleteGroup_Click(object sender, EventArgs e)
    {
        int groupId = int.Parse(Request.Params["groupID"]);     // cleanup...make sure valid group ID
        person theAdmin = (person) Session["user"];      // on assume que si l'utilisateur voit ce modal, il est admin


        groupFacade.CloseGroup(theAdmin.Id, groupId);

        Response.Redirect("Groups.aspx");       // maybe with confirmation message
    }
}