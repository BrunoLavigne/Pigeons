﻿using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalHelpers
/// </summary>
public class GlobalHelpers
{
    public GlobalHelpers()
    {

    }

    /**
    *
    * Get the current user in the Session
    *
    * @return person the user
    * @return null if no user is connected
    */
    public person getCurrentUser()
    {

        // Make sure we have a  person in session
        if (HttpContext.Current != null && 
            HttpContext.Current.Session != null &&
            HttpContext.Current.Session["user"] != null && 
            HttpContext.Current.Session["user"] is person)
        {
            return (person)HttpContext.Current.Session["user"];
        }

        return null;
    }
}
