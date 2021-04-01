using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONWSEquivalenciasFormasPagoRepository : BaseCONWSEquivalenciasFormasPagoRepository
    {

        public CONWSEquivalenciasFormasPagoRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONWSEquivalenciasFormasPago data, Boolean byId)
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

        public override void SetQueryParameters(IQuery query, CONWSEquivalenciasFormasPago data, Boolean byId)
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

        public override void SaveOrUpdateDetails(CONWSEquivalenciasFormasPago data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONWSEquivalenciasFormasPago data)
        {
        }

        public override CONWSEquivalenciasFormasPago FindById(CONWSEquivalenciasFormasPago data)
        {
            return base.FindById(data);
        }

        public override List<CONWSEquivalenciasFormasPago> FindAll(CONWSEquivalenciasFormasPago data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}