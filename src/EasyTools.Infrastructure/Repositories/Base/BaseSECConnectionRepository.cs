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

    public class BaseSECConnectionRepository : BaseRepository<SECConnection>
    {

        public BaseSECConnectionRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECConnection data, Boolean byId)
        {
            String dml = "Select a from SECConnection as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Login))
                    dml += "             AND upper(a.Login) like :Login \n";
                if (!String.IsNullOrWhiteSpace(data.Password))
                    dml += "             AND upper(a.Password) like :Password \n";
                if (!String.IsNullOrWhiteSpace(data.Service))
                    dml += "             AND upper(a.Service) like :Service \n";
                if (!String.IsNullOrWhiteSpace(data.DB))
                    dml += "             AND upper(a.DB) like :DB \n";
                if (!String.IsNullOrWhiteSpace(data.Name))
                    dml += "             AND upper(a.Name) like :Name \n";
                if (data.CompanyId != 0)
                    dml += "             AND a.CompanyId = :CompanyId \n";
                if ( !string.IsNullOrWhiteSpace( data.DbType))
                    dml += "             AND a.DbType = :DbType \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECConnection data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.Login))
                    query.SetString("Login", "%" + data.Login.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Password))
                    query.SetString("Password", "%" + data.Password.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Service))
                    query.SetString("Service", "%" + data.Service.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.DB))
                    query.SetString("DB", "%" + data.DB.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Name))
                    query.SetString("Name", "%" + data.Name.ToUpper() + "%");
                if (data.CompanyId != 0)
                    query.SetInt32("CompanyId", data.CompanyId);
                if (!string.IsNullOrWhiteSpace(data.DbType))
                    query.SetString("DbType", data.DbType);
            }
        }

        public override void SaveOrUpdateDetails(SECConnection data)
        {
        }

        public override void AddMoreDetailFindById(SECConnection data)
        {
        }

        public override SECConnection FindById(SECConnection data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECConnection>();
            if (data != null)
            {
                data = new SECConnection(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECConnection> FindAll(SECConnection data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECConnection>() select new SECConnection(a, option)).ToList<SECConnection>();
        }
    }
}