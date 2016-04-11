using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {

            // Set username
            person activeUser = (person)Session["user"];
            string username = activeUser.Name;
            lblWelcomeUsername.Text = activeUser.Name;

            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if (goodGroupId)
            {
                // connect to group chat...
            }
        }
    }
}