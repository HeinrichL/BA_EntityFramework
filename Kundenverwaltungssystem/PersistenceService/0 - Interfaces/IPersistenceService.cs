using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PersistenceService
{
    public interface IPersistenceService
    {
        /// <summary>
        /// Speichert eine Entität in der Datenbank
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Save<T>(T entity) where T : class;

        /// <summary>
        /// Aktualisiert eine Entität in der Datenbank
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update<T>(T entity) where T : class;

        /// <summary>
        /// Speichert eine Liste von Entitäten in der Datenbank
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        List<T> SaveAll<T>(List<T> entities) where T : class;

        /// <summary>
        /// Sucht ein Objekt vom Typ T mit der Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TIdTyp"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById<T, TIdTyp>(TIdTyp id) where T : class;

        /// <summary>
        /// Holt alle Objekte eines Typs aus der Datenbank
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetAll<T>() where T : class;

        /// <summary>
        /// Löscht das Objekt aus der DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Gibt ein IQueryable-Objekt zurück, auf das mit LINQ zugegriffen werden kann
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> Query<T>() where T : class;

        ObjectQuery<T> Query<T>(string query, params ObjectParameter[] parameters) where T : class;
    }
}
