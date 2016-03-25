﻿using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;
using System.Linq;

public partial class Partials_ConnectModal : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_createUser_Click(object sender, EventArgs e)
    {
        string firstName = createUserFirstName.Text;
        string lastName = createUserLastName.Text;
        string email = createUserEmail.Text;
        string pass1 = createUserPass1.Text;
        string pass2 = createUserPass2.Text;


        // Faire de la form validation sur les champs précédents...
        Controller controller = new Controller();

        person user = new person();
        user.Name = firstName + " " + lastName;
        user.Email = email;
        user.Password = pass1; // lol

        // todo: cleanup - this should be set in profile (and set to not null in DB)
        user.Description = "this dude is the best i met him once";
        user.Birth_date = DateTime.Now;
        user.Organization = "Big Money Affiliates and Sketchy biz";
        user.Phone_number = "5144444444";
        user.Position = "this guy is on top nuff said";


        if(controller.PersonService.registerNewUser(user, email, pass1))
        {

            // Also connect the user in session
            Session["user"] = user;

            Response.Redirect("Groups.aspx");

        } else
        {
            Response.Redirect("Index.aspx");
        }
    }

    protected void btn_connectUser_Click(object sender, EventArgs e)
    {
        string userEmail = connectUserEmail.Text;
        string userPassword = connectUserPassword.Text;

        Controller controller = new Controller();
        if(!controller.PersonService.loginValidation(userEmail, userPassword))
        {
            // Login failed
            Response.Redirect("Index.aspx");
        } else
        {
            // Login success
            // Put user in session
            Session["user"] = controller.PersonService.GetBy("Email", userEmail).ToList().ElementAt(0);

            // Redirect
            Response.Redirect("Groups.aspx");
        }
    }
}