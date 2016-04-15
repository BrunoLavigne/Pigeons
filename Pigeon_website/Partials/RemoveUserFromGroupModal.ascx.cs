using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_RemoveUserFromGroupModal : System.Web.UI.UserControl
{

    protected static GroupFacade groupFacade { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(groupFacade == null)
            {
                groupFacade = new GroupFacade();
            }

            int currentGroupId = int.Parse(Request.Params["groupID"]);   // dirty still

            List<person> groupUsers = groupFacade.GetGroupFollowers(currentGroupId);

            panelFollowersInfo.Visible = false;
            followingListView.DataSource = groupUsers;
            followingListView.DataBind();
        }

    }

    protected void btnRemoveFollowing_Command(Object sender, CommandEventArgs e)
    {

        if(e.CommandName.Equals("RemoveFollowing"))
        {
            int userId = int.Parse(e.CommandArgument.ToString());

            int groupId = int.Parse(Request.Params["groupID"]);   // dirty still

            groupFacade.RemoveTheFollower(groupId, userId);
            testLabel.Text = "Removed following....... > GroupID : " + groupId + " userID : + " + userId;

        } else
        {
            // Error - unrecognized command
        }

    }

}