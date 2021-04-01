using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONStructureDetailRepository : BaseCONStructureDetailRepository
    {

        public CONStructureDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONStructureDetail data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.IsRequired = :IsRequired \n" ;
                //dml += "             AND a.Visible = :Visible \n" ;

                //add more parameters to method for query by any field

                if (data.Structure != null && data.Structure.Id != 0)
                    dml += "             AND a.Structure.Id = :Structure \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructureDetail data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("IsRequired",  data.IsRequired);
                //query.SetBoolean("Visible",  data.Visible);

                //add more parameters to method for query by any field

                if (data.Structure != null && data.Structure.Id != 0)
                    query.SetInt32("Structure", data.Structure.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONStructureDetail data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONStructureDetail data)
        {
        }

        public override CONStructureDetail FindById(CONStructureDetail data)
        {
            return base.FindById(data);
        }

        public override List<CONStructureDetail> FindAll(CONStructureDetail data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}