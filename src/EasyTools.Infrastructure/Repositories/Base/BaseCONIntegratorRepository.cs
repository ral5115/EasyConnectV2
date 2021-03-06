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

    public class BaseCONIntegratorRepository : BaseRepository<CONIntegrator>
    {

        public BaseCONIntegratorRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONIntegrator data, Boolean byId)
        {
            String dml = "Select a from CONIntegrator as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Name))
                    dml += "             AND upper(a.Name) like :Name \n";
                if (!String.IsNullOrWhiteSpace(data.XMLDefinition))
                    dml += "             AND upper(a.XMLDefinition) like :XMLDefinition \n";
                if (!String.IsNullOrWhiteSpace(data.XMLRoot))
                    dml += "             AND upper(a.XMLRoot) like :XMLRoot \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONIntegrator data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.Name))
                    query.SetString("Name", "%" + data.Name.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.XMLDefinition))
                    query.SetString("XMLDefinition", "%" + data.XMLDefinition.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.XMLRoot))
                    query.SetString("XMLRoot", "%" + data.XMLRoot.ToUpper() + "%");
            }
        }

        public override void SaveOrUpdateDetails(CONIntegrator data)
        {
        }

        public override void AddMoreDetailFindById(CONIntegrator data)
        {
        }

        public override CONIntegrator FindById(CONIntegrator data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONIntegrator>();
            if (data != null)
            {
                data = new CONIntegrator(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONIntegrator> FindAll(CONIntegrator data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONIntegrator>() select new CONIntegrator(a, option)).ToList<CONIntegrator>();
        }
    }
}