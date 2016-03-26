﻿using PigeonsLibrairy.Controller;
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
}