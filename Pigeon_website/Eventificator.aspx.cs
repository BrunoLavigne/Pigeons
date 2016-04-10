using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eventificator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Calendar1.SelectedDates.Add(new DateTime(2016, 4, 4));        
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        GroupFacade facade = new GroupFacade();
        List<@event> eventsList = facade.GetGroupEvent(16);

        Style eventDates = new Style();
        eventDates.BackColor = System.Drawing.Color.DarkOrange;
        eventDates.ForeColor = System.Drawing.Color.White;
        //eventDates.BorderStyle = BorderStyle.Solid;
        //eventDates.BorderColor = System.Drawing.Color.WhiteSmoke;
        //eventDates.BorderWidth = 1;

        //if ((e.Day.Date >= new DateTime(2016, 04, 06)) &&
        //    (e.Day.Date <= new DateTime(2016, 04, 10)))
        //{
        //    e.Cell.ApplyStyle(eventDates);
        //    e.Cell.ToolTip = "event day";
        //}

        foreach (@event ev in eventsList)
        {
            if(e.Day.Date == ev.Event_Start.Date)
            {
                e.Cell.ApplyStyle(eventDates);
                e.Cell.ToolTip = ev.Description;
            }
        }

        e.Cell.Attributes.Add("onmouseover", "this.className='Highlight';");
        e.Cell.Attributes.Add("onmouseout", "this.className='Normal';");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool visible = Calendar2.Visible;
        Calendar2.Visible = (visible) ? false : true;        
    }
}