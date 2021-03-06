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

    public class BaseCONIntegratorConfigurationRepository : BaseRepository<CONIntegratorConfiguration>
    {

        public BaseCONIntegratorConfigurationRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONIntegratorConfiguration data, Boolean byId)
        {
            String dml = "Select a from CONIntegratorConfiguration as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                //if (!String.IsNullOrWhiteSpace(data.WebServiceUrl))
                //    dml += "             AND upper(a.WebServiceUrl) like :WebServiceUrl \n";
                if (!String.IsNullOrWhiteSpace(data.InternalUser))
                    dml += "             AND upper(a.InternalUser) like :InternalUser \n";
                if (!String.IsNullOrWhiteSpace(data.InternalPassword))
                    dml += "             AND upper(a.InternalPassword) like :InternalPassword \n";
                //if (!String.IsNullOrWhiteSpace(data.InternalConnectionName))
                //    dml += "             AND upper(a.InternalConnectionName) like :InternalConnectionName \n";
                if (data.ConnectionNumber != null && data.ConnectionNumber != 0)
                    dml += "             AND a.ConnectionNumber = :ConnectionNumber \n";
                if (!String.IsNullOrWhiteSpace(data.ProgramPath))
                    dml += "             AND upper(a.ProgramPath) like :ProgramPath \n";
                if (data.IntegratorId != 0)
                    dml += "             AND a.IntegratorId = :IntegratorId \n";
                if (data.ConnectionId != null && data.ConnectionId != 0)
                    dml += "             AND a.ConnectionId = :ConnectionId \n";
                if (data.CompanyId != 0)
                    dml += "             AND a.CompanyId = :CompanyId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONIntegratorConfiguration data, Boolean byId)
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
                //if (!String.IsNullOrWhiteSpace(data.WebServiceUrl))
                //    query.SetString("WebServiceUrl", "%" + data.WebServiceUrl.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.InternalUser))
                    query.SetString("InternalUser", "%" + data.InternalUser.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.InternalPassword))
                    query.SetString("InternalPassword", "%" + data.InternalPassword.ToUpper() + "%");
                //if (!String.IsNullOrWhiteSpace(data.InternalConnectionName))
                //    query.SetString("InternalConnectionName", "%" + data.InternalConnectionName.ToUpper() + "%");
                if (data.ConnectionNumber != null && data.ConnectionNumber != 0)
                    query.SetInt32("ConnectionNumber", (Int32)data.ConnectionNumber);
                if (!String.IsNullOrWhiteSpace(data.ProgramPath))
                    query.SetString("ProgramPath", "%" + data.ProgramPath.ToUpper() + "%");
                if (data.IntegratorId != 0)
                    query.SetInt32("IntegratorId", data.IntegratorId);
                if (data.ConnectionId != null && data.ConnectionId != 0)
                    query.SetInt32("ConnectionId", (Int32)data.ConnectionId);
                if (data.CompanyId != 0)
                    query.SetInt32("CompanyId", data.CompanyId);
            }
        }

        public override void SaveOrUpdateDetails(CONIntegratorConfiguration data)
        {
        }

        public override void AddMoreDetailFindById(CONIntegratorConfiguration data)
        {
        }

        public override CONIntegratorConfiguration FindById(CONIntegratorConfiguration data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONIntegratorConfiguration>();
            if (data != null)
            {
                data = new CONIntegratorConfiguration(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONIntegratorConfiguration> FindAll(CONIntegratorConfiguration data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONIntegratorConfiguration>() select new CONIntegratorConfiguration(a, option)).ToList<CONIntegratorConfiguration>();
        }
    }
}