using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONRecordRepository : BaseCONRecordRepository
    {

        public CONRecordRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONRecord data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    dml += "             AND upper(a.LogicalKey) = :LogicalKey \n";
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                dml += "             AND a.IsSend = :IsSend \n";
                //dml += "             AND a.IsExternal = :IsExternal \n" ;

                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    dml += "             AND a.SQL.Id = :SQL \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONRecord data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
                if (!String.IsNullOrWhiteSpace(data.LogicalKey))
                    query.SetString("LogicalKey", data.LogicalKey.ToUpper());
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                query.SetBoolean("IsSend", data.IsSend);
                //query.SetBoolean("IsExternal",  data.IsExternal);

                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    query.SetInt32("SQL", data.SQL.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONRecord data)
        {
            base.SaveOrUpdateDetails(data);
            if (data.Errors1 != null && data.Errors1.Count > 0)
            {
                for (int i = 0; i < data.Errors1.Count; i++)
                {
                    data.Errors1[i].RecordId = data.Id;
                    data.Errors1[i].LastUpdate = DateTime.Now;
                    data.Errors1[i].UpdatedBy = data.UpdatedBy;
                    if (data.Errors1[i].Id == 0)
                        data.Errors1[i] = Add(data.Errors1[i]);
                    else
                        data.Errors1[i] = Modify(data.Errors1[i]);
                }
            }
            if (data.RecordDetails != null && data.RecordDetails.Count > 0)
            {
                for (int i = 0; i < data.RecordDetails.Count; i++)
                {
                    data.RecordDetails[i].RecordId = data.Id;
                    data.RecordDetails[i].LastUpdate = DateTime.Now;
                    data.RecordDetails[i].UpdatedBy = data.UpdatedBy;

                    if (data.RecordDetails[i].SQL != null)
                        data.RecordDetails[i].SQLId = data.RecordDetails[i].SQL.Id;

                    if (data.IsExternal)
                        data.RecordDetails[i].Fields = new Dictionary<string, string>();
                    else
                        data.RecordDetails[i].GetPlaintText();
                    data.RecordDetails[i].XMLData = XMLSerializer.SerializeToString<Dictionary<string, string>>(data.RecordDetails[i].Fields);

                    if (data.RecordDetails[i].Id == 0)
                        data.RecordDetails[i] = Add(data.RecordDetails[i]);
                    else
                        data.RecordDetails[i] = Modify(data.RecordDetails[i]);
                }
            }

        }

        public override void AddMoreDetailFindById(CONRecord data)
        {
        }

        public override CONRecord FindById(CONRecord data)
        {
            return base.FindById(data);
        }

        public override List<CONRecord> FindAll(CONRecord data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}