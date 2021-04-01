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

    public class BaseSECCompanyRepository : BaseRepository<SECCompany>
    {

        public BaseSECCompanyRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECCompany data, Boolean byId)
        {
            String dml = "Select a from SECCompany as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.IdentificationNumer))
                    dml += "             AND upper(a.IdentificationNumer) like :IdentificationNumer \n";
                if (!String.IsNullOrWhiteSpace(data.TradeName))
                    dml += "             AND upper(a.TradeName) like :TradeName \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECCompany data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.IdentificationNumer))
                    query.SetString("IdentificationNumer", "%" + data.IdentificationNumer.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.TradeName))
                    query.SetString("TradeName", "%" + data.TradeName.ToUpper() + "%");
            }
        }

        public override void SaveOrUpdateDetails(SECCompany data)
        {
        }

        public override void AddMoreDetailFindById(SECCompany data)
        {
        }

        public override SECCompany FindById(SECCompany data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECCompany>();
            if (data != null)
            {
                data = new SECCompany(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECCompany> FindAll(SECCompany data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECCompany>() select new SECCompany(a, option)).ToList<SECCompany>();
        }

    }
}