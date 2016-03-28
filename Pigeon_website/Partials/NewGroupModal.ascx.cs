using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_NewGroupModal : System.Web.UI.UserControl
{

    protected Controller controller { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {


        if(controller == null)
        {
            controller = new Controller();
        }

        personFilterList.DataSource = controller.PersonService.GetBy("email", txtPersonSearch.Text);
        personFilterList.DataBind();
    }

    protected void btn_createGroup_Click(object sender, EventArgs e)
    {
        // Create the new group

        // Form validation before...
        string groupName = newGroupName.Text;
        string groupDescription = newGroupDescription.Value; //....
        string groupePicture = newGroupPictureLink.Text;        // TODO: create field in table

        group g = new group();
        g.Name = groupName;
        g.Description = groupDescription;
        g.Creation_date = DateTime.Now;                         // should be set automatically in backend   
        g.Is_active = true;                                     // also? should be active by default

        person theCreator = (person)Session["user"];

        // get all the peeps invited to group, send to "following" table

        controller.GroupService.CreateNewGroupAndRegister(g, theCreator.Id);
        controller.Save();      // ?
    }
}