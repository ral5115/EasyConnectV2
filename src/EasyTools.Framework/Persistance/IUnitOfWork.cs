using EasyTools.Framework.Data;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Framework.Persistance
{
    public abstract class IUnitOfWork : IDisposable
    {
        private ISession session;

        public ISession Session
        {
            get
            {
                if (session == null || !session.IsOpen)
                    session = PersistenceManager.GetCurrentSession(Settings.Name);
                return session;
            }
            private set
            {
                session = value;
            }
        }

        public DatabaseSetting Settings { get; protected set; }

        private ITransaction transaction;

        protected Dictionary<string, dynamic> _repositories;

        public BaseRepository<T> Repository<T>() where T : FrameworkEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (BaseRepository<T>)_repositories[type];
            }

            var repositoryType = typeof(T);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), Session));

            return _repositories[type];
        }

        public void BeginTransaction()
        {
            if (transaction == null || !transaction.IsActive)
                transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Commit();
            }
            catch (Exception e)
            {

            }
        }

        public void Dispose()
        {
            Session.Close();
        }

        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Rollback();
        }

        public abstract void LoadReposiories();

        public abstract void AddDefaultConfig(DatabaseSetting confg);

        public IUnitOfWork(DatabaseSetting confg)
        {

            Settings = confg;
            if (!PersistenceManager.IsValidSession(Settings.Name))
                AddDefaultConfig(Settings);
            Session = PersistenceManager.GetCurrentSession(Settings.Name);
            LoadReposiories();
        }

    }
}