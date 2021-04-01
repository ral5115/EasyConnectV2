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

    public class BaseCONEquivalenceRepository : BaseRepository<CONEquivalence>
    {

        public BaseCONEquivalenceRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONEquivalence data, Boolean byId)
        {
            String dml = "Select a from CONEquivalence as a where 1=1 ";
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
                if (!String.IsNullOrWhiteSpace(data.LabelValue1))
                    dml += "             AND upper(a.LabelValue1) like :LabelValue1 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue2))
                    dml += "             AND upper(a.LabelValue2) like :LabelValue2 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue3))
                    dml += "             AND upper(a.LabelValue3) like :LabelValue3 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue4))
                    dml += "             AND upper(a.LabelValue4) like :LabelValue4 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue5))
                    dml += "             AND upper(a.LabelValue5) like :LabelValue5 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue6))
                    dml += "             AND upper(a.LabelValue6) like :LabelValue6 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue7))
                    dml += "             AND upper(a.LabelValue7) like :LabelValue7 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue8))
                    dml += "             AND upper(a.LabelValue8) like :LabelValue8 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue9))
                    dml += "             AND upper(a.LabelValue9) like :LabelValue9 \n";
                if (!String.IsNullOrWhiteSpace(data.LabelValue10))
                    dml += "             AND upper(a.LabelValue10) like :LabelValue10 \n";
                if (data.CompanyId != 0)
                    dml += "             AND a.CompanyId = :CompanyId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONEquivalence data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.LabelValue1))
                    query.SetString("LabelValue1", "%" + data.LabelValue1.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue2))
                    query.SetString("LabelValue2", "%" + data.LabelValue2.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue3))
                    query.SetString("LabelValue3", "%" + data.LabelValue3.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue4))
                    query.SetString("LabelValue4", "%" + data.LabelValue4.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue5))
                    query.SetString("LabelValue5", "%" + data.LabelValue5.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue6))
                    query.SetString("LabelValue6", "%" + data.LabelValue6.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue7))
                    query.SetString("LabelValue7", "%" + data.LabelValue7.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue8))
                    query.SetString("LabelValue8", "%" + data.LabelValue8.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue9))
                    query.SetString("LabelValue9", "%" + data.LabelValue9.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LabelValue10))
                    query.SetString("LabelValue10", "%" + data.LabelValue10.ToUpper() + "%");
                if (data.CompanyId != 0)
                    query.SetInt32("CompanyId", data.CompanyId);
            }
        }

        public override void SaveOrUpdateDetails(CONEquivalence data)
        {
        }

        public override void AddMoreDetailFindById(CONEquivalence data)
        {
        }

        public override CONEquivalence FindById(CONEquivalence data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONEquivalence>();
            if (data != null)
            {
                data = new CONEquivalence(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONEquivalence> FindAll(CONEquivalence data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONEquivalence>() select new CONEquivalence(a, option)).ToList<CONEquivalence>();
        }
    }
}