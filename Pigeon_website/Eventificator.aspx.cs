using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Eventificator : System.Web.UI.Page
{
    private List<@event> eventsList { get; set; }
    private GroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            groupFacade = new GroupFacade();
            eventsList = groupFacade.GetGroupEvent(16);

            Session["events"] = eventsList;
            Session["facade"] = groupFacade;
        }
        else
        {
            eventsList = (List<@event>)Session["events"];
            groupFacade = (GroupFacade)Session["facade"];
        }
        createEventTable(eventsList);
    }

    /// <summary>
    /// Affichage des événements
    /// </summary>
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Style eventDates = new Style();
        eventDates.BackColor = System.Drawing.Color.DarkOrange;
        eventDates.ForeColor = Color.White;

        Style lateDates = new Style();
        lateDates.BackColor = Color.Red;
        lateDates.ForeColor = Color.White;

        Style rangeDates = new Style();
        rangeDates.BackColor = Color.LightBlue;
        rangeDates.ForeColor = Color.White;

        // Affichage des events
        foreach (@event ev in eventsList)
        {
            // Events Start
            if (e.Day.Date == ev.Event_Start.Date)
            {
                if (ev.Event_Start.Date < DateTime.Now.Date)
                {
                    e.Cell.ApplyStyle(lateDates);
                }
                else
                {
                    e.Cell.ApplyStyle(eventDates);
                }
                e.Cell.ToolTip = e.Cell.ToolTip + "\n" + "Debut : " + ev.Description;
                e.Cell.Attributes.Add("data-id", ev.ID.ToString());
            }
            // Event dates between start and end
            if (e.Day.Date > ev.Event_Start && e.Day.Date <= ev.Event_End)
            {
                // Event end
                if (e.Day.Date == ev.Event_End.Value.Date)
                {
                    e.Cell.ToolTip = e.Cell.ToolTip + "\n" + "Fin : " + ev.Description;
                }
                else
                {
                    e.Cell.ToolTip = e.Cell.ToolTip + "\n" + ev.Description;
                }
                e.Cell.ApplyStyle(rangeDates);
                e.Cell.Attributes.Add("data-id", ev.ID.ToString());
            }
        }

        e.Cell.Attributes.Add("onmouseover", "this.className='Highlight';");
        e.Cell.Attributes.Add("onmouseout", "this.className='day';");
    }

    /// <summary>
    /// Affichage des évènements dans le tableau
    /// </summary>
    /// <param name="eventsList"></param>
    private void createEventTable(List<@event> eventsList)
    {
        Table1.Rows.Clear();

        TableHeaderRow tableHeader = new TableHeaderRow();
        tableHeader.Font.Size = 10;
        tableHeader.Height = 20;
        tableHeader.BackColor = System.Drawing.Color.Black;
        tableHeader.HorizontalAlign = HorizontalAlign.Center;
        tableHeader.ForeColor = System.Drawing.Color.White;

        TableCell[] headerCells = { new TableCell(), new TableCell(), new TableCell() };
        Label[] headerLabels = { new Label(), new Label(), new Label() };

        foreach (Label lb in headerLabels)
        {
            lb.Style["text-align"] = "center";
            lb.Enabled = false;
            lb.Style["padding"] = "10px";
        }

        headerLabels[0].ID = "eventDescription";
        headerLabels[0].Text = "Description";
        headerLabels[1].ID = "eventStart";
        headerLabels[1].Text = "Debut";
        headerLabels[2].ID = "eventEnd";
        headerLabels[2].Text = "Fin";

        for (int i = 0; i < headerCells.Count(); i++)
        {
            headerCells[i].Controls.Add(headerLabels[i]);
            tableHeader.Cells.Add(headerCells[i]);
        }

        Table1.Rows.Add(tableHeader);

        foreach (@event ev in eventsList)
        {
            TableRow tr = new TableRow();
            tr.Font.Size = 8;
            tr.Height = 20;
            tr.ToolTip = ev.Description;
            tr.Attributes.Add("data-id", ev.ID.ToString());
            tr.CssClass = "eventRow";

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

            for (int i = 0; i < cells.Count(); i++)
            {
                cells[i].Controls.Add(labels[i]);
                tr.Cells.Add(cells[i]);
            }

            Table1.Rows.Add(tr);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool visible = Calendar2.Visible;
        Calendar2.Visible = (visible) ? false : true;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtEventStart.Text = Calendar2.SelectedDate.Date.ToString("d MMMM yyyy");
        Calendar2.Visible = false;
    }

    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        txtEventEnd.Text = Calendar3.SelectedDate.Date.ToString("d MMMM yyyy");
        Calendar3.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        bool visible = Calendar3.Visible;
        Calendar3.Visible = (visible) ? false : true;
    }

    /// <summary>
    /// Création de l'évènement
    /// </summary>
    protected void btnCreateEvent_Click(object sender, EventArgs e)
    {
        string eventDesc = txtEventDescription.Text;
        string sStart = txtEventStart.Text;
        string sEnd = txtEventEnd.Text;

        DateTime eventStart = DateTime.Parse(sStart);
        DateTime eventEnd = DateTime.Parse(sEnd);

        @event newEvent = new @event();
        newEvent.Description = eventDesc;
        newEvent.Event_Start = eventStart;
        newEvent.Event_End = eventEnd;
        newEvent.Group_ID = 16; // DIRTY HARDCODAGE

        groupFacade.CreateNewEvent(newEvent);
    }

    protected void btnNewEvent_Click(object sender, EventArgs e)
    {
        bool visible = newEvent.Visible;
        newEvent.Visible = (visible) ? false : true;
    }
}