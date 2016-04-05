using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;

public partial class Partials_NewGroupModal : System.Web.UI.UserControl
{

    // protected Controller controller { get; set; }

    protected GroupFacade groupFacade { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {


        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        // personFilterList.DataSource = controller.PersonService.GetBy("email", txtPersonSearch.Text);
        // personFilterList.DataBind();
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
        groupFacade.CreateNewGroupAndRegister(g, theCreator.Id);
    }
}