using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using SignalRChat.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        #region Data Members

        public List<UserDetail> ConnectedUsers = new List<UserDetail>();
        private IGroupFacade groupFacade = new GroupFacade();
        private List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        #endregion Data Members

        public void Connect(string userName, int groupID)
        {
            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                List<chathistory> messagesHistory = groupFacade.GetGroupChatHistory(groupID);

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        public void SendMessage(SendData data)
        {
            Clients.Group(data.roomName, Context.ConnectionId).newMessage(data.name + ": " + data.message);

            chathistory message = new chathistory();
            message.Author_ID = int.Parse(data.name);
            message.Group_ID = int.Parse(data.roomName);
            message.Message = data.message;

            groupFacade.InsertChatMessage(message);
        }

        public void JoinRoom(string roomName)
        {
            Groups.Add(Context.ConnectionId, roomName);
            ConnectedUsers.Add(new UserDetail { ConnectionId = Context.ConnectionId });
        }

        public void LeaveRoom(string roomName)
        {
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }

    public class SendData
    {
        public string message { get; set; }
        public string roomName { get; set; }
        public string name { get; set; }
    }
}