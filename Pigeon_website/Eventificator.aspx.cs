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

    List<@event> eventsList { get; set; }
    GroupFacade facade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            facade = new GroupFacade();
            eventsList = facade.GetGroupEvent(16);

            Session["events"] = eventsList;
        }
        else
        {
            eventsList = (List<@event>)Session["events"];
        }
        createEventTable(eventsList);
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        
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
                e.Cell.ToolTip = e.Cell.ToolTip + "\n" + ev.Description;                                
            }
        }

        e.Cell.Attributes.Add("onmouseover", "this.className='Highlight';");
        e.Cell.Attributes.Add("onmouseout", "this.className='Normal';");
        
    }

    private void createEventTable(List<@event> eventsList)
    {
        Table1.Rows.Clear();

        TableHeaderRow tableHeader = new TableHeaderRow();
        tableHeader.Font.Size = 10;
        tableHeader.Height = 20;
        tableHeader.BackColor = System.Drawing.Color.Black;
        tableHeader.HorizontalAlign = HorizontalAlign.Center;
        tableHeader.ForeColor = System.Drawing.Color.White;

        TableCell[] hCells = { new TableCell(), new TableCell(), new TableCell() };
        Label[] hLabels = { new Label(), new Label(), new Label() };

        foreach (Label lb in hLabels)
        {
            lb.Style["text-align"] = "center";
            lb.Enabled = false;
            lb.Style["padding"] = "10px";
        }

        hLabels[0].ID = "eventDescription";
        hLabels[0].Text = "Description";
        hLabels[1].ID = "eventStart";
        hLabels[1].Text = "Debut";
        hLabels[2].ID = "eventEnd";
        hLabels[2].Text = "Fin";

        for (int i = 0; i < hCells.Count(); i++)
        {
            hCells[i].Controls.Add(hLabels[i]);
            tableHeader.Cells.Add(hCells[i]);
        }

        Table1.Rows.Add(tableHeader);

        foreach (@event ev in eventsList)
        {
            TableRow tr = new TableRow();
            tr.Font.Size = 8;
            tr.Height = 20;
            tr.Attributes.Add("onmouseover", amazingTest("bob"));

            TableCell[] cells = { new TableCell(), new TableCell(), new TableCell() };
            Label[] labels = { new Label(), new Label(), new Label() };

            foreach (Label lb in labels)
            {
                lb.Style["text-align"] = "center";
                lb.Enabled = false;
                lb.Style["padding"] = "5px";                
            }


            labels[0].Text = ev.Description;
            labels[1].Text = (ev.Event_Start != null) ? ev.Event_Start.Date.ToString("d MMM yyyy") : "";
            labels[2].Text = (ev.Event_End != null) ? ev.Event_End.Value.ToString("d MMM yyyy") : "";

            for(int i = 0; i < cells.Count(); i++)
            {
                cells[i].Controls.Add(labels[i]);
                tr.Cells.Add(cells[i]);
            }

            Table1.Rows.Add(tr);
        }


    }

    public string amazingTest(string e)
    {
        return e.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool visible = Calendar2.Visible;
        Calendar2.Visible = (visible) ? false : true;        
    }
}