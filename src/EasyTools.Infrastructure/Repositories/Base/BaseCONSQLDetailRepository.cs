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

    public class BaseCONSQLDetailRepository : BaseRepository<CONSQLDetail>
    {

        public BaseCONSQLDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONSQLDetail data, Boolean byId)
        {
            String dml = "Select a from CONSQLDetail as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Field))
                    dml += "             AND upper(a.Field) like :Field \n";
                if (!String.IsNullOrWhiteSpace(data.Description))
                    dml += "             AND upper(a.Description) like :Description \n";
                if (data.Secuence != 0)
                    dml += "             AND a.Secuence = :Secuence \n";
                if (!String.IsNullOrWhiteSpace(data.DBType))
                    dml += "             AND upper(a.DBType) like :DBType \n";
                if (!String.IsNullOrWhiteSpace(data.DefaultValue))
                    dml += "             AND upper(a.DefaultValue) like :DefaultValue \n";
                if (data.EquivalenceColumnId != null && data.EquivalenceColumnId != 0)
                    dml += "             AND a.EquivalenceColumnId = :EquivalenceColumnId \n";
                if (data.EquivalenceId != null && data.EquivalenceId != 0)
                    dml += "             AND a.EquivalenceId = :EquivalenceId \n";
                //if (data.MainSQLDetailId != null && data.MainSQLDetailId != 0)
                //    dml += "             AND a.MainSQLDetailId = :MainSQLDetailId \n";
                if (data.SQLId != 0)
                    dml += "             AND a.SQLId = :SQLId \n";
                if (data.StructureDetailId != null && data.StructureDetailId != 0)
                    dml += "             AND a.StructureDetailId = :StructureDetailId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLDetail data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.Field))
                    query.SetString("Field", "%" + data.Field.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Description))
                    query.SetString("Description", "%" + data.Description.ToUpper() + "%");
                if (data.Secuence != 0)
                    query.SetInt16("Secuence", data.Secuence);
                if (!String.IsNullOrWhiteSpace(data.DBType))
                    query.SetString("DBType", "%" + data.DBType.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.DefaultValue))
                    query.SetString("DefaultValue", "%" + data.DefaultValue.ToUpper() + "%");
                if (data.EquivalenceColumnId != null && data.EquivalenceColumnId != 0)
                    query.SetInt16("EquivalenceColumnId", (Int16)data.EquivalenceColumnId);
                if (data.EquivalenceId != null && data.EquivalenceId != 0)
                    query.SetInt32("EquivalenceId", (Int32)data.EquivalenceId);
                //if (data.MainSQLDetailId != null && data.MainSQLDetailId != 0)
                //    query.SetInt32("MainSQLDetailId", (Int32)data.MainSQLDetailId);
                if (data.SQLId != 0)
                    query.SetInt32("SQLId", data.SQLId);
                if (data.StructureDetailId != null && data.StructureDetailId != 0)
                    query.SetInt32("StructureDetailId", (Int32)data.StructureDetailId);
            }
        }

        public override void SaveOrUpdateDetails(CONSQLDetail data)
        {
        }

        public override void AddMoreDetailFindById(CONSQLDetail data)
        {
        }

        public override CONSQLDetail FindById(CONSQLDetail data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONSQLDetail>();
            if (data != null)
            {
                data = new CONSQLDetail(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONSQLDetail> FindAll(CONSQLDetail data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONSQLDetail>() select new CONSQLDetail(a, option)).ToList<CONSQLDetail>();
        }
    }
}