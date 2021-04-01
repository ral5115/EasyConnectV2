using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONErrorRepository : BaseCONErrorRepository
    {

        public CONErrorRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONError data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field

                if (data.Record != null && data.Record.Id != 0)
                    dml += "             AND a.Record.Id = :Record \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONError data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

                if (data.Record != null && data.Record.Id != 0)
                    query.SetInt32("Record", data.Record.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONError data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONError data)
        {
        }

        public override CONError FindById(CONError data)
        {
            return base.FindById(data);
        }

        public override List<CONError> FindAll(CONError data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}