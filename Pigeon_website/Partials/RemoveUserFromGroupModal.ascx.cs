using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partials_RemoveUserFromGroupModal : System.Web.UI.UserControl
{

    protected static GroupFacade groupFacade { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {

        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }
        
    }

}