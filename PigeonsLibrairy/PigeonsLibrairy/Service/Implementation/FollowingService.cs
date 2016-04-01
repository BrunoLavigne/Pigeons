using System;
using System.Collections.Generic;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using System.Linq;
using PigeonsLibrairy.DAO.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class FollowingService : Service<following>, IFollowingService
    {
        private IFollowingDAO followingDAO;
        private IGroupDAO groupDAO;

        public FollowingService() : base()
        {
            followingDAO = new FollowingDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Ajoute une nouvelle personne à un groupe
        /// </summary>
        /// <param name="personId">Le ID de la personne à ajouter</param>
        /// <param name="groupeId">Le ID du groupe où la personne dans lequel la personne doit être ajouté</param>
        public void AddPersonToGroup(object adminID, object personId, object groupId)
        {
            if(personId == null)
            {
                throw new ServiceException("Le ID de la personne est null");
            }

            if(groupId == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            if(adminID == null)
            {
                throw new ServiceException("Le ID de l'administrateur est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    // Validating the group
                    group theGroup = groupDAO.GetByID(context, groupId);

                    if (theGroup == null)
                    {
                        throw new ServiceException("Ce groupe n'existe pas");
                    }

                    if (!theGroup.Is_active)
                    {
                        throw new ServiceException("Ce groupe n'est pas actif");
                    }

                    List<following> followingList = followingDAO.GetBy(context, following.COLUMN_GROUP_ID, groupId).ToList();

                    foreach (following follow in followingList)
                    {
                        // If the user is already following that group
                        if (follow.Person_Id == (int)personId && follow.Is_active)
                        {
                            throw new ServiceException("Cette personne suis déjà ce groupe");
                        }
                        // He was following the group but was deactivated - Reactivating the person
                        else if (follow.Person_Id == (int)personId && !follow.Is_active)
                        {
                            follow.Is_active = true;
                            followingDAO.Update(context, follow);
                            context.SaveChanges();
                            return;
                        }
                        // The user adding is not admin of this group
                        if (follow.Person_Id == (int)adminID && !follow.Is_admin)
                        {
                            throw new ServiceException("La personne qui tente d'ajouter une autre personne n'est pas l'administrateur du groupe");
                        }
                    }

                    // Everyting is ok, adding the following
                    following newFollowing = new following();
                    newFollowing.Person_Id = (int)personId;
                    newFollowing.Group_id = (int)groupId;
                    newFollowing.Is_admin = false;
                    newFollowing.Is_active = true;
                    newFollowing.Last_checkin = DateTime.Now;

                    followingDAO.Insert(context, newFollowing);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Retire un 'follower' d'un groupe (Set is_active à false)        
        /// </summary>
        /// <param name="groupID">Le ID du groupe pour lequel la personne est retirée</param>
        /// <param name="followerID">Le ID du 'follower' à retirer</param>
        /// <returns>Retourne True si la personne est retirer. False sinon</returns>
        public bool RemoveTheFollower(object groupID, object followerID)
        {
            if(groupID == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            if (followerID == null)
            {
                throw new ServiceException("Le ID du follower est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {             
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException("Ce groupe n'existe pas");
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException("Ce groupe n'est pas actif, impossible de le changer");
                    }

                    List<following> followerList = followingDAO.GetBy(context, following.COLUMN_PERSON_ID, followerID).ToList();

                    if(followerList == null)
                    {
                        throw new ServiceException("Ce follower n'existe pas");
                    }

                    following theFollower = followerList[0];

                    if (!theFollower.Is_active)
                    {
                        throw new ServiceException("Ce follower ne suis déjà plus ce groupe");
                    }

                    if (theFollower.Is_admin)
                    {
                        throw new ServiceException("Il est impossible de retirer l'admin d'un groupe");
                    }            

                    theFollower.Is_active = false;
                    followingDAO.Update(context, theFollower);
                    context.SaveChanges();
                    return true;
                }                
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Recherche des follower actif d'un groupe
        /// </summary>
        /// <param name="groupID">Le ID du groupe pour lequel nous désirons les followers</param>
        /// <returns>Une liste de follower, une liste vide sinon</returns>
        public IList<following> GetTheFollowers(object groupID)
        {
            if(groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    group group = groupDAO.GetByID(context, groupID);

                    if (group == null)
                    {
                        throw new ServiceException("Ce groupe n'existe pas");
                    }

                    if (!group.Is_active)
                    {
                        throw new ServiceException("Ce groupe n'est pas actif");
                    }

                    return followingDAO.GetTheFollowers(context, groupID);
                }
            }
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }           
        }

        /// <summary>
        /// Vérification si la person qui accède à un groupe est l'administrateur
        /// </summary>
        /// <param name="personID">Le ID de la personne qui accède au groupe</param>
        /// <param name="groupID">Le ID du groupe que la personne tente d'accèder</param>
        /// <returns>True si la personne est admin, false sinon</returns>
        public bool PersonIsGroupAdmin(object personID, object groupID)
        {
            if (personID == null)
            {
                throw new ServiceException("Le ID de la personne est null");
            }

            if (groupID == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    List<following> adminValidation = followingDAO.GetByID(context, personID, groupID).ToList();

                    if (adminValidation == null)
                    {
                        throw new ServiceException("Cette personne n'existe pas");
                    }

                    if (adminValidation.Count != 1)
                    {
                        throw new ServiceException("Il-y-a un problème avec ce groupe (Plus qu'un administrateur)");
                    }

                    // returning the value
                    return adminValidation[0].Is_admin;
                }
            }
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }                        
        }

        /// <summary>
        /// Appel le DAO pour trouver un following dans la base de donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste de following qui correspondent à la recherche</returns>
        public new IEnumerable<following> GetBy(string columnName, object value)
        {
            if(columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if(value == null || (string)value == "")
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }
            
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return followingDAO.GetBy(context, columnName, value);
                }                    
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }            
        }
    }
}
