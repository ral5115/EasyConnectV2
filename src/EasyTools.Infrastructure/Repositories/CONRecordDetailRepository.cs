using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONRecordDetailRepository : BaseCONRecordDetailRepository
    {

        public CONRecordDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONRecordDetail data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    dml += "             AND a.SQL.Id = :SQL \n";
                if (data.Record != null && data.Record.Id != 0)
                    dml += "             AND a.Record.Id = :Record \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONRecordDetail data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    query.SetInt32("SQL", data.SQL.Id);
                if (data.Record != null && data.Record.Id != 0)
                    query.SetInt32("Record", data.Record.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONRecordDetail data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONRecordDetail data)
        {
        }

        public override CONRecordDetail FindById(CONRecordDetail data)
        {
            return base.FindById(data);
        }

        public override List<CONRecordDetail> FindAll(CONRecordDetail data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}