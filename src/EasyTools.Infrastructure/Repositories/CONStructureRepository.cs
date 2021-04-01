using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONStructureRepository : BaseCONStructureRepository
    {

        public CONStructureRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONStructure data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                dml += "             AND a.Main = :Main \n";
                dml += "             AND a.Active = :Active \n";

                //add more parameters to method for query by any field

                if (data.Integrator != null && data.Integrator.Id != 0)
                    dml += "             AND a.Integrator.Id = :Integrator \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructure data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                query.SetBoolean("Main", data.Main);
                query.SetBoolean("Active", data.Active);

                //add more parameters to method for query by any field

                if (data.Integrator != null && data.Integrator.Id != 0)
                    query.SetInt32("Integrator", data.Integrator.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONStructure data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONStructure data)
        {
        }

        public override CONStructure FindById(CONStructure data)
        {
            return base.FindById(data);
        }

        public override List<CONStructure> FindAll(CONStructure data, Options option)
        {
            return base.FindAll(data, option);

        }
    }
}