using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO
{
    public class PersonDAO_toremove
    {
        private pigeonsEntities1 pigeonsEntity { get; set; }

        public PersonDAO_toremove()
        {
            pigeonsEntity = new pigeonsEntities1();

            person thePerson = new person();
            thePerson.Name = "Bob";
            thePerson.Email = "bob@gmail.com";
            thePerson.Profile_picture_link = "http://bob.com";
            thePerson.Birth_date = DateTime.Now;
            thePerson.Phone_number = "5145224949";
            thePerson.Organization = "A simple test";
            thePerson.Position = "The master tester";
            thePerson.Description = "Burp";
            thePerson.Password = "1234";

            pigeonsEntity.people.Add(thePerson);
            pigeonsEntity.SaveChanges();
        }
    }
}
