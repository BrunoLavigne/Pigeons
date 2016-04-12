using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.GroupFacade"/>
    /// </summary>
    public interface IGroupFacade : IFacade
    {
        #region Group

        group CreateNewGroupAndRegister(group newGroup, object personID);

        bool CloseGroup(object adminID, object groupID);

        #endregion Group

        #region Person

        void AddPersonToGroup(object adminID, object personToAddID, object groupID);

        #endregion Person

        #region Following

        List<person> GetGroupFollowers(object groupID);

        bool RemoveTheFollower(object groupID, object followerID);

        bool PersonIsGroupAdmin(object activePersonID, object activeGroupID);

        #endregion Following

        #region Message

        bool CreateNewMessage(message messageToCreate);

        List<message> GetGroupMessages(object groupID);

        #endregion Message

        #region Task

        task CreateNewTask(task newTask, object groupID, object personID);

        List<task> GetGroupTasks(object groupID, bool completed);

        void UpdateTaskCompleted(object taskID, bool completed);

        void DeleteTask(object taskID);

        #endregion Task

        #region Assignation

        assignation AssignTaskToPerson(assignation newAssignation);

        #endregion Assignation

        #region Event

        @event CreateNewEvent(@event newEvent);

        List<@event> GetGroupEvent(object groupID, object monthID = null);

        #endregion Event
    }
}