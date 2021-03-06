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

    public class BaseCONEquivalenceDetailRepository : BaseRepository<CONEquivalenceDetail>
    {

        public BaseCONEquivalenceDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override void AddMoreDetailFindById(CONEquivalenceDetail data)
        {
            
        }

        public override List<CONEquivalenceDetail> FindAll(CONEquivalenceDetail data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONEquivalenceDetail>() select new CONEquivalenceDetail(a, option)).ToList<CONEquivalenceDetail>();
        }

        public override CONEquivalenceDetail FindById(CONEquivalenceDetail data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONEquivalenceDetail>();
            if (data != null)
            {
                data = new CONEquivalenceDetail(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override String GetQuery(CONEquivalenceDetail data, Boolean byId)
        {
            String dml = "Select a from CONEquivalenceDetail as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Code))
                    dml += "             AND upper(a.Code) like :Code \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Code))
                    dml += "             AND upper(a.Code) like :Code \n";
                if (!String.IsNullOrWhiteSpace(data.Name))
                    dml += "             AND upper(a.Name) like :Name \n";
                if (!String.IsNullOrWhiteSpace(data.Value1))
                    dml += "             AND upper(a.Value1) like :Value1 \n";
                if (!String.IsNullOrWhiteSpace(data.Value2))
                    dml += "             AND upper(a.Value2) like :Value2 \n";
                if (!String.IsNullOrWhiteSpace(data.Value3))
                    dml += "             AND upper(a.Value3) like :Value3 \n";
                if (!String.IsNullOrWhiteSpace(data.Value4))
                    dml += "             AND upper(a.Value4) like :Value4 \n";
                if (!String.IsNullOrWhiteSpace(data.Value5))
                    dml += "             AND upper(a.Value5) like :Value5 \n";
                if (!String.IsNullOrWhiteSpace(data.Value6))
                    dml += "             AND upper(a.Value6) like :Value6 \n";
                if (!String.IsNullOrWhiteSpace(data.Value7))
                    dml += "             AND upper(a.Value7) like :Value7 \n";
                if (!String.IsNullOrWhiteSpace(data.Value8))
                    dml += "             AND upper(a.Value8) like :Value8 \n";
                if (!String.IsNullOrWhiteSpace(data.Value9))
                    dml += "             AND upper(a.Value9) like :Value9 \n";
                if (!String.IsNullOrWhiteSpace(data.Value10))
                    dml += "             AND upper(a.Value10) like :Value10 \n";
                if (data.EquivalenceId != 0)
                    dml += "             AND a.EquivalenceId = :EquivalenceId \n";

            }
            return dml;
        }

        public override void SaveOrUpdateDetails(CONEquivalenceDetail data)
        {
            
        }

        public override void SetQueryParameters(IQuery query, CONEquivalenceDetail data, Boolean byId)
        {
            if (byId)
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (!String.IsNullOrWhiteSpace(data.Code))
                    query.SetString("Code", "%" + data.Code.ToUpper() + "%");
            }
            else
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (!String.IsNullOrWhiteSpace(data.Code))
                    query.SetString("Code", "%" + data.Code.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Name))
                    query.SetString("Name", "%" + data.Name.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value1))
                    query.SetString("Value1", "%" + data.Value1.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value2))
                    query.SetString("Value2", "%" + data.Value2.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value3))
                    query.SetString("Value3", "%" + data.Value3.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value4))
                    query.SetString("Value4", "%" + data.Value4.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value5))
                    query.SetString("Value5", "%" + data.Value5.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value6))
                    query.SetString("Value6", "%" + data.Value6.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value7))
                    query.SetString("Value7", "%" + data.Value7.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value8))
                    query.SetString("Value8", "%" + data.Value8.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value9))
                    query.SetString("Value9", "%" + data.Value9.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Value10))
                    query.SetString("Value10", "%" + data.Value10.ToUpper() + "%");
                if (data.EquivalenceId != 0)
                    query.SetInt32("EquivalenceId", data.EquivalenceId);
            }
        }

    }
}