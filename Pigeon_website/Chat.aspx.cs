using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat : System.Web.UI.Page
{
    private IGroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            groupFacade = new GroupFacade();

            // Set username
            person activeUser = (person)Session["user"];

            lblWelcomeUsername.Text = activeUser.Name;
            hdPersondId.Value = activeUser.Id.ToString();
            hdPersondUserName.Value = activeUser.Name;

            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if (goodGroupId)
            {
                hdGroupId.Value = groupId.ToString();
            }
        }
    }
}