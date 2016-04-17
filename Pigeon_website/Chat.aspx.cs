using Newtonsoft.Json;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using SignalRChat;
using SignalRChat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat : System.Web.UI.Page
{
    private static IGroupFacade groupFacade { get; set; }
    private static IHomeFacade homeFacade { get; set; }

    private static person theUser { get; set; }

    private static List<group> following;
    private static List<int> groupsId;

    private static List<chathistory> groupMessages;
    private static List<string> message;

    private static List<person> groupPerson;
    private static List<string> listPerson;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            groupFacade = new GroupFacade();

            // Set username
            theUser = (person)Session["user"];

            //lblWelcomeUsername.Text = theUser.Name;
            hdPersondId.Value = theUser.Id.ToString();
            hdPersondUserName.Value = theUser.Name;

            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if (goodGroupId)
            {
                hdGroupId.Value = groupId.ToString();
            }
        }
    }

    

    [WebMethod]
    public static string GetGroupMessages()
    {
        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
        //Si groupFacade est null on l'instancie
        if (groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        //Si homeFacade est null on l'instancie
        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }

        //On ajoute a la liste following tous les groups aux quels l'utilisateur participe
        following = homeFacade.GetPersonGroups(theUser.Id);

        //On instance une nouvelle liste qui contiendera les id des groups aux quels l'utilisateur participe
        groupsId = new List<int>();

        //On initialise une nouvelle liste, qui contiendera des objets de MessageDetail
        List<MessageDetail> listMessageDetail = new List<MessageDetail>();
        
        //Pour chaque group dans la liste following
        foreach (group followingId in following)
        {
            //On initialise une nouvelle liste qui contiendera les messages
            List<Message> listMessage = new List<Message>();

            //On ajoute dans la liste groupMessages tous les messages des groups dans lesquels l'utilisateur participe
            groupMessages = groupFacade.GetGroupChatHistory(followingId.Id);

            //Pour chaque message de la liste groupMessages
            foreach (chathistory msg in groupMessages)
            {
                //..On ajoute dans la liste listMessage les messages qui se trouve dans la liste prit a partir des messages de groupe
                listMessage.Add(new Message
                {
                    authorName = msg.person.Name,
                    message = msg.Message,
                    dateMessage = msg.CreationDate.ToString()
                });
            }
            MessageDetail messageDetail = new MessageDetail
            {
                groupId = followingId.Id,
                groupName = followingId.Name,
                Message = listMessage
            };
            listMessageDetail.Add(messageDetail);
        }
        // TheSerializer.Serialize(personId);
        return TheSerializer.Serialize(listMessageDetail);
    }

    [WebMethod]
    public static string GetGroupPeople()
    {
        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

        //Si groupFacade est null on l'instancie
        if (groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        //Si homeFacade est null on l'instancie
        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }
        List<GroupDetail> listeGroupDetail = new List<GroupDetail>();

        //On ajoute a la liste following tous les groups aux quels l'utilisateur participe
        following = homeFacade.GetPersonGroups(theUser.Id);
        
        foreach (group followingId in following)
        {
            groupPerson = groupFacade.GetGroupFollowers(followingId.Id);
            listPerson = new List<string>();
            //Pour chaque group dans la liste following
            foreach (person personId in groupPerson)
            {
                listPerson.Add(personId.Name);
            }
            GroupDetail groupDetail = new GroupDetail
            {
                groupId = followingId.Id,
                personName = listPerson
            };
            listeGroupDetail.Add(groupDetail);
        }
        return TheSerializer.Serialize(listeGroupDetail);
    }
}