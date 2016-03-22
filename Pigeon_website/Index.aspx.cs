using PigeonsLibrairy.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
    }
    protected void connectButton_Click(object sender, EventArgs e)
    {
        string userEmail = this.userEmail.Text;
        string userPassword = this.userPassword.Text;

        Controller controller = new Controller();

        // TODO: use service method
        List<PigeonsLibrairy.Model.person> lp = controller.PersonService.GetPersonsBy("email", userEmail).ToList();

        // And check password...
        if(lp.Count != 0 && lp[0] != null)
        {

            Session["user"] = lp[0];
            Response.Redirect("Groups.aspx");
        }

    }
}