using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONEquivalenceRepository : BaseCONEquivalenceRepository
    {

        public CONEquivalenceRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONEquivalence data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.Active = :Active \n" ;

                //add more parameters to method for query by any field

                if (data.Company != null && data.Company.Id != 0)
                    dml += "             AND a.Company.Id = :Company \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONEquivalence data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("Active",  data.Active);

                //add more parameters to method for query by any field

                if (data.Company != null && data.Company.Id != 0)
                    query.SetInt32("Company", data.Company.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONEquivalence data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONEquivalence data)
        {
        }

        public override CONEquivalence FindById(CONEquivalence data)
        {
            return base.FindById(data);
        }

        public override List<CONEquivalence> FindAll(CONEquivalence data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}