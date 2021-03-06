﻿using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="task"/>
    /// </summary>
    internal class TaskDAO : DAO<task>, ITaskDAO
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public TaskDAO() : base() { }

        /// <summary>
        /// Recherche des Task d'un group
        /// </summary>
        /// <param name="groupID">Le ID du group pour lequel nous voulons les tasks</param>
        /// <param name="completed">True si nous cherchons les task complété, False pour les non complété</param>
        /// <returns></returns>
        public IEnumerable<task> GetGroupTasks(object groupID, bool completed)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    Expression<Func<task, bool>> filter = (t => t.Group_ID == (int)groupID && t.Is_completed == completed);
                    return Get(context, filter).OrderBy(t => t.Is_important).ThenBy(t => t.Task_DateTime);
                }
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException(ex.Message);
            }
        }

        /// <summary>
        /// Recherche d'un task en recherchant une valeur dans une colonne donnée
        /// </summary>
        /// <param name="context">La connection à la base de données</param>
        /// <param name="columnName">Le nom de la colonne</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste de task qui correspondes à la recherche, une liste vide sinon</returns>
        public new IEnumerable<task> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<task, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case task.COLUMN_GROUP_ID:
                        filter = (t => t.Group_ID == (int)value);
                        break;

                    case task.COLUMN_AUTHOR_ID:
                        filter = (t => t.Author_ID == (int)value);
                        break;

                    case task.COLUMN_DESCRIPTION:
                        filter = (t => t.Description.ToLower().Contains(((string)value).ToLower()));
                        break;

                    case task.COLUMN_TASK_DATETIME:
                        //filter = (t => t.Task_DateTime.Value.Date == ((DateTime)value).Date);
                        break;

                    case task.COLUMN_IS_COMPLETED:
                        filter = (t => t.Is_completed == (bool)value);
                        break;

                    case task.COLUMN_TASK_ISIMPORTANT:
                        filter = (t => t.Is_completed == (bool)value);
                        break;

                    default:
                        break;
                }
                return Get(context, filter);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException(ex.Message);
            }
        }
    }
}