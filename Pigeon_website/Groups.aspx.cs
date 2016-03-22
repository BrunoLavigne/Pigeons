using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            GlobalHelpers gh = new GlobalHelpers();
            TestLabel.Text = gh.getCurrentUser().Description;
            
        }

    }
}