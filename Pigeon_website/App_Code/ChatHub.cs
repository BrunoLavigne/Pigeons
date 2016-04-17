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
        List<chathistory> messagesHistory;

        #endregion Data Members

        public void JoinRoom(string roomName)
        {
            Groups.Add(Context.ConnectionId, roomName);
            ConnectedUsers.Add(new UserDetail { ConnectionId = Context.ConnectionId });

        }

        public void SendMessage(SendData data)
        {
            Clients.Group(data.roomName, Context.ConnectionId).newMessage(data.name, data.message, data.roomName);

            chathistory message = new chathistory();
            message.Author_ID = data.authorId;
            message.Group_ID = int.Parse(data.roomName);
            message.Message = data.message;

            groupFacade.InsertChatMessage(message);
        }

        public void LeaveRoom(string roomName)
        {
            Groups.Remove(Context.ConnectionId, roomName);
        }
    }

    public class SendData
    {
        public int authorId { get; set; }
        public string message { get; set; }
        public string roomName { get; set; }
        public string name { get; set; }
    }
}