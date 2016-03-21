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
        List<PigeonsLibrairy.Model.person> lp = controller.PersonService.GetPersonsBy("email", userEmail).ToList();
        if (lp[0] != null)
        {

            // todo: vérif. passowrd
            Response.Redirect("http://google.com");
        }
    }
}