using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONIntegratorConfigurationRepository : BaseCONIntegratorConfigurationRepository
    {

        public CONIntegratorConfigurationRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONIntegratorConfiguration data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                dml += "             AND a.Active = :Active \n";
                //dml += "             AND a.DirectImport = :DirectImport \n";

                //add more parameters to method for query by any field

                if (data.Integrator != null && data.Integrator.Id != 0)
                    dml += "             AND a.Integrator.Id = :Integrator \n";
                if (data.Connection != null && data.Connection.Id != 0)
                    dml += "             AND a.Connection.Id = :Connection \n";
                if (data.Company != null && data.Company.Id != 0)
                    dml += "             AND a.Company.Id = :Company \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONIntegratorConfiguration data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                query.SetBoolean("Active", data.Active);
                //query.SetBoolean("DirectImport", data.DirectImport);

                //add more parameters to method for query by any field


                if (data.Integrator != null && data.Integrator.Id != 0)
                    query.SetInt32("Integrator", data.Integrator.Id);
                if (data.Connection != null && data.Connection.Id != 0)
                    query.SetInt32("Connection", data.Connection.Id);
                if (data.Company != null && data.Company.Id != 0)
                    query.SetInt32("Company", data.Company.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONIntegratorConfiguration data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONIntegratorConfiguration data)
        {
        }

        public override CONIntegratorConfiguration FindById(CONIntegratorConfiguration data)
        {
            return base.FindById(data);
        }

        public override List<CONIntegratorConfiguration> FindAll(CONIntegratorConfiguration data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}