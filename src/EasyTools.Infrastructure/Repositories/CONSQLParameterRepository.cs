using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONSQLParameterRepository : BaseCONSQLParameterRepository
    {

        public CONSQLParameterRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONSQLParameter data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.IsDate = :IsDate \n" ;
                //dml += "             AND a.IsInt = :IsInt \n" ;
                //dml += "             AND a.IsString = :IsString \n" ;

                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    dml += "             AND a.SQL.Id = :SQL \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLParameter data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("IsDate",  data.IsDate);
                //query.SetBoolean("IsInt",  data.IsInt);
                //query.SetBoolean("IsString",  data.IsString);

                //add more parameters to method for query by any field

                if (data.SQL != null && data.SQL.Id != 0)
                    query.SetInt32("SQL", data.SQL.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONSQLParameter data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONSQLParameter data)
        {
        }

        public override CONSQLParameter FindById(CONSQLParameter data)
        {
            return base.FindById(data);
        }

        public override List<CONSQLParameter> FindAll(CONSQLParameter data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}