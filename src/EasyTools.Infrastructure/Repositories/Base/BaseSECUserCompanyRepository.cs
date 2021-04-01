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

    public class BaseSECUserCompanyRepository : BaseRepository<SECUserCompany>
    {

        public BaseSECUserCompanyRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECUserCompany data, Boolean byId)
        {
            String dml = "Select a from SECUserCompany as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.CompanyId != 0)
                    dml += "             AND a.CompanyId = :CompanyId \n";
                if (data.UserId != 0)
                    dml += "             AND a.UserId = :UserId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECUserCompany data, Boolean byId)
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
                if (data.CompanyId != 0)
                    query.SetInt32("CompanyId", data.CompanyId);
                if (data.UserId != 0)
                    query.SetInt32("UserId", data.UserId);
            }
        }

        public override void SaveOrUpdateDetails(SECUserCompany data)
        {
        }

        public override void AddMoreDetailFindById(SECUserCompany data)
        {
        }

        public override SECUserCompany FindById(SECUserCompany data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECUserCompany>();
            if (data != null)
            {
                data = new SECUserCompany(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECUserCompany> FindAll(SECUserCompany data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECUserCompany>() select new SECUserCompany(a, option)).ToList<SECUserCompany>();
        }
    }
}