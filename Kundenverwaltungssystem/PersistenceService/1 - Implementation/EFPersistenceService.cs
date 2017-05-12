using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Linq;
using Common;
using System.Data.Entity.Infrastructure;
using EntityFramework.BulkInsert.Extensions;
using System.Data.Entity.Core.Objects;

namespace PersistenceService
{
    public class EFPersistenceService : IPersistenceService, ITransactionService
    {
        private readonly KundenverwaltungContext _context;

        public EFPersistenceService()
        {
            _context = new KundenverwaltungContext();
        }

        public T Save<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            _context.SaveChanges();
            return entity;
        }

        public T Refresh<T>(T entity) where T : class
        {
            _context.Entry(entity).Reload();
            return entity;
        }

        public List<T> SaveAll<T>(List<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();

            return entities;
        }

        public T GetById<T, TIdTyp>(TIdTyp id) where T : class
        {
            //_context.Set<T>().Find(id);
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        public ObjectQuery<T> Query<T>(string query, params ObjectParameter[] parameters) where T : class
        {
            return ((IObjectContextAdapter)_context).ObjectContext.CreateQuery<T>(query, parameters);
        }

        public void ExecuteInTransaction(Action action)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    action.Invoke();
                    transaction.Commit();
                }
                catch (DBConcurrencyException e)
                {
                    transaction.Rollback();
                    throw e;
                }

            }
        }

        public T ExecuteInTransaction<T>(Func<T> func)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var res = func.Invoke();
                    transaction.Commit();
                    return res;
                }
                catch (DBConcurrencyException e)
                {
                    transaction.Rollback();
                    throw e;
                }

            }
        }
    }
}
