using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class GroupRoom
    {
        public string RoomName { get; set; }
        public virtual ICollection<UserDetail> Users { get; set; }
    }
}