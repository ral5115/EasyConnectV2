using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONIntegratorRepository : BaseCONIntegratorRepository
    {

        public CONIntegratorRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONIntegrator data, Boolean byId)
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


                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONIntegrator data, Boolean byId)
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

            }
        }

        public override void SaveOrUpdateDetails(CONIntegrator data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONIntegrator data)
        {
        }

        public override CONIntegrator FindById(CONIntegrator data)
        {
            return base.FindById(data);
        }

        public override List<CONIntegrator> FindAll(CONIntegrator data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}