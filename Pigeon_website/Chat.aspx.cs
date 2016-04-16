using Newtonsoft.Json;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
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
    public static string GetFollowings()
    {
        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }
        following = homeFacade.GetPersonGroups(theUser.Id);
        groupsId = new List<int>();

        foreach (group followingId in following)
        {
            groupsId.Add(followingId.Id);
        }
        // TheSerializer.Serialize(personId);
        return TheSerializer.Serialize(groupsId);
    }

    //[WebMethod]
    //public static string GetGroupMessages()
    //{
    //    JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

    //    if (groupFacade == null)
    //    {
    //        groupFacade = new GroupFacade();
    //    }
    //    if (homeFacade == null)
    //    {
    //        homeFacade = new HomeFacade();
    //    }
    //    following = homeFacade.GetPersonGroups(theUser.Id);
    //    groupsId = new List<int>();
    //    List<MessageDetail> listMessageDetail = new List<MessageDetail>();

    //    foreach (group followingId in following)
    //    {
    //        List<string> listMessage = new List<string>();
    //        groupMessages = groupFacade.GetGroupChatHistory(followingId.Id);

    //        foreach (chathistory msg in groupMessages)
    //        {
    //            listMessage.Add(msg.Message);
    //        }
    //        MessageDetail messageDetail = new MessageDetail
    //        {
    //            groupId = followingId.Id,
    //            Message = listMessage.ToArray()
    //        };
    //        listMessageDetail.Add(messageDetail);
    //    }
    //    // TheSerializer.Serialize(personId);
    //    return TheSerializer.Serialize(listMessageDetail);
    //}
    [WebMethod]
    public static string GetGroupMessages()
    {
        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

        if (groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }
        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }
        following = homeFacade.GetPersonGroups(theUser.Id);
        groupsId = new List<int>();
        List<MessageDetail> listMessageDetail = new List<MessageDetail>();

        foreach (group followingId in following)
        {
            List<Message> listMessage = new List<Message>();
            groupMessages = groupFacade.GetGroupChatHistory(followingId.Id);

            foreach (chathistory msg in groupMessages)
            {
                listMessage.Add(new Message
                {
                    authorName = msg.person.Name,
                    message = msg.Message
                });
            }
            MessageDetail messageDetail = new MessageDetail
            {
                groupId = followingId.Id,
                Message = listMessage
            };
            listMessageDetail.Add(messageDetail);
        }
        // TheSerializer.Serialize(personId);
        return TheSerializer.Serialize(listMessageDetail);
    }
}