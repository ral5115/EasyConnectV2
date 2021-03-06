using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONSQLSendRepository : BaseCONSQLSendRepository
    {

        public CONSQLSendRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONSQLSend data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation

                //dml += "             AND a.Active = :Active \n";

                //add more parameters to method for query by any field

                if (data.CONIntegratorConfiguration != null && data.CONIntegratorConfiguration.Id != 0)
                    dml += "             AND a.CONIntegratorConfiguration.Id = :CONIntegratorConfiguration \n";
                if (data.SQL != null && data.SQL.Id != 0)
                    dml += "             AND a.SQL.Id = :SQL \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLSend data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("Active", data.Active);

                //add more parameters to method for query by any field

                if (data.CONIntegratorConfiguration != null && data.CONIntegratorConfiguration.Id != 0)
                    query.SetInt32("CONIntegratorConfiguration", data.CONIntegratorConfiguration.Id);
                if (data.SQL != null && data.SQL.Id != 0)
                    query.SetInt32("SQL", data.SQL.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONSQLSend data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONSQLSend data)
        {
        }

        public override CONSQLSend FindById(CONSQLSend data)
        {
            return base.FindById(data);
        }

        public override List<CONSQLSend> FindAll(CONSQLSend data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}