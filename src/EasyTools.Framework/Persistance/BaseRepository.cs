using EasyTools.Framework.Data;
using NHibernate;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EasyTools.Framework.Persistance
{

    public abstract class BaseRepository<T> where T : FrameworkEntity
    {

        protected IUnitOfWork work;

        public BaseRepository(IUnitOfWork context)
        {
            work = context;
        }

        public abstract void SaveOrUpdateDetails(T data);

        public T Add(T data)
        {
            data.Id = (Int32)work.Session.Save(data);
            SaveOrUpdateDetails(data);
            return data;
        }

        public D Add<D>(D data) where D : FrameworkEntity
        {
            data.Id = (Int32)work.Session.Save(data);
            return data;
        }

        public T Modify(T data)
        {
            work.Session.Update(data);
            SaveOrUpdateDetails(data);
            return data;
        }

        public D Modify<D>(D data) where D : FrameworkEntity
        {
            work.Session.Update(data);
            return data;
        }


        public T Remove(T data)
        {
            work.Session.Delete(data);
            return data;
        }

        public D Remove<D>(D data)
        {
            work.Session.Delete(data);
            return data;
        }


        public T Remove(List<T> datas)
        {
            T data = null;
            if (datas != null && datas.Count > 0)
                for (int i = 0; i < datas.Count; i++)
                {
                    work.Session.Delete(datas[i]);
                    if (i == datas.Count - 1)
                        data = datas[i];
                }
            return data;
        }

        public abstract void AddMoreDetailFindById(T data);

        public abstract T FindById(T data);

        public bool Exist(T data)
        {
            return FindById(data) != null;
        }

        public abstract List<T> FindAll(T data, Options option);

        public abstract String GetQuery(T data, Boolean byId);

        public abstract void SetQueryParameters(IQuery query, T data, Boolean byId);

        public Int32 GetConsecutive(string consecutiveId)
        {
            List<SQLParameter> parames = new List<SQLParameter>();
            parames.Add(new SQLParameter { Name = "@PConsecutiveId", IsString = true, StringValue = consecutiveId });
            parames.Add(new SQLParameter { Name = "@PType", IsInt = true, Int32Value = 0 });
            parames.Add(new SQLParameter { Name = "@PSecuence", IsInt = true, Direction = ParameterDirection.Output.ToString() });
            Database db = new Database(work.Settings.ConnectionString, work.Settings.DBType);
            Dictionary<string, object> res = db.ExecuteStoreProcedure("GetNHConcecutives", parames);
            return int.Parse(res["@PSecuence"].ToString());
        }

    }
}