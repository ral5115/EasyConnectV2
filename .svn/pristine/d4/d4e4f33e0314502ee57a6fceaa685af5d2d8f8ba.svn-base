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

    public class BaseCONErrorRepository : BaseRepository<CONError>
    {

        public BaseCONErrorRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONError data, Boolean byId)
        {
            String dml = "Select a from CONError as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.ErrorLevel != 0)
                    dml += "             AND a.ErrorLevel = :ErrorLevel \n";
                if (!String.IsNullOrWhiteSpace(data.ErrorValue))
                    dml += "             AND upper(a.ErrorValue) like :ErrorValue \n";
                if (!String.IsNullOrWhiteSpace(data.ErrorDetail))
                    dml += "             AND upper(a.ErrorDetail) like :ErrorDetail \n";
                if (data.RecordNumber != 0)
                    dml += "             AND a.RecordNumber = :RecordNumber \n";
                if (data.RecordType != 0)
                    dml += "             AND a.RecordType = :RecordType \n";
                if (data.SubRecordType != 0)
                    dml += "             AND a.SubRecordType = :SubRecordType \n";
                if (data.Version != 0)
                    dml += "             AND a.Version = :Version \n";
                if (data.RecordId != 0)
                    dml += "             AND a.RecordId = :RecordId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONError data, Boolean byId)
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
                if (data.ErrorLevel != 0)
                    query.SetInt16("ErrorLevel", data.ErrorLevel);
                if (!String.IsNullOrWhiteSpace(data.ErrorValue))
                    query.SetString("ErrorValue", "%" + data.ErrorValue.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.ErrorDetail))
                    query.SetString("ErrorDetail", "%" + data.ErrorDetail.ToUpper() + "%");
                if (data.RecordNumber != 0)
                    query.SetInt32("RecordNumber", data.RecordNumber);
                if (data.RecordType != 0)
                    query.SetInt32("RecordType", data.RecordType);
                if (data.SubRecordType != 0)
                    query.SetInt32("SubRecordType", data.SubRecordType);
                if (data.Version != 0)
                    query.SetInt32("Version", data.Version);
                if (data.RecordId != 0)
                    query.SetInt32("RecordId", data.RecordId);
            }
        }

        public override void SaveOrUpdateDetails(CONError data)
        {
        }

        public override void AddMoreDetailFindById(CONError data)
        {
        }

        public override CONError FindById(CONError data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONError>();
            if (data != null)
            {
                data = new CONError(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONError> FindAll(CONError data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONError>() select new CONError(a, option)).ToList<CONError>();
        }
    }
}