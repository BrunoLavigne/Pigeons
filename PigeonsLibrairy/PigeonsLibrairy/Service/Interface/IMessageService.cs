﻿using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IMessageService : IService<message>
    {
        bool CreateNewMessage(message messageToCreate);
        IEnumerable<message> GetGroupMessages(object groupID);
    }
}
