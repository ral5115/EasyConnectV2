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

    public class BaseCONStructureDetailRepository : BaseRepository<CONStructureDetail>
    {

        public BaseCONStructureDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONStructureDetail data, Boolean byId)
        {
            String dml = "Select a from CONStructureDetail as a where 1=1 ";
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
                if (data.DBType != 0)
                    dml += "             AND a.DBType = :DBType \n";
                if (!String.IsNullOrWhiteSpace(data.Observations))
                    dml += "             AND upper(a.Observations) like :Observations \n";
                if (data.Secuence != 0)
                    dml += "             AND a.Secuence = :Secuence \n";
                if (data.InitialPosition != null && data.InitialPosition != 0)
                    dml += "             AND a.InitialPosition = :InitialPosition \n";
                if (data.Sizes != null && data.Sizes != 0)
                    dml += "             AND a.Sizes = :Sizes \n";
                if (data.FinalPosition != null && data.FinalPosition != 0)
                    dml += "             AND a.FinalPosition = :FinalPosition \n";
                if (!String.IsNullOrWhiteSpace(data.DefaultValue))
                    dml += "             AND upper(a.DefaultValue) like :DefaultValue \n";
                if (data.Ent != 0)
                    dml += "             AND a.Ent = :Ent \n";
                if (data.Dec != 0)
                    dml += "             AND a.Dec = :Dec \n";
                if (data.StructureId != 0)
                    dml += "             AND a.StructureId = :StructureId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructureDetail data, Boolean byId)
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
                if (data.DBType != 0)
                    query.SetInt16("DBType", data.DBType);
                if (!String.IsNullOrWhiteSpace(data.Observations))
                    query.SetString("Observations", "%" + data.Observations.ToUpper() + "%");
                if (data.Secuence != 0)
                    query.SetInt16("Secuence", data.Secuence);
                if (data.InitialPosition != null && data.InitialPosition != 0)
                    query.SetInt16("InitialPosition", (Int16)data.InitialPosition);
                if (data.Sizes != null && data.Sizes != 0)
                    query.SetInt16("Sizes", (Int16)data.Sizes);
                if (data.FinalPosition != null && data.FinalPosition != 0)
                    query.SetInt16("FinalPosition", (Int16)data.FinalPosition);
                if (!String.IsNullOrWhiteSpace(data.DefaultValue))
                    query.SetString("DefaultValue", "%" + data.DefaultValue.ToUpper() + "%");
                if (data.Ent != 0)
                    query.SetInt16("Ent", data.Ent);
                if (data.Dec != 0)
                    query.SetInt16("Dec", data.Dec);
                if (data.StructureId != 0)
                    query.SetInt32("StructureId", data.StructureId);
            }
        }

        public override void SaveOrUpdateDetails(CONStructureDetail data)
        {
        }

        public override void AddMoreDetailFindById(CONStructureDetail data)
        {
        }

        public override CONStructureDetail FindById(CONStructureDetail data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONStructureDetail>();
            if (data != null)
            {
                data = new CONStructureDetail(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONStructureDetail> FindAll(CONStructureDetail data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONStructureDetail>() select new CONStructureDetail(a, option)).ToList<CONStructureDetail>();
        }
    }
}