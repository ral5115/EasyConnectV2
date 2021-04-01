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

    public class BaseCONStructureRepository : BaseRepository<CONStructure>
    {

        public BaseCONStructureRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONStructure data, Boolean byId)
        {
            String dml = "Select a from CONStructure as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Code))
                    dml += "             AND upper(a.Code) like :Code \n";
                if (!String.IsNullOrWhiteSpace(data.Name))
                    dml += "             AND upper(a.Name) like :Name \n";
                if (data.Version != 0)
                    dml += "             AND a.Version = :Version \n";
                if (data.ColumnNumber != 0)
                    dml += "             AND a.ColumnNumber = :ColumnNumber \n";
                if (data.IntegratorId != 0)
                    dml += "             AND a.IntegratorId = :IntegratorId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructure data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.Code))
                    query.SetString("Code", "%" + data.Code.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Name))
                    query.SetString("Name", "%" + data.Name.ToUpper() + "%");
                if (data.Version != 0)
                    query.SetInt32("Version", data.Version);
                if (data.ColumnNumber != 0)
                    query.SetInt16("ColumnNumber", data.ColumnNumber);
                if (data.IntegratorId != 0)
                    query.SetInt32("IntegratorId", data.IntegratorId);
            }
        }

        public override void SaveOrUpdateDetails(CONStructure data)
        {
        }

        public override void AddMoreDetailFindById(CONStructure data)
        {
        }

        public override CONStructure FindById(CONStructure data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONStructure>();
            if (data != null)
            {
                data = new CONStructure(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONStructure> FindAll(CONStructure data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONStructure>() select new CONStructure(a, option)).ToList<CONStructure>();
        }
    }
}