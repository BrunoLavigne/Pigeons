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
    private DateTime dateValidation = DateTime.Parse("0001-01-01 12:00:00 AM");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            groupFacade = new GroupFacade();
            eventsList = groupFacade.GetGroupEvent(16);

            Session["events"] = eventsList;
            Session["facade"] = groupFacade;

            // Events table avec les Events du mois
            createEventTable(DateTime.Now);
        }
        else
        {
            eventsList = (List<@event>)Session["events"];
            groupFacade = (GroupFacade)Session["facade"];

            // Events table selon le mois visible en ce moment sur la page (au first load la visible date est égale à la date de validation et nous ne voulons pas afficher pour celle-ci)
            createEventTable((Calendar1.VisibleDate == dateValidation) ? DateTime.Now : Calendar1.VisibleDate);
        }
    }

    /// <summary>
    /// Affichage des événements
    /// </summary>
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        Style eventDayStyle = new Style();
        eventDayStyle.BackColor = System.Drawing.Color.LightSlateGray;
        eventDayStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

        Style lateEventDayStyle = new Style();
        lateEventDayStyle.BackColor = System.Drawing.Color.Red;
        lateEventDayStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

        // Loops sur les évènement à chaque jour pour voir s'il-y-a quelquechose
        foreach (@event ev in eventsList)
        {
            // Évènement de plus d'une journée
            if (ev.Event_End != null)
            {
                if (e.Day.Date >= ev.Event_Start.Date && e.Day.Date <= ev.Event_End.Value.Date)
                {
                    string actualID = e.Cell.Attributes["data-id"];
                    e.Cell.Attributes.Add("data-id", actualID + ev.ID.ToString() + ",");

                    // Si la date précède la date d'aujourd'hui, la cellule est en rouge. Sinon regular style
                    e.Cell.ApplyStyle((e.Day.Date < DateTime.Now) ? lateEventDayStyle : eventDayStyle);
                }
            }
            // Évènement d'une journée
            else
            {
                if (e.Day.Date == ev.Event_Start.Date)
                {
                    string actualID = e.Cell.Attributes["data-id"];
                    e.Cell.Attributes.Add("data-id", actualID + ev.ID.ToString() + ",");

                    // Si la date précède la date d'aujourd'hui, la cellule est en rouge. Sinon regular style
                    e.Cell.ApplyStyle((e.Day.Date < DateTime.Now) ? lateEventDayStyle : eventDayStyle);
                }
            }
        }

        e.Cell.Attributes.Add("onmouseover", "this.className='Highlight';");
        e.Cell.Attributes.Add("onmouseout", "this.className='day';");
    }

    /// <summary>
    /// Affichage des évènements dans le tableau
    /// </summary>
    /// <param name="eventsList"></param>
    private void createEventTable(DateTime selectedDate)
    {
        eventsList = groupFacade.GetGroupEvent(16, selectedDate); // DIRTY HARCODAGE { must use active group }
        listViewEvents.DataSource = eventsList;
        listViewEvents.DataBind();
    }

    protected void btnDeleteEvent_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hiddenIdField = (HiddenField)btn.Parent.FindControl("eventIDHolder");

        groupFacade.ChangeEventStatus(hiddenIdField, false);
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
        newEvent.Group_ID = 16; // DIRTY HARDCODAGE { PLACE ACTIVE GROUP ID }

        groupFacade.CreateNewEvent(newEvent);
        createEventTable(Calendar1.VisibleDate);

        txtEventDescription.Text = "";
        txtEventStart.Text = "";
        txtEventEnd.Text = "";
    }

    /// <summary>
    /// Réaffichage du table d'évènements selon le mois visible sur le calendrier
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        createEventTable(e.NewDate);
    }

    #region BUTTONS

    /// <summary>
    /// Affichage du formulaire de création d'un Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNewEvent_Click(object sender, EventArgs e)
    {
        bool visible = newEvent.Visible;
        newEvent.Visible = (visible) ? false : true;
    }

    /// <summary>
    /// Affichage Calendar2 pour choisir date départ de l'Event
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool visible = Calendar2.Visible;
        Calendar2.Visible = (visible) ? false : true;
    }

    /// <summary>
    /// Affichage Calendar3 pour choisir date de fin de l'Event
    /// </summary>
    protected void Button2_Click(object sender, EventArgs e)
    {
        bool visible = Calendar3.Visible;
        Calendar3.Visible = (visible) ? false : true;
    }

    /// <summary>
    /// Affichage de la sélection de la date de départ dans un TextBox
    /// </summary>
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtEventStart.Text = Calendar2.SelectedDate.Date.ToString("d MMMM yyyy");
        Calendar2.Visible = false;
    }

    /// <summary>
    /// Affichage de la sélection de la date de fin dans un TextBox
    /// </summary>
    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        txtEventEnd.Text = Calendar3.SelectedDate.Date.ToString("d MMMM yyyy");
        Calendar3.Visible = false;
    }

    #endregion BUTTONS
}