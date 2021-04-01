using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyTools.Infrastructure.Repositories.Base
{

    public class BaseCONSQLSendRepository : BaseRepository<CONSQLSend>
    {

        public BaseCONSQLSendRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONSQLSend data, Boolean byId)
        {
            String dml = "Select a from CONSQLSend as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.CONIntegratorConfigurationId != 0)
                    dml += "             AND a.CONIntegratorConfigurationId = :CONIntegratorConfigurationId \n";
                if (data.SQLId != 0)
                    dml += "             AND a.SQLId = :SQLId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLSend data, Boolean byId)
        {
            if (byId)
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
            }
            else
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (data.CONIntegratorConfigurationId != 0)
                    query.SetInt32("CONIntegratorConfigurationId", data.CONIntegratorConfigurationId);
                if (data.SQLId != 0)
                    query.SetInt32("SQLId", data.SQLId);
            }
        }

        public override void SaveOrUpdateDetails(CONSQLSend data)
        {
        }

        public override void AddMoreDetailFindById(CONSQLSend data)
        {
        }

        public override CONSQLSend FindById(CONSQLSend data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONSQLSend>();
            if (data != null)
            {
                data = new CONSQLSend(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONSQLSend> FindAll(CONSQLSend data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONSQLSend>() select new CONSQLSend(a, option)).ToList<CONSQLSend>();
        }
    }
}