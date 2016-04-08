using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_NewGroupMessageModal : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNewMessage_Click(object sender, EventArgs e)
    {
        GroupFacade gf = new GroupFacade();
        message msg = new message();
        person author = (person) Session["user"]; // cleanup

        // Message properties
        msg.Author_Id = author.Id;
        msg.Date_created = DateTime.Now;
        msg.Content = txtMessageContent.Text.Length > 0 ? txtMessageContent.Text : " ";               // user validation

        msg.Group_Id = int.Parse(Request.Params["groupID"]); // cleanup - on assume que si on s'est rendu là, le ID du groupe devrait être bon. Mais le user peut se
                                                             // rendre sur un groupe valide, changer le param dans l'url et ensuite poster le message.
        gf.CreateNewMessage(msg);

    }
}