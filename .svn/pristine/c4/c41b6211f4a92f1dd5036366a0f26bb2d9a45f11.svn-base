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

    public class BaseCONRecordDetailRepository : BaseRepository<CONRecordDetail>
    {

        public BaseCONRecordDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONRecordDetail data, Boolean byId)
        {
            String dml = "Select a from CONRecordDetail as a where 1=1 ";
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
                if (data.RecordType != 0)
                    dml += "             AND a.RecordType = :RecordType \n";
                if (data.SubRecordType != 0)
                    dml += "             AND a.SubRecordType = :SubRecordType \n";
                if (data.Version != 0)
                    dml += "             AND a.Version = :Version \n";
                if (!String.IsNullOrWhiteSpace(data.Company))
                    dml += "             AND upper(a.Company) like :Company \n";
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    dml += "             AND upper(a.LogicalKey) like :LogicalKey \n";
                if (data.DocumentNumber != null && data.DocumentNumber != 0)
                    dml += "             AND a.DocumentNumber = :DocumentNumber \n";
                if (data.XMLData != null)
                    dml += "             AND upper(a.XMLData) like :XMLData \n";
                if (!String.IsNullOrWhiteSpace(data.OperationCenter))
                    dml += "             AND upper(a.OperationCenter) like :OperationCenter \n";
                if (!String.IsNullOrWhiteSpace(data.DocumentType))
                    dml += "             AND upper(a.DocumentType) like :DocumentType \n";
                if (data.PlainText != null)
                    dml += "             AND upper(a.PlainText) like :PlainText \n";
                if (data.SQLId != null && data.SQLId != 0)
                    dml += "             AND a.SQLId = :SQLId \n";
                if (data.RecordId != 0)
                    dml += "             AND a.RecordId = :RecordId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONRecordDetail data, Boolean byId)
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
                if (data.RecordType != 0)
                    query.SetInt32("RecordType", data.RecordType);
                if (data.SubRecordType != 0)
                    query.SetInt32("SubRecordType", data.SubRecordType);
                if (data.Version != 0)
                    query.SetInt32("Version", data.Version);
                if (!String.IsNullOrWhiteSpace(data.Company))
                    query.SetString("Company", "%" + data.Company.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    query.SetString("LogicalKey", "%" + data.LogicalKey.ToUpper() + "%");
                if (data.DocumentNumber != null && data.DocumentNumber != 0)
                    query.SetInt32("DocumentNumber", (Int32)data.DocumentNumber);
                if (data.XMLData != null)
                    query.SetString("XMLData", "%" + data.XMLData.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.OperationCenter))
                    query.SetString("OperationCenter", "%" + data.OperationCenter.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.DocumentType))
                    query.SetString("DocumentType", "%" + data.DocumentType.ToUpper() + "%");
                if (data.PlainText != null)
                    query.SetString("PlainText", "%" + data.PlainText.ToUpper() + "%");
                if (data.SQLId != null && data.SQLId != 0)
                    query.SetInt32("SQLId", (Int32)data.SQLId);
                if (data.RecordId != 0)
                    query.SetInt32("RecordId", data.RecordId);
            }
        }

        public override void SaveOrUpdateDetails(CONRecordDetail data)
        {
        }

        public override void AddMoreDetailFindById(CONRecordDetail data)
        {
        }

        public override CONRecordDetail FindById(CONRecordDetail data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONRecordDetail>();
            if (data != null)
            {
                data = new CONRecordDetail(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONRecordDetail> FindAll(CONRecordDetail data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONRecordDetail>() select new CONRecordDetail(a, option)).ToList<CONRecordDetail>();
        }
    }
}