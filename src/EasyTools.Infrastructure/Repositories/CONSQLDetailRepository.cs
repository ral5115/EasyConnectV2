using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONSQLDetailRepository : BaseCONSQLDetailRepository
    {

        public CONSQLDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONSQLDetail data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field

                if (data.Equivalence != null && data.Equivalence.Id != 0)
                    dml += "             AND a.Equivalence.Id = :Equivalence \n";
                //if (data.MainSQLDetail != null && data.MainSQLDetail.Id != 0)
                //    dml += "             AND a.MainSQLDetail.Id = :MainSQLDetail \n";
                if (data.SQL != null && data.SQL.Id != 0)
                    dml += "             AND a.SQL.Id = :SQL \n";
                if (data.StructureDetail != null && data.StructureDetail.Id != 0)
                    dml += "             AND a.StructureDetail.Id = :StructureDetail \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLDetail data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

                if (data.Equivalence != null && data.Equivalence.Id != 0)
                    query.SetInt32("Equivalence", data.Equivalence.Id);
                //if (data.MainSQLDetail != null && data.MainSQLDetail.Id != 0)
                //    query.SetInt32("MainSQLDetail", data.MainSQLDetail.Id);
                if (data.SQL != null && data.SQL.Id != 0)
                    query.SetInt32("SQL", data.SQL.Id);
                if (data.StructureDetail != null && data.StructureDetail.Id != 0)
                    query.SetInt32("StructureDetail", data.StructureDetail.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONSQLDetail data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONSQLDetail data)
        {
        }

        public override CONSQLDetail FindById(CONSQLDetail data)
        {
            return base.FindById(data);
        }

        public override List<CONSQLDetail> FindAll(CONSQLDetail data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}