using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la class <see cref="Implementation.FollowingDAO"/>
    /// </summary>
    interface IFollowingDAO : IDAO<following>
    {
        /// <summary>
        /// <see cref="Implementation.FollowingDAO.GetTheFollowersCount(pigeonsEntities1, object)"/>
        /// </summary>
        IList<following> GetTheFollowersCount(pigeonsEntities1 context, object groupID);

        /// <summary>
        /// <see cref="Implementation.FollowingDAO.GetByID(pigeonsEntities1, object, object)"/>
        /// </summary>
        following GetByID(pigeonsEntities1 context, object personID, object groupID);

        /// <summary>
        /// <see cref="Implementation.FollowingDAO.GetTheFollowersCount(pigeonsEntities1, object)"/>
        /// </summary>
        IEnumerable<following> GetTheFollowers(pigeonsEntities1 context, object groupID);

        /// <summary>
        /// <see cref="Implementation.FollowingDAO.GetPersonFollowingGroups(pigeonsEntities1, object)"/>
        /// </summary>
        IEnumerable<following> GetPersonFollowingGroups(pigeonsEntities1 context, object personID);
    }
}
