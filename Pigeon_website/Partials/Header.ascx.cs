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
        GlobalHelpers helper = new GlobalHelpers();
        if (helper.getCurrentUser() != null)
        {
            // show menu accordingly
            header_panel_connected.Visible = true;
            header_panel_disconnected.Visible = false;
        }
        else
        {
            header_panel_disconnected.Visible = true;
            header_panel_connected.Visible = false;
        }
    }

    protected void btn_deconnexion_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }

}
