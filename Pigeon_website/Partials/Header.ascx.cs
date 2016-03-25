using PigeonsLibrairy.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_deconnexion_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }

    protected void btn_connexion_Click(object sender, EventArgs e)
    {
        // connect user...
        string userEmail = "bob@gmail.com"; // this.userEmail.Text;
        string userPassword = "1234"; //  this.userPassword.Text;

        Controller controller = new Controller();

        // TODO: use service method
        List<PigeonsLibrairy.Model.person> lp = controller.PersonService.GetPersonsBy("email", userEmail).ToList();

        // And check password...
        if (lp.Count != 0 && lp[0] != null)
        {

            Session["user"] = lp[0];
            Response.Redirect("Groups.aspx");
        }
    }
}