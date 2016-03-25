using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionsTester
{
    public partial class Form2 : Form
    {
        private Controller controller { get; set; }

        public Form2()
        {
            InitializeComponent();
            controller = new Controller();
        }

        /// <summary>
        /// Test - Creating a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInscription_Click(object sender, EventArgs e)
        {
            string name, email, emailConfirmation, password, passwordConfirmation, phonenumber, organisation, position, description;
            DateTime birthdate;

            name = person_name.Text;
            email = person_email.Text;
            emailConfirmation = person_emailConfirmation.Text;
            password = person_password.Text;
            passwordConfirmation = person_passwordConfirmation.Text;
            phonenumber = person_phone.Text;
            organisation = person_organization.Text;
            position = person_position.Text;
            description = person_description.Text;
            birthdate = person_birthdate.Value.Date;

            person aNewPerson = new person();
            aNewPerson.Name         = name;
            aNewPerson.Email        = email;
            aNewPerson.Password     = password;            
            aNewPerson.Phone_number = phonenumber;
            aNewPerson.Organization = organisation;
            aNewPerson.Position     = position;
            aNewPerson.Description  = description;
            aNewPerson.Birth_date   = birthdate;

            if(controller.PersonService.registerNewUser(aNewPerson, emailConfirmation, passwordConfirmation))
            {
                person_result.Text = "The user is created";
            }
            else
            {
                person_result.Text = "Error";
            }

        }

        /// <summary>
        /// Test - Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginUsername.Text;
            string password = loginPassword.Text;

            if(controller.PersonService.loginValidation(username, password))
            {
                loginResult.Text = "Login Accepted";                
            }
            else
            {
                loginResult.Text = "Login Refused";
            }
        }

        /// <summary>
        /// Test - Show current groups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActivePersonGroups_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Test - Create a new group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGroup_Click(object sender, EventArgs e)
        {

        }
    }
}
