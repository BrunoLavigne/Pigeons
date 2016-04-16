using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class MessageDetail
    {

        public int groupId { get; set; }
        public List<Message> Message { get; set; }

    }
}