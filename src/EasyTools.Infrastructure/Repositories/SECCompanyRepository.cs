using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class SECCompanyRepository : BaseSECCompanyRepository
    {

        public SECCompanyRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECCompany data, Boolean byId)
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

        public override void SetQueryParameters(IQuery query, SECCompany data, Boolean byId)
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

        public override void SaveOrUpdateDetails(SECCompany data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(SECCompany data)
        {
        }

        public override SECCompany FindById(SECCompany data)
        {
            return base.FindById(data);
        }

        public override List<SECCompany> FindAll(SECCompany data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}