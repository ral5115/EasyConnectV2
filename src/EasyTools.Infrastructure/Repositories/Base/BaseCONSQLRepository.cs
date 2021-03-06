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

    public class BaseCONSQLRepository : BaseRepository<CONSQL>
    {

        public BaseCONSQLRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONSQL data, Boolean byId)
        {
            String dml = "Select a from CONSQL as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Description))
                    dml += "             AND upper(a.Description) like :Description \n";
                if (!String.IsNullOrWhiteSpace(data.SQLSentence))
                    dml += "             AND upper(a.SQLSentence) like :SQLSentence \n";
                if (!String.IsNullOrWhiteSpace(data.ExecuteStoreProcedure))
                    dml += "             AND upper(a.ExecuteStoreProcedure) like :ExecuteStoreProcedure \n";
                //if (!String.IsNullOrWhiteSpace(data.FileName))
                //    dml += "             AND upper(a.FileName) like :FileName \n";
                if (!String.IsNullOrWhiteSpace(data.Tag))
                    dml += "             AND upper(a.Tag) like :Tag \n";
                //if (!String.IsNullOrWhiteSpace(data.FileExtension))
                //    dml += "             AND upper(a.FileExtension) like :FileExtension \n";
                if (data.ConnectionId != 0)
                    dml += "             AND a.ConnectionId = :ConnectionId \n";
                if (data.StoreProcedureConnectionId != null && data.StoreProcedureConnectionId != 0)
                    dml += "             AND a.StoreProcedureConnectionId = :StoreProcedureConnectionId \n";
                //if (data.DestinyConnectionId != null && data.DestinyConnectionId != 0)
                //    dml += "             AND a.DestinyConnectionId = :DestinyConnectionId \n";
                if (data.CompanyId != 0)
                    dml += "             AND a.CompanyId = :CompanyId \n";
                if (data.MainSQLId != null && data.MainSQLId != 0)
                    dml += "             AND a.MainSQLId = :MainSQLId \n";
                if (data.StructureId != 0)
                    dml += "             AND a.StructureId = :StructureId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQL data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.Description))
                    query.SetString("Description", "%" + data.Description.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.SQLSentence))
                    query.SetString("SQLSentence", "%" + data.SQLSentence.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.ExecuteStoreProcedure))
                    query.SetString("ExecuteStoreProcedure", "%" + data.ExecuteStoreProcedure.ToUpper() + "%");
                //if (!String.IsNullOrWhiteSpace(data.FileName))
                //    query.SetString("FileName", "%" + data.FileName.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Tag))
                    query.SetString("Tag", "%" + data.Tag.ToUpper() + "%");
                //if (!String.IsNullOrWhiteSpace(data.FileExtension))
                //    query.SetString("FileExtension", "%" + data.FileExtension.ToUpper() + "%");
                if (data.ConnectionId != 0)
                    query.SetInt32("ConnectionId", data.ConnectionId);
                if (data.StoreProcedureConnectionId != null && data.StoreProcedureConnectionId != 0)
                    query.SetInt32("StoreProcedureConnectionId", (Int32)data.StoreProcedureConnectionId);
                //if (data.DestinyConnectionId != null && data.DestinyConnectionId != 0)
                //    query.SetInt32("DestinyConnectionId", (Int32)data.DestinyConnectionId);
                if (data.CompanyId != 0)
                    query.SetInt32("CompanyId", data.CompanyId);
                if (data.MainSQLId != null && data.MainSQLId != 0)
                    query.SetInt32("MainSQLId", (Int32)data.MainSQLId);
                if (data.StructureId != 0)
                    query.SetInt32("StructureId", data.StructureId);
            }
        }

        public override void SaveOrUpdateDetails(CONSQL data)
        {
        }

        public override void AddMoreDetailFindById(CONSQL data)
        {
        }

        public override CONSQL FindById(CONSQL data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONSQL>();
            if (data != null)
            {
                data = new CONSQL(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONSQL> FindAll(CONSQL data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONSQL>() select new CONSQL(a, option)).ToList<CONSQL>();
        }
    }
}