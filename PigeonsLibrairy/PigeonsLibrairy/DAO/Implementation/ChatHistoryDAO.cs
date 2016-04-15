using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="chathistory"/>
    /// </summary>
    internal class ChatHistoryDAO : DAO<chathistory>, IChatHistoryDAO
    {
        /// <summary>
        /// Recherche de tout les message d'un groupe contenu dans la base de données
        /// </summary>
        /// <param name="context">La connection à la base de données</param>
        /// <param name="groupID">Le ID du groupe pour lequel les chat messages sont voulues</param>
        /// <returns>Une liste avec les ChatMessage ou bien une liste vide.</returns>
        public IEnumerable<chathistory> GetAllMessagesByGroup(pigeonsEntities1 context, object groupID)
        {
            try
            {
                Expression<Func<chathistory, bool>> filter = (ch => ch.Group_ID == (int)groupID);
                return Get(context, filter).OrderBy(ch => ch.CreationDate);
            }
            catch (Exception ex)
            {
                throw new DAOException(ex.Message);
            }
        }
    }
}