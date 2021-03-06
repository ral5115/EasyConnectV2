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

    public class BaseCONRecordRepository : BaseRepository<CONRecord>
    {

        public BaseCONRecordRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONRecord data, Boolean byId)
        {
            String dml = "Select a from CONRecord as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.RecordNumber != null && data.RecordNumber != 0)
                    dml += "             AND a.RecordNumber = :RecordNumber \n";
                if (data.RecordType != 0 && data.RecordType != null)
                    dml += "             AND a.RecordType = :RecordType \n";
                if (data.SubRecordType != 0 && data.SubRecordType != null)
                    dml += "             AND a.SubRecordType = :SubRecordType \n";
                if (data.Version != 0 && data.Version != null)
                    dml += "             AND a.Version = :Version \n";
                if (!String.IsNullOrWhiteSpace(data.Company))
                    dml += "             AND upper(a.Company) like :Company \n";
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    dml += "             AND upper(a.LogicalKey) like :LogicalKey \n";
                if (data.DocumentNumber != null && data.DocumentNumber != 0)
                    dml += "             AND a.DocumentNumber = :DocumentNumber \n";
                if (!String.IsNullOrWhiteSpace(data.XMLData))
                    dml += "             AND upper(a.XMLData) like :XMLData \n";
                if (!String.IsNullOrWhiteSpace(data.OperationCenter))
                    dml += "             AND upper(a.OperationCenter) like :OperationCenter \n";
                if (!String.IsNullOrWhiteSpace(data.DocumentType))
                    dml += "             AND upper(a.DocumentType) like :DocumentType \n";
                if (!String.IsNullOrWhiteSpace(data.PlainText))
                    dml += "             AND upper(a.PlainText) like :PlainText \n";
                if (data.SQLId != null && data.SQLId != 0)
                    dml += "             AND a.SQLId = :SQLId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONRecord data, Boolean byId)
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
                if (data.RecordNumber != null && data.RecordNumber != 0)
                    query.SetInt32("RecordNumber", (Int32)data.RecordNumber);
                if (data.RecordType != null && data.RecordType != 0)
                    query.SetInt32("RecordType", (Int32)data.RecordType);
                if (data.SubRecordType != null && data.SubRecordType != 0)
                    query.SetInt32("SubRecordType", (Int32)data.SubRecordType);
                if (data.Version != null && data.Version != 0)
                    query.SetInt32("Version", (Int32)data.Version);
                if (!String.IsNullOrWhiteSpace(data.Company))
                    query.SetString("Company", "%" + data.Company.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    query.SetString("LogicalKey", "%" + data.LogicalKey.ToUpper() + "%");
                if (data.DocumentNumber != null && data.DocumentNumber != 0)
                    query.SetInt32("DocumentNumber", (Int32)data.DocumentNumber);
                if (!String.IsNullOrWhiteSpace(data.XMLData))
                    query.SetString("XMLData", "%" + data.XMLData.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.OperationCenter))
                    query.SetString("OperationCenter", "%" + data.OperationCenter.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.DocumentType))
                    query.SetString("DocumentType", "%" + data.DocumentType.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.PlainText))
                    query.SetString("PlainText", "%" + data.PlainText.ToUpper() + "%");
                if (data.SQLId != null && data.SQLId != 0)
                    query.SetInt32("SQLId", (Int32)data.SQLId);
            }
        }

        public override void SaveOrUpdateDetails(CONRecord data)
        {
        }

        public override void AddMoreDetailFindById(CONRecord data)
        {
        }

        public override CONRecord FindById(CONRecord data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONRecord>();
            if (data != null)
            {
                data = new CONRecord(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONRecord> FindAll(CONRecord data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONRecord>() select new CONRecord(a, option)).ToList<CONRecord>();
        }
    }
}